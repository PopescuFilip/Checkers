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

        public Enums.Type PieceType
        {
            get { return _piece.Type; }
            set 
            {
                _piece.Type = value;
                Image = ImagePickerService.GetImage(_piece);
            }
        }
        public string Image {  get; set; }
        public Color TileColor { get; }

        public bool HasPiece
        {
            get => Piece.Type != Enums.Type.None;
        }

        private readonly Position _positon;
        public Position Position { get { return _positon; } }
        public int X { get { return _positon.X; } }
        public int Y { get { return _positon.Y; } }

        public Tile(int x, int y)
        {
            _positon = new Position(x, y);
            TileColor = (x + y) % 2 == 0 ? Color.White : Color.Black;
            TileService.InitPiece(this);

            Image = ImagePickerService.GetImage(this);
        }
        
    }
}
