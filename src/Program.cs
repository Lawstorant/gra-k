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
                // test interfejsu graficznego
                if (args[0] == "-t" || args[0] == "--test")
                {
                    moznaGrac = false;
                    InterfejsGry interfejs = new InterfejsGry();
                    interfejs.test();
                }

                // tutaj robimy szybkie testy pomysłu na kod
                if (args[0] == "-g")
                {
                    moznaGrac = false;
                    uint obrazenia = 2;
                    obrazenia = (uint) Math.Floor ((0.7 * (double)obrazenia));
                    System.Console.WriteLine(obrazenia);
                }
            }

            if (moznaGrac)
            {
                Gra rozgrywka = new Gra();
                rozgrywka.graj();
            }

            // TODO: przenieść to do destruktorów
            Console.CursorVisible = true; 
        }
    }
}
