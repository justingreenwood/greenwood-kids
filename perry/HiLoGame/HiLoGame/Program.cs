using System;

namespace HiLoGame
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to HiLo.");
            Console.WriteLine($"Guess numbers between 1 and {HiLoClass.Maximum}");
            HiLoClass.Hint();
            while(HiLoClass.GetPot() > 0)
            {

                Console.WriteLine("Press h for higher, l for lower, ? to buy a hint,");
                Console.WriteLine($"or any other key to quit with {HiLoClass.GetPot()}.");
                char key = Console.ReadKey(true).KeyChar;
                if (key == 'h') HiLoClass.Guess(true);
                else if (key == 'l') HiLoClass.Guess(false);
                else if (key == '?') HiLoClass.Hint();
                else return;

            }
            Console.WriteLine("The pot is empty. Bye!");

        }
    }
}
