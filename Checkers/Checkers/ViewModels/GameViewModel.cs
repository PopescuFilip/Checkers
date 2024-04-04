using Checkers.Enums;
using Checkers.Models;
using Checkers.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Checkers.ViewModels
{
    public class GameViewModel: ViewModelBase
    {
        public ObservableCollection<ObservableCollection<TileViewModel>> Board { get; set; }
        private Enums.Color _currentPlayer;
        public Enums.Color CurrentPlayer
        {
            get { return _currentPlayer; }
            set 
            { 
                _currentPlayer = value;
                OnPropertyChanged(nameof(CurrentPlayer));
                OnPropertyChanged(nameof(WhiteTurn));
                OnPropertyChanged(nameof(RedTurn));
            }
        }

        private Enums.Color _nonCurrentPlayer;
        public Enums.Color NonCurrentPlayer
        {
            get { return _nonCurrentPlayer; }
            set
            {
                _nonCurrentPlayer = value;
                OnPropertyChanged(nameof(NonCurrentPlayer));
            }
        }

        private bool _hasPickedPiece;

        public bool HasPickedPiece
        {
            get { return _hasPickedPiece; }
            set 
            { 
                _hasPickedPiece = value;
                OnPropertyChanged(nameof(HasPickedPiece));
            }
        }

        private Position _pickedPosition;

        public Position PickedPosition
        {
            get { return _pickedPosition; }
            set 
            {
                _pickedPosition = value;
            }
        }


        public Visibility WhiteTurn
        {
            get { return CurrentPlayer == Enums.Color.White ? Visibility.Visible : Visibility.Hidden; }
        }

        public Visibility RedTurn
        {
            get { return CurrentPlayer == Enums.Color.Red ? Visibility.Visible : Visibility.Hidden; }
        }
        public GameViewModel() 
        {
            CurrentPlayer = Enums.Color.Red;
            NonCurrentPlayer = Enums.Color.White;
            HasPickedPiece = false;

            InitBoard();
        }
        private void InitBoard()
        {
            Board = new ObservableCollection<ObservableCollection<TileViewModel>>();

            for (int i = 0; i < Models.Board.Rows; i++)
            {
                ObservableCollection<TileViewModel> row = new ObservableCollection<TileViewModel>();
                for (int j = 0; j < Models.Board.Cols; j++)
                    row.Add(new TileViewModel(this, Models.Board.BoardMatrix[i, j]));
                Board.Add(row);
            }
        }
        public void PickPiece(Position pickedPosition)
        {
            PickedPosition = pickedPosition;
            HasPickedPiece = true;
        }

        public Piece ExtractPickedPiece()
        {
            return Board[PickedPosition.X][PickedPosition.Y].ExtractPiece();
        }
    }
}
