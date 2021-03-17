using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userinput
{
    class Program
    {
        static void Main(string[] args)
        {
            string whatUserTyped = Console.ReadLine();
            int aNuber = Convert.ToInt32(whatUserTyped);
            bool b = false;
            int i = Convert.ToInt32(b);
            double d = 3.4;
            float f = Convert.ToSingle(d);
            // fake calc
            Console.WriteLine("my cylindar calc");
            Console.Write("Enter cylinder radius");
            string radiusAsAString = Console.ReadLine();
            double radius = Convert.ToDouble(radiusAsAString);
            Console.Write("Enter cylinder height");
            string heightAsAString = Console.ReadLine();
            double height = Convert.ToDouble(heightAsAString);
            double pi = 3.141592654;
            double volume = pi * radius * radius * height;
            double surfaceArea = 2 * pi * radius * (radius + height);
            Console.WriteLine("The cylinder's volume is: "+volume+" cubic units."); 
            Console.WriteLine("The cylinder's surface area is: "+surfaceArea+" square units.");
            Console.ReadKey();
            //done
            Console.WriteLine("\"");
            Console.WriteLine("Text\non\nmore\nthan\none\nline.");
            Console.WriteLine("C:\\User\\RB\\Desktop\\MyFile.txt"); 
            Console.WriteLine(@"C:\User\RB\Desktop\MyFile.txt");
            Console.WriteLine($"The cylinder's volume is: {volume} cubic units.");
        }
    }
}
