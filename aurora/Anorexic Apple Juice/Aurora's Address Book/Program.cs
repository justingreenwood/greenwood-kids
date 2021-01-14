using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aurora_s_Address_Book
{
    class Program
    {
        static void Main(string[] args)
        {
            var addresses = GrabAddresses();

            ConsoleKeyInfo KeY;
            do
            {
                Console.Write("Choose [L]ist, [E]dit, or type a record number or [Q]uit:");
                KeY = Console.ReadKey();
                Console.WriteLine();
                if (KeY.Key == ConsoleKey.L)
                {
                    Console.WriteLine("------------------------------------");
                    for (var i = 0; i < addresses.Count; i++)
                    {
                        var address = addresses[i];
                        Console.WriteLine($"[{i + 1}]");
                        Console.WriteLine(address);
                        Console.WriteLine("------------------------------------");
                    }
                }
                if (KeY.Key == ConsoleKey.E)
                {
                    Console.Write("Type a record number to edit: ");
                    var numAsString = Console.ReadLine();
                    if (int.TryParse(numAsString, out var TacoBell))
                    {
                        if (TacoBell > 0 && TacoBell <= addresses.Count)
                        {
                            var address = addresses[TacoBell - 1];
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine($"[{TacoBell}]***");
                            Console.WriteLine(address);
                            ConsoleKeyInfo ChangeWhat;
                            do
                            {
                                Console.WriteLine("------------------------------------");
                                Console.WriteLine("What do you want to change?");
                                Console.WriteLine(" [N]ame");
                                Console.WriteLine(" [A]ddress");
                                Console.WriteLine(" [O]ccupation");
                                Console.WriteLine(" [P]hone Number");
                                Console.WriteLine(" [C]ity State Zip");
                                Console.WriteLine(" [E]-mail Address");
                                Console.WriteLine(" [Q]uit");
                                ChangeWhat = Console.ReadKey();
                                if (ChangeWhat.Key == ConsoleKey.N)
                                {
                                    Console.WriteLine("!");
                                    Console.WriteLine("Would you mind just typing the name in. Don't forget that it MUST be sorted by last comma first middle.");
                                    Console.ReadLine();
                                    Console.WriteLine(" If it is sorted incorrectly, you will pay!");
                                }
                                else if (ChangeWhat.Key == ConsoleKey.A)
                                {
                                    Console.WriteLine("!");
                                    Console.WriteLine("What should the address be?");
                                    Console.ReadLine();
                                    Console.WriteLine(" Oh, ok!");
                                    //Tomorrow, I will have to ask my dad to explain more!
                                }
                                else if (ChangeWhat.Key == ConsoleKey.Q)
                                {
                                    Console.WriteLine("!");
                                    Console.WriteLine("Quitting in process......");
                                }
                                else if (ChangeWhat.Key == ConsoleKey.O) 
                                {
                                    Console.WriteLine("!");
                                    Console.WriteLine("I'm sorry. What is this person's real occupation?");
                                    Console.ReadLine();
                                    Console.WriteLine("Alright, I will put that into the system.");
                                }
                                else if (ChangeWhat.Key == ConsoleKey.P)
                                {
                                    Console.WriteLine("!");
                                    Console.WriteLine("I apologize for the inconvenience I must have caused for you. What is the correct phone number?");
                                    Console.ReadLine();
                                    Console.WriteLine("Right away, sire.");
                                }
                                else if (ChangeWhat.Key == ConsoleKey.E)
                                {
                                    Console.WriteLine("!");
                                    Console.WriteLine("I was sure that that was the correct e-mail address... Well, maybe I was wrong. What is the e-mail address?");
                                    Console.ReadLine();
                                    Console.WriteLine("Oh, alright.");
                                }
                                else if (ChangeWhat.Key == ConsoleKey.C)
                                {
                                    Console.WriteLine("!");
                                    Console.WriteLine("There must be a typo somewhere. Well, don't fret. Just type in the correct city, state, and zip code.");
                                    Console.ReadLine();
                                    Console.WriteLine("I thank you for your co-operation during this time. Have a fabulicious day.");
                                }
                                else
                                {
                                    Console.WriteLine("!");
                                    Console.WriteLine("Either you are testing my patience, or you have the brain of a sun-addled bullfrog during mating season!");
                                }
                            } while (ChangeWhat.Key != ConsoleKey.Q);
                        }
                        else
                        {
                            Console.WriteLine($"There is no {TacoBell}! What kind of an idiot do you think I am?!");
                        }
                    }
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

            SaveTheAddresses(addresses);
        }
        public static void SaveTheAddresses(List<Address> addresses)
        {
            var lines = new List<string>();
            foreach (var address in addresses)
            {
                lines.Add(address.ToFileString());
            }

            File.WriteAllLines("addresses.txt", lines);
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
    
