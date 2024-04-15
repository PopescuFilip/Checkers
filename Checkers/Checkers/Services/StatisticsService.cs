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
        public static string GetStatistics()
        {
            int redVictories = 0;
            int whiteVictories = 0;
            int maxRedPieces = 0;
            int maxWhitePieces = 0;
            using (StreamReader sr = new StreamReader(Path))
            {
                string s;
                while((s = sr.ReadLine()) != null)
                {
                    Enums.Color winnerColor = TileService.StringToColor(s);
                    s = sr.ReadLine();
                    int maxPieces = Int32.Parse(s);
                    if (winnerColor == Enums.Color.White)
                    {
                        whiteVictories++;
                        if(maxPieces > maxWhitePieces)
                            maxWhitePieces = maxPieces;
                    }
                    else
                    {
                        redVictories++;
                        if(maxPieces > maxRedPieces)
                            maxRedPieces = maxPieces;
                    }
                }
            }

            return 
                $"White wins: {whiteVictories}\n" +
                $"Max white pieces: {maxWhitePieces}\n" +
                $"Red wins: {redVictories}\n" +
                $"Max red pieces: {maxRedPieces}\n";
        }
    }
}
