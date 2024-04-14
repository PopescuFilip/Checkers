using Checkers.Enums;
using Checkers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Checkers.Services
{
    public static class TileService
    {
        private static readonly int ThirdWhiteRow = 2;
        private static readonly int ThirdRedRow = 5;
        public const int noOfPieces = 12;
        public static void InitPiece(Tile tile)
        {
            if (tile.X > ThirdWhiteRow && tile.X < ThirdRedRow || tile.TileColor == Enums.Color.Black)
            {
                tile.Piece = new Piece();
                return;
            }
                
            if (tile.X <= ThirdWhiteRow)
            {
                tile.Piece = new Piece(Enums.Color.White);
                return;
            }
            
            tile.Piece = new Piece(Enums.Color.Red);
        }

        public static bool IsOnFinalRow(Tile tile)
        {
            if (tile.Piece.Color == Enums.Color.White)
            {
                return tile.Position.X == Board.Rows - 1;
            }
            return tile.Position.X == 0;
        }
        public static string EnumToString(Enums.Color color)
        {
            switch (color)
            {
                case Enums.Color.White:
                    return "white";
                case Enums.Color.Black:
                    return "black";
                case Enums.Color.Red:
                    return "red";
                default:
                    return "none";
            }
        }
        public static string EnumToString(Enums.Type type)
        {
            switch (type)
            {
                case Enums.Type.Normal:
                    return "normal";
                case Enums.Type.King:
                    return "king";
                default:
                    return "none";
            }
        }
        public static Enums.Color StringToColor(string str)
        {
            switch (str)
            {
                case "white":
                    return Enums.Color.White;
                case "black":
                    return Enums.Color.Black;
                case "red":
                    return Enums.Color.Red;
                default:
                    return Enums.Color.None;
            }
        }
        public static Enums.Type StringToType(string str) 
        {
            switch (str)
            {
                case "normal":
                    return Enums.Type.Normal;
                case "king":
                    return Enums.Type.King;
                default:
                    return Enums.Type.None;
            }
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
