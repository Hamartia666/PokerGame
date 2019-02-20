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

        public GameRoom(IOutput output) : base(output)
        {
            _playingClients = new List<Client>();
        }

        public override void ProcessMessage(IMessage message)
        {
            switch (message.Command)
            {
                case eCommand.sitPlayer:
                    if (_playingClients.Count < MAX_PLAYERS)
                    {
                        _playingClients.Add(_clients.First(x => x.Id == message.ClientId));
                        SendMessage(new Message(eCommand.sitPlayer, Id, message.ClientId, ""));
                    }
                    else
                    {
                        SendMessage(_clients.First(x => x.Id == message.ClientId), new Message(eCommand.txt, Id, message.ClientId, "The number of players is already at maximum!"));
                    }
                    break;
                case eCommand.txt:
                    break;
                default:
                    break;
            }
        }    
        
        
    }
}
