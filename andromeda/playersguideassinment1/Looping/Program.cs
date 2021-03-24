using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Looping
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 1;
            while(x<=10)
            {
                Console.WriteLine(x);
                x++;
            }
            int playerNumber = -1;
            while(playerNumber<0||playerNumber>10)
            {
                Console.Write("Enter a number between 0 and 10: ");
                string playerResponse = Console.ReadLine();
                playerNumber = Convert.ToInt32(playerResponse);
            }
            do
            {
                Console.Write("Enter a number between 0 and 10: ");
                string playerResponse = Console.ReadLine();
                playerNumber = Convert.ToInt32(playerResponse);
            }
            while (playerNumber < 0 || playerNumber > 10);
            x = 1;
            for (x = 1; x <= 10; x++)
            {
                Console.WriteLine(x);
            }
            x = 1;
            int numtroublecause=54;
            for (x = 1; x <= 100; x++)
            {
                Console.WriteLine(x);
                if (x == numtroublecause)
                { 
                    break; 
                }
            }
            while(true)
            {
                Console.Write("What is thy bidding, my master? ");
                string input = Console.ReadLine();
                if(input=="exit"||input=="quit")
                {
                    break;
                }
            }
            x = 1;
            for (x = 1; x <= 10; x++)
            {
                if (x == 3)
                { 
                    continue; 
                }
                Console.WriteLine(x);
            }
           for(int row =0;row<5;row++)
           {
             for(int colomn = 0; colomn < 10; colomn++)
             {
                    Console.Write("*");
             }
                Console.WriteLine();
           } 
            for (int row = 0; row < 5; row++)
            {
                for (int colomn = 0; colomn < row+1; colomn++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            for (int row = 0; row<5; row++)
            {
                for (int colomn = 5; colomn > row; colomn--)
                {
                    Console.Write(" ");
                }
                for (int colomn = 0; colomn <= row*2 ; colomn++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            for (int nums=1;nums<101;nums++)
            {
                var printNumber = true;
                if ((nums%3)==0)
                {
                   Console.Write("Fizz");
                    printNumber = false;
                }
                if ((nums % 5) == 0)
                {
                    Console.Write("Buzz");
                    printNumber = false;
                }

                if (printNumber)
                {
                    Console.Write(nums);
                }
                Console.Write(" ");
            }
            // wednesday the 24th of march
            int score1 = 100;
            int score2 = 95;
            int score3 = 92;
            int[] scores;
            scores = new int[10];
            string[] names = new string[10];
            scores[0] = 99;
            int fourthScore = scores[3];
            int eighthScore = scores[7];
            int[] Scores = new[] { 100, 95, 92, 87, 55, 50, 48, 40, 35, 30 };
            int totalThingsInArray = Scores.Length;
            Console.WriteLine("There are " + totalThingsInArray + " things in the array.");
            int[] array = new int[] {4, 51, -7, 13, -99, 15, -8, 45, 90 };
            int currentMinimum = Int32.MaxValue;
            for (int index=0;index<array.Length;index++)
            {
                if (array[index] < currentMinimum)
                    currentMinimum = array[index];
            }
            int total = 0;
            for (int index = 0; index < array.Length; index++)
            {
                total += array[index];
            }
            float average = (float)total / array.Length;
            int[] myPersonalArray = new int[] { 1, 5, 6, 9, 55, 25, 81, 18, 21, 125 };
            total = 0;
            for (int index = 0; index <myPersonalArray.Length; index++)
            {
                total += myPersonalArray[index];
            }
            float myAverage = (float)total / myPersonalArray.Length;
            int[] perryArray = new int[myPersonalArray.Length];
            for (int index = 0; index < myPersonalArray.Length; index++)
            {
                perryArray[index]= myPersonalArray[index];
                Console.WriteLine(perryArray[index]);
            }
            int[,] matrix = new int[4, 4];
            matrix[0, 0] = 1;
            matrix[0, 1] = 0;
            matrix[0, 2] = 3;
            matrix[0, 3] = 5;
            matrix[1, 0] = 6;
            matrix[1, 1] = 9;
            matrix[1, 2] = 75;
            matrix[1, 3] = 50;
            matrix[2, 0] = 55;
            matrix[2, 1] = 25; 
            matrix[2, 2] = 99; 
            matrix[2, 3] = 10; 
            matrix[3, 0] = 100;
            matrix[3, 1] = 125;
            matrix[3, 2] = 25;
            matrix[3, 3] = 1;
            for(int row=0; row< matrix.GetLength(0);row++)
            {
                for( int column=0; column< matrix.GetLength(1);column++)
                {
                    Console.Write(matrix[row, column] + " ");
                }
                Console.WriteLine();
            }
            foreach (int score in Scores)
                Console.WriteLine("Someone had this score:" + score);
            for (int index = 0; index <Scores.Length; index++)
            {
                int score = Scores[index];
                Console.WriteLine("Score#"+index+":"+score);
            }
            int minimum = Int32.MaxValue;
            foreach (int item in array)
            {
                if (item < minimum)
                    minimum = item;
            }
            total = 0;
            foreach (int item in array)
            {
                total += item;
            }
             average = (float)total / array.Length;
            Console.ReadKey();
        }
    }
}
