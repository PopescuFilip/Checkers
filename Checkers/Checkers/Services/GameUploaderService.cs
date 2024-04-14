using Checkers.Enums;
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
    public static class GameUploaderService
    {
        public static void Upload(GameViewModel game)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            bool? answer = saveFileDialog.ShowDialog();

            if (answer == false)
                return;

            string pathFile = saveFileDialog.FileName;
            using (StreamWriter sw = new StreamWriter(pathFile, false))
            {
                for (int i = 0; i < Board.Rows; i++)
                {
                    for (int j = 0; j < Board.Cols; j++)
                        TileUploader.Upload(sw, game.GetTile(i, j));
                }
                sw.WriteLine(TileService.EnumToString(game.CurrentPlayer));
                sw.WriteLine(game.AllowMultipleJump);
            }
            
        }
    }
}
