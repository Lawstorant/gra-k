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
        private uint turowaWytrzymalosc;



        public Walka(Postac bohater, Postac przeciwnik, InterfejsGry interfejs)
        {
            this.bohater = bohater;
            this.maxBohater = bohater.pobierzStatus().wytrzymalosc;
            this.przeciwnik = przeciwnik;
            this.maxPrzeciwnik = przeciwnik.pobierzStatus().wytrzymalosc;
            this.licznikTury = 1;
            this.interfejs = interfejs;
            this.przebieg = new List<string>();
            this.turowaWytrzymalosc = 3;
            
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
            uint pelneZycie = this.bohater.pobierzStatus().zycie;

            // 0 - ucieczka, 1 - wygrana, 2 - przegrana
            int exitState = 0;

            do
            {   
                this.interfejs.ekranWalki(wybor);

                if (this.bohater.pobierzStatus().zycie == 0)
                    exitState = 2;

                if (this.przeciwnik.pobierzStatus().zycie == 0)
                    exitState = 1;
                
                if (statusRefresh)
                {
                    this.interfejs.pasekStatusu(((Bohater)this.bohater).pobierzStatus());
                    statusRefresh = false;
                }

                if (przeciwnikRefresh)
                {
                    this.interfejs.oknoPrzeciwnika(
                        this.przeciwnik.pobierzStatus(),
                       this.przeciwnik.pobierzCiosy()
                    );
                   przeciwnikRefresh = false;
                }

                if (przebiegRefresh)
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
                    switch (wybor)
                    {   
                        // atak
                        case 0:
                            if (!wykonanoAtak)
                            {
                                wykonanoAtak = przeciwnikRefresh = this.atak();
                            }
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

            } while ((wybor != 3 || input.Key != ConsoleKey.Enter) && exitState == 0);

            this.przyznanieNagrod(exitState);
            this.bohater.ustawZycie(pelneZycie);
            this.bohater.ustawWytrzymalosc(maxBohater);
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
                        this.przebieg.Add($"Przeciwnik przyjmuje cios i otrzymuje {obrazenia} obrazen");

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
            Random rnd = new Random();
            var ciosy = this.przeciwnik.pobierzCiosy();
            Cios atak;
            int l = ciosy.Length;
            int s = 0;

            // atakowanie, 80% sansy na atak
            if (rnd.Next(1,11) <= 8)
            {
                int w = rnd.Next(0,ciosy.Length);

                if (this.przeciwnik.pobierzStatus().wytrzymalosc >= ciosy[w].pobierzKoszt())
                {
                    uint obrazenia = this.przeciwnik.wykonajAtak(w);
                    this.przebieg.Add($"Przeciwnik wykonuje atak {ciosy[w].pobierzNazwe()} z moca {obrazenia} punktow");

                    obrazenia = this.bohater.przyjmijObrazenia(obrazenia);
                    this.przebieg.Add($"Bohater przyjmuje cios i otrzymuje {obrazenia} obrazen");
                }
            }
            
            // 50% szansy na próbę obrony
            if (rnd.Next(1,11) <= 5)
            {
                if (rnd.Next(0,2) == 1)
                {
                    if (this.przeciwnik.pobierzStatus().wytrzymalosc >= SilaObrony.kosztMocna)
                        s = 2;
                    else if (this.przeciwnik.pobierzStatus().wytrzymalosc >= SilaObrony.kosztNormalna)
                        s = 1;
                }
                else
                {
                    if (this.przeciwnik.pobierzStatus().wytrzymalosc >= SilaObrony.kosztNormalna)
                        s = 1;
                }
            }
            
            if (s == 1)
            {
                this.bohater.pozycjaObronna(SilaObrony.normalna);
                this.przebieg.Add("Przeciwnik przyjmuje normalna pozycję obronną,");
                this.przebieg.Add($"otrzyma tylko {SilaObrony.normalna} obrażeń");
            }
            else if (s == 2)
            {
                this.bohater.pozycjaObronna(SilaObrony.mocna);
                this.przebieg.Add("Przeciwnik przyjmuje lepszą pozycję obronną,");
                this.przebieg.Add($"otrzyma tylko {SilaObrony.mocna} obrażeń");
            }
        }

        

        private void KolejnaTura()
        {
            ++this.licznikTury;
            this.przebieg.Add(" ");
            this.przebieg.Add("Zaczynamy nową turę!");
            this.przebieg.Add($"=== TURA {this.licznikTury} ===");

            uint wytrzymalosc = this.bohater.pobierzStatus().wytrzymalosc;
            wytrzymalosc = wytrzymalosc + this.turowaWytrzymalosc;
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

        private void przyznanieNagrod(int wynikWalki)
        {
            // TODO: poprawa balansu
            switch (wynikWalki)
            {   
                // wygrana
                case 1:
                    ((Bohater)this.bohater).dodajPieniadze(200);
                    ((Bohater)this.bohater).dodajDoswiadczenie(600);
                    break;

                // przegrana
                case 2:
                    ((Bohater)this.bohater).dodajPieniadze(50);
                    ((Bohater)this.bohater).dodajDoswiadczenie(200);
                    break;
            }
        }
    }
}
