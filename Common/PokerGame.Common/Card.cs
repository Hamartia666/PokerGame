using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame.Common
{ 
    public class Card : IComparable
    {
        public eSuit Suit { get; set; }
        public eValue Value { get; set; }
        public Card(eSuit s, eValue v)
        {
            Suit = s;
            Value = v;
        }

        public int CompareTo(Card that)
        {
            if (Value < that.Value) return -1;
            if (Value == that.Value)
            {
                if (Suit < that.Suit) return -1;
            }
            return 1;
        }

        public int CompareTo(object that)
        {
            var card = (Card)that;
            if (that == null) return -1;
            return CompareTo(card);
        }
    }
}
