using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Checkers.Commands
{
    public class AboutCommand : CommandBase
    {
        private const string Path = "../../Resources/About.txt";
        public override void Execute(object parameter)
        {
            string aboutMessage = string.Empty;
            using (StreamReader reader = new StreamReader(Path))
            {
                string s;
                while((s = reader.ReadLine()) != null)
                {
                    aboutMessage += '\n' + s;
                }
            }

            MessageBox.Show(aboutMessage);
        }
    }
}
