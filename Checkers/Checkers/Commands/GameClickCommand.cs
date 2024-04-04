using Checkers.Models;
using Checkers.Services;
using Checkers.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Commands
{
    public class GameClickCommand : CommandBase
    {
        private GameViewModel _game;
        private Tile _tile;
        public GameClickCommand(GameViewModel board, Tile tile) 
        {
            _game = board;
            _tile = tile;
            _game.PropertyChanged += OnViewModelProperyChanged;
        }

        private void OnViewModelProperyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(GameViewModel.CurrentPlayer) ||
                e.PropertyName == nameof(GameViewModel.HasPickedPiece)) 
            {
                OnCanExecutedChanged();
            }
        }

        public override void Execute(object parameter)
        {
            GameService.ProcessClick(_game, _tile);
        }

        public override bool CanExecute(object parameter)
        {
            if(_game.HasPickedPiece)
                return _tile.IsAvailable && base.CanExecute(parameter);
            return _tile.HasPiece && _tile.Piece.Color == _game.CurrentPlayer && base.CanExecute(parameter);
        }

    }
}
