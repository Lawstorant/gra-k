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
                // próbuję zmienić kodowanie na en-US
                System.Diagnostics.Process.Start("CMD.exe", "chcp 437");
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

        public void gotoXY(int x, int y)
        {
            Console.CursorLeft = x;
            Console.CursorTop = y;
        }

        public void clrscr()
        {   
            //Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }

        public void pisz(string tekst, bool zaznaczony)
        {
            if(zaznaczony)
                Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.Write(tekst);
            Console.ForegroundColor = ConsoleColor.White; 
        }

        public void linia(bool pionowa, int dlugosc)
        {
            if (pionowa)
            {
                var x = Console.CursorLeft;
                var y = Console.CursorTop;
                for (int i = 0; i < dlugosc; i++)
                {
                    this.gotoXY(x, y+i);
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

        public void rozdzielacz(int dlugosc)
        {
            Console.Write('├');
            this.linia(false, dlugosc-2);
            Console.Write('┤');
        }

        public void prostokat(int x, int y, int width, int height)
        {
            // górna krawędź
            this.gotoXY(x,y);
            Console.Write('┌');
            this.linia(false, width-2);
            Console.Write('┐');

            // dolna krawędź
            this.gotoXY(x,y+height-1);
            Console.Write('└');
            this.linia(false, width-2);
            Console.Write('┘');

            // lewa krawędź
            this.gotoXY(x, y+1);
            this.linia(true, height-2);

            // prawa krawędź
            this.gotoXY(x+width-1, y+1);
            this.linia(true, height-2);
        }

        public void okienko(string tytul, int x, int y, int width, int height)
        {   
            var offset = (width - tytul.Length) / 2;
            this.prostokat(x, y, width, height);
            this.gotoXY(x+offset,y+1);
            Console.Write(tytul);
            this.gotoXY(x,y+2);
            this.rozdzielacz(width);
        }

        public void potwierdzenie()
        {

        }

    }
}
