using Checkers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Commands
{
    public class NewGameCommand : CommandBase
    {
        private GameViewModel _game;
        public NewGameCommand(GameViewModel game) 
        {
            _game = game;
        }
        public override void Execute(object parameter)
        {
            _game.Init();
        }
    }
}
