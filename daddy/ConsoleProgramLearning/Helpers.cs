using System;

namespace ConsoleProgramLearning
{
    public class Helpers
    {

        public static string AskStringQuestion(string character, string questionText, ConsoleColor color = ConsoleColor.Blue)
        {
            bool hasAnswer = false;
            string answer = null;
            var oldColor = Console.ForegroundColor;
            var oldBgColor = Console.BackgroundColor;

            while (!hasAnswer)
            {
                ConsoleColor charColor;
                switch (character.ToLower())
                {
                    case "aurora":
                        charColor = ConsoleColor.Magenta;
                        break;
                    case "andromeda":
                        charColor = ConsoleColor.Yellow;
                        break;
                    case "perry":
                        charColor = ConsoleColor.Green;
                        break;
                    default:
                        charColor = ConsoleColor.Cyan;
                        break;

                }

                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = charColor;
                Console.Write(character);
                Console.BackgroundColor = oldBgColor;

                Console.Write(" ");

                Console.ForegroundColor = color;
                Console.Write(questionText);

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("? ");


                Console.ForegroundColor = ConsoleColor.Red;
                answer = Console.ReadLine();

                Console.ForegroundColor = oldColor;

                // not empty, spaces, tabs, newlines or null
                hasAnswer = !string.IsNullOrWhiteSpace(answer);
                if (!hasAnswer) Console.WriteLine("YOU SUCK! Give me an answer!");
            }
            return answer;
        }
    }
}
