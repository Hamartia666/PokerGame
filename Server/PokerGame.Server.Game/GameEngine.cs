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
        public List<Card> Table { get; } = new List<Card>();
        private int _poll;
        public eGameState gameState;
        public List<Player> Players { get; } = new List<Player>();
        private List<Player> _playersLeft;
        private RoundCounter _roundCounter;
        public Guid winner;

        public GameEngine()
        {
            _deck = new List<Card>();
        }

        private void InitializeDeck()
        {
            _deck.Clear();
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
            _roundCounter = new RoundCounter(Players.Count);
            InitializeDeck();
            Shuffle();
            DealHands();
            SetBlinds();
            InitializeTurn();
        }

        private void SetBlinds()
        {
            if (Players.All(x => !x.IsDealer))
            {
                var rnd = new Random();
                var c = rnd.Next(Players.Count);
                Players[c].IsDealer = true;
            }            
            var index = Players.IndexOf(Players.First(x => x.IsDealer == true));
            Players[index++].IsDealer = false;
            Players[index % Players.Count].IsDealer = true;
            Players[index++ % Players.Count].Bid.Blind = eBlind.no;
            Players[index++ % Players.Count].Bid.Blind = eBlind.small;
            Players[index % Players.Count].Bid.Blind = eBlind.big;            
        }

        private void InitializeTurn()
        {
            _roundCounter.ResetCounter();
            Players.Select(x => x.HasTurn = false);
            switch (gameState)
            {
                case eGameState.preFlop:
                    var index = Players.IndexOf(Players.First(x => x.Bid.Blind == eBlind.big));
                    Players[index + 1].HasTurn = true;
                    _playersLeft = Players;
                    break;
                case eGameState.flop:
                case eGameState.turn:
                case eGameState.river:
                    var i = _playersLeft.IndexOf(_playersLeft.First(x => x.IsDealer));
                    _playersLeft[i + 1].HasTurn = true;
                    break;
                case eGameState.showdown:
                    break;
            }
        }

        public void NextTurn()
        {
            //turn counter or sth and if
            _roundCounter.CountOne();
            var index = _playersLeft.IndexOf(_playersLeft.First(x => x.HasTurn));
            _playersLeft[index++ % _playersLeft.Count].HasTurn = false;
            _playersLeft[index % _playersLeft.Count].HasTurn = true;
            _playersLeft = Players.Where(x => !x.HasFolded && !x.IsAllIn).ToList();
            _roundCounter.UpdatePlayers(_playersLeft.Count);
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

        public void Fold(Guid clientId)
        {
            Players.First(x => x.ClientId == clientId).HasFolded = true;
            NextTurn();
        }

        private void Flop()
        {
            PopCard();
            for (var i = 0; i < 3; i++)
            {
                Table.Add(PopCard());
            }
        }

        private void Turn_River()
        {
            PopCard();
            Table.Add(PopCard());
        }

        public void AllIn(Guid Id, int bid)
        {
            Players.First(x => x.ClientId == Id).IsAllIn = true;
            AddBid(Id, bid);
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
            NextTurn();
        }

        public bool UpdateGameState()
        {
            if (_playersLeft.Count == 1)
            {
                if (Players.Where(x => x.IsAllIn).Any())
                {
                    SumBids();
                    Flop();
                    Turn_River();
                    Turn_River();
                    gameState = eGameState.showdown;
                    ShowDown();
                    return true;
                }
                else
                {
                    SumBids();
                    gameState = eGameState.finish;
                    ShowDown();
                    return true;
                }
            }
            else if (_playersLeft.All(x=>x.Bid.bid == Players.Max(y=>y.Bid.bid)) && _roundCounter.RoundFinished)
            {
                SumBids();
                switch (gameState)
                {
                    case eGameState.preFlop:
                        gameState = eGameState.flop;
                        Flop();
                        break;
                    case eGameState.flop:
                        gameState = eGameState.turn;
                        Turn_River();
                        break;
                    case eGameState.turn:
                        gameState = eGameState.river;
                        Turn_River();
                        break;
                    case eGameState.river:
                        gameState = eGameState.showdown;
                        ShowDown();
                        break;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ShowDown()
        {
            foreach (var player in Players.Where(x => !x.HasFolded))
            {
                player.HandRank = GetBestHandRank(player.Hand, Table);
            }
            var bestPlaya = Players.Where(x => !x.HasFolded).OrderByDescending(i => i.HandRank).First(); //OUTPUT
            winner = bestPlaya.ClientId;
        }

        private HandRank GetBestHandRank(List<Card> hand, List<Card> table)
        {
            var possibleHands = GetPossibleHands(hand, table);
            return EvaluateHands(possibleHands);
        }

        private HandRank EvaluateHands(List<List<Card>> possibleHands)
        {
            var rankList = new List<HandRank>();
            foreach (var hand in possibleHands)
            {
                rankList.Add(HandRank.GetHandRank(hand));
            }
            return rankList.Max();
        }

        private List<List<Card>> GetPossibleHands(List<Card> hand, List<Card> table)
        {
            var retList = new List<List<Card>>();
            var handArray = new int[2] { 0, 1 };
            var tableArray = new int[5] { 0, 1, 2, 3, 4 };
            for (var i =0; i<3; i++)//you gotta take first card in hamd, second, then both
            {
                var chosenHandCard = i == 2 ? new int[2] { 0, 1 } : new int[1] { i };
                var possibleTablecombinations = GetKCombs<int>(tableArray, 5 - chosenHandCard.Length);
                foreach (var tableComb in possibleTablecombinations)
                {
                    retList.Add(GetHandAndTableCards(hand, table, chosenHandCard, tableComb));
                }
            }
            return retList;
        }

        private List<Card> GetHandAndTableCards(List<Card> hand, List<Card> table, int[] chosenHandCard, IEnumerable<int> tableComb)
        {
            var retList = new List<Card>();
            //take hand
            foreach (var handCard in chosenHandCard)
                retList.Add(hand[handCard]);
            foreach (var tableCard in tableComb)
                retList.Add(table[tableCard]);
            return retList;
        }

        static IEnumerable<IEnumerable<T>> GetKCombs<T>(IEnumerable<T> list, int length) where T : IComparable //https://stackoverflow.com/a/10629938
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetKCombs(list, length - 1)
                .SelectMany(t => list.Where(o => o.CompareTo(t.Last()) > 0),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        

        private List<Card> PossibleTables() //P3
        {
            throw new NotImplementedException();
        }

        private List<Card> PossibleOpponents() //P3.2
        {
            throw new NotImplementedException();
        }

        private void WinProbability(Player player) //P4
        {

        }


        //evaluation who won




    }
}
