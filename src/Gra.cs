using System;

namespace gra_k
{
    public class Gra
    {
        private Bohater bohater;
        private Dojo dojo;
        private InterfejsGry interfejs;
        private Postac przeciwnik;



        public Gra()
        {
            this.dojo = new Dojo();
            this.bohater = new Bohater(5, 5, 2, 0);
            this.bohater.dodajCios(new Cios("ciosy/prosty.txt"));
            this.przeciwnik = null;
            this.interfejs = new InterfejsGry();
        }



        public void graj()
        {
            int wybor = 0;
            ConsoleKeyInfo input;
            var nastRefresh = true;
            var instRefresh = true;

            this.interfejs.pasekStatusu(this.bohater.pobierzStatus());
            do
            {   
                // wyświetlam ekran gry
                this.interfejs.ekranGry(wybor);

                if(nastRefresh)
                {
                    if(przeciwnik != null)
                        this.interfejs.oknoNastepnego(
                            przeciwnik.pobierzStatus(),
                            przeciwnik.pobierzCiosy()
                        );
                    else
                        this.interfejs.oknoNastepnego();

                    nastRefresh = false;
                }

                if(instRefresh)
                {
                    this.interfejs.oknoInstrukcji();
                    instRefresh = false;
                }

                // wczytuję wciśnięty klawisz
                input = Console.ReadKey();
                
                // na podstawie klawisza zmieniam wybór,
                // lub wybieram zaznaczoną opcję
                if (input.Key == ConsoleKey.UpArrow)
                    --wybor;
                else if (input.Key == ConsoleKey.DownArrow)
                    ++wybor;
                else if (input.Key == ConsoleKey.Enter)
                {
                    switch(wybor)
                    {
                        case 1:
                            przeciwnik = Postac.generujPostac (
                                (int) this.bohater.pobierzStatus().poziom,
                                this.dojo.pobierzCiosy()
                            );
                            nastRefresh = true;
                            break;
                    }
                }

                // zapętlające się menu
                if (wybor < 0)
                    wybor = 3;
                else if (wybor > 3)
                    wybor = 0;

            } while ((wybor != 3) || (input.Key != ConsoleKey.Enter));
        }



        public void menuDojo()
        {

        }



        public void walka()
        {

        }
    }
}
