using Checkers.Models;
using Checkers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Commands
{
    public class GameClickCommand : CommandBase
    {
        private BoardViewModel _board;
        private Tile _tile;
        public GameClickCommand(BoardViewModel board, Tile tile) 
        {
            _board = board;
            _tile = tile;
        }
        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        public override bool CanExecute(object parameter)
        {
            return _tile.HasPiece && _tile.Piece.Color == _board.CurrentPlayer && base.CanExecute(parameter);
        }

    }
}
