using System;

namespace MathFarts
{
    class Program
    {
        const int NumberOfProblems = 20;
        static Random rand = new Random();

        static void Main(string[] args)
        {
            int fart = NumberOfProblems;
            int mistakes = 0;
            while (true)
            {
                var an = rand.Next(15);
                var bn = rand.Next(15);

                int answer;
                string textAnswer;
                do {
                    Console.Write($"What is {an} * {bn}? ");
                    textAnswer = Console.ReadLine();
                } while (!int.TryParse(textAnswer, out answer));

                if (answer != an * bn)
                {
                    Console.WriteLine("You are an idiot.");
                    mistakes++;
                }
                fart--;
                if (fart == 0)
                    break;

            }
            var score = (double)(NumberOfProblems - mistakes) / NumberOfProblems;
            Console.WriteLine($"You got {score.ToString("P")}");
        }
    }
}
