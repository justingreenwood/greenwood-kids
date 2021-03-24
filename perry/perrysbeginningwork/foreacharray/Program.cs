using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foreacharray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] scores = new int[10];
            string[] names = new string[10];
            scores[0] = 99;
            int fourthscore = scores[3];
            int[] Score = new[] { 100, 95, 92, 87, 55, 50, 48, 40, 35, 10 };
            int totalThingsInArray = scores.Length;
            Console.WriteLine($"There are {totalThingsInArray} thing in the array.");

            int[] array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };

            int currentMinimum = Int32.MaxValue;

            foreach(int index in array)
            {
                if (index < currentMinimum)
                {
                    currentMinimum = index;
                    Console.WriteLine(currentMinimum);
                }
            }

            int total = 0;
            foreach (int indexes in array)
                total += indexes;
            float average = (float)total / array.Length;
            Console.WriteLine("The average is " + average);

            string[] Names = new string[10] { "Andromeda", "Aurora", "Abraham", "Spencer", "Whitney", "Kelly", "Justin", "Eugene", "Josephine", "Renee" };

            string[] copiedNames = new string[Names.Length];

            for(int i = 0; i < Names.Length; i++)
            {
                copiedNames[i] = Names[i];
                Console.WriteLine(Names[i] + " = " + copiedNames[i]);

            }

            int[,] matrix = new int[4, 4];
            

            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                    Console.Write(matrix[row, column] + " ");
                Console.WriteLine();
            }

            foreach (int score in scores)
                Console.WriteLine("Someone had this score: " + score);







            Console.ReadKey();
        }
    }
}
