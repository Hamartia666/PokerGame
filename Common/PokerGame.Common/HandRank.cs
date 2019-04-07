using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame.Common
{
    public class HandRank : IComparable<HandRank>
    {
        eCardRank CardRank { get; set; }
        Card HighCard { get; set; }

        public HandRank()
        {
            CardRank = eCardRank.highCard;
            HighCard = null;
        }

        public int CompareTo(HandRank that)
        {
            if (CardRank < that.CardRank) return -1;
            if (CardRank == that.CardRank)
            {
                //check highCard
                if (HighCard == null || HighCard.Value < that.HighCard.Value || (HighCard.Value == that.HighCard.Value && HighCard.Suit < that.HighCard.Suit)) return -1;
            }            
            return 1;
        }

        public static HandRank GetHandRank(IEnumerable<Card> cards)
        {
            return new HandRank() { HighCard = cards.Max(), CardRank = GetRank(cards.ToList()) };
        }

        private static eCardRank GetRank(List<Card> cards)
        {
            cards.Sort();

            if (cards.All(x => x.Suit == cards[0].Suit) //same suit
                && cards[0].Value == eValue.ten && cards[4].Value == eValue.ace) //from ten to ace
            {
                return eCardRank.royalFlush;
            }

            if (cards.All(x => x.Suit == cards[0].Suit) //same suit
               && cards[4].Value == cards[0].Value + 4) //five in a row
            {
                return eCardRank.straightFlush;
            }

            if (cards.Count(x => x.Value == cards[2].Value) == 4)
            {
                return eCardRank.fourOfAKind;
            }

            if ((cards.Count(x => x.Value == cards[0].Value) == 3 && cards.Count(x => x.Value == cards[4].Value) == 2) //3-2
                || (cards.Count(x => x.Value == cards[0].Value) == 2 && cards.Count(x => x.Value == cards[4].Value) == 3)) //2-3
            {
                return eCardRank.fullHouse;
            }

            if (cards.All(x => x.Suit == cards[0].Suit)) //same suit
            {
                return eCardRank.flush;
            }

            if (cards[4].Value == cards[0].Value + 4) //five in a row
            {
                return eCardRank.straight;
            }

            if (cards.Count(x => x.Value == cards[2].Value) == 3)
            {
                return eCardRank.fourOfAKind;
            }

            if ((cards.Count(x => x.Value == cards[0].Value) == 2 && cards.Count(x => x.Value == cards[2].Value) == 2) //2-2-x
                || (cards.Count(x => x.Value == cards[1].Value) == 2 && cards.Count(x => x.Value == cards[3].Value) == 2) //x-2-2
                || (cards.Count(x => x.Value == cards[0].Value) == 2 && cards.Count(x => x.Value == cards[3].Value) == 2)) //2-x-2
            {
                return eCardRank.twoPair;
            }

            if (cards.GroupBy(x => x.Value).Where(x=>x.Count()==2).Any())
            {
                return eCardRank.pair;
            }

            return eCardRank.highCard;
        }

    }
}
