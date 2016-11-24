using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace klasseprogram.Viewmodel
{
    public class HentDataCommand : ICommand
    {
        // denne class arver fra icommand classes
        // denne class bruges til at lave en command som henter det gemte data fra disken og tilføjer det til
        //den eksisterende liste
        private readonly Action execute;

        public event EventHandler CanExecuteChanged;

        public HentDataCommand(Action execute)
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
