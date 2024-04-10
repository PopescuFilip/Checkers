﻿using Checkers.Enums;
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
    public class GameViewModel : ViewModelBase
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

        private bool _hasCaptured;
        public bool HasCaptured 
        {
            get { return _hasCaptured; } 
            set
            {
                _hasCaptured = value;
                OnPropertyChanged(nameof(HasCaptured));
            }
        }

        public Position PickedPiecePosition { get; set; }

        public Visibility WhiteTurn
        {
            get { return CurrentPlayer == Enums.Color.White ? Visibility.Visible : Visibility.Hidden; }
        }

        public Visibility RedTurn
        {
            get { return CurrentPlayer == Enums.Color.Red ? Visibility.Visible : Visibility.Hidden; }
        }

        private int _whitePieces;
        public int WhitePieces
        {
            get { return _whitePieces; }
            set { _whitePieces = value; OnPropertyChanged(nameof(WhitePieces)); }
        }

        private int _redPieces;
        public int RedPieces
        {
            get { return _redPieces; }
            set { _redPieces = value; OnPropertyChanged(nameof(RedPieces)); }
        }

        public GameViewModel()
        {
            CurrentPlayer = Enums.Color.Red;
            NonCurrentPlayer = Enums.Color.White;
            HasPickedPiece = false;
            HasCaptured = false;
            WhitePieces = TileService.noOfPieces;
            RedPieces = TileService.noOfPieces;
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
            AddCaptureMove(newMove);
        }
        private bool AddCaptureMove(Move move)
        {
            Position nextPosition = move.Next();
            if (!Models.Board.Contains(nextPosition))
                return false;

            TileViewModel nextTile = GetTile(nextPosition);
            if (nextTile.HasPiece)
                return false;

            move.AddCapture(nextPosition);
            GetTile(nextPosition).Move = move;
            return true;
        }

        public bool AddCaptureMove(Position initialPosition, Position finalPosition)
        {
            TileViewModel tileVM = GetTile(finalPosition);
            Move newMove = new Move(initialPosition, finalPosition);
            if (!tileVM.HasPiece || tileVM.PieceColor == CurrentPlayer)
                return false;
            return AddCaptureMove(newMove);

        }
        public void ApplyMove(TileViewModel tileVM)
        {
            if(tileVM.Move.HasCaptured)
            {
                HasCaptured = true;
                foreach (Position pos in tileVM.Move.Captured)
                {
                    TileViewModel tile = GetTile(pos);
                    UpdateNoOfPieces(tile.PieceColor);
                    tile.ExtractPiece();
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

        public void TurnChange()
        {
            (CurrentPlayer, NonCurrentPlayer) = (NonCurrentPlayer, CurrentPlayer);
            HasPickedPiece = false;
            HasCaptured = false;
        }

        private void UpdateNoOfPieces(Enums.Color removedPieceColor)
        {
            if (removedPieceColor == Enums.Color.Red)
            {
                RedPieces--;
                if (RedPieces == 0)
                    MessageBox.Show("White wins");
                return;
            }
            WhitePieces--;
            if (WhitePieces == 0)
                MessageBox.Show("Red wins");
        }
    }
}
