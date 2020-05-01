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
            this.punktyZdolnosci -= wykorzystane;
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
    }
}
