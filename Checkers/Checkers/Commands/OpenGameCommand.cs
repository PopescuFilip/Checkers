﻿using Checkers.Services;
using Checkers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Commands
{
    public class OpenGameCommand : CommandBase
    {
        private readonly GameViewModel _game;
        public OpenGameCommand(GameViewModel game) 
        {
            _game = game;
        }
        public override void Execute(object parameter)
        {
            GameDownloaderService.DownloadTo(_game);
        }
    }
}
