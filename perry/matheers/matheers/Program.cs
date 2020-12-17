using System;

namespace matheers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("               Multiplication table 15 by 15.");
            int j = 1;
            for (j = 1; j <= 15; j++)
            {
                int J = 1;
                for (J = 1; J <= 15; J++)
                {
                    var Jj = (j * J).ToString().PadLeft(4);
                    Console.Write(Jj);
                }
                Console.WriteLine();
            }
            Console.WriteLine();


        Iikey:
            Console.WriteLine("3(i + 11) - 15");            
            string I;
            double i;
            do
            {
                Console.WriteLine("Type in a value for i.");
                I = Console.ReadLine();
            } while (!double.TryParse(I, out i));

            Console.WriteLine($"The answer is {3 * (i + 11) - 15}");
            yekiI:
            Console.WriteLine("Do you want to play again? (y/n)");
            var key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.Y)
                goto Iikey;
            else if (key.Key == ConsoleKey.N)
                Console.WriteLine("Good Bye.");
            else if(key.Key == ConsoleKey.Tab)
            {
                int a = 1;
                while (a <= 5)
                {
                    int b = 1;
                    while(b <= a)
                    {
                        Console.Write(" You are an idiot! ");
                        b++;
                    }
                    Console.WriteLine();
                    a++;
                }
                
                while(a > 1)
                {
                    int b = 1;
                    while (b <= a)
                    {
                        Console.Write(" You are an idiot! ");
                        b++;
                    }
                    Console.WriteLine();
                    a--;
                }
            }
            else
            {
                Console.WriteLine("You are an idiot!");
                goto yekiI;
            }


            
        }
    }
}
