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
                        case 0:
                            this.menuDojo();
                            instRefresh = true;
                            nastRefresh = true;
                            break;

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

            } while (wybor != 3 || input.Key != ConsoleKey.Enter);
        }



        private void menuDojo()
        {
            int wybor = 0;
            ConsoleKeyInfo input;
            var prawyRefresh = true;
            var statusRefresh = true;

            // decyduje w którym menu się poruszamy:
            // 0 -> Ćwiczenia
            // 1 -> Ciosy
            // 2 -> Przedmioty
            // 3 -> Ogólne Dojo
            int ktoreMenu = 3;

            int[] limit = {
                this.dojo.pobierzCwiczenia().Length,
                this.dojo.pobierzCiosy().Length,
                this.dojo.PobierzPrzedmioty().Length,
                3
            };
            
            do
            {   
                // wyświetlam ekran Dojo
                switch (ktoreMenu)
                {
                    case 0:
                        this.interfejs.oknoCwiczen(this.dojo.pobierzCwiczenia(), wybor);
                        break;
                    case 1:
                        this.interfejs.oknoNaukiCiosow(this.dojo.pobierzCiosy(), wybor);
                        break;
                    case 2:
                        this.interfejs.oknoPrzedmiotow(this.dojo.PobierzPrzedmioty(), wybor);
                        break;
                    case 3:
                        this.interfejs.ekranDojo(wybor);
                        break;
                }

                // sprawdzam czy trzeba odświeżyć status naszego bohatera
                if(statusRefresh)
                {
                    this.interfejs.pasekStatusu(this.bohater.pobierzStatus());
                    statusRefresh = false;
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
                    if(ktoreMenu == 3 && wybor != 3)
                    {
                        ktoreMenu = wybor;
                        wybor = 0;
                    }
                    else
                    {
                        
                        wybor = ktoreMenu;
                        ktoreMenu = 3;
                    }
                }

                // zapętlające się menu
                if (wybor < 0)
                    wybor = limit[ktoreMenu];
                else if (wybor > limit[ktoreMenu])
                    wybor = 0;

                    // pętla kończy się jeżeli wybór jest równy 3, został wciśnięty enter i
                    // jesteśmy w ogólnym menu dojo
            } while (!((wybor == 3) && (input.Key == ConsoleKey.Enter) && (ktoreMenu == 3)));
        }



        public void walka()
        {

        }
    }
}
