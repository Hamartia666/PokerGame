using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame.Common
{
    public class Player
    {
        public Guid ClientId { get; set; }
        public List<Card> Hand {get;set;}
        public Bid Bid { get; set; }
        public bool HasTurn { get; set; }
        public bool HasFolded { get; set; }
        public bool IsAllIn { get; set; }
        public bool IsDealer { get; set; }

        public Player(Guid id)
        {
            ClientId = id;
            Hand = new List<Card>();
            Bid = new Bid();
        }
    }
}
