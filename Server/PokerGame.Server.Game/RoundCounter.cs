namespace PokerGame.Server.Game
{
    public class RoundCounter
    {
        private int _turn;
        private int _playersInRound;
        private int _playersNextRound;
        public bool RoundFinished { get; set; }

        public RoundCounter(int players)
        {
            _turn = 1;
            _playersInRound = players;
            _playersNextRound = players;
        }

        public void ResetCounter()
        {
            _turn = 1;
            RoundFinished = false;
            _playersInRound = _playersNextRound;
        }

        public void CountOne()
        {
            _turn++;
            if (_turn == _playersInRound + 1)
            {
                RoundFinished = true;
                _turn = 1;
                _playersInRound = _playersNextRound;
            }
            else
                RoundFinished = false;
        }

        public void UpdatePlayers(int players)
        {
            _playersNextRound = players;
        }
    }
}