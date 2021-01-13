using System;

namespace stuffbook
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo chose;

            Console.WriteLine("(Q)uit,(S)ave,(L)ist");
            chose = Console.ReadKey();
            Console.WriteLine();
        }
    }
}
