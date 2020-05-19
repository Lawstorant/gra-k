using System;

namespace gra_k
{
    class Program
    {
        static void Main(string[] args)
        {   
            bool moznaGrac = true;
            if (args.Length > 0)
            {
                if (args[0] == "-t" || args[0] == "--test")
                {
                    moznaGrac = false;
                    InterfejsGry interfejs = new InterfejsGry();
                    interfejs.test();
                }
            }

            if (moznaGrac)
            {
                Gra rozgrywka = new Gra();
                rozgrywka.graj();
            }

            Console.CursorVisible = true; 
        }
    }
}
