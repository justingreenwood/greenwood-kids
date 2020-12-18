using System;

namespace If_There_Was_A_Dime_For_Every__insert_
{
    class Program
    {
        static void Main(string[] args)
        {
            var CHEX = 10;
            var MIX = 10;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Multiplication Table");

            Console.ForegroundColor = ConsoleColor.White;

            for (var FreeToBe = 1; FreeToBe <= CHEX; FreeToBe++) Console.Write("----");
            Console.WriteLine();

            var SERIOUSLY = 1;

            //Console.ForegroundColor = ConsoleColor.Red;

            for (SERIOUSLY = 1; SERIOUSLY <= MIX; SERIOUSLY++)
            {
                var ISuckAtMakingVariables = 1;
                for (ISuckAtMakingVariables = 1; ISuckAtMakingVariables <= CHEX; ISuckAtMakingVariables++)
                {
                    var answer = (ISuckAtMakingVariables * SERIOUSLY).ToString().PadLeft(3);
                    Console.Write($"|{answer}|");
                }

                Console.WriteLine("");
            }
            Console.ForegroundColor = ConsoleColor.White;
            for (var FreeToBe = 1; FreeToBe <= CHEX; FreeToBe++) Console.Write("----");

            Console.ForegroundColor = ConsoleColor.DarkGray;
        }
    }
}
