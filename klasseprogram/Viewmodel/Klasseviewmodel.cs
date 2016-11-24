using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Newtonsoft.Json;
using System.IO;
using Windows.Storage;

namespace klasseprogram.Viewmodel
{
    public class Klasseviewmodel : INotifyPropertyChanged
    {
        
   

        #region En metode til den valgte elev
        public Model.klasseinfo SelectedElev
        {
            // denne metode bruges til at man kan vælge en elev og gøre noget med den, f.eks. slette via en anden metode
            get { return selectedElev; }
            set
            {
                this.selectedElev = value;
                this.OnPropertyChanged(nameof(SelectedElev));
            }
        }
        #endregion

        #region Constuctor
        public Klasseviewmodel()
            {
            // her laves alle de nye instanser
            Listen = new Model.Klasseliste();
            SelectedElev = new Model.klasseinfo();
            AddElevCommand = new AddElevCommand(addnyelev);
            SletElevCommand = new SletElevCommand(SletElev);
            Nyelev = new Model.klasseinfo();
            GemElevCommand = new GemElevCommand(GemDataTilDiskAsync);
            HentDataCommand = new HentDataCommand(HentDataFraDiskAsync);

            localfolder = ApplicationData.Current.LocalFolder;
            //addnyelevcommand = new RelayCommand(addnyelev);
            }
        #endregion

        #region property changed metoden

        protected virtual void OnPropertyChanged(string propertyName)
        // denne metode er predifineret, til at tjekke om der er lavet noget nyt om imens man er i programmet
        // og derefter opdaterer det
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }


        }
        #endregion
        /// <summary>
        /// gemmer json data fra liste i localfolder
        /// </summary>
        #region Gem Data til lokal disk
        public async void GemDataTilDiskAsync()
            // her gemmes dataen fra programmet til lokal disken
        {
            string jsonText = this.Listen.GetJson();
            StorageFile file = await localfolder.CreateFileAsync(filnavn, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, jsonText);
        }
        #endregion

        #region properties til commands via set og get
        private readonly string filnavn = "JsonText.json";

        public event PropertyChangedEventHandler PropertyChanged;

        private Model.klasseinfo selectedElev;

        public Model.Klasseliste Listen { get; set; }

        public AddElevCommand AddElevCommand { get; set; }

        public SletElevCommand SletElevCommand { get; set; }

        public Model.klasseinfo Nyelev { get; set; }

        public GemElevCommand GemElevCommand { get; set; }

        public HentDataCommand HentDataCommand { get; set; }

        StorageFolder localfolder = null;

        #endregion

        #region opret en ny elev
        // Her laves først en midlertidig klasse, og så laves eleven, så man kan slette den elev man vælger under listen
        // så ikke den sletter den senest tilføjede. Derfor laves den midlertidige klasse så hvert nyt objekt sin egen værdi
        public void addnyelev()
        {
            Model.klasseinfo TempKlasseinfo = new Model.klasseinfo();
            TempKlasseinfo.ForNavn = Nyelev.ForNavn;
            TempKlasseinfo.EfterNavn = Nyelev.EfterNavn;
            TempKlasseinfo.Email = Nyelev.Email;
            TempKlasseinfo.GitNavn = Nyelev.GitNavn;
            TempKlasseinfo.MobilNr = Nyelev.MobilNr;
            Listen.Add(TempKlasseinfo);

        }
        #endregion
        #region Slet en elev fra listen
        //  her er metoden som sletter en elev fra den nuværnde liste
        public void SletElev()
        {
            Listen.Remove(SelectedElev);
        }
        // public RelayCommand addnyelevcommand { get; set; }
        #endregion

        #region Hent data fra diseken 
        public async void HentDataFraDiskAsync() // her har jeg lavet en metode til at finde og loade data fra disken
                                                 // Først clear den listen så derefter henter den det data den kan finde under fil nanet
        {
            this.Listen.Clear();

            StorageFile file = await localfolder.GetFileAsync(filnavn);
            string jsonText = await FileIO.ReadTextAsync(file);

            Listen.IndsætJson(jsonText);

        }
        #endregion
    }
}
