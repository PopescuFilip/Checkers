﻿using Checkers.Models;
using Checkers.Services;
using Checkers.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Commands
{
    public class GameClickCommand : CommandBase
    {
        private readonly GameViewModel _game;
        private readonly TileViewModel _tile;
        public GameClickCommand(GameViewModel board, TileViewModel tile) 
        {
            _game = board;
            _tile = tile;
            _game.PropertyChanged += OnViewModelProperyChanged;
            _tile.PropertyChanged += OnViewModelProperyChanged;
        }

        private void OnViewModelProperyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(GameViewModel.CurrentPlayer) ||
                e.PropertyName == nameof(GameViewModel.HasPickedPiece) ||
                e.PropertyName == nameof(TileViewModel.IsAvailable) ||
                e.PropertyName == nameof(GameViewModel.HasCaptured))
            {
                OnCanExecutedChanged();
            }
        }

        public override void Execute(object parameter)
        {
            GameService.ProcessClick(_game, _tile);
        }

        public override bool CanExecute(object parameter)
        {
            if(_game.HasCaptured)
                return _tile.IsAvailable && base.CanExecute(parameter);
            if(_game.HasPickedPiece)
                return (_tile.IsAvailable || IsCurrentPlayerPiece()) && base.CanExecute(parameter);
            return IsCurrentPlayerPiece() && base.CanExecute(parameter);
        }

        private bool IsCurrentPlayerPiece()
        {
            return _tile.PieceColor == _game.CurrentPlayer;
        }
    }
}
