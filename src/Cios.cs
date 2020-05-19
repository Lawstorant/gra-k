using System.IO;

namespace gra_k
{
    /// <summary>
    /// Klasa odpowiedzialna za utworzenie zmiennych oraz pobrania i przypisania wartości
    /// </summary>
    public class Cios
    {
        private string nazwa;
        private uint obrazenia;
        private uint koszt;

        
        /// <summary>
        /// Przypisanie wartości do zmiennych 
        /// </summary>
        /// <param name="nazwa"></param> Nazwa ciosu
        /// <param name="obrazenia"></param> Ilość zadawanych obrażeń
        /// <param name="koszt"></param> Koszt zakupu ciosu
        public Cios(string nazwa, uint obrazenia, uint koszt)
        {
            this.nazwa = nazwa;
            this.obrazenia = obrazenia;
            this.koszt = koszt;
        }

        /// <summary>
        /// Pobiranie ze ścieżki oraz przypisanie paramertów 
        /// </summary>
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

        /// <summary>
        /// Pobranie wartości nazwa
        /// </summary>
        public string pobierzNazwe()
        {
            return this.nazwa;
        }
        /// <summary>
        /// Pobranie wartości obrażenia
        /// </summary>
        public uint pobierzObrazenia()
        {
            return this.obrazenia;
        }

        /// <summary>
        /// Pobranie wartości koszt
        /// </summary>
        public uint pobierzKoszt()
        {
            return this.koszt;
        }

    }
}
