using System;
using System.Runtime.Serialization;

namespace go.dnp.dart.core
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