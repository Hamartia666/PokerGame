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

        public Guid? ClientId { get; }

        public Guid RoomId { get; }

        public static char END_MESSAGE = '$';

        public Message(string text)
        {
            var parts = text.Split('|');
            Command = ParseCommand(parts[0]);
            RoomId = Guid.Parse(parts[1]);
            ClientId = ParseClientGuid(parts[2]);
            Body = parts[3];
        }

        private Guid? ParseClientGuid(string v)
        {
            Guid g = new Guid();
            if (Guid.TryParse(v, out g))
                return g;
            else
                return null;
        }

        public Message(eCommand command, Guid roomId, Guid? clientId, string body)
        {
            Command = command;
            RoomId = roomId;
            ClientId = clientId;
            Body = body;
        }

        private eCommand ParseCommand(string s)
        {
            switch (s)
            {
                case "quit":
                    return eCommand.quit;
                case "info":
                    return eCommand.info;
                case "list":
                    return eCommand.list;
                case "changeName":
                    return eCommand.changeName;
                case "createRoom":
                    return eCommand.createRoom;
                case "joinRoom":
                    return eCommand.joinRoom;
                case "listRoom":
                    return eCommand.listRoom;
                case "sitPlayer":
                    return eCommand.sitPlayer;
                case "startGame":
                    return eCommand.startGame;
                case "bid":
                    return eCommand.bid;
                case "showCards":
                    return eCommand.showCards;
                case "fold":
                    return eCommand.fold;
                case "turn":
                    return eCommand.turn;
                default:
                    return eCommand.txt;
            }
        }

        public override string ToString()
        {
            string s = $"{Command}|{RoomId}|{ClientId}|{Body}{END_MESSAGE}";
            return s;
        }
    }
}
