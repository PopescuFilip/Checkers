using Checkers.Commands;
using Checkers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Checkers.ViewModels
{
    public class TileViewModel : ViewModelBase
    {
        private Tile _tile;
        public Tile Tile
        {
            get { return _tile; }
            set
            {
                _tile = value;
                OnPropertyChanged(nameof(Tile));
            }
        }
        public bool HasPiece
        {
            get
            {
                return _tile.HasPiece;
            }
            set
            {
                Tile.HasPiece = value;
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
                Tile.IsAvailable = value;
                OnPropertyChanged(nameof(IsAvailable));
            }
        }
        public ICommand GameClick { get; }
        public TileViewModel(GameViewModel board, Tile tile)
        {
            Tile = tile;
            GameClick = new GameClickCommand(board, tile);
        }
        public Piece ExtractPiece()
        {
            Piece piece = Tile.Piece;
            Tile.Piece = new Piece();
            return piece;
        }
    }
}
