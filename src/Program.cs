using System;

namespace gra_k
{
    class Program
    {
        static void Main(string[] args)
        {
            Cios test = new Cios("ciosy/prosty.txt");
            System.Console.WriteLine($"{test.pobierzNazwe()} {test.pobierzObrazenia()} {test.pobierzKoszt()}");
        }
    }
}
