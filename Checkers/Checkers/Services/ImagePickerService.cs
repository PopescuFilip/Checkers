using Checkers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Services
{
    public static class ImagePickerService
    {
        private const string DefaultPath = "/Checkers;component/Resources/";
        private const string BlackTile = "black.jpg";
        private const string WhiteTile = "white.jpg";
        private const string WhitePiece = "checker_piece_white.jpg";
        private const string RedPiece = "checker_piece_red.jpg";
        private const string KingWhitePiece = "checker_piece_white_king.png";
        private const string KingRedPiece = "checker_piece_red_king.png";
        public static string GetImage(Tile tile)
        {
            if(tile.TileColor == Enums.Color.Black) 
                return GetBlackTile();

            if(!tile.HasPiece)
                return GetWhiteTile();

            return GetImage(tile.Piece);
        }
 
        public static string GetImage(Piece piece)
        {
            if(piece.Type == Enums.Type.None)
                return GetWhiteTile();

            if(piece.Type == Enums.Type.Normal)
            {
                if (piece.Color == Enums.Color.White)
                    return GetWhitePiece();

                return GetRedPiece();
            }

            if (piece.Color == Enums.Color.White)
                return GetKingWhitePiece();

            return GetKingRedPiece();
        }
        private static string GetWhiteTile()
        {
            return DefaultPath + WhiteTile;
        }
        private static string GetBlackTile()
        {
            return DefaultPath + BlackTile;
        }
        private static string GetWhitePiece()
        {
            return DefaultPath + WhitePiece;
        }
        private static string GetRedPiece() 
        {
            return DefaultPath + RedPiece;
        }

        private static string GetKingWhitePiece()
        {
            return DefaultPath + KingWhitePiece;
        }
        private static string GetKingRedPiece()
        {
            return DefaultPath + KingRedPiece;
        }
    }
}
