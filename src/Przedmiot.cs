namespace gra_k
{
    public class Przedmiot
    {
        string nazwa;
        uint pancerz;
        uint cena;



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