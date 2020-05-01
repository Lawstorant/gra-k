using System.Collections.Generic;
using System;

namespace gra_k
{
    public struct SilaObrony
    {
        public const double brak = 0;
        public const double normalna = 0.6;
        public const double mocna = 0.2;
    }

    public struct StatusPostaci
    {
        public uint zycie;
        public uint wytrzymalosc;
        public uint sila;
        public uint pancerz;
        public double obrona;
    }

    public class Postac
    {
        protected uint zycie;
        protected uint wytrzymalosc;
        protected uint sila;
        protected uint pancerz;
        // Lista ciosów jako generyczna lista dynamiczna, ułatwia dodawanie ciosów
        protected List<Cios> listaCiosow;
        protected double obrona;



        public Postac(uint zycie, uint wytrzymalosc, uint sila, uint pancerz)
        {
            this.zycie = zycie;
            this.wytrzymalosc = wytrzymalosc;
            this.sila = sila;
            this.pancerz = pancerz;
            this.obrona = 0;
            this.listaCiosow = new List<Cios>();
        }

        public Cios[] pobierzCiosy()
        {
            Cios[] zawartosc = new Cios[this.listaCiosow.Count];

            for (int i = 0; i < this.listaCiosow.Count; i++)
            {
                zawartosc[i] = this.listaCiosow[i];
            }

            return zawartosc;
        }

        public void dodajCios(Cios dodawany)
        {
            this.listaCiosow.Add(dodawany);
        }

        public uint wykonajAtak(uint ciosIndex)
        {
            return this.sila * this.listaCiosow[(int) ciosIndex].pobierzObrazenia();
        }

        public void przyjmijObrazenia(uint obrazenia)
        {
            // COMEBAK: będzie potrzebny balans, może plik konfiguacyjny?
            obrazenia -= this.pancerz;
            obrazenia = (uint) Math.Ceiling ((this.obrona * (double)obrazenia));

            if (obrazenia <= this.zycie)
                this.zycie -= obrazenia;
            else
                zycie = 0;
        }

        public void pozycjaObronna(double moc)
        {
            this.obrona = moc;
            if (moc == SilaObrony.normalna)
                this.wytrzymalosc -= 1;
            else
                this.wytrzymalosc -= 2;
        }

        public StatusPostaci pobierzStatus()
        {
            // TODO: trzeba wypełnić
            // status jako struct? Ułatwiłoby to przesyłanie
            // do bufora wyświetlania
            // Tomek

            var aktualnyStatus = new StatusPostaci();

            aktualnyStatus.zycie = this.zycie;
            aktualnyStatus.wytrzymalosc = this.wytrzymalosc;
            aktualnyStatus.sila = this.sila;
            aktualnyStatus.pancerz = this.pancerz;
            aktualnyStatus.obrona = this.obrona;

            return aktualnyStatus;
        }
    }
}
