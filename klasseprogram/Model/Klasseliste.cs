using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace klasseprogram.Model
{
    public class Klasseliste : ObservableCollection<klasseinfo>
    {
        public Klasseliste() : base()
        {
            this.Add(new klasseinfo() { ForNavn = "Benjamin", EfterNavn = "Brobæk Lindgaard", MobilNr = 30112203, Email = "Benjaminlindgaard@ka-net.dk", GitNavn = "BenjiiBoy" });
            this.Add(new klasseinfo() { ForNavn = "Anders", EfterNavn = "Thomsen", MobilNr = 29932466, Email = "ande605x@edu.easj.dk", GitNavn = "ande605x" });
        }
    }
}
