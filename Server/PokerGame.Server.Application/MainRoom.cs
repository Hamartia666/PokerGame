using PokerGame.Common;
using PokerGame.Server.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame.Server.Application
{
    public class MainRoom : RoomBase, IMainRoom
    {
        private List<IServerRoom> _rooms;
        private CommunicationHub _hub;

        public MainRoom(IOutput output) : base(output)
        {
            roomName = "Main Room";
            _rooms = new List<IServerRoom>
            {
                this
            };
        }

        public void Connect(object sender, ClientEventArgs args)
        {
            var client = args.Client;
            client.Name += (_clients.Count + 1).ToString();
            _clients.Add(client);            
            _output.Write(client.Name + " has connected!");
            SendMessage(client, new Message(eCommand.info, Id, client.Id, ""));
            SendMessage(new Message(eCommand.txt, Id, null, $"{client.Name} has connected"), client);
            SendMessage(new Message(eCommand.list, Id, null, string.Join(",", _clients.Select(x => x.Name))));
            SendMessage(new Message(eCommand.listRoom, Id, null, string.Join(",", _rooms.Select(x => $"{x.Id.ToString()}%{x.roomName}"))));
        }

        public bool StartServer(int port)
        {
            _hub = new CommunicationHub();
            if (_hub.ServerSetup(port))
            {
                _output.Write("Server started!");
                _hub.OnClientConnect += Connect;
                _hub.OnMessageReceived += ReceiveMessage;
                return true;
            }
            else
            {
                _output.Write("Server start failed!");
                return false;
            }
        }

        public void ReceiveMessage(object sender, MessageEventArgs args)
        {
            foreach (var msg in args.messages)
            {
                _rooms.FirstOrDefault(x => x.Id == msg.RoomId).ProcessMessage(msg);
            }
        }

        public override void ProcessMessage(IMessage message)
        {
            switch (message.Command)
            {
                case eCommand.quit:
                    //zamknac socket
                    var client = _clients.First(x => x.Id == message.ClientId);
                    client.Release();
                    _clients.Remove(client);
                    SendMessage(new Message(eCommand.txt, Id, null, $"{client.Name} has disconnected"));
                    SendMessage(new Message(eCommand.list, Id, null, string.Join(",", _clients.Select(x => x.Name))));
                    break;
                case eCommand.changeName:
                    var c = _clients.First(x => x.Id == message.ClientId).Name;
                    _clients.First(x => x.Id == message.ClientId).Name = message.Body;
                    SendMessage(new Message(eCommand.list, Id, null, string.Join(",", _clients.Select(x => x.Name))));
                    SendMessage(new Message(eCommand.txt, Id, null, $"{c} has changed his name to {_clients.First(x => x.Id == message.ClientId).Name}"));
                    break;
                case eCommand.createRoom:
                    var gameRoom = new GameRoom(_output);
                    gameRoom.roomName = $"Room {_rooms.Count}";
                    _rooms.Add(gameRoom);
                    SendMessage(new Message(eCommand.listRoom, Id, null, string.Join(",", _rooms.Select(x => $"{x.Id.ToString()}%{x.roomName}"))));
                    SendMessage(new Message(eCommand.txt, Id, null, $"{_clients.First(x => x.Id == message.ClientId).Name} has created {gameRoom.roomName}"));
                    break;
                case eCommand.joinRoom:
                    _rooms.First(x => x.Id == Guid.Parse(message.Body)).AddClient(_clients.First(x => x.Id == message.ClientId));
                    SendMessage(_clients.First(x => x.Id == message.ClientId), new Message(eCommand.info, _rooms.First(x => x.Id == Guid.Parse(message.Body)).Id, _clients.First(x => x.Id == message.ClientId).Id, ""));
                    SendMessage(new Message(eCommand.list, _rooms.First(x => x.Id == Guid.Parse(message.Body)).Id, null, string.Join(",", _clients.Select(x => x.Name))));
                    break;
                case eCommand.txt:
                    SendMessage(new Message(eCommand.txt, Id, null, $"{_clients.First(x => x.Id == message.ClientId).Name}: {message.Body}"));
                    break;
            }
        }
    }
}
