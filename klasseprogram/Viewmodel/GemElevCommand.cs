using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace klasseprogram.Viewmodel
{
    public class GemElevCommand : ICommand
    {
        // denne class arver fra icommand classes
        // denne class bruges til at lave en command som gemmer dataen fra programmet.
        private readonly Action execute;

        public event EventHandler CanExecuteChanged;

        public GemElevCommand(Action execute)
        {
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            execute();
        }
    }
}
