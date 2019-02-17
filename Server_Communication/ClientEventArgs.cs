using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame.Server.Communication
{
    public class ClientEventArgs : EventArgs
    {
        public Client Client;
        public ClientEventArgs(Client c)
        {
            Client = c;
        }
    }
}
