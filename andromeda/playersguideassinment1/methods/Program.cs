using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace methods
{
    class Program
    {
        static void Main(string[] args)
        {
            CountToTen();
            Console.WriteLine("I'm about to go into a method.");
            DoSomthingAwsome();
            Console.WriteLine("I'm back from the method.");
            int userNumber = GetNumberFromUser();
            Count(5);
            Count(15);
           // int[] numbers = GenerateNumbers();
           // Reverse( numbers);
            PrintNumbers();
            Multiply(5, 10);
            Multiply(1, 6, 9);
            Multiply(10.2, 69.5);
            fibonacci(1);
            Console.ReadKey();
        }
        static void CountToTen()
        {
            for (int index = 1; index < +10; index++)
                Console.WriteLine(index);
        }
        static void DoSomthingAwsome()
        {
            Console.WriteLine("I'm inside of a method! Awsome!");
        }
        static float GetRandomNumber()
        {
            return 1.569f;
        }
        static int GetNumberFromUser()
        {
            int userNumber = 0;
            while (userNumber < 1 || userNumber > 10)
            {
                Console.WriteLine("Enter a number between 1 and 10:");
                string userResponse = Console.ReadLine();
                userNumber = Convert.ToInt32(userResponse);
            }
            return userNumber;
        }
        static void Count(int numberToCountTo)
        {
            for (int current = 1; current <= numberToCountTo; current++)
            {
                Console.WriteLine(current);
            }
        }
       // static int[] GenerateNumbers()
       // {
         //   for (int index = 1; index < +10; index++)
         //   {
         //      array[index];
         //       index = int[] numbers;
         //   }
         //   return int[];
       // }
       // static int Reverse()
      //  {
       //     for (int index = 12;index => numbers.length; index--)
         //   {
       //         Array[Array.length - index - 1];
        //    }
       //     return numbers;
       // }
        static void PrintNumbers()
        {
            for (int current =10; current > 0; current--)
            {
                Console.WriteLine(current);
            }
        }
        static int Multiply(int a, int b)
        {
            return a * b;
        }
        static int Multiply(int a, int b, int c)
        {
            return a * b * c;
        }
        static double Multiply( double a, double b)
        {
            return a * b;
        }
        static int Factorial(int number)
        {
            if (number == 1)
                return 1;
            return number * Factorial(number - 1);
        }
        static int fibonacci( int sums)
        {
            int ans =1;
            switch (sums)
            {
                case 1:
                case 2:
                    break;
                case 3:
                  ans=++ans;
                    break;
                case 4:
                    ans =--sums;
                    break;
                case 5:
                    ans = sums;
                    break;
                case 6:
                    ans = sums+2;
                    break;
                case 7:
                    ans = sums + 6;
                    break;
                case 8:
                    ans = sums + 13;
                    break;
                case 9:
                    ans = sums + 25;
                    break;
                case 10:
                    ans = sums + 45;
                    break;
                default:
                    ans = 0;
                    break;
            }
            return ans; 
        }
    }
}
