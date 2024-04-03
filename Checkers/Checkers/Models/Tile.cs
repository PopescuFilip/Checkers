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
        public PieceColor PieceColor { get; set; }
        public PieceType PieceType { get; set; }
        public TileColor TileColor { get; }
        public bool HasPiece { get; set; }
        public int X { get; }
        public int Y { get; }
        public string Image {  get; set; }

        public Tile(int x, int y)
        {
            X = x;
            Y = y;
            TileColor = (x + y) % 2 == 0 ? TileColor.White : TileColor.Black;
            InitPiece();

            Image = ImagePickerService.GetImage(this);
        }
        private void InitPiece()
        {
            if (X >= 3 && X <= 4 || TileColor == TileColor.Black)
            {
                PieceColor = PieceColor.None;
                PieceType = PieceType.None;
                HasPiece = false;
            }
            else 
            {
                if (X < 3)
                    PieceColor = PieceColor.White;
                else
                    PieceColor = PieceColor.Red;

                PieceType = PieceType.Normal;
                HasPiece = true;
            }
        }
    }
}
