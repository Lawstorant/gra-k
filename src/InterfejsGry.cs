using System;

namespace gra_k
{
    public class InterfejsGry
    {
        private string[] opcjeDojo;
        private string[] opcjeWalki;
        private string[] opcjeGry;
        private string sciezkaInstrukcji;



        public InterfejsGry()
        {   
            // COMEBAK: Zrobić stringi w pliku i ich wczytywanie
            // stringi powinny być dla wszystkich okien
            this.opcjeDojo = new string[4] {"Idz na silownie", "Poznaj nowe ciosy", "Kup sobie pancerz", "Powrot"};
            this.opcjeGry = new string[4] {"Odwiedz Dojo", "Generuj przeciwnika", "Walczmy!", "Wyjscie z gry"};
            this.opcjeWalki = new string[3] {"Idz na silownie", "Poznaj nowe ciosy", "Kup sobie pancerz"};
            this.sciezkaInstrukcji = "textfiles/instrukcja.txt";

            // rzeczy windowsowe
            try
            {
                // zmieniam wielkosć okna do rozmiaru gry
                Console.SetWindowSize(120, 40);
                Console.SetBufferSize(121, 41);
                // próbuję zmienić kodowanie na en-US
                //System.Diagnostics.Process.Start("CMD.exe", "chcp 437");
            }
            catch(Exception)
            {
    
            }

            // ustawiam domyślne kolory
            Console.CursorVisible = false;            
            //Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }

        public void test()
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
            var status = tomek.pobierzStatus();
            tomek.przyjmijObrazenia(10);

            this.pasekStatusu(status, 2, 2, 2, 3);
            this.ekranGry(0, status, pobraneCiosy);
            Console.ReadKey();
            this.ekranDojo(1);
            this.oknoNaukiCiosow(pobraneCiosy, 2);
            Console.ReadKey();
            var xp = new Cwiczenie("cwiczenia/test.txt");
            var cwiczenia = new Cwiczenie[3] {xp, xp, xp};
            this.ekranDojo(0);
            this.oknoCwiczen(cwiczenia, 1);
            Console.ReadKey();
            Wyswietlanie.gotoXY(0,38);
        }

        public void pasekStatusu(
            StatusPostaci status,
            uint poziom,
            uint doswiadczenie,
            uint zdol,
            uint pieniadze)
        {
            Wyswietlanie.prostokat(0, 0, 120, 3);
            Wyswietlanie.wyczyscPole(1,1,118, 1);

            string tekst = $"Sila:{status.sila}, Pancerz:{status.pancerz}, ";
            tekst += $"Poziom:{poziom}, Doswiadczenie:{doswiadczenie}/1000, ";
            tekst += $"Pkt. Zdol:{zdol}, Pieniadze:{pieniadze}g";

            Wyswietlanie.pisz($"Zycie:{status.zycie}, ", ConsoleColor.Red, 2, 1);
            Wyswietlanie.pisz($"Wytrzymalosc:{status.wytrzymalosc}, ", ConsoleColor.Yellow);
            Wyswietlanie.pisz(tekst, ConsoleColor.White);
        }

        public void ekranGry(uint zaznaczonaOpcja)
        {
            Wyswietlanie.okienko("Menu glowne", 0, 3, 30, 30);

            for (int i = 0; i < this.opcjeGry.Length; ++i)
            {
                if(i == zaznaczonaOpcja)
                    Wyswietlanie.pisz(this.opcjeGry[i], ConsoleColor.Blue, 3, 7+2*i);
                else
                    Wyswietlanie.pisz(this.opcjeGry[i], ConsoleColor.White, 3, 7+2*i);
            }

            Wyswietlanie.okienko("Instrukcja", 70, 3, 50, 30);
            var czytnik = new System.IO.StreamReader(this.sciezkaInstrukcji);
            string linia;
            int offsetY = 0;
            while ((linia = czytnik.ReadLine()) != null)
            {
                Wyswietlanie.pisz(linia, ConsoleColor.White, 73, 7+offsetY);
                offsetY += 1;
            }
            czytnik.Close();

            Wyswietlanie.okienko("Nastepny przeciwnik", 30, 3, 40, 30);
        }

        public void ekranGry(uint zaznaczonaOpcja, StatusPostaci przeciwnik, Cios[] listaCiosow)
        {
            this.ekranGry(zaznaczonaOpcja);
            const int x = 33;

            Wyswietlanie.pisz($"Statystyki", ConsoleColor.White, x, 6);
            Wyswietlanie.pisz($"Życie: {przeciwnik.zycie}", ConsoleColor.Red, x, 8);
            Wyswietlanie.pisz($"Wytrzymalosc: {przeciwnik.wytrzymalosc}", ConsoleColor.Yellow, x, 9);
            Wyswietlanie.pisz($"Sila: {przeciwnik.sila}", ConsoleColor.White, x, 10);
            Wyswietlanie.pisz($"Pancerz: {przeciwnik.pancerz}", ConsoleColor.White, x, 11);
            Wyswietlanie.pisz($"Znane ciosy", ConsoleColor.White, x, 16);

            Wyswietlanie.rozdzielacz(40, false, 30, 7);

            Wyswietlanie.rozdzielacz(40, false, 30, 15);
            Wyswietlanie.rozdzielacz(40, false, 30, 17);

            for (int i = 0; i < listaCiosow.Length; i++)
            {
                Wyswietlanie.pisz($"{listaCiosow[i].pobierzNazwe()}", ConsoleColor.White, x, 18+i);
            }
        }

        public void ekranDojo(uint zaznaczonaOpcja)
        {
            Wyswietlanie.okienko("Dojo", 0, 3, 40, 30);

            for (int i = 0; i < this.opcjeDojo.Length; ++i)
            {
                if(i == zaznaczonaOpcja)
                    Wyswietlanie.pisz(this.opcjeDojo[i], ConsoleColor.Blue, 3, 7+2*i);
                else
                    Wyswietlanie.pisz(this.opcjeDojo[i], ConsoleColor.White, 3, 7+2*i);
            }
        }

        public void oknoNaukiCiosow(Cios[] listaCiosow, int zaznaczonaOpcja)
        {
            Wyswietlanie.okienko("Nauka ciosow", 40, 3, 80, 30);
            Wyswietlanie.pisz("Nazwa", ConsoleColor.White, 43, 6);
            Wyswietlanie.pisz("DMG", ConsoleColor.White, 109, 6);
            Wyswietlanie.pisz("Koszt", ConsoleColor.White, 114, 6);

            // Wyswietlanie.rozdzielacz(28, true, 80, 5);
            Wyswietlanie.rozdzielacz(28, true, 107, 5);
            Wyswietlanie.rozdzielacz(28, true, 113, 5);
            Wyswietlanie.rozdzielacz(80, false, 40, 7);

            // Wyswietlanie.krzyz(80, 7);
            Wyswietlanie.krzyz(107, 7);
            Wyswietlanie.krzyz(113, 7);

            int y = 8;
            ConsoleColor kolor = ConsoleColor.White;
            for (int i = 0; i < listaCiosow.Length; ++i)
            {
                if(i == zaznaczonaOpcja)
                    kolor = ConsoleColor.Blue;

                Wyswietlanie.pisz(listaCiosow[i].pobierzNazwe(), kolor, 43, y);
                Wyswietlanie.pisz(listaCiosow[i].pobierzObrazenia().ToString(), kolor, 110, y);
                Wyswietlanie.pisz(listaCiosow[i].pobierzKoszt().ToString(), kolor, 116, y);

                if(i == zaznaczonaOpcja)
                    kolor = ConsoleColor.White;

                y += 2;
            }
        }

        public void oknoCwiczen(Cwiczenie[] listaCwiczen, int zaznaczonaOpcja)
        {
            Wyswietlanie.okienko("Cwiczenia na silowni", 40, 3, 80, 30);
            Wyswietlanie.pisz("Cwiczenie", ConsoleColor.White, 43, 6);
            Wyswietlanie.pisz("koszt", ConsoleColor.White, 93, 6);
            Wyswietlanie.pisz("zycie", ConsoleColor.White, 99, 6);
            Wyswietlanie.pisz("stamina", ConsoleColor.White, 105, 6);
            Wyswietlanie.pisz("sila", ConsoleColor.White, 114, 6);

            Wyswietlanie.rozdzielacz(28, true, 92, 5);
            Wyswietlanie.rozdzielacz(28, true, 98, 5);
            Wyswietlanie.rozdzielacz(28, true, 104, 5);
            Wyswietlanie.rozdzielacz(28, true, 112, 5);
            Wyswietlanie.rozdzielacz(80, false, 40, 7);

            Wyswietlanie.krzyz(92, 7);
            Wyswietlanie.krzyz(98, 7);
            Wyswietlanie.krzyz(104, 7);
            Wyswietlanie.krzyz(112, 7);

            int y = 8;
            ConsoleColor kolor = ConsoleColor.White;
            for (int i = 0; i < listaCwiczen.Length; ++i)
            {
                if(i == zaznaczonaOpcja)
                    kolor = ConsoleColor.Blue;

                Wyswietlanie.pisz(listaCwiczen[i].pobierzNazwe(), kolor, 43, y);
                Wyswietlanie.pisz($"{listaCwiczen[i].pobierzKoszt()}g", kolor, 94, y);
                uint[] staty = listaCwiczen[i].pobierzStaty();
                Wyswietlanie.pisz($"{staty[0]}", kolor, 101, y);
                Wyswietlanie.pisz($"{staty[1]}", kolor, 108, y);
                Wyswietlanie.pisz($"{staty[2]}", kolor, 115, y);

                if(i == zaznaczonaOpcja)
                    kolor = ConsoleColor.White;

                y += 2;
            }
        }

        public void oknoPrzedmiotow(Przedmiot[] listaPrzedmiotow, int zaznaczonaOpcja)
        {
            Wyswietlanie.okienko("Pancerze do kupienia", 40, 3, 80, 30);
            Wyswietlanie.pisz("Nazwa", ConsoleColor.White, 43, 6);
            Wyswietlanie.pisz("Pancerz", ConsoleColor.White, 105, 6);
            Wyswietlanie.pisz("Cena", ConsoleColor.White, 114, 6);

            Wyswietlanie.rozdzielacz(28, true, 104, 5);
            Wyswietlanie.rozdzielacz(28, true, 112, 5);
            Wyswietlanie.rozdzielacz(80, false, 40, 7);

            Wyswietlanie.krzyz(104, 7);
            Wyswietlanie.krzyz(112, 7);

            int y = 8;
            ConsoleColor kolor = ConsoleColor.White;
            for (int i = 0; i < listaPrzedmiotow.Length; ++i)
            {
                if(i == zaznaczonaOpcja)
                    kolor = ConsoleColor.Blue;

                Wyswietlanie.pisz(listaPrzedmiotow[i].pobierzNazwe(), kolor, 43, y);
                Wyswietlanie.pisz(listaPrzedmiotow[i].pobierzPancerz().ToString(), kolor, 108, y);
                Wyswietlanie.pisz($"{listaPrzedmiotow[i].pobierzCene()}g", kolor, 114, y);

                if(i == zaznaczonaOpcja)
                    kolor = ConsoleColor.White;

                y += 2;
            }
        }

        public void ekranWalki()
        {
            
        }
    }
}
