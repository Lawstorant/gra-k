using System;

namespace gra_k
{
    class Program
    {
        static void Main(string[] args)
        {
            Bohater tomek = new Bohater(10, 10, 10, 10);
            tomek.dodajPieniadze(200);
            tomek.dodajDoswiadczenie(3300);
            tomek.wydajPieniadze(20);

            Cios xd = new Cios("ciosy/prosty.txt");

            tomek.dodajCios(xd);
        }
    }
}
