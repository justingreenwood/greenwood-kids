
using System;
using System.IO;

namespace MadLifeFromFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            //var files = Directory.GetFiles(".");
            var files = Directory.GetFiles(@".", "madlibs*.txt");
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {files[i]}: ");
            }
            Console.Write($"Choose! ");
            var choice = Convert.ToInt32(Console.ReadKey().KeyChar.ToString());

            var file = files[choice - 1];

            Console.WriteLine();

            var myStory = File.ReadAllText(file);

            var fragments = myStory.Split('^');


            var isBoy = true;
            for (int i = 0; i < fragments.Length; i++)
            {
                var isWordToAskFor = ((i % 2) == 0);
                if (!isWordToAskFor)
                {
                    
                    Console.Write($"Please enter a {fragments[i]}: ");
                    var answer = Console.ReadLine();
                    if (fragments[i] == "(boy or girl)" && answer == "girl")
                        isBoy = false;

                    fragments[i] = answer;
                }
            }

            var j = 0;
            foreach (var fragment in fragments)
            {
                var copy = fragment;
                var isStoryText = ((j % 2) == 0);
                if (isStoryText)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;

                    copy = copy.Replace("*he*", isBoy ? "he" : "she");

                    if (isBoy) 
                        copy = copy.Replace("*his*", "his");
                    else 
                        copy = copy.Replace("*his*", "her");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.Write(copy);

                j++;
            }

            Console.ReadKey();
        }
    }
}
