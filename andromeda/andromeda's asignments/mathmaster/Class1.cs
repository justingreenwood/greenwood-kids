using System;
using System.Collections.Generic;
using System.Text;

namespace mathmaster
{
    class Class1
    {
        public static void add()
        {
         number1:
             Console.WriteLine("pick a num");
             var num1 = Console.ReadLine();
             if (!double.TryParse(num1, out double x))
             {
                Console.WriteLine($"{num1} is not a valid integer - MORON!");
                goto number1;
             }
         number2:
             Console.WriteLine("pick a num");
             var num2 = Console.ReadLine();
             if (!double.TryParse(num2, out double y))
             {
                Console.WriteLine($"{num1} is not a valid integer - MORON!");
                goto number2;
             }
            Console.WriteLine($"{x}+{y}={x + y}");
        }
        public static void sub()
        {
        number1:
            Console.WriteLine("pick a num");
            var num1 = Console.ReadLine();
            if (!double.TryParse(num1, out double x))
            {
                Console.WriteLine($"{num1} is not a valid integer - MORON!");
                goto number1;
            }
        number2:
            Console.WriteLine("pick a num");
            var num2 = Console.ReadLine();
            if (!double.TryParse(num2, out double y))
            {
                Console.WriteLine($"{num1} is not a valid integer - MORON!");
                goto number2;
            }
            Console.WriteLine($"{x}-{y}={x - y}");
        }
        public static void multiply()
        {
        number1:
            Console.WriteLine("pick a num");
            var num1 = Console.ReadLine();
            if (!double.TryParse(num1, out double x))
            {
                Console.WriteLine($"{num1} is not a valid integer - MORON!");
                goto number1;
            }
        number2:
            Console.WriteLine("pick a num");
            var num2 = Console.ReadLine();
            if (!double.TryParse(num2, out double y))
            {
                Console.WriteLine($"{num1} is not a valid integer - MORON!");
                goto number2;
            }
            Console.WriteLine($"{x}*{y}={x * y}");
        }
        public static void divide()
        {
        number1:
            Console.WriteLine("pick a num");
            var num1 = Console.ReadLine();
            if (!double.TryParse(num1, out double x))
            {
                Console.WriteLine($"{num1} is not a valid integer - MORON!");
                goto number1;
            }
        number2:
            Console.WriteLine("pick a num");
            var num2 = Console.ReadLine();
            if (!double.TryParse(num2, out double y))
            {
                Console.WriteLine($"{num1} is not a valid integer - MORON!");
                goto number2;
            }
            Console.WriteLine($"{x}/{y}={x / y}");
        }
        public static void min()
        {
        number1:
            Console.WriteLine("pick a num");
            var num1 = Console.ReadLine();
            if (!double.TryParse(num1, out double x))
            {
                Console.WriteLine($"{num1} is not a valid integer - MORON!");
                goto number1;
            }
        number2:
            Console.WriteLine("pick a num");
            var num2 = Console.ReadLine();
            if (!double.TryParse(num2, out double y))
            {
                Console.WriteLine($"{num1} is not a valid integer - MORON!");
                goto number2;
            }
            Console.WriteLine(Math.Min(x,y));
        }
        public static void max()
        {
        number1:
            Console.WriteLine("pick a num");
            var num1 = Console.ReadLine();
            if (!double.TryParse(num1, out double x))
            {
                Console.WriteLine($"{num1} is not a valid integer - MORON!");
                goto number1;
            }
        number2:
            Console.WriteLine("pick a num");
            var num2 = Console.ReadLine();
            if (!double.TryParse(num2, out double y))
            {
                Console.WriteLine($"{num1} is not a valid integer - MORON!");
                goto number2;
            }
            Console.WriteLine(Math.Max(x,y));
        }
    }
}
