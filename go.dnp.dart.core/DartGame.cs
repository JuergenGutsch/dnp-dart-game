using System;
using System.Collections.Generic;
using System.Linq;

namespace go.dnp.dart.core
{
    public class DartGame : IDartGame
    {
        private readonly IEnumerator<Player> _enumerator;
        private readonly IEnumerable<Player> _players;
        private int _run = 0;

        public DartGame(IEnumerable<Player> players)
        {
            if (players == null) throw new ArgumentNullException("players");
            if (!players.Any()) throw new ArgumentException("players", "Players can't be empty.");

            _players = players;
            _enumerator = _players.GetEnumerator();

            if (!_enumerator.MoveNext())
            {
                throw new ArgumentException("players", "Players can't be empty.");
            }
        }

        public Player CurrentPlayer
        {
            get
            {
                return _enumerator.Current;
            }
        }

        public IEnumerable<Player> Players
        {
            get
            {
                return _players;
            }
        }

        public void UpdateCurrentPlayer(int value)
        {
            if(value > 50 || value < 1)
            {
                throw new ValueOutOfRangeException(value, "The value {0} is out of range. Must be between 1 and 50");
            }

            _run++;

            var currentScore = CurrentPlayer.Score;
            currentScore -= value;

            if(currentScore == 0)
            {
                throw new PlayerWinsException(CurrentPlayer.Name);
            }
            if (currentScore < 0)
            {
                // error
                throw new ScoreToLowException(CurrentPlayer.Score, value);
            }

            CurrentPlayer.Score = currentScore;
            if (_run == 3)
            {
                if (!_enumerator.MoveNext())
                {
                    _enumerator.Reset();
                    _enumerator.MoveNext();
                }
                _run = 0;
            }
        }
    }

}
