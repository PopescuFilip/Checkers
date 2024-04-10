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
        public static bool Contains(Position position)
        {
            bool containsX = position.X < Rows && position.X >= 0;
            bool containsY = position.Y < Cols && position.Y >= 0;
            return containsX && containsY;
        }
    }
}
