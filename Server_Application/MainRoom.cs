using PokerGame.Common;
using PokerGame.Server.Communication;
using PokerGame.Server.Console;
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
            //wywwolaj metode send message(room)
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
            throw new NotImplementedException();
        }
    }
}
