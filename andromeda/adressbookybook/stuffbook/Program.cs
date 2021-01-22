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
            var addresslist = new List<Contact>();
            var rows = File.ReadAllLines("AddressBook.txt");
            for (int i = 0; i < rows.Length; i++)
            {
                string row = rows[i];
                var columns = row.Split('~');
                if (columns.Length == 6)
                {
                    var a = new Contact();
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
                    SaveToFile(addresslist);
                }
                else if (chose.Key == ConsoleKey.L)
                {
                    Console.WriteLine("here is list");
                    for (int z = 0; z < addresslist.Count; z++)
                    {
                        var isOdd = ((z % 2) == 1); // The remainder of z / 2
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"____________________________________");
                        if (isOdd) Console.ForegroundColor = ConsoleColor.DarkBlue;
                        else Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine($"({z + 1}) {addresslist[z]}");
                    }
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"____________________________________");

                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (chose.Key == ConsoleKey.A)
                {
                    var aa = new Contact();
                    Console.WriteLine("cool");

                    aa.firstname = AskForInfo("Enter First Name: ");
                    aa.lastname = AskForInfo("Enter Last Name: ");


                    Console.Write("enter street num");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    var an = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    aa.streetnum = an;

                    Console.Write("enter city");
                    var ac = Console.ReadLine();
                    aa.city = ac;

                    Console.Write("enter state");
                    var at = Console.ReadLine();
                    aa.state = at;

                    Console.Write("enter zip");
                    var az = Console.ReadLine();
                    aa.zip = az;

                    addresslist.Add(aa);
                }
                else if (chose.Key == ConsoleKey.R)
                {
                    bool good = true;
                    while (good)
                    {
                        Console.WriteLine("which one");
                        if (int.TryParse(Console.ReadLine(), out int Removed))
                        {
                            if (Removed != 0 && Removed <= (addresslist.Count))
                            {
                                addresslist.RemoveAt(Removed - 1);
                                Console.WriteLine("all gone");
                            }
                            else
                            {
                                Console.WriteLine("okay dokay");
                            }
                            good = false;
                        }
                        else
                        {
                            Console.WriteLine("are you sure");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("you dumb; you really dumb");
                }
            }
        }

        public static string AskForInfo(string question)
        {
            Console.Write(question);
            Console.ForegroundColor = ConsoleColor.Magenta;
            var answer = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            return answer;
        }

        public static void SaveToFile(List<Contact> addresses)
        {
            var lines = new List<string>();
            foreach (var addr in addresses)
            {
                lines.Add(addr.ToFileLineString());
            }

            File.WriteAllLines("AddressBook.txt", lines);
        }
    }
}
