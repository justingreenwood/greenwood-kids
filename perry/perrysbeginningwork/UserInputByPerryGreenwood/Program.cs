using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInputByPerryGreenwood
{
    class Program
    {
        static void Main(string[] args)
        {
            string whatTheUserTyped = Console.ReadLine();
            int aNumber = Convert.ToInt32(whatTheUserTyped);
            bool b = false;
            int i = Convert.ToInt32(b);
            double d = 3.4;
            float f = Convert.ToSingle(d);

            Console.WriteLine("Welcome to Cylinder calculator 1.0!");

            Console.WriteLine("Type a number for radius. ");
            var radius = Console.ReadLine();
            float Radius = Convert.ToSingle(radius);
            Console.WriteLine("Type a number for height. ");
            var height = Console.ReadLine();
            float Height = Convert.ToSingle(height);
            float Pi = 3.1415926f;
            float volume = Pi * Radius * Radius * Height;
            float surfaceArea = 2 * Pi * Radius * (Radius + Height);
            Console.WriteLine("The volume of the cylinder is " + volume + ".");
            Console.WriteLine("The surface area of the cylinder is " + surfaceArea + ".");

            Console.WriteLine("\"");
            Console.WriteLine("Text\non\nmore\none\nline");
            Console.WriteLine("C:\\Users\\RB\\Desktop\\MyFart.txt");
            Console.WriteLine(@"c\c\d\g\e\g\d\\\\\n");
            Console.WriteLine($"The cylinder's volume is: {volume} cubic units.");



            Console.ReadKey();
            
        }
    }
}
