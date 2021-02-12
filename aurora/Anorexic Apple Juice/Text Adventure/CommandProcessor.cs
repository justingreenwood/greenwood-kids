using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Adventure
{
    class CommandProcessor
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
                        if (thing.Name.Equals(noun, StringComparison.InvariantCultureIgnoreCase))
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
                else if (line == "quit")
                {
                    p.IsReadyToQuit = true;
                    isValid = true;
                }
                else if (line=="take")
                {
                   //I'll figure out how to work with that later, but I find that this is necessary for the game to flow.
                }
                else if (line=="help")
                {
                   //Also will have to remember how to do THIS!
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"I don't know what \"{line}\" means.");
                }
            }
        }
    }
}

