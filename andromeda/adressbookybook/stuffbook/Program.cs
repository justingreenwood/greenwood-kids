using System;
using System.Collections.Generic;
using System.IO;

namespace stuffbook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            var addresslist = new List<Class1>();
            var rows = File.ReadAllLines("TextFile1.txt");
            for (int i = 0;i<rows.Length;i++)
            {
                string row = rows[i];
                var columns = row.Split('/');
                if (columns.Length == 6)
                {
                    var a = new Class1();
                    a.firstname = columns[0];
                    a.lastname = columns[1]; 
                    a.streetnum = columns[2]; 
                    a.city = columns[3]; 
                    a.state = columns[4]; 
                    a.zip = columns[5];
                    addresslist.Add(a);
                    Console.WriteLine(rows[i]);
                }
            }
            ConsoleKeyInfo chose;
            bool isplaying = true;
            while (isplaying)
            {

                Console.WriteLine("(Q)uit,(S)ave,(L)ist,(A)dd,(R)emove");
                chose = Console.ReadKey();

                Console.WriteLine();
                if (chose.Key == ConsoleKey.Q)
                {
                    isplaying = false;
                }
                else if (chose.Key == ConsoleKey.S)
                {
                    Console.WriteLine("......................");
                }
                else if (chose.Key == ConsoleKey.L)
                {
                    Console.WriteLine("here is list");
                }
                else if (chose.Key == ConsoleKey.A)
                {
                    Console.WriteLine("cool");
                }
                else if (chose.Key == ConsoleKey.R)
                {
                    Console.WriteLine("are you sure");
                }
                else
                {
                    Console.WriteLine("you dumb; you really dumb");
                }
            }
        }
    }
}
