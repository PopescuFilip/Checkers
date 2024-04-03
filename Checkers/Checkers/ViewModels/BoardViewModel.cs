using Checkers.Enums;
using Checkers.Models;
using Checkers.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Checkers.ViewModels
{
    public class BoardViewModel: BaseViewModel
    {
        public const int Rows = 8;
        public const int Cols = 8;
        public ObservableCollection<ObservableCollection<Tile>> Board { get; set; }
        public BoardViewModel() 
        {
            Board = new ObservableCollection<ObservableCollection<Tile>>();

            for (int i = 0; i < Rows; i++)
            {
                ObservableCollection<Tile> row = new ObservableCollection<Tile>();
                for (int j = 0; j < Cols; j++)
                    row.Add(new Tile(i, j));
                Board.Add(row);
            }
        }
    }
}
