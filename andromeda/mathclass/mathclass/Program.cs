using System;

namespace mathclass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("pick noun");
            var noun = Console.ReadLine();
            Console.WriteLine("write a verb");
            var verb = Console.ReadLine();
            Console.WriteLine("write a description");
            var sis = Console.ReadLine();
            Console.WriteLine("write a personality trait");
            var purse = Console.ReadLine();
            Console.WriteLine("name");
            var perry = Console.ReadLine();
            Console.WriteLine("Adjective");
            var adjective = Console.ReadLine();
        circle:
            Console.WriteLine("pick a num");
            var num1 = Console.ReadLine();
            if (!double.TryParse(num1, out double x))
            {
                Console.WriteLine($"{num1} is not a valid integer - MORON!");
                goto circle;
            }
        Square:
            Console.WriteLine("pick next num");
            var num2 = Console.ReadLine();
            if (!double.TryParse(num2, out double y))
            {
                Console.WriteLine($"{num2} is not a valid integer - MORON!");
                goto Square;
            }
        triangle:
            Console.WriteLine("pick last num");
            var num3 = Console.ReadLine();
            if (!double.TryParse(num3, out double z))
            {
                Console.WriteLine($"{num3} is not a valid integer - MORON!");
                goto triangle;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Jan used a {noun} to {verb} candy.");
            Console.WriteLine($"Aurora is {sis} and {purse}.");
            Console.WriteLine($"{perry} wore a {adjective} pair of high heels.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{x}+{y}={x + y}");
            Console.WriteLine($"{x}+{z}={x + z}"); 
            Console.WriteLine($"{z}+{y}={z + y}");
            Console.WriteLine($"{x}-{y}={x - y}"); 
            Console.WriteLine($"{y}-{x}={y - x}");
            Console.WriteLine($"{x}-{z}={x - z}");
            Console.WriteLine($"{z}-{x}={z - x}");
            Console.WriteLine($"{z}-{y}={z - y}");
            Console.WriteLine($"{y}-{z}={y - z}");
            Console.WriteLine($"{x}*{y}={x * y}");
            Console.WriteLine($"{x}*{z}={x * z}");
            Console.WriteLine($"{z}*{y}={z * y}");
            Console.WriteLine($"{x}/{y}={x / y}");
            Console.WriteLine($"{y}/{x}={y / x}"); 
            Console.WriteLine($"{x}/{z}={x / z}");
            Console.WriteLine($"{z}/{x}={z / x}");
            Console.WriteLine($"{z}/{y}={z / y}");
            Console.WriteLine($"{y}/{z}={y / z}");
        }
    }
}
