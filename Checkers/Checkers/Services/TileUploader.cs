using Checkers.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Services
{
    public static class TileUploader
    {
        public static void Upload(StreamWriter sw, Tile tile)
        {
            sw.WriteLine(TileService.EnumToString(tile.Piece.Color));
            sw.WriteLine(TileService.EnumToString(tile.PieceType));
        }
    }
}
