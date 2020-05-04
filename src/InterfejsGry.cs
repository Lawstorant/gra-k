using System;

namespace gra_k
{
    public class InterfejsGry
    {
        private string[] opcjeDojo;
        private string[] opcjeWalki;
        private string[] opcjeGry;

        public InterfejsGry()
        {   
            // COMEBAK: Zrobić stringi w pliku i ich wczytywanie
            // stringi powinny być dla wszystkich okien
            this.opcjeDojo = new string[4] {"Idz na silownie", "Poznaj nowe ciosy", "Kup sobie pancerz", "Powrot"};
            this.opcjeGry = new string[3] {"Idz na silownie", "Poznaj nowe ciosy", "Kup sobie pancerz"};
            this.opcjeWalki = new string[3] {"Idz na silownie", "Poznaj nowe ciosy", "Kup sobie pancerz"};

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

        public static void ekranGry()
        {
            
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
