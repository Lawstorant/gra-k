using System;

namespace gra_k
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Bohater tomek = new Bohater(10, 10, 10, 1);
            tomek.dodajPieniadze(200);
            tomek.dodajDoswiadczenie(3300);
            tomek.wydajPieniadze(20);

            Cios xd = new Cios("ciosy/prosty.txt");

            tomek.dodajCios(xd);
            tomek.dodajCios(xd);

            tomek.pozycjaObronna(SilaObrony.mocna);

            var pobraneCiosy = tomek.pobierzCiosy();

            foreach (var item in pobraneCiosy)
            {
                System.Console.WriteLine(item.pobierzNazwe());
            }

            var status = tomek.pobierzStatus();

            System.Console.WriteLine(status.wytrzymalosc);

            tomek.przyjmijObrazenia(10);
            */

            var buforEkranu = new BuforEkranu(10,10);
            buforEkranu.test();
        }
    }
}
