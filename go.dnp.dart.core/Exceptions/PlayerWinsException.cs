using System;

namespace go.dnp.dart.core.Exceptions
{
    [Serializable]
    public class PlayerWinsException : Exception
    {
        public PlayerWinsException(string playerName)
            : base(String.Format("Player {0} wins the game.", playerName))
        {
        }
    }
}