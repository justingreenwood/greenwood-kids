using System;

namespace DadsProjects.Monsters
{
    public class Monster
    {
        private static Random rand = new Random();
        public static ConsoleColor GetRandomColor()
        {
            return (ConsoleColor)(rand.Next(15) + 1);
        }

        public static void WriteCoolCrap(string myName)
        {
            var currentColor = Console.ForegroundColor;
            foreach (var letter in myName)
            {
                Console.ForegroundColor = GetRandomColor();
                Console.Write(letter);
            }
            Console.ForegroundColor = currentColor;
        }
    }
}
