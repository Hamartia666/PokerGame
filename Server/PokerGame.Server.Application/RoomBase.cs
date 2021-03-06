using PokerGame.Common;
using PokerGame.Server.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame.Server.Application
{
    public class RoomBase : IServerRoom
    {
        public string roomName { get; set; }
        public Guid Id { get; }
        public List<Client> _clients { get; set; }
        protected readonly IOutput _output;

        public RoomBase(IOutput output)
        {
            Id = Guid.NewGuid();
            _output = output;
            _clients = new List<Client>();
        }

        public void SendMessage(IMessage message)
        {
            foreach (var c in _clients)
                SendMessage(c, message);
        }

        public void SendMessage(IMessage message, Client notThisClient)
        {
            _clients.Where(x => x != notThisClient).ToList().ForEach(x => x.Send(message));
        }

        public void SendMessage(Client client, IMessage message)
        {
            client.Send(message);
        }

        public void AddClient(Client c)
        {
            _clients.Add(c);
            SendMessage(c, new Message(eCommand.info, Id, c.Id, ""));
            SendMessage(new Message(eCommand.list, Id, null, string.Join(",", _clients.Select(x => $"{x.Name}%{x.Id}"))));
        }

        public virtual void ProcessMessage(IMessage message)
        { }
    }
}
