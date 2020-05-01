using System.Collections.Generic;

namespace gra_k
{
    public struct SilaObrony
    {
        public const double brak = 0;
        public const double normalna = 0.4;
        public const double mocna = 0.8;
    }

    public class Postac
    {
        protected uint zycie;
        protected uint wytrzymalosc;
        protected uint sila;
        protected uint pancerz;
        // Lista ciosów jako generyczna lista dynamiczna, ułatwia dodawanie ciosóœ
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
            return this.sila * this.listaCiosow[(int)ciosIndex].pobierzObrazenia();
        }

        public void pozycjaObronna(double moc)
        {
            this.obrona = moc;
            this.wytrzymalosc -= (uint)(moc*5)/2;
        }

        public void pobierzStatus()
        {
            // TODO: trzeba wypełnić
            // status jako struct? Ułatwiłoby to przesyłanie
            // do bufora wyświetlania
            // Tomek
        }
    }
}
