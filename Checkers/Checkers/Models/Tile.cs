using Checkers.Enums;
using Checkers.Services;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Models
{
    public class Tile
    {
        private Piece _piece;
        public Piece Piece 
        { 
            get { return _piece; }
            set 
            {  
                _piece = value;
                Image = ImagePickerService.GetImage(_piece);
            } 
        }
        public bool HasPiece { get { return _piece.Type != Enums.Type.None; } }
        public bool IsAvailable { get; set; }
        public string Image {  get; set; }
        public Color TileColor { get; }

        private readonly Position _positon;
        public Position Position { get { return _positon; } }
        public int X { get { return _positon.X; } }
        public int Y { get { return _positon.Y; } }

        public Tile(int x, int y)
        {
            _positon = new Position(x, y);
            TileColor = (x + y) % 2 == 0 ? Color.White : Color.Black;
            IsAvailable = false;
            InitPiece();

            Image = ImagePickerService.GetImage(this);
        }
        private void InitPiece()
        {
            if (X >= 3 && X <= 4 || TileColor == Color.Black)
            {
                Piece = new Piece();
            }
            else 
            {
                if (X < 3)
                    Piece = new Piece(Color.White);
                else
                    Piece = new Piece(Color.Red);
            }
        }
        public List<Position> GetAllPossibleMoves()
        {
            if(Piece.Type == Enums.Type.King)
                return GetPossibleRedMoves().Concat(GetPossibleWhiteMoves()).ToList();

            if(Piece.Color == Color.White)
                return GetPossibleWhiteMoves();
            else
                return GetPossibleRedMoves();
        }
        private List<Position> GetPossibleWhiteMoves()
        {
            List<Position> positions = new List<Position>();

            if (X == Board.Rows - 1)
                return positions;
            
            if (Y < Board.Cols - 1)
                positions.Add(new Position(X + 1, Y + 1));
            if (Y > 0)
                positions.Add(new Position(X + 1, Y - 1));
            
            return positions;
        }
        private List<Position> GetPossibleRedMoves()
        {
            List<Position> positions = new List<Position>();

            if (X == 0)
                return positions;

            if (Y < Board.Cols - 1)
                positions.Add(new Position(X - 1, Y + 1));
            if (Y > 0)
                positions.Add(new Position(X - 1, Y - 1));

            return positions;
        }
    }
}
