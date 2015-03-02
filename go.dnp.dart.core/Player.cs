using System;

namespace go.dnp.dart.core
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
            Score = 501;
        }

        public string Name { get; set; }
        public int Score { get; set; }

        public override string ToString()
        {
            return String.Format("{0} [{1}]", Name, Score);
        }
    }
}
