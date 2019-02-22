using PokerGame.Common;
using PokerGame.Server.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame.Server.Game
{
    public class GameEngine
    {
        //deck
        private List<Card> _deck;
        //private Dictionary<Client, Bid> _bids = new Dictionary<Client, Bid>();
        public List<Card> Table { get; } = new List<Card>();
        //public Dictionary<Client, List<Card>> Hands { get; } = new Dictionary<Client, List<Card>>();
        private int _poll;

        public List<Player> Players { get; } = new List<Player>();

        public GameEngine()
        {
            InitializeDeck();
        }

        private void InitializeDeck()
        {
            _deck = new List<Card>();
            foreach (eSuit s in Enum.GetValues(typeof(eSuit)))
            {
                foreach (eValue v in Enum.GetValues(typeof(eValue)))
                {
                    _deck.Add(new Card(s, v));
                }
            }
        }

        private void Shuffle()
        {
            var rng = new Random();
            var n = _deck.Count;
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                var value = _deck[k];
                _deck[k] = _deck[n];
                _deck[n] = value;
            }
        }

        public void AddPlayer(Client p)
        {
            Players.Add(new Player(p.Id));
        }

        public void StartGame()
        {
            Shuffle();
            DealHands();
            SetBlinds();            
        }

        private void SetBlinds()
        {
            if (Players.Where(x => x.Bid.Blind != eBlind.no).Any())
            {
                var rnd = new Random();
                var c = rnd.Next(Players.Count);
                Players[c++].Bid.Blind = eBlind.big;
                Players[c++%Players.Count].Bid.Blind = eBlind.small;
                InitializeTurn(c % Players.Count);
            }
            else
            {
                var index = Players.IndexOf(Players.First(x => x.Bid.Blind == eBlind.big));
                Players[index++].Bid.Blind = eBlind.no;
                Players[index++ % Players.Count].Bid.Blind = eBlind.big;
                Players[index++ % Players.Count].Bid.Blind = eBlind.small;
                InitializeTurn(index % Players.Count);
            }
            
        }

        private void InitializeTurn(int index)
        {
            Players[index].HasTurn = true;
        }

        public void NextTurn()
        {     
            //what if player is all in
            var playersLeft = Players.Where(x => !x.HasFolded).ToList();
            var index = playersLeft.IndexOf(playersLeft.First(x => x.HasTurn));
            playersLeft[index++ % playersLeft.Count].HasTurn = false;
            playersLeft[index % playersLeft.Count].HasTurn = true;
        }

        private void DealHands()
        {
            for (var i = 0; i < 2; i++)
            {
                foreach (var p in Players)
                {
                    p.Hand.Add(PopCard());
                }
            }           
        }

        private void Flop()
        {
            for (var i = 0; i < 3; i++)
            {
                Table.Add(PopCard());
            }
        }

        private void Turn_River()
        {
            Table.Add(PopCard());
        }

        private Card PopCard()
        {
            var c = _deck[0];
            _deck.RemoveAt(0);
            return c;
        }

        private void SumBids()
        {
            _poll += Players.Sum(x => x.Bid.bid);
            Players.Select(x => x.Bid.bid=0);            
        }
        
        public void AddBid(Guid Id, int bid)
        {
            Players.First(x => x.ClientId == Id).Bid.bid += bid;
        }

        //evaluation who won




    }
}
