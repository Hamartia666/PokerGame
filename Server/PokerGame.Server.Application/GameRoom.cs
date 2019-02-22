using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerGame.Common;
using PokerGame.Server.Communication;
using PokerGame.Server.Game;

namespace PokerGame.Server.Application
{
    public class GameRoom : RoomBase
    {
        List<Client> _playingClients;
        private GameEngine _gameEngine;
        private const int MAX_PLAYERS = 4;
        private int startVotes = 0;

        public GameRoom(IOutput output) : base(output)
        {
            _playingClients = new List<Client>();
            _gameEngine = new GameEngine();
        }

        public override void ProcessMessage(IMessage message)
        {
            switch (message.Command)
            {
                case eCommand.sitPlayer:
                    if (_playingClients.Count < MAX_PLAYERS)
                    {
                        _playingClients.Add(_clients.First(x => x.Id == message.ClientId));
                        _gameEngine.AddPlayer(_clients.First(x => x.Id == message.ClientId));
                        SendMessage(new Message(eCommand.sitPlayer, Id, message.ClientId, ""));
                    }
                    else
                    {
                        SendMessage(_clients.First(x => x.Id == message.ClientId), new Message(eCommand.txt, Id, message.ClientId, "The number of players is already at maximum!"));
                    }
                    break;
                case eCommand.txt:
                    SendMessage(new Message(eCommand.txt, Id, null, $"{_clients.First(x => x.Id == message.ClientId).Name}: {message.Body}"));
                    break;
                case eCommand.startGame:
                    startVotes++;
                    if (startVotes == _playingClients.Count)
                    {
                        if (startVotes == 1)
                        {
                            SendMessage(new Message(eCommand.txt, Id, null, "There must be at least two players to start!"));
                        }
                        else
                        {
                            _gameEngine.StartGame();
                            //now the hands are dealt and deck is shuffled.
                            //we send the hand information to client
                            var hands = string.Join("*",_gameEngine.Players.Select(x => $"{x.ClientId}%{string.Join(";", x.Hand.Select(y => $"{(int)y.Suit},{(int)y.Value}"))}"));
                            SendMessage(new Message(eCommand.startGame, Id, null, hands));
                            SendMessage(new Message(eCommand.bid, Id, null, string.Join(",", $"{_gameEngine.Players.Select(x => $"{x.ClientId}%{x.Bid.bid}")}")));
                            SendMessage(new Message(eCommand.turn, Id, _gameEngine.Players.First(x => x.HasTurn).ClientId, ""));
                        }
                    }
                    else
                    {
                        SendMessage(new Message(eCommand.txt, Id, null, $"Awaiting players: {startVotes}/{_playingClients.Count}"));
                    }
                    break;
                case eCommand.bid:
                    _gameEngine.AddBid(message.ClientId.Value, int.Parse(message.Body));
                    _gameEngine.NextTurn();
                    SendMessage(new Message(eCommand.bid, Id, null, string.Join(",", $"{_gameEngine.Players.Select(x => $"{x.ClientId}%{x.Bid.bid}")}")));
                    SendMessage(new Message(eCommand.turn, Id, _gameEngine.Players.First(x => x.HasTurn).ClientId, ""));
                    break;
                case eCommand.fold:
                    break;
                case eCommand.check:
                    break;
                case eCommand.allIn:
                    break;
                default:
                    break;
            }
        }
    }
}
