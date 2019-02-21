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
        private Dictionary<Client, int> _bids = new Dictionary<Client, int>();
        public List<Card> Table { get; } = new List<Card>();
        public Dictionary<Client, List<Card>> Hands { get; } = new Dictionary<Client, List<Card>>();
        private int _poll;


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
            Hands.Add(p, new List<Card>());
        }

        public void StartGame()
        {
            Shuffle();
            DealHands();
        }

        private void DealHands()
        {
            for (var i = 0; i < 2; i++)
            {
                foreach (var p in Hands)
                {
                    p.Value.Add(PopCard());
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
        //hands

        private void SumBids()
        {
            foreach (var p in _bids)
            {
                _poll += p.Value;
            }
            _bids.Clear();
        }
        
        private void AddBid(Client p, int bid)
        {
            if (_bids.ContainsKey(p))
            {
                _bids[p] += bid;
            }
            else
            {
                _bids.Add(p, bid);
            }
        }

        //evaluation who won




    }
}
