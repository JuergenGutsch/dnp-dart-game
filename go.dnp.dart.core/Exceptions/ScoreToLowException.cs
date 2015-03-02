using System;

namespace go.dnp.dart.core.Exceptions
{
    [Serializable]
    public class ScoreToLowException : Exception
    {
        public ScoreToLowException(int score, int value)
        {
            Score = score;
            Value = value;
        }

        public int Value { get; set; }
        public int Score { get; set; }
    }
}