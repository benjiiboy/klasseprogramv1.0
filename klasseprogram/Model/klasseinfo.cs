using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klasseprogram.Model
{
    public class klasseinfo
    {
        // Her laver jeg de properties som bruges til at beskrive den klasse vi skal lave. f.eks info om 1R.
        public string ForNavn { get; set; }

        public string EfterNavn { get; set; }

        public int MobilNr { get; set; }

        public string Email { get; set; }

        public string GitNavn { get; set; }

        public override string ToString()
        {
            return "Fornavn: " + ForNavn + " Efternavn: " + EfterNavn + " Mobil Nr: " + MobilNr + " Email: " + Email + " Githubnavn: " + GitNavn;
        }
    }
}
