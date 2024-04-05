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

        public Position PickedPiecePosition {  get; set; }

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
        public void AddMove(Position initialPosition, Position finalPosition)
        {
            TileViewModel tileVM = GetTile(finalPosition);
            Move newMove = new Move(initialPosition, finalPosition);
            if (!tileVM.HasPiece)
            {
                tileVM.Move = newMove;
                return;
            }
            if (tileVM.PieceColor == CurrentPlayer)
                return;
            Position nextPosition = newMove.Next();
            if (!Models.Board.Contains(nextPosition))
                return;

            TileViewModel nextTile = GetTile(nextPosition); 
            if(!nextTile.HasPiece)
            {
                newMove.AddCapture(nextPosition);
                GetTile(nextPosition).Move = newMove;
            }
        }

        public void ApplyMove(TileViewModel tileVM)
        {
            if(tileVM.Move.HasCaptured)
            {
                foreach (Position pos in tileVM.Move.Captured)
                {
                    GetTile(pos).ExtractPiece();
                }
            }
            tileVM.Piece = GetTile(PickedPiecePosition).ExtractPiece();
            if (TileService.IsOnFinalRow(tileVM.Tile))
                tileVM.PieceType = Enums.Type.King;
        }
        public TileViewModel GetTile(Position position)
        {
            return Board[position.X][position.Y];
        }
        public void PickPiece(Position pickedPosition)
        {
            PickedPiecePosition = pickedPosition;
            HasPickedPiece = true;
        }
    }
}
