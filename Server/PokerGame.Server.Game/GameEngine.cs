using PokerGame.Common;
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
        List<Card> _deck;
        Dictionary<Player, int> _bids = new Dictionary<Player, int>();
        List<Card> _table = new List<Card>();
        Dictionary<Player, List<Card>> _hands = new Dictionary<Player, List<Card>>();
        int poll;


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

        private void AddPlayer(Player p)
        {
            _hands.Add(p, new List<Card>());
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
                foreach (var p in _hands)
                {
                    p.Value.Add(PopCard());
                }
            }           
        }

        private void Flop()
        {
            for (var i = 0; i < 3; i++)
            {
                _table.Add(PopCard());
            }
        }

        private void Turn_River()
        {
            _table.Add(PopCard());
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
                poll += p.Value;
            }
            _bids.Clear();
        }
        
        private void AddBid(Player p, int bid)
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
