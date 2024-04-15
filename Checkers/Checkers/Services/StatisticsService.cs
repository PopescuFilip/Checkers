using Checkers.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Services
{
    public static class StatisticsService
    {
        private const string Path = "../../Resources/Statistics.txt";

        public static void Log(Enums.Color winner, int noOfPieces)
        {
            using (StreamWriter sw = File.AppendText(Path))
            {
                sw.WriteLine(TileService.EnumToString(winner));
                sw.WriteLine(noOfPieces);
            }
        }
    }
}
