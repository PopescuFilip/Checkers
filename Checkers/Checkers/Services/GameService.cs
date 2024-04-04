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
        public static void ProcessClick(GameViewModel game, TileViewModel tileVM)
        {
            if (game.HasPickedPiece)
                PickSpace(game, tileVM);
            else
                PickPiece(game, tileVM);
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
            SetAvailableTiles(game, tileVM);
            game.PickPiece(tileVM.Position);
        }
        private static void SetAvailableTiles(GameViewModel game, TileViewModel tileVM)
        {
            foreach (Position item in tileVM.GetAllPossibleMoves())
            {
                TileViewModel tile = game.Board[item.X][item.Y];
                if (!tile.HasPiece)
                    tile.IsAvailable = true;
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
            tileVM.PlacePiece(game.ExtractPickedPiece());
        }

    }
}
