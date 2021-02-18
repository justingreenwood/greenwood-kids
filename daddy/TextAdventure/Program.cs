using System;
using System.Collections.Generic;

namespace TextAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new CommandProcessor();
            var bathroom = new Room
            {
                Name = "Bathroom",
                Description = "It's a bathroom. You poop here."
            };

            bathroom.ThingsInTheRoom.Add(new Thing
            {
                Name = "Bottle of Water",
                Description = "This is a complementary bottle of water this hotel usually provides guests.",
                Synonyms = new List<string>
                {
                    "bottle", "water"
                }
            });
            bathroom.ThingsInTheRoom.Add(new Thing
            {
                Name = "Stinky Pile",
                Description = "It looks like someone missed the toilet.",
                CanBeTaken = false,
                Synonyms = new List<string>
                {
                    "pile", "poop", "stinky"
                }
            });

            var hotel = new Room();
            hotel.Name = "Hotel Suite";
            hotel.Description = "You find yourself in a small hotel room. There is a window and luggage on the ground.";
            hotel.ThingsInTheRoom.Add(new Thing
            {
                Name = "Luggage",
                CanBeTaken = false,
                Description = "It's your stuff! Your wallet is in there.",
                Things = new List<Thing>
                {
                    new Thing
                    {
                        Name = "Wallet",
                        CanBeTaken = false,
                        Description = "This appears to be your wallet.",
                        Things = new List<Thing>
                        {
                            new Thing
                            {
                                Name = "key",
                              Description="Look a key.",
                            }
                        }
                    }
                }
            });
            var closet = new Room
            {
                Name = "Closet",
                Description = "WOW! A big closet."
            };
            closet.ThingsInTheRoom.Add(new Thing
            {
                Name = "A mug",
                Description = "Thats where I left my mug.",
                Synonyms = new List<string>
                {
                    "cup", "glass"
                }
            });
            closet.ThingsInTheRoom.Add(new Thing
            {
                Name = "box",
                Description = "You need a key.",
                CanBeTaken = false,
                Synonyms = new List<string>
                {
                    "chest"
                }
            });
            hotel.Connections.Add(bathroom);
            bathroom.Connections.Add(hotel);

            var playerJoe = new Player();
            playerJoe.CurrentRoom = hotel;

            // intro text
            Console.WriteLine("Welcome to the text adventure.");
            Console.WriteLine("You wake up with a pounding headache.");

            // Game Loop
            while (!playerJoe.IsReadyToQuit)
            {
                Console.WriteLine();
                DrawLine("=");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(playerJoe.CurrentRoom.Name);
                DrawLine("_/\\_", 25);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(playerJoe.CurrentRoom.Description);
                Console.Write("Items in the room include: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var thing in playerJoe.CurrentRoom.ThingsInTheRoom)
                {
                    Console.Write($"{thing.Name} ");
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Connecting Rooms: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var rm in playerJoe.CurrentRoom.Connections)
                {
                    Console.Write($"{rm.Name} ");
                }
                Console.WriteLine();
                DrawLine("=");

                processor.ReadCommand(playerJoe);

            }
        }

        private static void DrawLine(string c = "-", int count = 100, ConsoleColor color = ConsoleColor.White)
        {
            var tmp = Console.ForegroundColor;
            Console.ForegroundColor = color;
            for (var i=0; i< count; i++)
            {
                Console.Write(c);
            }
            Console.WriteLine();
            Console.ForegroundColor = tmp;
        }
    }
}
