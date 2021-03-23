using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Looping
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 1;
            while(x<=10)
            {
                Console.WriteLine(x);
                x++;
            }
            int playerNumber = -1;
            while(playerNumber<0||playerNumber>10)
            {
                Console.Write("Enter a number between 0 and 10: ");
                string playerResponse = Console.ReadLine();
                playerNumber = Convert.ToInt32(playerResponse);
            }
            do
            {
                Console.Write("Enter a number between 0 and 10: ");
                string playerResponse = Console.ReadLine();
                playerNumber = Convert.ToInt32(playerResponse);
            }
            while (playerNumber < 0 || playerNumber > 10);
            x = 1;
            for (x = 1; x <= 10; x++)
            {
                Console.WriteLine(x);
            }
            x = 1;
            int numtroublecause=54;
            for (x = 1; x <= 100; x++)
            {
                Console.WriteLine(x);
                if (x == numtroublecause)
                { 
                    break; 
                }
            }
            while(true)
            {
                Console.Write("What is thy bidding, my master? ");
                string input = Console.ReadLine();
                if(input=="exit"||input=="quit")
                {
                    break;
                }
            }
            x = 1;
            for (x = 1; x <= 10; x++)
            {
                if (x == 3)
                { 
                    continue; 
                }
                Console.WriteLine(x);
            }
           for(int row =0;row<5;row++)
           {
             for(int colomn = 0; colomn < 10; colomn++)
             {
                    Console.Write("*");
             }
                Console.WriteLine();
           } 
            for (int row = 0; row < 5; row++)
            {
                for (int colomn = 0; colomn < row+1; colomn++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            for (int row = 0; row<5; row++)
            {
                for (int colomn = 5; colomn > row; colomn--)
                {
                    Console.Write(" ");
                }
                for (int colomn = 0; colomn <= row*2 ; colomn++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            for (int nums=1;nums<101;nums++)
            {
                var printNumber = true;
                if ((nums%3)==0)
                {
                   Console.Write("Fizz");
                    printNumber = false;
                }
                if ((nums % 5) == 0)
                {
                    Console.Write("Buzz");
                    printNumber = false;
                }

                if (printNumber)
                {
                    Console.Write(nums);
                }
                Console.Write(" ");
            }
            Console.ReadKey();
        }
    }
}
