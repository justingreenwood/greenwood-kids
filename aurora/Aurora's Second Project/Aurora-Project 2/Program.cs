using System;
using System.Drawing;

namespace Aurora_Project_2
{
    class Program
    {
        static void Main(string[] args)
        {
            BEGINNING:
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine("Give me one of the recognized colors on the rainbow:");
            var Color = Console.ReadLine();

            switch (Color)
            {
                case "red":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" Red is a warm color, that is used to symbolize anger in most cases. Blood is red, though it turns a different color when it dries. The opposite of red is green. Red is one of the primary colors.");
                    break;
                case "orange":
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(" Orange is a warm color. Nothing rhymes with orange, and oranges are orange. The opposite of orange is blue.");
                    break;
                case "yellow":
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" Some types of daisies are yellow, and sunflowers are yellow. Yellow is one of the primary colors, and its opposite is purple. It is a warm color. ");
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(" Green's opposite is red. Grass, leaves, Dad's eyes, and celery are all green. Green sometimes symbolizes life or illness.");
                    break;
                case "blue":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(" People sometimes say water is blue, but it is technically clear. Blue is the color of some people's eyes, sort of blueberries, some flowers, and it is the color of very cold fingers. Blue is the opposite of orange. It is one of the primary colors. Blue usually is used to symbolize cold, sadness, or an extreme calm.");
                    break;
                case "indigo":
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(" Indigo is a dark blueish-purple. I would probably say that the opposite of this color is a very mellow yellow. Indigo is the color of some types of flower.");
                    break;
                case "violet":
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine(" Violet is a pale-ish slightly blueish purple, though it is generally well balanced in its red and blue content. The opposite would probably be a medium yellow. Violets are violet. Violet also makes a fantastic girl name.");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"What you typed in, which was {Color}, is not an acceptable answer. If you think that that is a legal color in the rainbow, think again.");
                    break;
            }
            Console.ReadKey();

            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Would you like to play again? (y or n)");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            var wouldyouliketoplayagain = Console.ReadLine();

            if ((wouldyouliketoplayagain == "y"))
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
