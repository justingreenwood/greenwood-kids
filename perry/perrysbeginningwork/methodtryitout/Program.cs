using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace methodtryitout
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = GenerateNumbers();
            //PrintNumbers(numbers);
            Reverse(numbers);
            PrintNumbers(numbers);

            Console.ReadKey();
        }

        static int[] GenerateNumbers()
        {
            int usersnumber;
            Console.WriteLine("Enter a number. ");
            string userinput = Console.ReadLine();
            usersnumber = Convert.ToInt32(userinput);

            int[] list = new int[usersnumber];
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = i+1;
            }

            return list;
        }

        static void Reverse(int [] numbers)
        {
            //int[] bw = new int[numbers.Length];
            
            for(int i = 0; i < numbers.Length/2; i++)
            {
                var e = numbers[numbers.Length-1-i];
                numbers[numbers.Length - 1 - i] = numbers[i];
                numbers[i] = e;
            }
            //numbers = bw;
        }

        static void PrintNumbers(int [] numbers)
        {

            foreach(int Numbers in numbers)
            {
                Console.Write(Numbers + " ");
            }

        }


    }
}
