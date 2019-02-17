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
            _rooms.FirstOrDefault(x => x.Id == args.message.RoomId).ProcessMessage(args.message);
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
                    break;
                case eCommand.txt:
                    SendMessage(new Message(eCommand.txt, Id, null, $"{_clients.First(x => x.Id == message.ClientId).Name}: {message.Body}"));
                    break;
            }
        }
    }
}
