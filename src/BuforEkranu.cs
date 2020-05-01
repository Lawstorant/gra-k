namespace gra_k
{
    public class BuforEkranu
    {
        private uint width;
        private uint height;
        private char[,] buffer;



        public BuforEkranu(uint x, uint y)
        {
            this.width = x;
            this.height = y;
            this.buffer = new char[y, x+1];

            for (int i = 0; i < y; ++i)
            {
                for (int j = 0; j < x; ++j)
                {
                    this.buffer[i, j] = 'x';
                }
                this.buffer[i, x] = '\n';
            }
        }

        public void wyswietlBufor()
        {
            System.Console.Clear();
            
            for (int i = 0; i < this.height; ++i)
            {
                for (int j = 0; j <= this.width; ++j)
                {
                    System.Console.Write(this.buffer[i, j]);
                }
            }
        }

        public void test()
        {
            this.buffer[2, 2] = ' ';
            this.buffer[6, 6] = ' ';
            
        }
    }
}
