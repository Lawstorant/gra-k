using System.IO;

namespace gra_k
{
    public class Dojo
    {
        private Cios[] listaCiosow;
        private Przedmiot[] listaPrzedmiotow;
        private Cwiczenie[] listaCwiczen;

        public Dojo()
        {
            // policzyć pliki w folderach i zapisać ścieżki do tablicy
            // na podstawie ilości zainicjować tablice o takim rozmiarze
            // w pętli tworzyć poszczegołne ciosy / przedmioty / ćwiczenia na podstawie ścieżek
            // (przekazywać ścieżki do konstruktorów, obiekty przypisywać do tablicy)
            var folder = "ciosy/";
            var iloscPlikow = Directory.GetFiles(folder).Length;
            this.listaCiosow = new Cios[iloscPlikow];
            
            for (int i = 0; i < iloscPlikow; i++)
            {
                listaCiosow[i] = new Cios(Directory.GetFiles(folder)[i]);
            }

            folder = "przedmioty/";
            iloscPlikow = Directory.GetFiles(folder).Length;
            this.listaPrzedmiotow = new Przedmiot[iloscPlikow];
            
            for (int i = 0; i < iloscPlikow; i++)
            {
                listaPrzedmiotow[i] = new Przedmiot(Directory.GetFiles(folder)[i]);
            }

            folder = "cwiczenia/";
            iloscPlikow = Directory.GetFiles(folder).Length;
            this.listaCwiczen = new Cwiczenie[iloscPlikow];
            
            for (int i = 0; i < iloscPlikow; i++)
            {
                listaCwiczen[i] = new Cwiczenie(Directory.GetFiles(folder)[i]);
            }
        }

        public Cios[] pobierzCiosy()
        {
            return this.listaCiosow;
        }

        public Przedmiot[] PobierzPrzedmioty()
        {
            return this.listaPrzedmiotow;
        }

        public Cwiczenie[] pobierzCwiczenia()
        {
            return this.listaCwiczen;
        }
    }
}
