using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace mathmaster
{
    class Program
    {
        static void Main(string[] args)
        {  gr:
            Console.WriteLine("***Math Master***");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[1] Add two numbers");
            Console.WriteLine("[2] Subtract two numbers");
            Console.WriteLine("[3] Multiply two numbers");
            Console.WriteLine("[4] Divide two numbers");
            Console.WriteLine("[5] Least common denominator");
            Console.WriteLine("[6] greatest common demomenator");
            Console.WriteLine("");
            Console.WriteLine("[0] Quit");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Please choose an option:");
            var num = Console.ReadLine();
            switch (num)
            {
                case "1":
                    Class1.add();
                    goto gr;
                case "2":
                    Class1.sub();
                    goto gr;
                case "3":
                    Class1.multiply();
                    goto gr;
                case "4":
                    Class1.divide();
                    goto gr;
                case "5":
                    Class1.min();
                    Console.WriteLine("replaced wit min.");
                    goto gr;
                case "6":
                    Class1.max();
                    Console.WriteLine("replaced with max.");
                    goto gr;
                case "0":
                    Console.WriteLine("bye");
                    break;
                default:
                    Console.WriteLine("not real");
                    goto gr;
            }

        }

    }
}
