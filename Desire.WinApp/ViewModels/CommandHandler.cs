using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Desire.WinApp.ViewModels
{
    public class CommandHandler : ICommand
    {
        private MainViewModel obj; // Point 1
        public CommandHandler(MainViewModel _obj) // Point 2
        {
            obj = _obj;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true; // Point 3
        }
        public void Execute(object parameter)
        {
            
        }
    }
}
