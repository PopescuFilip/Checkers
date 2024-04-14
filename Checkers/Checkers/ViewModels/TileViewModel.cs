using Checkers.Commands;
using Checkers.Enums;
using Checkers.Models;
using Checkers.Services;
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
        private readonly Tile _tile;
        public Tile Tile { get { return _tile; } }
        public Piece Piece
        {
            get => _tile.Piece;
            set 
            { 
                _tile.Piece = value; 
                OnPropertyChanged(nameof(Image)); 
                OnPropertyChanged(nameof(HasPiece)); 
            }
        }
        public Enums.Type PieceType
        {
            get => _tile.PieceType;
            set
            {
                _tile.PieceType = value;
                OnPropertyChanged(nameof(Image));
            }
        }
        public string Image
        {
            get => _tile.Image;
        }
        public bool HasPiece 
        { 
            get => _tile.HasPiece; 
        }
        
        private bool _isAvailable;
        public bool IsAvailable
        {
            get { return _isAvailable; }
            set
            {
                _isAvailable = value;
                OnPropertyChanged(nameof(IsAvailable));
            }
        }

        public Enums.Color PieceColor
        {
            get => _tile.Piece.Color;
        }

        public Position Position
        {
            get => _tile.Position;
        }

        private Move _move;
        public Move Move
        {
            get { return _move; }
            set 
            { 
                _move = value;
                IsAvailable = true;
            }
        }

        public ICommand GameClick { get; }
        public TileViewModel(GameViewModel board, Tile tile)
        {
            _tile = tile;
            IsAvailable = false;
            GameClick = new GameClickCommand(board, this);
        }
        public Piece ExtractPiece()
        {
            Piece piece = new Piece();
            (Piece, piece) = (piece, Piece);
            return piece;
        }

        public void Update(Enums.Color color, Enums.Type type) 
        {
            if (_tile.TileColor != Enums.Color.White)
                return;
            Piece = new Piece(color, type);
            IsAvailable = false;
            _move = null;
        }
    }
}
