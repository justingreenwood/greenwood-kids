using System;
using System.Collections.Generic;

namespace TextAdventure
{
    public class CommandProcessor
    {
        public void ReadCommand(Player p)
        {
            Console.WriteLine();

            var isValid = false;
            while (!isValid)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("What would you like to do? ");
                Console.ForegroundColor = ConsoleColor.Green;
                var line = Console.ReadLine();

                if (line.StartsWith("enter "))
                {
                    var noun = line.Substring(6);
                    foreach (var connectingRoom in p.CurrentRoom.Connections)
                    {
                        if (connectingRoom.IsMatchingName(noun))
                        {
                            p.CurrentRoom = connectingRoom;
                            isValid = true;
                            break;
                        }
                    }
                }
                else if (line.StartsWith("look "))
                {
                    var noun = line.Substring(5);
                    foreach (var thing in p.CurrentRoom.ThingsInTheRoom)
                    {
                        if (thing.IsMatchingName(noun))
                        {
                            if(thing.HasBeenOpened == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(thing.Name);
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine(thing.HasNotBeenOpenedDescription);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(thing.Name);
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine(thing.Description);
                                Console.Write("Things inside: ");
                                var first = true;
                                foreach (var stuffInThing in thing.Things)
                                {
                                    stuffInThing.HasBeenLookedAt = true;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    if (!first) Console.Write($", ");
                                    Console.Write($"{stuffInThing.Name}");
                                    first = false;
                                }
                            }
                           
                            isValid = true;
                            break;
                        }
                    }
                }
                else if (line.StartsWith("get ") || line.StartsWith("take ") || line.StartsWith("pick up "))
                {
                    string noun = null;
                    if (line.StartsWith("pick up "))
                        noun = line.Substring(8);
                    else
                        noun = line.Substring(line.IndexOf(' ')+1);

                    LookForThingsToPickUp(noun, p, p.CurrentRoom.ThingsInTheRoom);
                    isValid = true;
                }
                else if (line == "inventory" || line == "i")
                {
                    if (p.Inventory.Count == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You have absolutely nothing!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        Console.WriteLine("Inventory: ");
                        foreach (var thing in p.Inventory)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(thing.Name + " ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(thing.Description);
                        }
                    }
                    isValid = true;
                }
                else if (line == "use")
                {
                    //use x with y
                }
                else if (line.StartsWith("consume "))
                {
                    var noun = line.Substring(8);
                    foreach (var i in p.Inventory)
                    {

                        if (i.IsMatchingName(noun))
                        {

                            if (!i.CanBeConsumed)
                            { 
                                Console.WriteLine($"{noun} is not edible");
                            }
                            else
                            {                                
                                p.Inventory.Remove(i);
                                Console.WriteLine($"{noun}  has been consumed.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"I don't know what '{line}' means.");
                        }
                        isValid = true;
                        break;
                    }

                }
                else if (line.StartsWith("open "))
                {
                    var noun = line.Substring(5);
                    foreach (var i in p.CurrentRoom.ThingsInTheRoom)
                    {

                        if (i.IsMatchingName(noun))
                        {

                            if(!i.HasBeenOpened)
                            {
                                i.HasBeenOpened = true;
                                Console.WriteLine($"{noun} is open");
                            }
                            else
                            {
                                Console.WriteLine($"{noun} is already open.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"I don't know what '{line}' means.");
                        }
                        isValid = true;
                        break;
                    }
                }
                else if (line == "quit")
                {
                    p.IsReadyToQuit = true;
                    isValid = true;
                }
                
                if (!isValid)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"I don't know what \"{line}\" means.");
                }
            }
        }

        private void LookForThingsToPickUp(string noun, Player p, List<Thing> things)
        {
            for (var i = things.Count - 1; i >= 0; i--)
            {
                var thing = things[i];
                if (!thing.IsMatchingName(noun))
                {
                    LookForThingsToPickUp(noun, p, thing.Things);
                }
                else
                {
                    if (!thing.HasBeenLookedAt)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"You haven't seen that yet.");
                    }
                    else if (!thing.CanBeTaken)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write($"You can't pick up: ");
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine(thing.Name);
                    }
                    else
                    {
                        p.CurrentRoom.ThingsInTheRoom.Remove(thing);
                        p.Inventory.Add(thing);

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write($"You picked up: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(thing.Name);
                    }
                }
            }
        }
    }
}
