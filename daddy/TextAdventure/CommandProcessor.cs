using System;

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
                        if (connectingRoom.Name.Equals(noun, StringComparison.InvariantCultureIgnoreCase))
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
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(thing.Name);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(thing.Description);
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

                    for (var i= p.CurrentRoom.ThingsInTheRoom.Count-1; i >= 0; i--)
                    {
                        var thing = p.CurrentRoom.ThingsInTheRoom[i];
                        
                        if (thing.IsMatchingName(noun))
                        {
                            if (!thing.CanBeTaken)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write($"You can't pick up: ");
                                Console.ForegroundColor = ConsoleColor.Red;
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
                            isValid = true;
                            break;
                        }
                    }
                }
                else if (line == "inventory" || line == "i")
                {
                    if (p.Inventory.Count == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Your inventory is EMPTY!");
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
    }
}
