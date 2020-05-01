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
