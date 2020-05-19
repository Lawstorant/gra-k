using System;
using System.Collections.Generic;

namespace gra_k
{
    public class Walka
    {
        private Postac bohater;
        private Postac przeciwnik;
        private uint licznikTury;
        private InterfejsGry interfejs;
        private List<string> przebieg;
        private uint maxBohater;
        private uint maxPrzeciwnik;
        private const uint turowaWytrzymalosc = 3;



        public Walka(Postac bohater, Postac przeciwnik, InterfejsGry interfejs)
        {
            this.bohater = bohater;
            this.maxBohater = bohater.pobierzStatus().wytrzymalosc;
            this.przeciwnik = przeciwnik;
            this.maxPrzeciwnik = przeciwnik.pobierzStatus().wytrzymalosc;
            this.licznikTury = 1;
            this.interfejs = interfejs;
            this.przebieg = new List<string>();
            
            this.przebieg.Add("Panie i Panowie!");
            this.przebieg.Add("Na arenie zaczynamy wlasnie nowy pojedynek!");
            this.przebieg.Add("Czy dzielny bohater da sobie tym razem rade?");
            this.przebieg.Add(" ");
            this.przebieg.Add($"=== TURA {this.licznikTury} ===");
        }



        public void rozpocznij()
        {
            int wybor = 0;
            ConsoleKeyInfo input;

            var statusRefresh = true;
            var przeciwnikRefresh = true;
            var przebiegRefresh = true;
            var wykonanoAtak = false;
            var wykonanoObrone = false;

            do
            {   
                this.interfejs.ekranWalki(wybor);
                
                if (statusRefresh)
                {
                    this.interfejs.pasekStatusu(this.bohater.pobierzStatus());
                    statusRefresh = false;
                }

                if(przeciwnikRefresh)
                {
                    this.interfejs.oknoPrzeciwnika(
                        this.przeciwnik.pobierzStatus(),
                       this.przeciwnik.pobierzCiosy()
                    );
                   przeciwnikRefresh = false;
                }

                if(przebiegRefresh)
                {
                    this.interfejs.oknoPrzebieguWalki(this.przebieg.ToArray());
                    przebiegRefresh = false;
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
                        // atak
                        case 0:
                            if (!wykonanoAtak)
                                wykonanoAtak = przeciwnikRefresh = this.atak();
                            
                            statusRefresh = true;
                            przebiegRefresh = true;
                            break;

                        // obrona
                        case 1:
                            if (!wykonanoObrone)
                                wykonanoObrone = this.obrona();

                            statusRefresh = true;
                            przebiegRefresh = true;
                            break;

                        // zakonczenie tury
                        case 2:
                            this.przebieg.Add("Bohater oddal inicjatywe przciwnikowi");
                            this.przebieg.Add(" ");
                            this.ruchyPrzeciwnika();
                            this.KolejnaTura();
                            wykonanoAtak = wykonanoObrone = false;
                            przebiegRefresh = statusRefresh = true;
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


        private bool atak()
        {   
            var wynik = false;
            int wybor = 0;
            ConsoleKeyInfo input;
            int limit = this.bohater.pobierzCiosy().Length;
            Cios[] ciosy = this.bohater.pobierzCiosy();
            uint wytrzymalosc = this.bohater.pobierzStatus().wytrzymalosc;

            do
            {   
                this.interfejs.okienkoWyboruCiosu(ciosy, wybor);

                // wczytuję wciśnięty klawisz
                input = Console.ReadKey();
                
                // na podstawie klawisza zmieniam wybór,
                // lub wybieram zaznaczoną opcję
                if (input.Key == ConsoleKey.UpArrow)
                    --wybor;
                else if (input.Key == ConsoleKey.DownArrow)
                    ++wybor;
                else if (input.Key == ConsoleKey.Enter && wybor < limit)
                {
                    if(ciosy[wybor].pobierzKoszt() <= wytrzymalosc)
                    {   
                        uint obrazenia = this.bohater.wykonajAtak(wybor);
                        this.przebieg.Add($"Bohater wykonuje atak {ciosy[wybor].pobierzNazwe()} z moca {obrazenia} punktow");

                        obrazenia = this.przeciwnik.przyjmijObrazenia(obrazenia);
                        this.przebieg.Add($"Przeciwnik przyjmuje cios i otzymuje {obrazenia} obrazen");

                        wynik = true;
                        wybor = limit;
                    }
                }

                // zapętlające się menu
                if (wybor < 0)
                    wybor = limit;
                else if (wybor > limit)
                    wybor = 0;

            } while (wybor != limit || input.Key != ConsoleKey.Enter);

            return wynik;
        }



        private bool obrona()
        {
            var wynik = false;
            int wybor = 0;
            ConsoleKeyInfo input;
            int limit = 2;
            uint wytrzymalosc = this.bohater.pobierzStatus().wytrzymalosc;

            do
            {   
                this.interfejs.okienkoWyboruObrony(wybor);

                // wczytuję wciśnięty klawisz
                input = Console.ReadKey();
                
                // na podstawie klawisza zmieniam wybór,
                // lub wybieram zaznaczoną opcję
                if (input.Key == ConsoleKey.UpArrow)
                    --wybor;
                else if (input.Key == ConsoleKey.DownArrow)
                    ++wybor;
                else if (input.Key == ConsoleKey.Enter && wybor < limit)
                {
                    if (wybor == 0 && SilaObrony.kosztNormalna <= wytrzymalosc)
                    {
                        this.bohater.pozycjaObronna(SilaObrony.normalna);
                        this.przebieg.Add("Bohater przyjmuje normalna pozycję obronną,");
                        this.przebieg.Add($"otrzyma tylko {SilaObrony.normalna} obrażeń");
                        wynik = true;
                        wybor = limit;
                    }
                    else if (SilaObrony.kosztMocna <= wytrzymalosc)
                    {
                        this.bohater.pozycjaObronna(SilaObrony.mocna);
                        this.przebieg.Add("Bohater przyjmuje lepszą pozycję obronną,");
                        this.przebieg.Add($"otrzyma tylko {SilaObrony.mocna} obrażeń");
                        wynik = true;
                        wybor = limit;
                    }
                }

                // zapętlające się menu
                if (wybor < 0)
                    wybor = limit;
                else if (wybor > limit)
                    wybor = 0;

            } while (wybor != limit || input.Key != ConsoleKey.Enter);

            return wynik;
        }



        private void ruchyPrzeciwnika()
        {

        }

        

        private void KolejnaTura()
        {
            ++this.licznikTury;
            this.przebieg.Add(" ");
            this.przebieg.Add("Zaczynamy nową turę!");
            this.przebieg.Add($"=== TURA {this.licznikTury} ===");

            uint wytrzymalosc = this.bohater.pobierzStatus().wytrzymalosc;
            wytrzymalosc += turowaWytrzymalosc;
            if (wytrzymalosc > maxBohater)
                wytrzymalosc = maxBohater;

            this.bohater.ustawWytrzymalosc(wytrzymalosc);

            wytrzymalosc = this.przeciwnik.pobierzStatus().wytrzymalosc;
            wytrzymalosc += turowaWytrzymalosc;
            if (wytrzymalosc > maxPrzeciwnik)
                wytrzymalosc = maxPrzeciwnik;

            this.przeciwnik.ustawWytrzymalosc(wytrzymalosc);

            this.przebieg.Add($"Uczestnicy dostaja po {turowaWytrzymalosc} punkty wytrzymalosci");
        }

        private void przyznanieNagrod()
        {
            ((Bohater)this.bohater).dodajPieniadze(1000);
        }
    }
}
