using System;

namespace gra_k
{
    class Program
    {
        static void Main(string[] args)
        {
            Cwiczenie test1 = new Cwiczenie("cwiczenia/test.txt");
            Przedmiot test2 = new Przedmiot("przedmioty/test.txt");

            System.Console.WriteLine(test1.pobierzNazwe());
            System.Console.WriteLine(test2.pobierzNazwe());
        }
    }
}
