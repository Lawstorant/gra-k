using System;

namespace gra_k
{
    public class Wyswietlanie
    {
        private uint width;
        private uint height;


        public Wyswietlanie(uint width, uint height)
        {
            this.width = width;
            this.height = height;


            // rzeczy windowsowe
            try
            {
                // zmieniam wielkosć okna do rozmiaru gry
                Console.SetWindowSize((int)width, (int)height);
                Console.SetBufferSize((int)width, (int)height);
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

        public static void gotoXY(int x, int y)
        {
            Console.CursorLeft = x;
            Console.CursorTop = y;
        }

        public static void clrscr()
        {   
            //Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }

        public static void wyczyscPole(int x, int y, int width, int height)
        {
            for (int i = 0; i < height; i++)
            {
                Wyswietlanie.gotoXY(x,y+i);
                for (int j = 0; j < width; j++)
                {
                    Console.Write(" ");
                }
            }
        }

        public static void pisz(string tekst, ConsoleColor kolor)
        {
            Console.ForegroundColor = kolor;
            Console.Write(tekst);
            Console.ForegroundColor = ConsoleColor.White; 
        }

        public static void pisz(string tekst, ConsoleColor kolor, int x, int y)
        {
            gotoXY(x, y);
            Wyswietlanie.pisz(tekst, kolor);
        }

        public static void linia(int dlugosc, bool pionowa)
        {
            if (pionowa)
            {
                var x = Console.CursorLeft;
                var y = Console.CursorTop;
                for (int i = 0; i < dlugosc; i++)
                {
                    Wyswietlanie.gotoXY(x, y+i);
                    Console.Write('│');
                }
            }
            else
            {   
                for (int i = 0; i < dlugosc; i++)
                {
                    Console.Write('─');
                }
            }           
        }

        public static void rozdzielacz(int dlugosc, bool pionowy)
        {   
            if (pionowy)
            {   
                var x = Console.CursorLeft;
                var y = Console.CursorTop;
                Console.Write('┬');
                Wyswietlanie.gotoXY(x, y+1);
                Wyswietlanie.linia(dlugosc-2, true);
                Wyswietlanie.gotoXY(x, y+dlugosc-1);
                Console.Write('┴');
            }
            else
            {
                Console.Write('├');
                Wyswietlanie.linia(dlugosc-2, false);
                Console.Write('┤');
            }
        }

        public static void rozdzielacz(int dlugosc, bool pionowy, int x, int y)
        {
            Wyswietlanie.gotoXY(x, y);
            rozdzielacz(dlugosc, pionowy);
        }

        public static void krzyz(int x, int y)
        {
            Wyswietlanie.gotoXY(x, y);
            Console.Write('┼');
        }

        public static void prostokat(int x, int y, int width, int height)
        {
            // górna krawędź
            Wyswietlanie.gotoXY(x,y);
            Console.Write('┌');
            Wyswietlanie.linia(width-2, false);
            Console.Write('┐');

            // dolna krawędź
            Wyswietlanie.gotoXY(x,y+height-1);
            Console.Write('└');
            Wyswietlanie.linia(width-2, false);
            Console.Write('┘');

            // lewa krawędź
            Wyswietlanie.gotoXY(x, y+1);
            Wyswietlanie.linia(height-2, true);

            // prawa krawędź
            Wyswietlanie.gotoXY(x+width-1, y+1);
            Wyswietlanie.linia(height-2, true);
        }

        public static void okienko(string tytul, int x, int y, int width, int height)
        {   
            Wyswietlanie.wyczyscPole(x, y, width, height);
            var offset = (width - tytul.Length) / 2;
            Wyswietlanie.prostokat(x, y, width, height);
            Wyswietlanie.gotoXY(x+offset,y+1);
            Console.Write(tytul);
            Wyswietlanie.gotoXY(x,y+2);
            Wyswietlanie.rozdzielacz(width, false);
        }
    }
}
