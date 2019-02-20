using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame.Common
{ 
    public class Card
    {
        public eSuit Suit { get; set; }
        public eValue Value { get; set; }
        public Card(eSuit s, eValue v)
        {
            Suit = s;
            Value = v;
        }
    }
}
