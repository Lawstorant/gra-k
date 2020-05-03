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

            var ekran = new Wyswietlanie(40, 40);

            ekran.pisz("TEST TEST TEST", false, 10, 1);
            ekran.okienko("Tytuł okienka", 2, 2, 30, 20);
            ekran.gotoXY(3, 6);
            ekran.pisz("Tutaj coś napisałem", true);
            //ekran.gotoXY(3, 7);
            ekran.pisz("Tutaj też coś napisałem", false, 3, 7);
            ekran.rozdzielacz(18, true, 27, 4);
            ekran.pisz("2", true, 29, 6);
            ekran.pisz("4", false, 29, 7);
            Console.ReadLine();
            Console.CursorVisible = true;
        }
    }
}
