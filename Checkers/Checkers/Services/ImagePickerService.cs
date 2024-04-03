using Checkers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Services
{
    public class ImagePickerService
    {
        private const string DefaultPath = "/Checkers;component/Resources/";
        private const string BlackTile = "black.jpg";
        private const string WhiteTile = "white.jpg";
        private const string WhitePiece = "checker_piece_white.jpg";
        private const string RedPiece = "checker_piece_red.jpg";
        public static string GetImage(Tile tile)
        {
            if(tile.TileColor == Enums.TileColor.Black) 
                return GetBlackTile();

            if(!tile.HasPiece)
                return GetWhiteTile();

            if (tile.Piece.PieceColor == Enums.PieceColor.White)
                return GetWhitePiece();

            return GetRedPiece();
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
    }
}
