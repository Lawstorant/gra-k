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
            this.bohater = new Bohater(5, 2, 1, 0);
            this.bohater.dodajCios(new Cios("ciosy/cios-1.txt"));
            this.przeciwnik = null;
            this.interfejs = new InterfejsGry();
        }



        public void graj()
        {
            int wybor = 0;
            ConsoleKeyInfo input;
            var nastRefresh = true;
            var instRefresh = true;
            var statusRefresh = true;

            do
            {   
                // wyświetlam ekran gry
                this.interfejs.ekranGry(wybor);
                
                if (statusRefresh)
                {
                    this.interfejs.pasekStatusu(this.bohater.pobierzStatus());
                    statusRefresh = false;
                }

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

                        case 2:
                            if (przeciwnik != null)
                            {
                                var walka = new Walka(this.bohater, this.przeciwnik, this.interfejs);
                                this.przeciwnik = null;
                                walka.rozpocznij();

                                statusRefresh = nastRefresh = instRefresh = true;
                            }
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
                        this.interfejs.ekranDojo(wybor, prawyRefresh);
                        if (prawyRefresh)
                            prawyRefresh = false;
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
                // ta część jest bardzo smacznym daniem
                // nazywa się spaghetti
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
                        this.interfejs.ekranDojo(-1, false);
                        prawyRefresh = true;
                    }

                    else
                    {
                        if (wybor != limit[ktoreMenu])
                        {
                            switch (ktoreMenu)
                            {
                                case 0:
                                    wyborCwiczenia(wybor);
                                    break;

                                case 1:
                                    wyborCiosu(wybor);
                                    break;

                                case 2:
                                    wyborPrzedmiotu(wybor);
                                    break;
                            }

                            // możliwe, że zmieniły się statystyki bohatera
                            statusRefresh = true;
                        }

                        else
                        {
                            wybor = ktoreMenu;
                            ktoreMenu = 3;
                        }
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



        private void wyborCiosu(int wybrane)
        {
            uint punkty = this.bohater.pobierzStatus().punktyZdolnosci;
            uint koszt = this.dojo.pobierzCiosy()[wybrane].pobierzKoszt();
            if (punkty >= koszt)
            {
                this.bohater.dodajCios(this.dojo.pobierzCiosy()[wybrane]);
            }
            else
            {
                // COMEBAK: trzeba zrobić popup z wynikiem operacji
            }
        }



        private void wyborCwiczenia(int wybrane)
        {
            uint pieniadze = this.bohater.pobierzStatus().pieniadze;
            uint koszt = this.dojo.pobierzCwiczenia()[wybrane].pobierzKoszt();
            if (pieniadze >= koszt)
            {
                this.bohater.wydajPieniadze(koszt);
                this.bohater.pocwicz(this.dojo.pobierzCwiczenia()[wybrane]);
            }
            else
            {
                // COMEBAK: trzeba zrobić popup z wynikiem operacji
            }
        }



        private void wyborPrzedmiotu(int wybrane)
        {
            uint pieniadze = this.bohater.pobierzStatus().pieniadze;
            uint koszt = this.dojo.PobierzPrzedmioty()[wybrane].pobierzCene();
            if (pieniadze >= koszt)
            {
                this.bohater.wydajPieniadze(koszt);
                this.bohater.ubierzPancerz(this.dojo.PobierzPrzedmioty()[wybrane]);
            }
            else
            {
                // COMEBAK: trzeba zrobić popup z wynikiem operacji
            }
        }
    }
}
