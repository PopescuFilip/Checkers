using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Models
{
    public  static class Board
    {
        public const int Rows = 8;
        public const int Cols = 8;

        public static Tile[,] BoardMatrix { get; }
        static Board()
        {
            BoardMatrix = new Tile[Rows, Cols];

            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    BoardMatrix[i, j] = new Tile(i, j);
        }
    }
}
