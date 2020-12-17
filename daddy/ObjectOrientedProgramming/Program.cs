using System;

namespace ObjectOrientedProgramming
{
    class Program
    {
        private static Random RAND = new Random();

        static void Main(string[] args)
        {
            var player = new Player();
            player.Name = "Justin";

            //var orc = new Orc {
            //    Name = "Jimbo"
            //};

            var keepGoing = true;
            while (keepGoing)
            {
                var monster = GetRandomCharacter();

                ConsoleKeyInfo key;
                do
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"You walk through the forest and meet an/a {monster.GetType().Name} named {monster.Name}.");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"Would you like to (a)ttack, (t)alk or (q)uit? ");
                    Console.ForegroundColor = ConsoleColor.White;
                    key = Console.ReadKey();
                    Console.WriteLine();
                } while (key.Key != ConsoleKey.A && key.Key != ConsoleKey.T && key.Key != ConsoleKey.Q);

                if (key.Key == ConsoleKey.A)
                {
                    monster.Defend(player);
                }
                else if (key.Key == ConsoleKey.T)
                {
                    monster.Talk(player);
                }
                else
                {
                    keepGoing = false;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                if (player.HitPoints <= 0)
                {
                    Console.Write($"You're dead!");
                    keepGoing = false;
                }
                else
                {
                    Console.WriteLine($"You have {player.HitPoints} life left!");
                }
            }

            Console.ReadKey();
        }


        static string[] Names = { "Joe", "Jill", "Aurora", "Bob", "Andromeda", "Perry", "Jack",
                                    "Billy", "Kerry", "Fignewton", "Bologna", "Florian", "BootySpider"};
        static Character GetRandomCharacter()
        {
            Character dude;
            string name = Names[RAND.Next(Names.Length)];

            switch (RAND.Next(4))
            {
                case 0:
                    dude = new Orc();
                    break;
                case 1:
                    dude = new Fairy();
                    break;
                default:
                    dude = new Goblin();
                    break;
            }
            dude.Name = name;
            return dude;
        }
    }
}
