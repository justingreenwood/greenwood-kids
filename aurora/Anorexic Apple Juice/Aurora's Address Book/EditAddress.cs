using System;
using System.Collections.Generic;
using System.Text;

namespace Aurora_s_Address_Book
{
    public class EditAddress
    {
        public static void Edit(List<Address> addresses)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Type a record number to edit: ");
            var numAsString = Console.ReadLine();
            if (int.TryParse(numAsString, out var TacoBell))
            {
                if (TacoBell > 0 && TacoBell <= addresses.Count)
                {
                    var address = addresses[TacoBell - 1];
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine($"[{TacoBell}]***");
                    Console.WriteLine(address);
                    ConsoleKeyInfo ChangeWhat;
                    do
                    {
                        Console.WriteLine("------------------------------------");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("What do you want to change?");
                        Console.WriteLine(" [N]ame");
                        Console.WriteLine(" [A]ddress");
                        Console.WriteLine(" [O]ccupation");
                        Console.WriteLine(" [P]hone Number");
                        Console.WriteLine(" [C]ity State Zip");
                        Console.WriteLine(" [E]-mail Address");
                        Console.WriteLine(" [Q]uit");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        ChangeWhat = Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.Black;
                        if (ChangeWhat.Key == ConsoleKey.N)
                        {
                            Console.WriteLine("!");
                            Console.WriteLine("Would you mind just typing the name in. Don't forget that it MUST be sorted by last comma first middle.");
                            var newName = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(newName))
                            {
                                Console.WriteLine(" Nothing is changed because you didn't put in a name!");
                            }
                            else
                            {
                                address.NAME = newName;
                                Console.WriteLine(" If it is sorted incorrectly, you will pay!");
                            }
                        }
                        else if (ChangeWhat.Key == ConsoleKey.A)
                        {
                            Console.WriteLine("!");
                            Console.WriteLine("UGH! TELL ME WHAT IT IS SUPPOSED TO BE THEN?!");
                            var NewHouseAddress = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(NewHouseAddress))
                            {
                                Console.WriteLine(" You didn't tell me what it was supposed to be! For that, you are expelled!");
                            }
                            else
                            {

                                address.Address1 = NewHouseAddress;
                                Console.WriteLine(" THANK YOU!");

                            }

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
                            var NewJob = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(NewJob))
                            {
                                Console.WriteLine(" Either you have no brain or you're messing with me.");
                            }
                            else
                            {
                                address.Occupation = NewJob;
                                Console.WriteLine("Alright, I will put that into the system.");
                            }
                        }
                        else if (ChangeWhat.Key == ConsoleKey.P)
                        {
                            Console.WriteLine("!");
                            Console.WriteLine("I apologize for the inconvenience I must have caused for you. What is the correct phone number?");
                            var NewNumber = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(NewNumber))
                            {
                                Console.WriteLine("I know where your family lives. Do not test me!");
                            }
                            else
                            {
                                address.Phone = NewNumber;
                                Console.WriteLine("Right away, sire.");
                            }
                        }
                        else if (ChangeWhat.Key == ConsoleKey.E)
                        {
                            Console.WriteLine("!");
                            Console.WriteLine("I was sure that that was the correct e-mail address... Well, maybe I was wrong. What is the e-mail address? And, please, do tell me quickly, I am on a time limit.");
                            var NewEmail = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(NewEmail))
                            {
                                Console.WriteLine("You test my patience.");
                            }
                            else
                            {
                                address.Email = NewEmail;
                                Console.WriteLine("Oh, alright.");
                            }
                        }
                        else if (ChangeWhat.Key == ConsoleKey.C)
                        {
                            Console.WriteLine("!");
                            Console.WriteLine("There must be a typo somewhere. Well, don't fret. Just type in the correct city, state, and zip code.");
                            var NewCityStateZip = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(NewCityStateZip))
                            {
                                Console.WriteLine("Of course, you changed your mind.");
                            }
                            else
                            {
                                address.CityStateZip = NewCityStateZip;
                                Console.WriteLine("I thank you for your co-operation during this time. Have a fabulicious day.");
                            }
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
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"There is no {TacoBell}! What kind of an idiot do you think I am?!");
                }
            }
        }
    }
}
