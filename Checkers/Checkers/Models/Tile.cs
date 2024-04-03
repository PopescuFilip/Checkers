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
        public Piece Piece {  get; set; }
        public Color TileColor { get; }
        public bool HasPiece { get; set; }
        public int X { get; }
        public int Y { get; }
        public string Image {  get; set; }

        public Tile(int x, int y)
        {
            X = x;
            Y = y;
            TileColor = (x + y) % 2 == 0 ? Color.White : Color.Black;
            InitPiece();

            Image = ImagePickerService.GetImage(this);
        }
        private void InitPiece()
        {
            if (X >= 3 && X <= 4 || TileColor == Color.Black)
            {
                Piece = new Piece();
                HasPiece = false;
            }
            else 
            {
                if (X < 3)
                    Piece = new Piece(Color.White);
                else
                    Piece = new Piece(Color.Red);
                HasPiece = true;
            }
        }
    }
}
