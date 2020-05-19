namespace gra_k
{
    ///Klasa ta odpowiedzialna jest za generowanie statystyk bohatera
    public class Bohater : Postac
    {
        protected uint poziom;
        protected uint doswiadczenie;
        protected uint punktyZdolnosci;
        protected uint pieniadze;


        /// <summary>
        /// Zmienne typ uint aby nie zostały wygenerowane na minusie
        /// </summary>
        /// <param name="zycie"></param> Zmienna odpowiadająca za poziom życia  
        /// <param name="wytrzymalosc"></param> Zmienna odpowiedzialna za poziom wytrzymałości 
        /// <param name="sila"></param> Zmienna odpowiedzialna za poziom siły
        /// <param name="pancerz"></param> Zmienna odpowiadająca za ilość pancerza 
        public Bohater(
            uint zycie,
            uint wytrzymalosc,
            uint sila,
            uint pancerz) : base(zycie, wytrzymalosc, sila, pancerz)
        {
            this.poziom = 1;
            this.doswiadczenie = 0;
            this.punktyZdolnosci = 0;
            this.pieniadze = 0;
        }

        // TODO: Zrobić konstruktor wczytujący bohatera z pliku zapisu

        // TODO: Zrobić pobieranie dodatkowych statystyk bohatera
        /// <summary>
        /// Metoda dodajDoswiadczenie() odpowiada za dodanie punktów doświadczenia po zakończonej walce w dojo.
        /// Znajduje się tu odowałenie do metody typu private sprawdzMozliwoscLVLUP() która sprawdza czy można podnieść poziom bohatera.
        /// </summary>
        /// <param name="doswiadczenie"></param>
        public void dodajDoswiadczenie(uint doswiadczenie)
        {
            this.doswiadczenie += doswiadczenie;
            this.sprawdzMozliwoscLVLUP();
        }

        private void sprawdzMozliwoscLVLUP()
        {
            // COMEBAK: Tutaj będzie trzeba ogarnąć próg punktowy
            // dla nowego poziomu, ewentualnie można zrobić
            // plik z konfiguracją
            // Tomek
            while (this.doswiadczenie >= 1000)
            {
                this.doswiadczenie -= 1000;
                this.poziom += 1;
                this.podniesPunktyZdolnosci();
            }
        }

        private void podniesPunktyZdolnosci()
        {
            // COMEBAK: Zbalansować ilość przyznawanych punktów
            // Tomek
            this.punktyZdolnosci += 2;
        }

        private void wykorzystajPunktyZdolnosci(uint wykorzystane) {
            if (wykorzystane <= this.punktyZdolnosci)
                this.punktyZdolnosci -= wykorzystane;
            else
                this.punktyZdolnosci = 0;
        }
        /// <summary>
        /// Metoda odpowiadająca za dodanie funduszy graczowi 
        /// </summary>
        /// <param name="przychod"></param>
        public void dodajPieniadze(uint przychod)
        {
            this.pieniadze += przychod;
        }
        /// <summary>
        /// Metoda odpowiedzialna za odjęcie z funduszu środków 
        /// </summary>
        /// <param name="wydatek"></param>
        public void wydajPieniadze(uint wydatek)
        {
            if(wydatek <= this.pieniadze)
            {
                this.pieniadze -= wydatek;
            }
        }
        /// <summary>
        /// Dodanie ciostu 
        /// Odwołanie do metody typu private z pobraniem kosztów związanych z zakupem ciosów
        /// </summary>
        public new void dodajCios(Cios dodawany)
        {
            base.dodajCios(dodawany);
            this.wykorzystajPunktyZdolnosci(dodawany.pobierzKoszt());
        }
        /// <summary>
        /// Metoda odpowiedzialna za dodanie statystyk po wykonaniu ćwiczenia 
        /// </summary>
        public void pocwicz(Cwiczenie doWykonania)
        {
            uint[] staty = doWykonania.pobierzStaty();

            this.zycie += staty[0];
            this.wytrzymalosc += staty[1];
            this.sila += staty[2];
        }
        /// <summary>
        /// Metoda odpowiedzialna za dodanie pancerza do statysyk
        /// </summary>
        /// <param name="pancerz"></param>
        public void ubierzPancerz(Przedmiot pancerz)
        {
            this.pancerz = pancerz.pobierzPancerz();
        }
        /// <summary>
        /// Metoda odpowiedzialna za pobranie statystyk 
        /// </summary>
        public new StatusPostaci pobierzStatus()
        {
            var aktualnyStatus = base.pobierzStatus();
            aktualnyStatus.poziom = this.poziom;
            aktualnyStatus.doswiadczenie = this.doswiadczenie;
            aktualnyStatus.punktyZdolnosci = this.punktyZdolnosci;
            aktualnyStatus.pieniadze = this.pieniadze;

            return aktualnyStatus;
        }
    }
}
