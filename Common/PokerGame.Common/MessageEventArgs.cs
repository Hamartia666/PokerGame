using PokerGame.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame.Common
{
    public class MessageEventArgs : EventArgs
    {
        public List<IMessage> messages = new List<IMessage>();
        
        public MessageEventArgs(string text)
        {
            var messagesReceived = text.Split(Message.END_MESSAGE);

            foreach (var msg in messagesReceived)
            {
                if (string.IsNullOrEmpty(msg))
                    continue;
                messages.Add(new Message(msg));
            }
        }
    }
}
