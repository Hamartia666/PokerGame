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
            var parts = text.Split('|');
            Command = ParseCommand(parts[0]);
            Body = parts[1];
        }

        private eCommand ParseCommand(string s)
        {
            switch (s)
            {
                case "q":
                    return eCommand.quit;
                default:
                    return eCommand.txt;
            }
        }

        public override string ToString()
        {
            //todo
            return base.ToString();
        }
    }
}
