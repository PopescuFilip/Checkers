using Checkers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Models
{
    public class Tile
    {
        public PieceColor PieceColor { get; set; }
        public PieceType PieceType { get; set; }
        public TileColor TileColor { get; set; }
        public bool HasPiece { get; set; }
        
        public Tile(TileColor tileColor, PieceColor pieceColor) 
        {
            TileColor = tileColor;
            PieceColor = pieceColor;
            PieceType = PieceType.None;
            HasPiece = true;
        }
        
        public Tile(TileColor tileColor) 
        {
            TileColor = tileColor;
            PieceColor = PieceColor.None;
            PieceType = PieceType.None;
            HasPiece = false;
        }
    }
}
