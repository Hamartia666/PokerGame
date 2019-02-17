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
        public IMessage message;
        
        public MessageEventArgs(string text)
        {
            message = new Message(text);
        }
    }
}
