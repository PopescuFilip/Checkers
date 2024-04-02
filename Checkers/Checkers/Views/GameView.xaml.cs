using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Checkers.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        public GameView()
        {
            InitializeComponent();
            CreateCheckerboard();
        }

        private void CreateCheckerboard()
        {
            const int rows = 8;
            const int columns = 8;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Button button = new Button();
                    button.Background = (i + j) % 2 == 0 ? Brushes.White : Brushes.Black;

                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);

                    MainGrid.Children.Add(button);
                }
            }
        }
    }
}
