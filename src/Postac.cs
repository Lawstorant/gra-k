namespace gra_k
{
    public class Postac
    {
        protected uint zycie;
        protected uint wytrzymalosc;
        protected uint sila;
        protected uint pancerz;
        protected Cios[] listaCiosow;
        protected bool obrona;



        public Postac(uint zycie, uint wytrzymalosc, uint sila, uint pancerz)
        {
            this.zycie = zycie;
            this.wytrzymalosc = wytrzymalosc;
            this.sila = sila;
            this.pancerz = pancerz;
            this.obrona = false;
            // this.listaCiosow = new Cios[];
            // TODO: pobierać ilość ciosów z dojo i na tej podstawie 
            // tworzyć wielkość tablicy?
            // Tomek
        }

        public Cios[] pobierzCiosy()
        {
            return this.listaCiosow;
        }

        public void dodajCios(Cios dodawany)
        {
            // tutaj trzeba zrobić dodawanie do tablicy
            // this.listaCiosów[i] = dodawany;
        }

        public uint wykonajAtak(uint ciosIndex)
        {
            return this.sila * this.listaCiosow[ciosIndex].pobierzObrazenia();
        }

        public void pozycjaObronna()
        {
            this.obrona = true;
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
