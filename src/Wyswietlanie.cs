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

        public void wyczysc(int x, int y, int width, int height)
        {
            for (int i = 0; i < height; i++)
            {
                this.gotoXY(x,y+i);
                
            }

        }

        public void pisz(string tekst, bool zaznaczony)
        {
            if(zaznaczony)
                Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.Write(tekst);
            Console.ForegroundColor = ConsoleColor.White; 
        }

        public void pisz(string tekst, bool zaznaczony, int x, int y)
        {
            gotoXY(x, y);
            this.pisz(tekst, zaznaczony);
        }

        public void linia(int dlugosc, bool pionowa)
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

        public void rozdzielacz(int dlugosc, bool pionowy)
        {   
            if (pionowy)
            {   
                var x = Console.CursorLeft;
                var y = Console.CursorTop;
                Console.Write('┬');
                this.gotoXY(x, y+1);
                this.linia(dlugosc-2, true);
                this.gotoXY(x, y+dlugosc-1);
                Console.Write('┴');
            }
            else
            {
                Console.Write('├');
                this.linia(dlugosc-2, false);
                Console.Write('┤');
            }
        }

        public void rozdzielacz(int dlugosc, bool pionowy, int x, int y)
        {
            gotoXY(x, y);
            rozdzielacz(dlugosc, pionowy);
        }

        public void prostokat(int x, int y, int width, int height)
        {
            // górna krawędź
            this.gotoXY(x,y);
            Console.Write('┌');
            this.linia(width-2, false);
            Console.Write('┐');

            // dolna krawędź
            this.gotoXY(x,y+height-1);
            Console.Write('└');
            this.linia(width-2, false);
            Console.Write('┘');

            // lewa krawędź
            this.gotoXY(x, y+1);
            this.linia(height-2, true);

            // prawa krawędź
            this.gotoXY(x+width-1, y+1);
            this.linia(height-2, true);
        }

        public void okienko(string tytul, int x, int y, int width, int height)
        {   
            var offset = (width - tytul.Length) / 2;
            this.prostokat(x, y, width, height);
            this.gotoXY(x+offset,y+1);
            Console.Write(tytul);
            this.gotoXY(x,y+2);
            this.rozdzielacz(width, false);
        }
    }
}
