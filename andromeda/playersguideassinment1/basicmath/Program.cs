using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basicmath
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 3 + 4;
            int b = 5 - 2;
            int d;
            d = 9 - 2;
            d = 3 + 3;
            b = 3 + 1;
            b = 1 + 2;
            a = 1;
            b = a + 4;
            int c = a - b;
            int result = 1 + 2 - 3 + 4 - 5 + a - b + c - d;
            float totalCost = 22.54f;
            float tipPercent = .18f;
            float tipAmount = totalCost * tipPercent;
            double moneyMadeFromGame = 100000;
            double totalProgrammers = 4;
            double moneyPerPerson = moneyMadeFromGame / totalProgrammers;//we are rich
            float radius = 4;
            float pi = 3.1415926536f;
            float area = pi * radius * radius;//using the + operator with strings results in "concatenation".
            Console.WriteLine("The area of the circle is " + area + ".");
            double h = 4;
            double B= 5;
           double A = B * h/2;
            Console.WriteLine(A);
           B = 5;
            h = 6;
            A = B * h / 2;
            Console.WriteLine(A);
            B = 1.5;
            h = 4;
            A = B * h / 2;
            Console.WriteLine(A);
            int totalApples = 23;
            int people = 7;
            int remaningApples = totalApples % people;//this will be 2
            int remainder = 20 % 4;//this will be 0, which tells us 20 is a multiple of 4.
            a = 17;
            b = 4;
            int quotient = a / b;
            remainder = a % b;
            Console.Write(a+"/"+b+" is "+quotient+" remainder "+ remainder);
            int ans = b * quotient + remainder;
            Console.WriteLine("                                       ");
            Console.WriteLine(ans );
            a = 9;
            b = 3;
            quotient = a / b;
            remainder = a % b;
            ans = b * quotient + remainder;
            Console.WriteLine(ans);
            a = 10;
            b = 5;
            quotient = a / b;
            remainder = a % b;
            ans = b * quotient + remainder;
            Console.WriteLine(ans);
            Console.ReadKey();
            a = +3;
            b = -44;
            a = 3 + 4;
            b = 2 - 66;
            double side1 = 5.5;
            double side2 = 3.25; 
            double height = 4.6;
            double areaOfTrapazoid = (side1 + side2) / 2 * height;
            int x = 5 - 3 - 1;
            a = 5;
            a = a + 1;
            a = 5;
            a += 3;
            b = 7; 
            b -= 3; 
            b *= 5;
            b /= 4;
            b %= 2;
        }
    }
}
