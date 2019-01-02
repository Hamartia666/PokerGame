using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame.Common
{
    public class Message : IMessage
    {
        public string Body { get; }

        public eCommand Command { get; }

        public Guid ClientId { get; }

        public Guid RoomId { get; }

        public Message(string text)
        {
            //
            var parts = text.Split('|');
            Command = parts[0] == "dupa" ? eCommand.quit : eCommand.txt;
        }

        public override string ToString()
        {
            //todo
            return base.ToString();
        }
    }
}
