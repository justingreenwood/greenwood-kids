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
            int[] numbers = GenerateNumbers();
            Reverse( numbers);
            PrintNumbers();
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
        static int[] GenerateNumbers()
        {
            for (int index = 1; index < +10; index++)
            {
               array[index];
                index = int[] numbers;
            }
            return int[];
        }
        static int Reverse()
        {
            for (int index = 12;index => numbers.length; index--)
            {
                Array[Array.length - index - 1];
            }
            return numbers;
        }
        static void PrintNumbers()
        {
            for (int current =10; current > 0; current--)
            {
                Console.WriteLine(current);
            }
        }
    }
}
