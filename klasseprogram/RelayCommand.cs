﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace klasseprogram
{
    public class RelayCommand : ICommand
    {
        private Action methodToExecute = null;
        private Func<bool> methodToDetectCanExecute = null;

        public RelayCommand(Action methodToExecute, Func<bool> methodToDetectCanExecute)
        {
            this.methodToExecute = methodToExecute;
            this.methodToDetectCanExecute = methodToDetectCanExecute;
        } 

        public void Execute(object parameter)
        {
            this.methodToExecute();
        }

        public bool CanExecute(object parameter)

        {
            if (this.methodToDetectCanExecute == null)
            {
                return true;
            }
            else
            {
                return this.methodToDetectCanExecute();
            }
        }

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action execute):this(execute,null)
        { }

        

    }
}
