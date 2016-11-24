﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace klasseprogram.Viewmodel
{
    public class SletElevCommand : ICommand

    {
        public event EventHandler CanExecuteChanged;

        private readonly Action execute;

        public SletElevCommand(Action execute)
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
