using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using go.dnp.dart.core;
using go.dnp.dart.gui.ViewModels.Commands;

namespace go.dnp.dart.gui.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Player> _players;
        public ObservableCollection<Player> Players
        {
            get { return _players; }
            set
            {
                if (value == _players)
                {
                    return;
                }
                _players = value;
                RaisePropertyChanged();
            }
        }

        private string _player;
        public string Player
        {
            get { return _player; }
            set
            {
                if (value == _player)
                {
                    return;
                }
                _player = value;
                RaisePropertyChanged();
                AddPlayer?.RaiseCanExecuteChanged();
            }
        }

        public IAppCommand AddPlayer { get; set; }

        public IAppCommand StartGame { get; set; }

        public MainViewModel()
        {
            Players = new ObservableCollection<Player>(new List<Player>());

            AddPlayer = new DelegateCommand(o =>
            {
                Players.Add(new Player(Player));
                Player = String.Empty;
                StartGame?.RaiseCanExecuteChanged();
            }, o => !String.IsNullOrWhiteSpace(Player));

            StartGame = new DelegateCommand(o =>
            {
                App.Game = new DartGame(Players);

                // TODO: call the game screen
            }, o => Players.Count >= 2);
        }
    }
}
