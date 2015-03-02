using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using System;
using go.dnp.dart.core.Exceptions;

namespace go.dnp.dart.core.tests
{
    [TestFixture]
    public class DartGameTests
    {
        [Test]
        public void Create_new_game()
        {
            var sut = new DartGame(new List<Player>
            {
                new Player("Jürgen"),
                new Player("Marion")
            });

            var currentPlayer = sut.CurrentPlayer;

            Assert.That(currentPlayer.Name, Is.EqualTo("Jürgen"));
            Assert.That(currentPlayer.Score, Is.EqualTo(501));
        }

        [Test]
        public void Empty_player_list_should_throw_an_error()
        {
            Assert.Throws<ArgumentException>(() => new DartGame(new List<Player> { }));
        }

        [Test]
        public void Null_player_list_should_throw_an_error()
        {
            Assert.Throws<ArgumentNullException>(() => new DartGame(null));
        }


        [Test]
        public void UpdateCurrentPlayer_value_should_not_be_smaller_than_1()
        {
            var sut = new DartGame(new List<Player>
            {
                new Player("Jürgen")
            });

            Assert.Throws<ValueOutOfRangeException>(() => sut.UpdateCurrentPlayer(0));
        }


        [Test]
        public void UpdateCurrentPlayer_value_should_not_be_greater_than_50()
        {
            var sut = new DartGame(new List<Player>
            {
                new Player("Jürgen")
            });

            Assert.Throws<ValueOutOfRangeException>(() => sut.UpdateCurrentPlayer(51));
        }

        [Test]
        public void UpdateCurrentPlayer_value_goes_lower_than_0()
        {
            var sut = new DartGame(new List<Player>
            {
                new Player("Jürgen")
            });

            Assert.Throws<ScoreToLowException>(() =>
            {
                for (int i = 0; i < 11; i++)
                {
                    sut.UpdateCurrentPlayer(50);
                }
            });
        }

        [Test]
        public void UpdateCurrentPlayer_Value_Goes_to_0_and_wins_the_game()
        {
            var sut = new DartGame(new List<Player>
            {
                new Player("Jürgen")
            });

            for (int i = 0; i < 10; i++)
            {
                sut.UpdateCurrentPlayer(50);
            }

            Assert.Throws<PlayerWinsException>(() =>
            {
                sut.UpdateCurrentPlayer(1);
            });
        }

        [Test]
        public void Update_current_player_once_with_50_sets_score_to_451()
        {
            var sut = new DartGame(new List<Player>
            {
                new Player("Jürgen"),
                new Player("Marion")
            });

            sut.UpdateCurrentPlayer(50);

            var currentPlayer = sut.CurrentPlayer;

            Assert.That(currentPlayer.Name, Is.EqualTo("Jürgen"));
            Assert.That(currentPlayer.Score, Is.EqualTo(451));
        }

        [Test]
        public void Update_current_player_twice_with_50_and_1_sets_score_to_450()
        {
            var sut = new DartGame(new List<Player>
            {
                new Player("Jürgen"),
                new Player("Marion")
            });

            sut.UpdateCurrentPlayer(50);
            sut.UpdateCurrentPlayer(1);

            var currentPlayer = sut.CurrentPlayer;

            Assert.That(currentPlayer.Name, Is.EqualTo("Jürgen"));
            Assert.That(currentPlayer.Score, Is.EqualTo(450));
        }

        [Test]
        public void Update_current_player_trice_with_50_and_1_and_30_sets_score_to_420()
        {
            var sut = new DartGame(new List<Player>
            {
                new Player("Jürgen"),
                new Player("Marion")
            });

            sut.UpdateCurrentPlayer(50);
            sut.UpdateCurrentPlayer(1);
            sut.UpdateCurrentPlayer(30);

            var currentPlayer = sut.Players.First();

            Assert.That(currentPlayer.Name, Is.EqualTo("Jürgen"));
            Assert.That(currentPlayer.Score, Is.EqualTo(420));
        }

        [Test]
        public void Update_current_player_trice_should_move_to_the_next_player()
        {
            var sut = new DartGame(new List<Player>
            {
                new Player("Jürgen"),
                new Player("Marion")
            });

            sut.UpdateCurrentPlayer(50);
            sut.UpdateCurrentPlayer(1);
            sut.UpdateCurrentPlayer(30);

            var currentPlayer = sut.CurrentPlayer;

            Assert.That(currentPlayer.Name, Is.EqualTo("Marion"));
        }

        [Test]
        public void Update_current_player_6_times_should_move_to_the_first_player()
        {
            var sut = new DartGame(new List<Player>
            {
                new Player("Jürgen"),
                new Player("Marion")
            });

            sut.UpdateCurrentPlayer(50);
            sut.UpdateCurrentPlayer(1);
            sut.UpdateCurrentPlayer(30);

            sut.UpdateCurrentPlayer(50);
            sut.UpdateCurrentPlayer(1);
            sut.UpdateCurrentPlayer(30);

            var currentPlayer = sut.CurrentPlayer;

            Assert.That(currentPlayer.Name, Is.EqualTo("Jürgen"));
        }


    }
}
