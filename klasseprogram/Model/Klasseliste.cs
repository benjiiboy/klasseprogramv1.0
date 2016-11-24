using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.IO;

namespace klasseprogram.Model
{
    public class Klasseliste : ObservableCollection<klasseinfo>
    {
        public Klasseliste() : base()
        {
            // her laves en ny klasseliste som indeholder 2 elever, som er defineret før programmet startes
            this.Add(new klasseinfo() { ForNavn = "Benjamin", EfterNavn = "Brobæk Lindgaard", MobilNr = "30112203", Email = "Benjaminlindgaard@ka-net.dk", GitNavn = "BenjiiBoy" });
            this.Add(new klasseinfo() { ForNavn = "Anders", EfterNavn = "Thomsen", MobilNr = "29932466", Email = "ande605x@edu.easj.dk", GitNavn = "ande605x" });
        }
        #region Laves til Json
        public string GetJson()
        {
            // seriallize laver din fil om til en json fil som kan sendes via nettet, og som indeholder alt data om programmet
        string json = JsonConvert.SerializeObject(this);
        return json;
        }
        #endregion

        #region Laves fra Json til fil
        public void IndsætJson(string JsonText)
        {
            // Deserialize laver json strengen om til brugbar kode, med de information som man pakkede ned
            // man kan sige at man pakker json filen ud til kode.
            List<klasseinfo> nyListe = JsonConvert.DeserializeObject<List<klasseinfo>>(JsonText);
            foreach (var i in nyListe)
            {
                this.Add(i);
            }
        }
        #endregion
    }

}
