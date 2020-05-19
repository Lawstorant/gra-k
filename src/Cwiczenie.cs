using System.IO;

namespace gra_k
{
    /// <summary>
    /// Klasa odpowiedzialna za utowrzenie zmiennych oraz pobierania i przypisywania wartości 
    /// </summary>
    public class Cwiczenie
    {
        /// <summary>
        /// Utworzenie zmiennych typu string i uint. 
        /// </summary>
        string nazwa;
        uint koszt;
        uint zycie;
        uint wytrzymalosc;
        uint sila;


        /// <summary>
        /// Metoda odpowiadająca za przypisanie wartości do zmiennych 
        /// </summary>
        public Cwiczenie(string nazwa, uint koszt, uint zycie, uint wytrzymalosc, uint sila)
        {
            this.nazwa = nazwa;
            this.koszt = koszt;
            this.zycie = zycie;
            this.wytrzymalosc = wytrzymalosc;
            this.sila = sila;
        }
        /// <summary>
        /// Metoda odpowiedzialna za pobranie ze ścieżki 
        /// </summary>
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
        /// <summary>
        /// Pobranie oraz zwrócenie wartości nazwa 
        /// </summary>
        public string pobierzNazwe() //pobieranie nazwy
        {
            return this.nazwa;
        }
        /// <summary>
        /// Pobranie oraz zwrócenie wartości koszty
        /// </summary>
        public uint pobierzKoszt() // Pobieranie kosztu
        {
            return this.koszt;
        }
        /// <summary>
        /// Pobranie oraz zwrócenie tablicy z zmiennymi życie, wytzymałośc oraz siła ćwiczenia 
        /// </summary>
        public uint[] pobierzStaty() // Pobieranie statystyk
        {
            // DLACZEGO? PO CO?
            uint[] staty = {this.zycie, this.wytrzymalosc, this.sila};
            return staty;
        }
    }
}
