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

            interfejs.pasekStatusu(status, 2, 2, 2, 3);
            interfejs.ekranGry(3, status, pobraneCiosy);
            Console.ReadKey();
            interfejs.ekranDojo(0);
            interfejs.oknoNaukiCiosow(pobraneCiosy, 2);

            Wyswietlanie.gotoXY(0,38);
            
            Console.CursorVisible = true; 
        }
    }
}
