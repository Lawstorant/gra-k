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
            uint pancerz)
            : base(zycie, wytrzymalosc, sila, pancerz)
        {
            this.poziom = 1;
            this.doswiadczenie = 0;
            this.punktyZdolnosci = 0;
            this.pieniadze = 0;
        }

        public void dodajDoswiadczenie(uint doswiadczenie)
        {
            this.doswiadczenie += doswiadczenie;
        }

        private void sprawdzMozliwoscLVLUP()
        {
            
        }

        private void podniesPunktyZdolnosci()
        {

        }
    }
}
