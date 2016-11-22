using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace klasseprogram.Viewmodel
{
    public class Klasseviewmodel : INotifyPropertyChanged
    {
        public Model.Klasseliste Listen { get; set; }


        private Model.klasseinfo selectedElev;

        public Model.klasseinfo SelectedElev
        {
            get { return selectedElev; }
            set
            {
                this.selectedElev = value;
                this.OnPropertyChanged(nameof(SelectedElev));
            }
        }

        public Klasseviewmodel()
            {
            Listen = new Model.Klasseliste();
            SelectedElev = new Model.klasseinfo();
            addnyelevcommand = new RelayCommand(addnyelev);
            }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }


        }
        public Model.klasseinfo Nyelev { get; set; }

        public void addnyelev()
        {
            Listen.Add(Nyelev);
        }

        public RelayCommand addnyelevcommand { get; set; }
    }
}
