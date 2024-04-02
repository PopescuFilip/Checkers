﻿using Checkers.Enums;
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
        public ObservableCollection<ObservableCollection<Tile>> Board { get; set; }

        public BoardViewModel() 
        {
            Board = InitBoard();
        }

        private ObservableCollection<ObservableCollection<Tile>> InitBoard()
        {
            ObservableCollection<ObservableCollection<Tile>> board = new ObservableCollection<ObservableCollection<Tile>>();

            for (int i = 0; i < 8; i++) 
            {
                board[i] = new ObservableCollection<Tile>();
                for (int j = 0; j < 8; j++)
                    board[i][j] = TilePickerService.PickTile(i, j);
            }

            return board;
        }
    }
}
