using System.IO;

namespace gra_k
{
    public class Cios
    {
        private string nazwa;
        private uint obrazenia;
        private uint koszt;

        

        public Cios(string nazwa, uint obrazenia, uint koszt)
        {
            this.nazwa = nazwa;
            this.obrazenia = obrazenia;
            this.koszt = koszt;
        }

        public Cios(string sciezka)
        {
            StreamReader czytnik = new StreamReader(sciezka);
            string[] linie = new string[3];

            for (int i = 0; i < 3; ++i)
            {
                linie[i] = czytnik.ReadLine();
                linie[i] = linie[i].Substring(linie[i].IndexOf('=')+1);
            }

            czytnik.Close();

            // przypisanie wczytanych parametrów do pól klasy
            this.nazwa = linie[0];
            this.obrazenia = uint.Parse(linie[1]);
            this.koszt = uint.Parse(linie[2]);
        }

        public string pobierzNazwe()
        {
            return this.nazwa;
        }

        public uint pobierzObrazenia()
        {
            return this.obrazenia;
        }

        public uint pobierzKoszt()
        {
            return this.koszt;
        }

    }
}
