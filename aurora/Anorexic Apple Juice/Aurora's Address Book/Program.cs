using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aurora_s_Address_Book
{
    class Program
    {
        //All of it works amazingly well as far as I can tell.
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            
            Console.WriteLine("                                                 RANDOM PROGRAMMING AND WHATEVER ELSE!");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Black;
            var addresses = GrabAddresses();

            ConsoleKeyInfo KeY;
            do
            {
                Console.Write("Choose [L]ist, [E]dit, [A]dd, [D]elete, [S]ave, or type a record number or [Q]uit:");
                KeY = Console.ReadKey();
                Console.WriteLine();
                if (KeY.Key == ConsoleKey.L)
                {
                    ShowList(addresses);
                }
                else if (KeY.Key == ConsoleKey.E)
                {
                    EditAddress.Edit(addresses);
                }
                else if (KeY.Key == ConsoleKey.A)
                {
                    Add(addresses);
                }
                else if (KeY.Key == ConsoleKey.D)
                {
                    Delete(addresses);
                }
                else if (KeY.Key == ConsoleKey.S)
                {
                    SaveTheAddresses(addresses);
                }
                else if (int.TryParse(KeY.KeyChar.ToString(), out var TacoBell))
                {
                    if (TacoBell > 0 && TacoBell <= addresses.Count)
                    {
                        var address = addresses[TacoBell - 1];
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine($"[{TacoBell}]***");
                        Console.WriteLine(address);
                        Console.WriteLine("------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine($"There is no {TacoBell}! What kind of an idiot do you think I am?!");
                    }

                }

            } while (KeY.Key != ConsoleKey.Q);
        }

        public static void Add(List<Address> addresses)
        {

            var newAddresses = new Address();

            Console.WriteLine(" What is the person's name? ( Sorted last name, first name middle name )");
            var AddName = Console.ReadLine();
            newAddresses.NAME = AddName;

            Console.WriteLine(" What is this person's house number and street?");
            var AddHomeAddress = Console.ReadLine();
            newAddresses.Address1 = AddHomeAddress;

            Console.WriteLine("What city/town, state, and zip code?");
            var AddCSZ = Console.ReadLine();
            newAddresses.CityStateZip = AddCSZ;

            Console.WriteLine(" What is this person's email address?");
            var AddEmail = Console.ReadLine();
            newAddresses.Email = AddEmail;

            Console.WriteLine(" May I have an occupation for this person?");
            var AddJob = Console.ReadLine();
            newAddresses.Occupation = AddJob;

            Console.WriteLine(" May I have this person's phone number?");
            var AddNumber = Console.ReadLine();
            newAddresses.Phone = AddNumber;

            addresses.Add(newAddresses);

        }

        public static void Delete(List<Address> addresses)
        {
            Console.Write("Type a record number to delete: ");
            var numAsString = Console.ReadLine();
            if (int.TryParse(numAsString, out var TacoBell))
            {
                if (TacoBell > 0 && TacoBell <= addresses.Count)
                {
                    addresses.RemoveAt(TacoBell-1);
                }
            }
        }

        public static void ShowList(List<Address> addresses)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("------------------------------------");
            for (var i = 0; i < addresses.Count; i++)
            {
                var address = addresses[i];
                Console.WriteLine($"[{i + 1}]");
                Console.WriteLine(address);
                Console.WriteLine("------------------------------------");

            }
            Console.ForegroundColor = ConsoleColor.Black;
        }

        
        public static void SaveTheAddresses(List<Address> addresses)
        {
            var lines = new List<string>();
            foreach (var address in addresses)
            {
                lines.Add(address.ToFileString());
            }

            File.WriteAllLines("MyAddresses.txt", lines);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Saving....");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Saving complete!");
            Console.ForegroundColor = ConsoleColor.Black;
        }

        static List<Address> GrabAddresses()
            {
                var linesArray = File.ReadAllLines("MyAddresses.txt");
                var lines = new List<string>(linesArray);
                var addresses = new List<Address>();

                foreach (var line in lines)
                {
                    var address = new Address(line);
                    addresses.Add(address);
                }
                return addresses;
            }

            }


         }
    
