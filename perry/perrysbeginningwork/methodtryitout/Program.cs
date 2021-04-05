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
            Random random = new Random();
            int arandomnumber = random.Next(6)+1;
            int[] numbers = GenerateNumbers();
            //PrintNumbers(numbers);
            Reverse(numbers);
            PrintNumbers(numbers);

            Console.WriteLine("---------------------------------------------------------");
            int k = 0;
            while (true)
            {
                k = 0;
                Console.WriteLine("Type in the amount of times you roll the dice. ");
                string amountOfRolls = Console.ReadLine();
                int rolls = Convert.ToInt32(amountOfRolls);
                
                //int dice = random.Next(6) + 1;
                for(int i = 0; i< rolls; i++)
                {
                    int dice = random.Next(6) + 1;
                    k += dice;

                }
                Console.WriteLine(k);

                Console.WriteLine("Type (Q)uit to (E)xit. ");
                string answer = Console.ReadLine();
                answer = answer.ToLower();
                if (answer == "quit" || answer == "q" || answer == "exit" || answer == "e")
                {
                    break;
                }
                


            }

            //====================================================================================================

            Console.WriteLine("====================================================================================================");
            Console.WriteLine("Type in a number. ");
            string typedin = Console.ReadLine();
            int choice = Convert.ToInt32(typedin);

            int answers = Fibonacci(choice);

            Console.WriteLine(answers);




            Console.ReadKey();
        }





        static int Fibonacci(int number, int x = 0, int y = 1)
        {
            int extra;

            if (number > 1)
            {
                extra = x + y;
                x = y;
                y = extra;

                number--;
                y = Fibonacci(number, x, y);
                
            }


            return y;
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
        /// <summary>
        /// Takes two numbers and multiplies them together, returning the result.
        /// </summary>
        /// <param name="i">The first number to multiply</param>
        /// <param name="v">The second number to multiply</param>
        /// <returns>The product of the two input numbers</returns>
        static double Multiply(int i, int v)
        {
            return i * v;
        }
        static void Multiply(int i, int v, int j)
        {

        }

        static void recursion()
        {
            recursion();
        }

        static int factorial(int number)
        {
            if (number == 1)
                return 1;

            return number * factorial(number - 1);

        }

        //static double Fibonacci(int number)
        //{








        //}

    }
}
