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
    public static class GameService
    {
        public static void ProcessClick(GameViewModel game, TileViewModel tileVM)
        {
            if (!game.HasPickedPiece)
            {
                PickPiece(game, tileVM);
                return;
            }
                
            if (tileVM.PieceColor == game.CurrentPlayer)
            {
                ResetAvailability(game);
                PickPiece(game, tileVM);
                return;
            }

            PickSpace(game, tileVM);
        }

        private static void PickSpace(GameViewModel game, TileViewModel tileVM)
        {
            ResetAvailability(game);
            MovePiece(game, tileVM);
            (game.CurrentPlayer, game.NonCurrentPlayer) = (game.NonCurrentPlayer, game.CurrentPlayer);
            game.HasPickedPiece = false;
        }
        private static void PickPiece(GameViewModel game, TileViewModel tileVM)
        {
            SetAvailableTiles(game, tileVM.Tile);
            game.PickPiece(tileVM.Position);
        }
        private static void SetAvailableTiles(GameViewModel game, Tile tile)
        {
            foreach (Position position in TileService.GetAllPossibleMoves(tile))
            {
                game.AddMove(tile.Position, position);
            }
        }

        private static void ResetAvailability(GameViewModel game)
        {
            foreach (var row in game.Board)
                foreach (var tile in row)
                    tile.IsAvailable = false;
        }

        private static void MovePiece(GameViewModel game, TileViewModel tileVM)
        {
            game.ApplyMove(tileVM);
        }

    }
}
