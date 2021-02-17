using System;

namespace Text_Adventure
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new CommandProcessor();
            var bathroom = new Room
            {
                Name = "Bathroom",
                Description = "It's a compacted version of the one you have at home."
                
            };

            bathroom.ThingsInTheRoom.Add(new Thing
            {
                Name = "Bottle of Water",
                Description = "This is a complementary bottle of water this hotel usually provides guests.",
                issmackable = false,
                isliftable = true
                
                
            });
            bathroom.ThingsInTheRoom.Add(new Thing
            {
                Name = "Stinky Pile",
                Description = "It looks like someone missed the toilet, and there is some sort of container sitting in it.",
                isliftable = false,
                issmackable = false,
                falsedescription = "Yuck! That would be gross."
            });
            bathroom.ThingsInTheRoom.Add(new Thing
            {
                Name = "Aspirin",
                Description = "A half-full bottle of aspirin has fallen off the counter and is in the Stinky Pile.",
                isliftable = false,
                issmackable = false,
                falsedescription = "I need something to get it out without my hands getting dirty."
            });
            bathroom.ThingsInTheRoom.Add(new Thing
            {
                Name = "Aurora",
                Description = "A hissing creature in the corner.",
                isliftable = false,
                issmackable = true
            }) ;

            var hotel = new Room();
            hotel.Name = "Hotel Suite";
            hotel.Description = "You find yourself in a small hotel room. There is a window and luggage on the ground.";
            hotel.ThingsInTheRoom.Add(new Thing
            {
                Name = "Luggage",
                Description = "It's your stuff!",
                isliftable = false,
                issmackable = false,
                falsedescription = "It is too heavy."
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(playerJoe.CurrentRoom.Name);
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

                processor.ReadCommand(playerJoe);
            }
        }
    }
}
