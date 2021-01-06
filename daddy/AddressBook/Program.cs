using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var addresses = LoadAddressesFromFile();
            ConsoleKeyInfo key;
            do {
                Console.Write("Choose [L]ist, a record number or [Q]uit:");
                key = Console.ReadKey();
                Console.WriteLine();

                if (key.Key == ConsoleKey.L)
                {
                    Console.WriteLine("------------------------------------");
                    for (var i=0; i < addresses.Count; i++)
                    {
                        var address = addresses[i];
                        Console.WriteLine($"[{i+1}]");
                        Console.WriteLine(address);
                        Console.WriteLine("------------------------------------");
                    }
                } 
                else if (int.TryParse(key.KeyChar.ToString(), out var mynumber)) 
                {
                    if (mynumber > 0 && mynumber <= addresses.Count)
                    {
                        var address = addresses[mynumber - 1];
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine($"[{mynumber}]***");
                        Console.WriteLine(address);
                        Console.WriteLine("------------------------------------");
                    } else
                    {
                        Console.WriteLine($"There is no address #{mynumber}!");
                    }

                }

            } while (key.Key != ConsoleKey.Q);

            //var fishersResidents = addresses
            //    .Where(addy => addy.City == "Fishers")
            //    .OrderBy(x => x.FirstName).ToList();

            //if (!addresses.Any(addy => addy.FirstName == "Andromeda"))
            //{
            //    addresses.Add(new Address
            //    {
            //        FirstName = "Andromeda",
            //        LastName = "Greenwood",
            //        City = "Indianapolis",
            //        State = "IN",
            //        Email = "andromeda.renee@gmail.com",
            //        Phone = "317-111-1111",
            //        StreetAddress = "11828 Corbin Dr",
            //        ZipCode = "46030"
            //    });
            //}
            //else
            //{
            //    Console.WriteLine("Andi exists...");
            //}

            //run program

            SaveAddressesToFile(addresses);
        }

        public static List<Address> LoadAddressesFromFile()
        {
            var linesArray = File.ReadAllLines("addresses.txt");
            var lines = new List<string>(linesArray);
            var addresses = new List<Address>();

            foreach (var line in lines)
            {
                var address = new Address(line);
                addresses.Add(address);
            }
            return addresses;
        }
        public static void SaveAddressesToFile(List<Address> addresses)
        {
            var lines = new List<string>();
            foreach (var address in addresses)
            {
                lines.Add(address.ToFileString());
            }

            File.WriteAllLines("addresses.txt", lines);
        }
    }
}
