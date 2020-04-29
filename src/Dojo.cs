namespace gra_k
{
    public class Dojo
    {
        private Cios[] listaCiosow;
        private Przedmiot[] listaPrzedmiotow;
        private Cwiczenie[] listaCwiczen;



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
