using System.Collections.Generic;
using System;

namespace gra_k
{
    public struct SilaObrony
    {
        public const double brak = 1.0;
        public const double normalna = 0.7;
        public const double mocna = 0.4;
        public const int kosztNormalna = 1;
        public const int kosztMocna = 2;
    }



    public struct StatusPostaci
    {
        public uint zycie;
        public uint wytrzymalosc;
        public uint sila;
        public uint pancerz;
        public double obrona;
        public uint poziom;
        public uint doswiadczenie;
        public uint punktyZdolnosci;
        public uint pieniadze;
    }



    public class Postac
    {
        protected uint zycie;
        protected uint wytrzymalosc;
        protected uint sila;
        protected uint pancerz;
        protected List<Cios> listaCiosow; // Lista ciosów jako generyczna lista dynamiczna, ułatwia dodawanie ciosów
        protected double obrona;



        public Postac(uint zycie, uint wytrzymalosc, uint sila, uint pancerz)
        {
            this.zycie = zycie;
            this.wytrzymalosc = wytrzymalosc;
            this.sila = sila;
            this.pancerz = pancerz;
            this.obrona = SilaObrony.brak;
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



        public uint wykonajAtak(int ciosIndex)
        {   
            this.wytrzymalosc -= this.listaCiosow[ciosIndex].pobierzKoszt();
            return this.sila + this.listaCiosow[ciosIndex].pobierzObrazenia();
        }



        public uint przyjmijObrazenia(uint obrazenia)
        {
            // COMEBAK: będzie potrzebny balans, może plik konfiguacyjny?
            obrazenia -= this.pancerz;
            obrazenia = (uint) Math.Floor ((this.obrona * (double)obrazenia));
            if (obrazenia == 0)
                obrazenia = 1;
            this.obrona = 1.0;

            if (obrazenia <= this.zycie)
                this.zycie -= obrazenia;
            else
                zycie = 0;

            return obrazenia;
        }



        public void ustawWytrzymalosc(uint punkty)
        {
            this.wytrzymalosc = punkty;
        }



        public void ustawZycie(uint zycie)
        {
            this.zycie = zycie;
        }



        public void pozycjaObronna(double moc)
        {
            this.obrona = moc;
            if (moc == SilaObrony.normalna)
                this.wytrzymalosc -= SilaObrony.kosztNormalna;
            else
                this.wytrzymalosc -= SilaObrony.kosztMocna;
        }



        public StatusPostaci pobierzStatus()
        {
            var aktualnyStatus = new StatusPostaci();

            aktualnyStatus.zycie = this.zycie;
            aktualnyStatus.wytrzymalosc = this.wytrzymalosc;
            aktualnyStatus.sila = this.sila;
            aktualnyStatus.pancerz = this.pancerz;
            aktualnyStatus.obrona = this.obrona;

            return aktualnyStatus;
        }



        public static Postac generujPostac(int poziom, Cios[] dostepneCiosy)
        {   
            var rnd = new Random();
            uint zycie = (uint) rnd.Next(poziom+2, 2 * poziom +5);
            uint wytrzymalosc = (uint) rnd.Next(poziom+1, 2 * poziom);
            uint sila = (uint) rnd.Next(1, poziom);
            uint pancerz = poziom > 5 ? (uint) rnd.Next(1, poziom / 5 +1) : 0;

            var postac = new Postac(zycie, wytrzymalosc, sila, pancerz);

            // losujemy ciosy dla postaci
            // ilosc bazowana na połowie poziomu
            bool[] wykorzystane = new bool[dostepneCiosy.Length];
            int i = 0, g = 0;
            while ((i < poziom / 3 +1) && (g < dostepneCiosy.Length))
            {
                var los = rnd.Next(0, dostepneCiosy.Length);

                // sprawdzam czy cios jest już wykorzystany
                // jeżeli nie, to dodaję go do postaci
                if(!wykorzystane[los])
                {
                    wykorzystane[los] = true;
                    if(dostepneCiosy[los].pobierzKoszt() <= postac.pobierzStatus().wytrzymalosc)
                    {
                        postac.dodajCios(dostepneCiosy[los]);
                        ++i;
                    }
                    ++g;
                }
            }

            return postac;
        }
    }
}
