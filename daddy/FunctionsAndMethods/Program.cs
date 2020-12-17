using System;

namespace FunctionsAndMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            var dadsCar = new Car();
            dadsCar.Color = ConsoleColor.Blue;
            dadsCar.Make = "Kia";
            dadsCar.Model = "Forte";
            dadsCar.Year = 2015;

            var andisCar = new Car();
            andisCar.Color = ConsoleColor.Yellow;
            andisCar.Make = "Mushroom";
            andisCar.Model = "Lemon";
            andisCar.Year = 2004;

            var spencersCar = new Car();
            spencersCar.Color = ConsoleColor.Black;
            spencersCar.Make = "Nissan";
            spencersCar.Model = "Frontier";
            spencersCar.Year = 2001;

            var answer = MyFunctions.AddThreeNumbers(-23, 234234, spencersCar.Year);
            Console.WriteLine($"Answer = {answer}");


            var cars = new Car[] { dadsCar, spencersCar, andisCar };
            foreach (var car in cars)
            {
                PrintCar(car);
            }

            //An Array
            int[] years = new int[] { 1999, 2000, 2001, 2015, 2020, 2021 };

            // foreach loop (forward through all items)
            foreach (var y in years)
            {
                Console.WriteLine(y);
            }

            // for loops
            for (var i = 0; i < years.Length; i++)
            {
                Console.WriteLine($"[{years[i]}]");
            }
            for (var i = years.Length - 1; i >= 0; i--)
            {
                Console.WriteLine($"({years[i]})");
            }

            // while loop
            var j = 0;
            while (j < years.Length)
            {
                Console.WriteLine($"-{years[j]}-");
                j++;
            }

            // while loop
            var x = 0;
            while (true)
            {
                Console.WriteLine($"<{years[x]}>");
                x++;
                if (x > 3) break;
            }
        }


        static void PrintCar(Car car)
        {
            var currentColor = Console.ForegroundColor;

            if (car.Color == ConsoleColor.Black)
            {
                Console.BackgroundColor = ConsoleColor.White;
            }
            Console.ForegroundColor = car.Color;
            Console.WriteLine(car.Description);
            if (car.Color == ConsoleColor.Black)
            {
                Console.BackgroundColor = ConsoleColor.Black;
            }

            Console.ForegroundColor = currentColor;
        }
    }

    public class Car
    {
        private string PrivateField = "$$$";
        public string Make;
        public string Model;
        public int Year;
        public ConsoleColor Color;

        public string Description
        {
            get
            {
                return $"{Year} {Make} {Model} {PrivateField}";
            }
        }
    }
}
