using Checkers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Checkers.Commands
{
    public class ShowStatisticsCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            MessageBox.Show(StatisticsService.GetStatistics());
        }
    }
}
