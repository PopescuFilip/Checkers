using Checkers.ViewModels;
using Checkers.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Checkers.Services
{
    public static class EndGameService
    {
        public static void ProcessEndGame(GameViewModel game)
        {
            if (game.RedPieces == 0)
            {
                MessageBox.Show("White wins!!");
                StatisticsService.Log(Enums.Color.White, game.WhitePieces);
            }
            else
            {
                MessageBox.Show("Red wins!!");
                StatisticsService.Log(Enums.Color.Red, game.RedPieces);
            }

            
            game.Init();
        }
    }
}
