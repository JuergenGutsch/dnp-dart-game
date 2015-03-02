using System.Collections.Generic;
using Machine.Specifications;

namespace go.dnp.dart.core.tests.mspec
{
    [Subject(typeof(DartGame), "Creating a game")]
    public class When_creating_a_new_game
    {
        Establish context = () =>
        {
            Players = new List<Player>
            {
                new Player("Jürgen"),
                new Player("Marion")
            };
        };

        static IEnumerable<Player> Players;
        static IDartGame Game;

        Because of = () => Game = new DartGame(Players);

        It should_set_the_current_player_to_Juergen = () => Game.CurrentPlayer.Name.ShouldEqual("Juergen");

    }
}