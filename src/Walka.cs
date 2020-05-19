namespace gra_k
{
    public class Walka
    {
        private Postac bohater;
        private Postac przeciwnik;
        private uint licznikTury;



        public void KolejnaTura()
        {
            ++this.licznikTury;
        }

        public void przyznanieNagrod()
        {

        }

        public static Walka generujWalke(Postac bohater, Dojo dojoGry)
        {
            Walka pojedynek = new Walka();

            return pojedynek;
        }
    }
}
