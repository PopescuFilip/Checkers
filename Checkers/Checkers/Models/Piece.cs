using Checkers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Models
{
    public class Piece
    {
        public PieceColor PieceColor { get; set; }
        public PieceType PieceType { get; set; }
        public Piece() 
        {
            PieceColor = PieceColor.None;
            PieceType = PieceType.None;
        }

        public Piece(PieceColor pieceColor)
        {
            PieceColor = pieceColor;
            PieceType = PieceType.Normal;
        }
    }
}
