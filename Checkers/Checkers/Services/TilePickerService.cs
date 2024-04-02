using Checkers.Enums;
using Checkers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Services
{
    public class TilePickerService
    {
        public static Tile PickTile(int row, int column)
        {
            TileColor tileColor = (row + column) % 2 == 0 ? TileColor.White : TileColor.Black;

            if(row >= 2 && row <= 5)
                return new Tile(tileColor);

            PieceColor pieceColor;
            if (row < 2)
                pieceColor = PieceColor.White;
            else
                pieceColor = PieceColor.Red;
            
            return new Tile(tileColor, pieceColor);
        }
    }
}
