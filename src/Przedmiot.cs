using System.IO;

namespace gra_k
{
    public class Przedmiot
    {
        string nazwa;
        uint pancerz;
        uint cena;



        public Przedmiot(string nazwa, uint pancerz, uint cena)
        {
            this.nazwa = nazwa;
            this.pancerz = pancerz;
            this.cena = cena;
        }

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


        public string pobierzNazwe() // pobieranie nazwy przedmiotu
        {
            return this.nazwa;
        }

        public uint pobierzPancerz() // pobieranie pancerza
        {
            return this.pancerz;
        }

        public uint pobierzCene() // pobieranie ceny 
        {
            return this.cena;
        }
    }
}
