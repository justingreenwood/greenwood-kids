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

                Console.WriteLine("(Q)uit,(S)ave,(L)ist,(A)dd,(R)emove,(E)dit");
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
                    Console.WriteLine("Here is list");
                    for (int z = 0; z < addresslist.Count; z++)
                    {
                        var isOdd = ((z % 2) == 1); // The remainder of z / 2
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"____________________________________");
                        if (isOdd) Console.ForegroundColor = ConsoleColor.DarkBlue;
                        else Console.ForegroundColor = ConsoleColor.DarkGray;
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
                    aa.streetnum = AskForInfo("Enter Street Number: ");
                    aa.city = AskForInfo("Enter City: ");
                    aa.state = AskForInfo("Enter State: ");
                    aa.zip= AskForInfo("Enter Zip Code: ");
                    addresslist.Add(aa);
                }
                else if (chose.Key == ConsoleKey.R)
                {
                    bool good = true;
                    while (good)
                    {
                        Console.WriteLine("Which one");
                        if (int.TryParse(Console.ReadLine(), out int Removed))
                        {
                            if (Removed != 0 && Removed <= (addresslist.Count))
                            {
                                addresslist.RemoveAt(Removed - 1);
                                Console.WriteLine("All gone");
                            }
                            else
                            {
                                Console.WriteLine("Okay Dokay");
                            }
                            good = false;
                        }
                        else
                        {
                            Console.WriteLine("Are you sure");
                        }
                    }
                }
                else if (chose.Key == ConsoleKey.E)
                {
                    Console.WriteLine("What do you want to edit");
                   if (int.TryParse(Console.ReadLine(), out int eor) && eor > 0 && eor <= addresslist.Count)
                   {
                        var changedadress = addresslist[eor - 1];
                        Console.WriteLine("Which part(first name(0),last name(1), street(2), city(3),state(4), zip(5))");
                        var rer = Console.ReadKey();
                        if (rer.Key == ConsoleKey.D0)
                        {
                            Console.WriteLine("Write  first name"); 
                            Console.WriteLine("");
                            var er = Console.ReadLine();
                            changedadress.lastname = (er);
                        }
                        else if (rer.Key == ConsoleKey.D1)
                        {
                            Console.WriteLine("Write last name");
                            Console.WriteLine("");
                            var er = Console.ReadLine();
                            changedadress.firstname = (er);
                        }

                        else if (rer.Key == ConsoleKey.D2)
                        {
                            Console.WriteLine("Write street");
                            Console.WriteLine("");
                            var er = Console.ReadLine();
                            changedadress.streetnum = (er);
                        }
                        else if (rer.Key == ConsoleKey.D3)
                        {
                            Console.WriteLine("Write city");
                            Console.WriteLine("");
                            var er = Console.ReadLine();
                            changedadress.city = (er);
                        }
                        else if (rer.Key == ConsoleKey.D4)
                        {
                            Console.WriteLine("Write state");
                            Console.WriteLine("");
                            var er = Console.ReadLine();
                            changedadress.state = (er);
                        }
                        else if (rer.Key == ConsoleKey.D5)
                        {
                            Console.WriteLine("Write zip");
                            Console.WriteLine("");
                            var er = Console.ReadLine();
                            changedadress.zip = (er);
                        }
                        else
                        {
                            Console.WriteLine("Not valid");
                        }
                   }
                    else
                    {
                        Console.WriteLine("Invalid");
                    }
                }
                else
                {
                    Console.WriteLine("You dumb; you really dumb");
                }
            }
        }

        public static string AskForInfo(string question)
        {
            Console.Write(question);
            Console.ForegroundColor = ConsoleColor.DarkRed;
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
