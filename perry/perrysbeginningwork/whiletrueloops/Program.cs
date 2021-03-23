using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whiletrueloops
{
    class Program
    {
        static void Main(string[] args)
        {

            int x = 1;
            while (x <= 10)
            {
                Console.WriteLine(x);
                x++;
            }

            int playersnumber = -1;

            while(playersnumber <0 || playersnumber > 10)
            {
                Console.WriteLine("Enter a number: ");
                string playernumber = Console.ReadLine();
                playersnumber = Convert.ToInt32(playernumber);
            }

            playersnumber = 0;
            do
            {
                Console.WriteLine("Enter a number: ");
                string playernumber = Console.ReadLine();
                playersnumber = Convert.ToInt32(playernumber);
            } while (playersnumber < 0 || playersnumber > 10);

            for(x = 1; x <= 10; x++)
            {
                Console.WriteLine(x);
            }

            for(int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 10; column++)
                    Console.Write("-");
                Console.WriteLine();
            }

            for (int row = 0; row < 10; row++)
            {
                for (int column = 0; column < row + 1; column++)
                    Console.Write("X");
                Console.WriteLine();
            }

            for (int row = 0; row < 5; row++)
            {
                for (int column = 4; column > row - 1; column--)
                {
                    Console.Write(" ");
                }
                for (int column = 0; column <= row * 2; column++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            for(int i = 1; i <= 100; i++)
            {
                int j_5 = i % 5;
                int j_3 = i % 3;
                if (j_3 == 0 && j_5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (j_3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (j_5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }

            }



            //if remainder of x/3 is zero than it is 3 
            //if remainder of x/5 is zero than it is 5





                Console.ReadKey();
        }
    }
}
