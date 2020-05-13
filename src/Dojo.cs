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
            // tworzymy i dodajemy ciosy
            var folder = "ciosy/";
            var iloscPlikow = Directory.GetFiles(folder).Length;
            this.listaCiosow = new Cios[iloscPlikow];
            
            for (int i = 0; i < iloscPlikow; i++)
            {
                listaCiosow[i] = new Cios(Directory.GetFiles(folder)[i]);
            }

            // tworzymy i dodajemy przedmioty
            folder = "przedmioty/";
            iloscPlikow = Directory.GetFiles(folder).Length;
            this.listaPrzedmiotow = new Przedmiot[iloscPlikow];
            
            for (int i = 0; i < iloscPlikow; i++)
            {
                listaPrzedmiotow[i] = new Przedmiot(Directory.GetFiles(folder)[i]);
            }

            // tworzymy i dodajemy ćwiczenia
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
