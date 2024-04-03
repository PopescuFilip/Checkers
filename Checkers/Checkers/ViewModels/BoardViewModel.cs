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
    public class BoardViewModel: ViewModelBase
    {
        public ObservableCollection<ObservableCollection<Tile>> Board { get; set; }
        private Enums.Color _currentPlayer;
        public Enums.Color CurrentPlayer
        {
            get { return _currentPlayer; }
            set 
            { 
                _currentPlayer = value;
                OnPropertyChanged(nameof(CurrentPlayer));
            }
        }

        public BoardViewModel() 
        {
            CurrentPlayer = Enums.Color.Red;

            Board = new ObservableCollection<ObservableCollection<Tile>>();

            for (int i = 0; i < Models.Board.Rows; i++)
            {
                ObservableCollection<Tile> row = new ObservableCollection<Tile>();
                for (int j = 0; j < Models.Board.Cols; j++)
                    row.Add(Models.Board.BoardMatrix[i,j]);
                Board.Add(row);
            }
        }
    }
}
