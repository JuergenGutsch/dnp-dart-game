using System.Collections.Generic;

namespace go.dnp.dart.core
{
    public interface IDartGame
    {
        IEnumerable<Player> Players { get; }

        Player CurrentPlayer { get; }

        void UpdateCurrentPlayer(int value);
    }
}