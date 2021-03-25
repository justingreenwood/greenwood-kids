using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumerations
{
    enum monthsInYear { jan = 1, feb = 2, march = 3, april = 4, may = 5, june = 6, july = 7, august = 8, sept = 9, oct = 10, nov = 11, dec = 12 };
    class Program
    {
        static void Main(string[] args)
        {
            int dayofweek = 3;
            if (dayofweek == 3)
                Console.WriteLine("It's Tuesday!");
            int sunday = 1;
            int monday = 2;
            int tuesday = 3;
            int wednesday = 4;
            int thursday = 5;
            int friday = 6;
            int saturday = 7;
            int dayOfWeek = tuesday;
             if (dayOfWeek==tuesday)
                Console.WriteLine("It's Tuesday!");
            Console.WriteLine("pick a number between 1 and 12.");
            string calendar= Console.ReadLine();
            int date = Convert.ToInt32(calendar);
            switch (date)
            {
                case 1:
                    Console.WriteLine(monthsInYear.jan);
                    Console.WriteLine("January");
                    break;
                case 2:
                    Console.WriteLine(monthsInYear.feb); 
                    Console.WriteLine("Febuary");
                    break;
                case 3:
                    Console.WriteLine(monthsInYear.march); 
                    Console.WriteLine("March");
                    break;
                case 4:
                    Console.WriteLine(monthsInYear.april); 
                    Console.WriteLine("April");
                    break;
                case 5:
                    Console.WriteLine(monthsInYear.may);
                    Console.WriteLine("May");
                    break;
                case 6:
                    Console.WriteLine(monthsInYear.june); 
                    Console.WriteLine("June");
                    break;
                case 7:
                    Console.WriteLine(monthsInYear.july); 
                    Console.WriteLine("July");
                    break;
                case 8:
                    Console.WriteLine(monthsInYear.august);
                    Console.WriteLine("August");
                    break;
                case 9:
                    Console.WriteLine(monthsInYear.sept); 
                    Console.WriteLine("September");
                    break;
                case 10:
                    Console.WriteLine(monthsInYear.oct);
                    Console.WriteLine("October");
                    break;
                case 11:
                    Console.WriteLine(monthsInYear.nov); 
                    Console.WriteLine("November");
                    break;
                case 12:
                    Console.WriteLine(monthsInYear.dec);
                    Console.WriteLine("December");
                    break;
                default:
                    Console.WriteLine("not option");
                    break;
            }
            Console.ReadKey();
        }
    }
}
