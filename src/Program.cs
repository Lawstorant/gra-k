using System;

namespace gra_k
{
    class Program
    {
        static void Main(string[] args)
        {   
            // InterfejsGry interfejs = new InterfejsGry();
            // interfejs.test();

            Gra rozgrywka = new Gra();
            rozgrywka.graj();
            
            Console.CursorVisible = true; 
        }
    }
}
