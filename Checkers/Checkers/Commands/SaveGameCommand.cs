using Checkers.Services;
using Checkers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Commands
{
    public class SaveGameCommand : CommandBase
    {
        private readonly GameViewModel _game;
        public SaveGameCommand(GameViewModel game) 
        {
            _game = game;
        }
        public override void Execute(object parameter)
        {
            GameUploaderService.Upload(_game);
        }
    }
}
