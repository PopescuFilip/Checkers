using Checkers.Models;
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
        private GameViewModel _board;
        private Tile _tile;
        public GameClickCommand(GameViewModel board, Tile tile) 
        {
            _board = board;
            _tile = tile;
            _board.PropertyChanged += OnViewModelProperyChanged;
        }

        private void OnViewModelProperyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(GameViewModel.CurrentPlayer)) 
            {
                OnCanExecutedChanged();
            }
        }

        public override void Execute(object parameter)
        {
            (_board.CurrentPlayer, _board.NonCurrentPlayer) = (_board.NonCurrentPlayer, _board.CurrentPlayer);
        }

        public override bool CanExecute(object parameter)
        {
            return _tile.HasPiece && _tile.Piece.Color == _board.CurrentPlayer && base.CanExecute(parameter);
        }

    }
}
