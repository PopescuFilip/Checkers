using Checkers.Commands;
using Checkers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Checkers.ViewModels
{
    public class TileViewModel : ViewModelBase
    {
        private Tile _tile;
        public bool HasPiece
        {
            get
            {
                return _tile.HasPiece;
            }
            set
            {
                _tile.HasPiece = value;
            }
        }

        public bool IsAvailable
        {
            get
            {
                return _tile.IsAvailable;
            }
            set
            {
                _tile.IsAvailable = value;
                OnPropertyChanged(nameof(IsAvailable));
            }
        }
        public Piece Piece
        {
            get { return _tile.Piece; }
            set { _tile.Piece = value; OnPropertyChanged(nameof(Image)); }
        }

        public string Image
        {
            get => _tile.Image;
            set { _tile.Image = value; OnPropertyChanged(nameof(Image));}
        }

        public Position Position
        {
            get { return _tile.Position; }
        }

        public ICommand GameClick { get; }
        public TileViewModel(GameViewModel board, Tile tile)
        {
            _tile = tile;
            GameClick = new GameClickCommand(board, this);
        }
        public Piece ExtractPiece()
        {
            Piece piece = Piece;
            Piece = new Piece();
            return piece;
        }

        public List<Position> GetAllPossibleMoves()
        {
            return _tile.GetAllPossibleMoves();
        }
    }
}
