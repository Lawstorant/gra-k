namespace gra_k
{
    public class Bohater : Postac
    {
        protected uint poziom;
        protected uint doswiadczenie;
        protected uint punktyZdolnosci;
        protected uint pieniadze;



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

        public void dodajPieniadze(uint przychod)
        {
            this.pieniadze += przychod;
        }

        public void wydajPieniadze(uint wydatek)
        {
            if(wydatek <= this.pieniadze)
            {
                this.pieniadze -= wydatek;
            }
        }
        
        public new void dodajCios(Cios dodawany)
        {
            base.dodajCios(dodawany);
            this.wykorzystajPunktyZdolnosci(dodawany.pobierzKoszt());
        }

        public void pocwicz(Cwiczenie doWykonania)
        {
            uint[] staty = doWykonania.pobierzStaty();

            this.zycie += staty[0];
            this.wytrzymalosc += staty[1];
            this.sila += staty[2];
        }

        public void ubierzPancerz(Przedmiot pancerz)
        {
            this.pancerz = pancerz.pobierzPancerz();
        }

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
