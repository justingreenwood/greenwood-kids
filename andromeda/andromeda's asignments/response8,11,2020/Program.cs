using System;
using System.Drawing;
using System.Reflection;
using System.Threading;

namespace response8_11_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            start:
            Console.WriteLine("                                                  Personalized Response");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");
            var name = ReadString("What is your name? ", ConsoleColor.Yellow);
            var gender = ReadString("Are you male or female (m/f)?", ConsoleColor.Green);
            if (gender == "m")
                gender = "Mr. ";
            else if (gender == "f")
                gender = "Miss ";
            else
                gender = "";
            int age = ReadInteger("How old are you? ", ConsoleColor.Blue);
            string ageDescription;
            if (age <= 1)
                ageDescription = "a baby";
            else if (age >= 2 && age <= 12)
                ageDescription = "a child";
            else if (age >= 13 && age <= 19)
                ageDescription = "a teen";
            else if (age >= 20 && age <= 25) // && - Logical AND, || - Logical OR
                ageDescription = "a young adult";
            else if (age >= 26 && age <= 35)
                ageDescription = "an adult";
            else if (age >= 36 && age <= 79)
                ageDescription = "middle aged";
            else
                ageDescription = "old";
            int weight = ReadInteger("How much do you weigh? ", ConsoleColor.DarkMagenta);
            string weightDescription;
            if (weight >= 70 && weight <= 80)
                weightDescription = "skinny";
            else if (weight >= 81 && weight <= 130)
                weightDescription = "normal";
            else if (weight >= 131 && weight <= 205)
                weightDescription = "fat";
            else
                weightDescription = "unhealthy";
            Console.WriteLine(""); 
            Console.WriteLine($"Hello {gender}{name}, you are {ageDescription} and {weightDescription}."); 
            Console.WriteLine("");
        askquestion: 
            Console.WriteLine("Would you like to play again? (y/n)");
           var answer = Console.ReadLine();
            if (answer == "y")
                goto start;
            else if(answer == "n")
              Console.WriteLine($"bye, {name}");
            else
                goto askquestion;
        }

        public static int ReadInteger(string question, ConsoleColor color = ConsoleColor.White)
        {
            var originalColor = Console.ForegroundColor;
            string answer;
            int answerAsInteger;
            do
            {
                Console.ForegroundColor = color;
                Console.Write(question);
                Console.ForegroundColor = originalColor;
                answer = Console.ReadLine();
            } while (int.TryParse(answer, out answerAsInteger) == false);
            return answerAsInteger;
        }
        public static string ReadString(string question, ConsoleColor color = ConsoleColor.White)
        {
            var originalColor = Console.ForegroundColor;
            string answer;
            do
            {
                Console.ForegroundColor = color;
                Console.Write(question);
                Console.ForegroundColor = originalColor;
                answer = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(answer));
            return answer;
        }
    }
}
