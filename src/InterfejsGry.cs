using System;
using System.Collections.Generic;

namespace gra_k
{
    public class InterfejsGry
    {
        private string[] opcjeDojo;
        private string[] opcjeWalki;
        private string[] opcjeGry;
        private string[] opcjeObrony;
        private string sciezkaInstrukcji;



        public InterfejsGry()
        {   
            // COMEBAK: Zrobić stringi w pliku i ich wczytywanie
            // stringi powinny być dla wszystkich okien
            this.opcjeDojo = new string[] {"Idz na silownie", "Poznaj nowe ciosy", "Kup sobie pancerz", "Powrot"};
            this.opcjeGry = new string[] {"Odwiedz Dojo", "Generuj przeciwnika", "Walczmy!", "Wyjscie z gry"};
            this.opcjeWalki = new string[] {"Atak", "Obrona", "Zakoncz ture", "Ucieczka"};
            this.opcjeObrony = new string[] {"Normalna", "Mocna", "Powrot"};
            this.sciezkaInstrukcji = "textfiles/instrukcja.txt";

            // rzeczy windowsowe
            try
            {
                // zmieniam wielkosć okna do rozmiaru gry
                Console.SetWindowSize(120, 40);
                Console.SetBufferSize(120, 40);
                // próbuję zmienić kodowanie na en-US
                //System.Diagnostics.Process.Start("CMD.exe", "chcp 437");
            }
            catch(Exception)
            {
                // whatever
            }

            // ustawiam domyślne kolory
            Console.CursorVisible = false;            
            //Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }


        // test interfejsu
        public void test()
        {
            Bohater tomek = new Bohater(100, 100, 100, 1);
            tomek.dodajPieniadze(200);
            tomek.dodajDoswiadczenie(3300);
            tomek.wydajPieniadze(20);

            Cios xd = new Cios("Testowy", 12, 2);

            for (int i = 0; i < 8; i++)
            {
                tomek.dodajCios(xd);
            }

            tomek.pozycjaObronna(SilaObrony.mocna);

            var pobraneCiosy = tomek.pobierzCiosy();
            var status = tomek.pobierzStatus();
            System.Console.WriteLine(status.punktyZdolnosci);
            tomek.przyjmijObrazenia(10);

            this.pasekStatusu(status);
            this.ekranGry(0, status, pobraneCiosy);
            Console.ReadKey();
            this.ekranDojo(1);
            Wyswietlanie.gotoXY(0,38);
            Console.ReadKey();
            this.oknoNaukiCiosow(pobraneCiosy, 2);
            Console.ReadKey();
            var xp = new Cwiczenie("Testowe", 4, 3, 4, 5);
            var cwiczenia = new Cwiczenie[] {xp, xp, xp};
            this.ekranDojo(0);
            this.oknoCwiczen(cwiczenia, 1);
            Console.ReadKey();
            this.ekranDojo(2);
            var xc = new Przedmiot("Testowy", 12, 154);
            var przedmioty = new Przedmiot[] {xc, xc, xc, xc};
            this.oknoPrzedmiotow(przedmioty, 1);
            Console.ReadKey();

            Wyswietlanie.clrscr();
            this.pasekStatusu(status);
            this.ekranWalki(0);
            var lista = new List<string>();
            lista.Add("Zaczynamy! Hej, Hej!");
            lista.Add(" ");
            for (int i = 0; i < 16; i++)
            {
                lista.Add($"{i} TEST TEST TEST");
            }
            this.oknoPrzebieguWalki(lista);
            this.oknoPrzeciwnika(status, pobraneCiosy);
            this.okienkoWyboruCiosu(pobraneCiosy, 1);
            Console.ReadKey();
            this.ekranWalki(1);
            this.oknoPrzebieguWalki(lista);
            this.okienkoWyboruObrony(1);
            Wyswietlanie.gotoXY(0,38);
            Console.ReadKey();
        }


        // wyświetlanie informacji o grupie pod ekranem gry
        public void info()
        {
            Wyswietlanie.prostokat(0, 33, 19, 3);
            Wyswietlanie.pisz("Grupa 12, INIS2", ConsoleColor.White, 2, 34);
        }


        // górny pasek statusu wyświetlający informacje o bohaterze
        // przyjmuje StatusPostaci
        public void pasekStatusu(StatusPostaci status)
        {
            // TODO: dodatkowe atrybuty przekazywać przez jakiś struct
            this.info();

            Wyswietlanie.prostokat(0, 0, 120, 3);
            Wyswietlanie.wyczyscPole(1,1,118, 1);

            string tekst = $"Sila:{status.sila}, Pancerz:{status.pancerz}, ";
            tekst += $"Poziom:{status.poziom}, Doswiadczenie:{status.doswiadczenie}/1000, ";
            tekst += $"Pkt. Zdol:{status.punktyZdolnosci}, Pieniadze:{status.pieniadze}g";

            Wyswietlanie.pisz($"Zycie:{status.zycie}, ", ConsoleColor.Red, 2, 1);
            Wyswietlanie.pisz($"Wytrzymalosc:{status.wytrzymalosc}, ", ConsoleColor.Yellow);
            Wyswietlanie.pisz(tekst, ConsoleColor.White);
        }


        // główne menu gry a także jej ekran tytułowy
        // wersja kiedy nie ma żadnego przeciwnika
        public void ekranGry(int zaznaczonaOpcja)
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


        // ekran główny wyświetlający informacje o kolejnym przeciwniku
        // przyjmuje status przeciwnika i jego listę ciosów
        public void ekranGry(int zaznaczonaOpcja, StatusPostaci przeciwnik, Cios[] listaCiosowPrzeciwnika)
        {
            this.ekranGry(zaznaczonaOpcja);
            const int x = 33;

            Wyswietlanie.pisz($"Statystyki", ConsoleColor.White, x, 6);
            Wyswietlanie.pisz($"Życie: {przeciwnik.zycie}", ConsoleColor.Red, x, 8);
            Wyswietlanie.pisz($"Wytrzymalosc: {przeciwnik.wytrzymalosc}", ConsoleColor.Yellow, x, 9);
            Wyswietlanie.pisz($"Sila: {przeciwnik.sila}", ConsoleColor.White, x, 10);
            Wyswietlanie.pisz($"Pancerz: {przeciwnik.pancerz}", ConsoleColor.White, x, 11);
            Wyswietlanie.pisz($"Znane ciosy", ConsoleColor.White, x, 16);

            Wyswietlanie.rozdzielacz(40, false, x-3, 7);

            Wyswietlanie.rozdzielacz(40, false, x-3, 15);
            Wyswietlanie.rozdzielacz(40, false, x-3, 17);

            for (int i = 0; i < listaCiosowPrzeciwnika.Length; i++)
            {
                Wyswietlanie.pisz($"{listaCiosowPrzeciwnika[i].pobierzNazwe()}", ConsoleColor.White, x, 19+i);
            }
        }


        // ekran dojo wyświetla dojo we współpracy z oknami ciosów, przedmiotów i ćwiczeń
        // przyjmuje int zaznaczonej opcji
        // (możemy wysłać -1 jeżeli nie chcemy zaznaczać niczego)
        public void ekranDojo(int zaznaczonaOpcja)
        {
            Wyswietlanie.okienko("Dojo", 0, 3, 40, 30);

            for (int i = 0; i < this.opcjeDojo.Length; ++i)
            {
                if(i == zaznaczonaOpcja)
                    Wyswietlanie.pisz(this.opcjeDojo[i], ConsoleColor.Blue, 3, 7+2*i);
                else
                    Wyswietlanie.pisz(this.opcjeDojo[i], ConsoleColor.White, 3, 7+2*i);
            }
            Wyswietlanie.okienko("Podmenu", 40, 3, 80, 30);
        }


        // pierwszy z ekranów pomocniczych dojo. Tutaj uczymy się nowych ciosów
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
            var kolor = ConsoleColor.White;
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


        // drugie okno pomocnicze dojo. Tutaj możemy wykonywać ćwiczenia,
        // które podnoszą statystyki bohatera
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
            var kolor = ConsoleColor.White;
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


        // ostatnie okno pomocnicze dojo. W tym możemy zakupować dodatkowe pancerze
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
            var kolor = ConsoleColor.White;
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


        // menu i ekran walki
        public void ekranWalki(int zaznaczonaOpcja)
        {   
            Wyswietlanie.okienko("Wybierz akcje", 0, 3, 30, 30);

            for (int i = 0; i < this.opcjeWalki.Length; ++i)
            {
                if(i == zaznaczonaOpcja)
                    Wyswietlanie.pisz(this.opcjeWalki[i], ConsoleColor.Blue, 3, 7+2*i);
                else
                    Wyswietlanie.pisz(this.opcjeWalki[i], ConsoleColor.White, 3, 7+2*i);
            }
        }


        // okno pomocnicze przeciwnika. Wyświetla jego status i znane ciosy
        public void oknoPrzeciwnika(StatusPostaci przeciwnik, Cios[] ciosyPrzeciwnika)
        {
            Wyswietlanie.okienko("Twoj przeciwnik", 80, 3, 40, 30);

            const int x = 83;
            Wyswietlanie.pisz($"Statystyki", ConsoleColor.White, x, 6);
            Wyswietlanie.pisz($"Życie: {przeciwnik.zycie}", ConsoleColor.Red, x, 8);
            Wyswietlanie.pisz($"Wytrzymalosc: {przeciwnik.wytrzymalosc}", ConsoleColor.Yellow, x, 9);
            Wyswietlanie.pisz($"Sila: {przeciwnik.sila}", ConsoleColor.White, x, 10);
            Wyswietlanie.pisz($"Pancerz: {przeciwnik.pancerz}", ConsoleColor.White, x, 11);
            Wyswietlanie.pisz($"Znane ciosy", ConsoleColor.White, x, 16);

            Wyswietlanie.rozdzielacz(40, false, x-3, 7);

            Wyswietlanie.rozdzielacz(40, false, x-3, 15);
            Wyswietlanie.rozdzielacz(40, false, x-3, 17);
            

            for (int i = 0; i < ciosyPrzeciwnika.Length; i++)
            {
                Wyswietlanie.pisz($"{ciosyPrzeciwnika[i].pobierzNazwe()}", ConsoleColor.White, x, 19+i);
            }
        }


        // Wyświetla przebieg walki (ciosy, ataki, punkty obrażeń)
        public void oknoPrzebieguWalki(List<string> przebieg)
        {
            Wyswietlanie.okienko("Przebieg Walki", 30, 3, 50, 30);

            const int x = 33;
            int y = 7;
            int i = 0;

            if(przebieg.Count > 24)
                i = przebieg.Count - 24;
            
            for (; i < przebieg.Count; i++)
            {
                Wyswietlanie.pisz(przebieg[i], ConsoleColor.White, x, y++);
            }
        }


        // pop-up do wyboru ciosu, przyjmuje listę ciosów bohatera
        public void okienkoWyboruCiosu(Cios[] listaCiosow, int zaznaczonaOpcja)
        {   
            const int x = 16;
            const int y = 6;
            const int w = 24;
            Wyswietlanie.prostokat(x, y, w, listaCiosow.Length*2 + 3);
            int temp, temp2 = x+w;
            var kolor = ConsoleColor.White;

            for (int i = 0; i <= listaCiosow.Length; i++)
            {   
                temp = y + 1 + i*2;
                if(i == zaznaczonaOpcja)
                    kolor = ConsoleColor.Blue;

                if(i < listaCiosow.Length)
                {
                    Wyswietlanie.pisz(listaCiosow[i].pobierzNazwe(), kolor, x+1, temp);
                    Wyswietlanie.pisz(listaCiosow[i].pobierzKoszt().ToString(), ConsoleColor.Yellow, temp2-6, temp);
                    Wyswietlanie.pisz(listaCiosow[i].pobierzObrazenia().ToString(), ConsoleColor.Red, temp2-3, temp);
                }
                else
                    Wyswietlanie.pisz("Powrot", kolor, x+1, temp);

                if(i == zaznaczonaOpcja)
                    kolor = ConsoleColor.White;
            }
        }


        // pop-up do wyboru obrony
        public void okienkoWyboruObrony(int zaznaczonaOpcja)
        {   
            const int x = 16;
            const int y = 6;
            const int w = 16;
            Wyswietlanie.prostokat(x, y, w, 7);
            int temp, temp2 = x+w-3;
            var kolor = ConsoleColor.White;

            for (int i = 0; i < opcjeObrony.Length; i++)
            {   
                temp = y + 1 + (i*2);
                if(i == zaznaczonaOpcja)
                    kolor = ConsoleColor.Blue;

                Wyswietlanie.pisz(this.opcjeObrony[i], kolor, x+1, temp);

                switch(this.opcjeObrony[i])
                {
                    case "Normalna":
                        Wyswietlanie.pisz(SilaObrony.kosztNormalna.ToString(), ConsoleColor.Yellow, temp2, temp);
                        break;
                    
                    case "Mocna":
                        Wyswietlanie.pisz(SilaObrony.kosztMocna.ToString(), ConsoleColor.Yellow, temp2, temp);
                        break;
                }

                if(i == zaznaczonaOpcja)
                    kolor = ConsoleColor.White;
            }
        }
    }
}
