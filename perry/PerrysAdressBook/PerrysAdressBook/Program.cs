using System;
using System.Collections.Generic;
using System.IO;

namespace PerrysAdressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isrunning = true;
            var addresses = new List<AddressLine>();
            var lines = File.ReadAllLines("Addresses.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                var columns = line.Split('|');
                if (columns.Length == 8)
                {
                    var a = new AddressLine();
                    a.lastname = columns[0].Trim();
                    a.firstname = columns[1].Trim();
                    a.streetaddress = columns[2].Trim();
                    a.city = columns[3].Trim();
                    a.state = columns[4].Trim();
                    a.zipcode = columns[5].Trim();
                    a.phonenumber = columns[6].Trim();
                    a.emailaddress = columns[7].Trim();
                    //Console.WriteLine(lines[i]);
                    addresses.Add(a);
                }
            }
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("                                                     Welcome To");
            Console.WriteLine("                                                   PerrysAdressBook");
            Console.WriteLine("");
            Console.WriteLine("");
            while (isrunning)
            {
                Console.Write("Do you want to (A)dd adress, (R)emove address, (C)hange address, (V)iew all, or (E)xit.   ");
                var key = Console.ReadKey();
                Console.WriteLine("");
                if (key.Key == ConsoleKey.A)
                {
                    var xy = new AddressLine();
                    Console.WriteLine("type in last name");
                    var xz = Console.ReadLine();
                    xy.lastname = xz;
                    Console.WriteLine("type in First name");
                    var xb = Console.ReadLine();
                    xy.firstname = xb;
                    Console.WriteLine("type in street address");
                    var xa = Console.ReadLine();
                    xy.streetaddress = xa;
                    Console.WriteLine("type in city");
                    var xc = Console.ReadLine();
                    xy.city = xc;
                    Console.WriteLine("type in state");
                    var xd = Console.ReadLine();
                    xy.state = xd;
                    Console.WriteLine("type in zipcode");
                    var xe = Console.ReadLine();
                    xy.zipcode = xe;
                    Console.WriteLine("type in phone number");
                    var xf = Console.ReadLine();
                    xy.phonenumber = xf;
                    Console.WriteLine("type in email address");
                    var xg = Console.ReadLine();
                    xy.emailaddress = xg;
                    addresses.Add(xy);

                    SaveToFile(addresses);
                }
                else if (key.Key == ConsoleKey.V)
                {
                    for (int i = 0; i < addresses.Count; i++)
                    {
                        Console.WriteLine($"({i+1}) {addresses[i]}");
                    }
                }
                else if (key.Key == ConsoleKey.E)
                {
                    isrunning = false;
                }
                else if (key.Key == ConsoleKey.R)
                {
                        Console.Write("Which would you like to remove?  ");
                        if (int.TryParse(Console.ReadLine(), out int Removed))
                        { 
                                    addresses.RemoveAt(Removed - 1);
                                    SaveToFile(addresses);  
                        }
                        else
                        {
                            Console.WriteLine("That is not a number, IDIOT!");
                        } 
                }
                else if (key.Key == ConsoleKey.C)
                {
                    Console.Write("Which would you like to change?  ");
                    if (int.TryParse(Console.ReadLine(), out int Changed))
                    {
                        Console.Write("First name(1), last name(2), street addres(3), city(4), state(5), zipcode(6), phone number(7), or email address(8)? ");
                        var v = Console.ReadKey();
                        Console.WriteLine();
                        if (v.Key == ConsoleKey.D1)
                        {
                            var fart = addresses[Changed - 1];
                            Console.Write("Type in first name. ");
                            var stupid = Console.ReadLine();
                            fart.firstname = (stupid);
                        }
                        else if(v.Key == ConsoleKey.D2)
                        {
                            var fart = addresses[Changed - 1];
                            Console.Write("Type in last name. ");
                            var stupid = Console.ReadLine();
                            fart.lastname = (stupid);
                        }
                        else if (v.Key == ConsoleKey.D3)
                        {
                            var fart = addresses[Changed - 1];
                            Console.Write("Type in street address. ");
                            var stupid = Console.ReadLine();
                            fart.streetaddress = (stupid);
                        }
                        else if (v.Key == ConsoleKey.D4)
                        {
                            var fart = addresses[Changed - 1];
                            Console.Write("Type in city. ");
                            var stupid = Console.ReadLine();
                            fart.city = (stupid);
                        }
                        else if (v.Key == ConsoleKey.D5)
                        {
                            var fart = addresses[Changed - 1];
                            Console.Write("Type in state. ");
                            var stupid = Console.ReadLine();
                            fart.state = (stupid);
                        }
                        else if (v.Key == ConsoleKey.D6)
                        {
                            var fart = addresses[Changed - 1];
                            Console.Write("Type in zipcode. ");
                            var stupid = Console.ReadLine();
                            fart.zipcode = (stupid);
                        }
                        else if (v.Key == ConsoleKey.D7)
                        {
                            var fart = addresses[Changed - 1];
                            Console.Write("Type in phone number. ");
                            var stupid = Console.ReadLine();
                            fart.phonenumber = (stupid);
                        }
                        else if (v.Key == ConsoleKey.D8)
                        {
                            var fart = addresses[Changed - 1];
                            Console.Write("Type in email address. ");
                            var stupid = Console.ReadLine();
                            fart.emailaddress = (stupid);
                        }
                        else
                        {
                            Console.WriteLine("That is not valid.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("That is not a number, STUPID!");
                    }
                }
                else
                {
                    Console.WriteLine("That is not valid.");
                }
            }
        }

        public static void SaveToFile(List<AddressLine> addresses)
        {
            var lines = new List<string>();
            foreach (var addr in addresses)
            {
                lines.Add(addr.ToFileLineString());
            }

            File.WriteAllLines("Addresses.txt", lines);
        }
    }
}
