using System;

namespace MathTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            double i = 12, j = 81;


            Console.WriteLine($"{j} + {i} = {j + i}");
            Console.WriteLine($"{j} - {i} = {j - i}");
            Console.WriteLine($"{i} - {j} = {i - j}");
            Console.WriteLine($"{j} * {i} = {j * i}");
            Console.WriteLine($"{j} / {i} = {j / i}");
            Console.WriteLine($"{i} / {j} = {i / j}");
            Console.WriteLine($"{j} % {i} = {j % i}");
            Console.WriteLine($"{i} % {j} = {i % j}");

            //Console.WriteLine($"{i} / 0 = {i / 0}");


            Console.WriteLine($"square root of {j} = { Math.Sqrt(j)}");
            Console.WriteLine($"square root of {i} = { Math.Sqrt(i)}");
            Console.WriteLine($"square root of -24 = { Math.Sqrt(-24)}");

            int clampSubject = 54;
            decimal myDecimal = 12.52545m;
            int myInteger = 12;
            Console.WriteLine($"square root of {myInteger} = { Math.Sqrt(myInteger)}");
            Console.WriteLine($"square root of {myDecimal} = { Math.Sqrt(Convert.ToDouble(myDecimal))}");

            Console.WriteLine($"Rounding {myDecimal} = { Math.Round(myDecimal, 2)}");
            Console.WriteLine($"Floor {myDecimal} = { Math.Floor(myDecimal)}");
            Console.WriteLine($"Ceiling {myDecimal} = { Math.Ceiling(myDecimal)}");
            Console.WriteLine($"Absolute value |-14| = { Math.Abs(-14)}");
            Console.WriteLine($"Clamp {clampSubject} between 1 and 100 = { Math.Clamp(clampSubject, 1, 100)}");
            Console.WriteLine($"Max of {clampSubject} and {myInteger} = { Math.Max(clampSubject, myInteger)}");
            Console.WriteLine($"Min of {clampSubject} and {myInteger} = { Math.Min(clampSubject, myInteger)}");


            Console.ReadKey();
            Console.Clear();

            var keepGoing = true;
            do
            {

            FirstQuestion:
                Console.Write("Enter the first number: ");
                var firstNumText = Console.ReadLine();
                // ! means "not" or "is false"
                if (!float.TryParse(firstNumText, out float firstNum))
                {
                    goto FirstQuestion;
                }

                Console.Write("Enter the second number: ");
                var secondNumText = Console.ReadLine();
                var secondNum = float.Parse(secondNumText);

                Console.Write("Enter the operation: ");
                var operationText = Console.ReadLine();

                double answer = 0;
                switch (operationText)
                {
                    case "+": answer = firstNum + secondNum; break;
                    case "-": answer = firstNum - secondNum; break;
                    case "/": answer = firstNum / secondNum; break;
                    case "*": answer = firstNum * secondNum; break;
                    case "^": answer = Math.Pow(firstNum, secondNum); break;
                    default: answer = 5318008; break;
                }
                Console.WriteLine($"{firstNum} {operationText} {secondNum} = {answer}");
                Console.WriteLine();
                Console.WriteLine($"Press Q to quit or anything else to keep playing.");

                if (Console.ReadKey().Key == ConsoleKey.Q) keepGoing = false;
            } while (keepGoing);

        }
    }
}
