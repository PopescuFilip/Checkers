using Checkers.Commands;
using Checkers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Checkers.ViewModels
{
    public class TileViewModel : ViewModelBase
    {
        private Tile _tile;

        public Tile Tile
        {
            get { return _tile; }
            set 
            { 
                _tile = value; 
                OnPropertyChanged(nameof(Tile));
            }
        }

        public ICommand GameClick { get; }
        public TileViewModel(BoardViewModel board, Tile tile) 
        {
            Tile = tile;
            GameClick = new GameClickCommand(board, tile);
        }
    }
}
