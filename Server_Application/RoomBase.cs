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
    public class RoomBase : IServerRoom
    {
        public Guid Id { get; }
        protected List<Client> _clients;
        protected readonly IOutput _output;

        public RoomBase(IOutput output)
        {
            Id = Guid.NewGuid();
            _output = output;
            _clients = new List<Client>();
        }

        public bool SendMessage()
        {
            _clients.Where
        }

        public bool SendMessage(Client client)
        {
            throw new NotImplementedException();
        }

        public virtual void ProcessMessage(IMessage message)
        { }
    }
}
