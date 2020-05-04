using System;

namespace gra_k
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Bohater tomek = new Bohater(100, 100, 100, 1);
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
            
            InterfejsGry interfejs = new InterfejsGry();
            Wyswietlanie.clrscr();
            interfejs.pasekStatusu(tomek.pobierzStatus(), 2, 200, 3, 230);

            interfejs.ekranDojo(0);
            
            Przedmiot xp = new Przedmiot("przedmioty/test.txt");
            Przedmiot[] przedmioty = new Przedmiot[5] {xp, xp, xp, xp, xp};
            interfejs.oknoPrzedmiotow(przedmioty, 3);
            Wyswietlanie.gotoXY(0, 39);

            /*
            Console.CursorVisible = false;
            Wyswietlanie.pisz("TEST TEST TEST", false, 10, 1);
            Wyswietlanie.okienko("Tytuł okienka", 2, 2, 30, 20);
            Wyswietlanie.pisz("Tutaj coś napisałem", true);
            //Wyswietlanie.gotoXY(3, 7);
            Wyswietlanie.pisz("Tutaj też coś napisałem", false, 3, 7);
            Wyswietlanie.rozdzielacz(18, true, 27, 4);
            Wyswietlanie.pisz("2", true, 29, 6);
            Wyswietlanie.pisz("4", false, 29, 7);
            */
            Console.CursorVisible = true; 
        }
    }
}
