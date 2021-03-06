﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace klasseprogram.Viewmodel
{
    public class AddElevCommand : ICommand
    {
        // denne class arver fra icommand classes
        // denne class bruges til at lave en command som tilføjer en elev, til den eksisterende liste
        private readonly Action execute;

        public event EventHandler CanExecuteChanged;

        public AddElevCommand(Action execute)
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
