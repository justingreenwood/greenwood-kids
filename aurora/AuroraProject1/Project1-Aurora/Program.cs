using System;
using System.ComponentModel.Design;
using System.Threading;

namespace Project1_Aurora
{
    class Program
    {
        static void Main(string[] args)
        {
            BEGINNING:

            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("AURORA'S MANSION");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("  |");
            Console.WriteLine("-------------------");

            Thread.Sleep(1000);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("I invite thee to join me in a game of Insanely Bad Mad Libs: Edition One! You cannot decline!");

            Thread.Sleep(3000);

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Give me a name. I would prefer if you would capitalize it...");

            Console.ForegroundColor = ConsoleColor.Blue;
            var name = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Hm.... How about a number?");

            Console.ForegroundColor = ConsoleColor.Blue;
            var number = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("I would like a plural noun. Do not capitalize.");

            Console.ForegroundColor = ConsoleColor.Blue;
            var pluralnoun = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("I would like an adjective. A capitalized adjective.");

            Console.ForegroundColor = ConsoleColor.Blue;
            var adjective1 = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Another adjective with the same rules.");

            Console.ForegroundColor = ConsoleColor.Blue;
            var adjective2 = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Another one. Capitalized again.");

            Console.ForegroundColor = ConsoleColor.Blue;
            var adjective3 = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("A singular noun, please. Lower-cased.");

            Console.ForegroundColor = ConsoleColor.Blue;
            var noun2 = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Another adjective. Lower-cased.");

            Console.ForegroundColor = ConsoleColor.Blue;
            var adjective4 = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("A body part, and I'd like it plural. Oh, and lower-cased.");

            Console.ForegroundColor = ConsoleColor.Blue;
            var pluralbodypart = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("A verb. Verb examples for tenses: cuddle, walk, smack.");

            Console.ForegroundColor = ConsoleColor.Blue;
            var verb = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Just type whatever comes to mind, but you must capitalize it.");

            Console.ForegroundColor = ConsoleColor.Blue;
            var firstthingthatcomestomind = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("An adverb. Lower-cased.");

            Console.ForegroundColor = ConsoleColor.Blue;
            var adverb = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("A noun. Lower-cased.");

            Console.ForegroundColor = ConsoleColor.Blue;
            var noun3 = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" A plural noun. Lower-cased.");

            Console.ForegroundColor = ConsoleColor.Blue;
            var pluralnoun2 = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Ok, type something random in when you are ready to see the results.");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($" Hello there! My name is {name}, and I'm {number} years old. I have seven younger {pluralnoun} who I usually call Sleepy, Sneezy, {adjective1}, Doc, {adjective2}, {adjective3}, and Grumpy. I also have a pet {noun2}! He has the biggest {adjective4} {pluralbodypart}, and I love to {verb} him! His name is {firstthingthatcomestomind}. I would love to tell you more, but I am {adverb} in need of a new {noun3} because {adjective3} spilled juice from freshly picked {pluralnoun2} on me.");

            Thread.Sleep(30000);

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Would you like to play again? (y or n)");

            Console.ForegroundColor = ConsoleColor.Red;
            var wouldyouliketoplayagain = Console.ReadLine();

            if ((wouldyouliketoplayagain=="y"))
            {
                goto BEGINNING;
            }
             if ((wouldyouliketoplayagain != "y"))
            {
                Console.WriteLine(" Well, you didn't say yes, so this is gong to end!");
            }
        }
    }
}
