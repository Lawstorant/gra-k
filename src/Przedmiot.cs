using System.IO;

namespace gra_k
{
    /// <summary>
    /// Klasa odpowiedzialna za pobieranie przedmiotu oraz zwracanie ich wartości
    /// </summary>
    public class Przedmiot
    {
        /// <summary>
        /// Zmienne typu string oraz uint odpowiedzialne za nazwę oraz statystyki pobranych przedmiotów
        /// </summary>
        string nazwa;
        uint pancerz;
        uint cena;


        /// <summary>
        /// Przypisanie do zmiennych nazwy oraz statystyk przedmiotu
        /// </summary>
        public Przedmiot(string nazwa, uint pancerz, uint cena)
        {
            this.nazwa = nazwa;
            this.pancerz = pancerz;
            this.cena = cena;
        }
        /// <summary>
        /// Metdoda pobiera przedmiot 
        /// </summary>
        public Przedmiot(string sciezka)
        {
            StreamReader czytnik = new StreamReader(sciezka);
            string[] linie = new string[3];

            for (int i = 0; i < 3; ++i)
            {
                linie[i] = czytnik.ReadLine();
                linie[i] = linie[i].Substring(linie[i].IndexOf('=') + 1);
            }

            czytnik.Close();

            // przypisanie wczytanych parametrów do pól klasy
            this.nazwa = linie[0];
            this.pancerz = uint.Parse(linie[1]);
            this.cena = uint.Parse(linie[2]);
        }

        /// <summary>
        /// Pobiera nazwę przedmiotu, a następnie  zwraca jego wartość
        /// </summary>
        public string pobierzNazwe() // pobieranie nazwy przedmiotu
        {
            return this.nazwa;
        }
        /// <summary>
        /// Pobiera wartość pancerza, a nastepnie zwraca jego wartość
        /// </summary>
        public uint pobierzPancerz() // pobieranie pancerza
        {
            return this.pancerz;
        }
        /// <summary>
        /// Pobiera wartość cena, a następnie ją zwraca jego wartość
        /// </summary>
        public uint pobierzCene() // pobieranie ceny 
        {
            return this.cena;
        }
    }
}
