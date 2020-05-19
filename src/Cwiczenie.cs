using System.IO;

namespace gra_k
{
    public class Cwiczenie
    {
        string nazwa;
        uint koszt;
        uint zycie;
        uint wytrzymalosc;
        uint sila;



        public Cwiczenie(string nazwa, uint koszt, uint zycie, uint wytrzymalosc, uint sila)
        {
            this.nazwa = nazwa;
            this.koszt = koszt;
            this.zycie = zycie;
            this.wytrzymalosc = wytrzymalosc;
            this.sila = sila;
        }

        public Cwiczenie(string sciezka)
        {
            StreamReader czytnik = new StreamReader(sciezka);
            string[] linie = new string[5];

            for (int i = 0; i < 5; ++i)
            {
                linie[i] = czytnik.ReadLine();
                linie[i] = linie[i].Substring(linie[i].IndexOf('=') + 1);
            }

            czytnik.Close();

            // przypisanie wczytanych parametrów do pól klasy
            this.nazwa = linie[0];
            this.koszt = uint.Parse(linie[1]);
            this.zycie = uint.Parse(linie[2]);
            this.wytrzymalosc = uint.Parse(linie[3]);
            this.sila = uint.Parse(linie[4]);
        }

        public string pobierzNazwe() //pobieranie nazwy
        {
            return this.nazwa;
        }

        public uint pobierzKoszt() // Pobieranie kosztu
        {
            return this.koszt;
        }

        public uint[] pobierzStaty() // Pobieranie statystyk
        {
            // DLACZEGO? PO CO?
            uint[] staty = {this.zycie, this.wytrzymalosc, this.sila};
            return staty;
        }
    }
}
