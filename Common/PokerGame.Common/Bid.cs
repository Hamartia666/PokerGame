using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame.Common
{
    public class Bid
    {
        public int bid;
        private eBlind _blind;
        public eBlind Blind { get { return _blind; } set { _blind = value; SetBid(); } }

        private void SetBid()
        {
            switch (_blind)
            {
                case eBlind.big:
                    bid = 10;
                    break;
                case eBlind.small:
                    bid = 5;
                    break;
                default:
                    bid = 0;
                    break;
            }
        }

        public Bid()
        {
            _blind = eBlind.no;
        }
    }
}
