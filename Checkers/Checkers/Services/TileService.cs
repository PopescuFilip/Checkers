using Checkers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Services
{
    public static class TileService
    {
        public static void InitPiece(Tile tile)
        {
            if (tile.X >= 3 && tile.X <= 4 || tile.TileColor == Enums.Color.Black)
            {
                tile.Piece = new Piece();
                return;
            }
                
            if (tile.X < 3)
            {
                tile.Piece = new Piece(Enums.Color.White);
                return;
            }
            
            tile.Piece = new Piece(Enums.Color.Red);
        }
        public static List<Position> GetAllPossibleMoves(Tile tile)
        {
            if (tile.Piece.Type == Enums.Type.King)
                return GetPossibleRedMoves(tile).Concat(GetPossibleWhiteMoves(tile)).ToList();

            if (tile.Piece.Color == Enums.Color.White)
                return GetPossibleWhiteMoves(tile);
            
            return GetPossibleRedMoves(tile);
        }
        private static List<Position> GetPossibleWhiteMoves(Tile tile)
        {
            List<Position> positions = new List<Position>();

            if (tile.X == Board.Rows - 1)
                return positions;

            if (tile.Y < Board.Cols - 1)
                positions.Add(new Position(tile.X + 1, tile.Y + 1));
            if (tile.Y > 0)
                positions.Add(new Position(tile.X + 1, tile.Y - 1));

            return positions;
        }
        private static List<Position> GetPossibleRedMoves(Tile tile)
        {
            List<Position> positions = new List<Position>();

            if (tile.X == 0)
                return positions;

            if (tile.Y < Board.Cols - 1)
                positions.Add(new Position(tile.X - 1, tile.Y + 1));
            if (tile.Y > 0)
                positions.Add(new Position(tile.X - 1, tile.Y - 1));

            return positions;
        }
    }
}
