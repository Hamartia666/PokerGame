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
    public class MainRoom : IServerRoom, IMainRoom
    {
        private List<Client> _clients;
        private List<IServerRoom> _rooms;
        private CommunicationHub _hub;
        private readonly IOutput _output;

        public Guid Id { get; }

        public MainRoom(IOutput output)
        {
            Id = Guid.NewGuid();
            _output = output;
        }

        public bool Connect(Client client)
        {
            //metoda do onConnect

            //dodaj klienta zrwoconego przez event do listy

            //wypisz na konsoli ze ktos sie polaczyl

            //wywwolaj metode send message(room)
            throw new NotImplementedException();
        }

        public bool SendMessage(IServerRoom room)
        {
            throw new NotImplementedException();
        }

        public bool SendMessage(Client client)
        {
            throw new NotImplementedException();
        }

        public bool StartServer(int port)
        {
            _hub = new CommunicationHub();
            if (_hub.ServerSetup(port))
            {
                _output.Write("Server started!");
                return true;
            }
            else
            {
                _output.Write("Server start failed!");
                return false;
            }
        }

        public void ReceiveMessage(IMessage message)
        {
            //
        }
    }
}
