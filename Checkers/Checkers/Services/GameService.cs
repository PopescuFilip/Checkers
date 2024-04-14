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
            //MovePiece(game, tileVM);
            game.ApplyMove(tileVM);

            if (game.AllowMultipleJump && game.HasCaptured)
            {
                MultipleMoveLogic(game, tileVM);
                return;
            }

            game.TurnChange();
        }
        private static void PickPiece(GameViewModel game, TileViewModel tileVM)
        {
            SetAvailableTiles(game, tileVM.Tile);
            game.PickPiece(tileVM.Position);
        }
        private static void SetAvailableTiles(GameViewModel game, Tile tile)
        {
            if(!game.HasCaptured)
            {
                foreach (Position position in TileService.GetAllPossibleMoves(tile))
                    game.AddMove(tile.Position, position);
                return;
            }

            bool atLeastOneCaptureMove = false;
            foreach (Position position in TileService.GetAllPossibleMoves(tile))
            {
                if(game.AddCaptureMove(tile.Position, position))
                    atLeastOneCaptureMove = true;
            }

            if(!atLeastOneCaptureMove)
                game.TurnChange();
        }

        private static void ResetAvailability(GameViewModel game)
        {
            foreach (var row in game.Board)
                foreach (var tile in row)
                    tile.IsAvailable = false;
        }

        private static void MultipleMoveLogic(GameViewModel game, TileViewModel tileVM)
        {
            game.PickPiece(tileVM.Position);
            SetAvailableTiles(game, tileVM.Tile);
        }

    }
}
