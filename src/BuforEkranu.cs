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
            this.buffer = new char[x+1,y+1];

            
        }

        public void test()
        {
            this.buffer[2,2] = 'c';
            System.Console.WriteLine(this.buffer[2,2]);
        }
    }
}
