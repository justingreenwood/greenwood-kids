using System;

namespace CLI.Learning
{
    class Program
    {   
        static void Main(string[] args)
        {
            Console.Write("Experiment 1: Move box around screen with keyboard and fill screen. (Press ESC to quit)");
            Console.ReadKey();
            Console.Clear();
            MoveObjectAroundConsoleWithArrows.Run();
            Console.Clear();


            Console.Write("Experiment 2: GameLoop Listening (Press ESC to quit)");
            Console.ReadKey();
            Console.Clear();
            GameLoop.Run();
        }
    }
}
