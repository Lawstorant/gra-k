namespace gra_k
{
    public class Cwiczenie
    {
        string nazwa;
        uint koszt;
        uint zycie;
        uint wytrzymalosc;
        uint sila;

        

        public string pobierzNazwe() //pobieranie nazwy
        {
            return this.nazwa;
        }

        public uint pobierzKoszt() // Pobieranie kosztu
        {
            return this.koszt;
        }

        public uint pobierzStaty() // Pobieranie statystyk
        {
            return 0;
        }
    }
}
