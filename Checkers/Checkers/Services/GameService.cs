using Checkers.Models;
using Checkers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;

namespace Checkers.Services
{
    public class GameService
    {
        public static void ProcessClick(GameViewModel game, Tile tile)
        {
            if (game.HasPickedPiece)
                PickSpace(game, tile);
            else
                PickPiece(game, tile);
        }

        private static void PickSpace(GameViewModel game, Tile tile)
        {
            ResetAvailability(game);
            MovePiece(game, tile);
            (game.CurrentPlayer, game.NonCurrentPlayer) = (game.NonCurrentPlayer, game.CurrentPlayer);
            game.HasPickedPiece = false;
        }
        private static void PickPiece(GameViewModel game, Tile tile)
        {
            SetAvailableTiles(game, tile);
            game.PickPiece(tile.Position);
        }
        private static void SetAvailableTiles(GameViewModel game, Tile tile)
        {
            foreach (Position item in tile.GetAllPossibleMoves())
            {
                TileViewModel tileVM = game.Board[item.X][item.Y];
                if (!tileVM.HasPiece)
                    tileVM.IsAvailable = true;
            }
        }

        private static void ResetAvailability(GameViewModel game)
        {
            foreach (var row in game.Board)
                foreach (var tile in row)
                    tile.IsAvailable = false;
        }

        private static void MovePiece(GameViewModel game, Tile tile)
        {
            Piece piece = game.ExtractPickedPiece();
            tile.Piece = piece;
        }
    }
}
