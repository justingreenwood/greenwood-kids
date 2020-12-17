
using System;

namespace ConsoleProgramLearning
{
    class Program
    {
        const string AURORA = "Aurora";
        const string ANDI = "Andromeda";
        const string PERRY = "Perry";

        static void Main(string[] args)
        {
            var answer = Helpers.AskStringQuestion(AURORA, "How are you doing");
            if (answer == "fine") Console.WriteLine("You ARE fine, hot stuff!");
            else Console.WriteLine($"{answer}??? You're lying!");

            answer = Helpers.AskStringQuestion(ANDI, "When can we watch Korean", ConsoleColor.DarkBlue);
            answer = Helpers.AskStringQuestion(PERRY, "Korean is annoying! When can we watch fighting and killing");
            answer = Helpers.AskStringQuestion("Justin", "When do you want to be grounded? Now, or in 1 minute?");
        }
    }
}
