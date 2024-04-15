using Checkers.Models;
using Checkers.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Services
{
    public static class GameDownloaderService
    {
        public static void DownloadTo(GameViewModel game)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            bool? answer = dialog.ShowDialog();

            if (answer == false)
                return;

            using (StreamReader reader = new StreamReader(dialog.FileName)) 
            {
                int noOfRedPieces = 0;
                int noOfWhitePieces = 0;
                for (int i = 0; i < Board.Rows; i++) 
                {
                    for (int j = 0; j < Board.Cols; j++)
                    {
                        Enums.Color color = TileService.StringToColor(reader.ReadLine());
                        Enums.Type type = TileService.StringToType(reader.ReadLine());
                        game.Board[i][j].Update(color, type);
                        if(color == Enums.Color.White)
                            noOfWhitePieces++;
                        else if(color == Enums.Color.Red)
                            noOfRedPieces++;
                    }
                }
                game.RedPieces = noOfRedPieces;
                game.WhitePieces = noOfWhitePieces;
                game.CurrentPlayer = TileService.StringToColor(reader.ReadLine());
                if(game.CurrentPlayer == Enums.Color.White)
                    game.NonCurrentPlayer = Enums.Color.Red;
                else
                    game.NonCurrentPlayer = Enums.Color.White;
                 
                string allow = reader.ReadLine();
                if(allow == "True")
                    game.SetMultipleJump(true);
                else
                    game.SetMultipleJump(false);
            }
        }
    }
}
