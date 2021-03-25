using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheNumberNation
{
    enum DaysOfWeek { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };
    enum Month { January = 1, February = 2, March = 3, April = 4, May = 5, June = 6, July = 7, August = 8, September = 9, October = 10, November = 11, December = 12};
    class Program
    {
        static void Main(string[] args)
        {

            int dayOfWeek = 3;
            if (dayOfWeek == 3)
                Console.WriteLine("It's Tuesday.");

            DaysOfWeek today;

            today = DaysOfWeek.Thursday;
            int dayasint = (int)DaysOfWeek.Sunday;

            Console.WriteLine("Type number of month it is.");
            string Answer = Console.ReadLine();
            int Answers = Convert.ToInt32(Answer);
            Month answer = (Month)Answers;

            if(answer == Month.January)
            {
                Console.WriteLine(Month.January);
            }
            else if (answer == Month.February)
            {
                Console.WriteLine(Month.February);
            }
            else if (answer == Month.March)
            {
                Console.WriteLine(Month.March);
            }
            else if (answer == Month.April)
            {
                Console.WriteLine(Month.April);
            }
            else if (answer == Month.May)
            {
                Console.WriteLine(Month.May);
            }
            else if (answer == Month.June)
            {
                Console.WriteLine(Month.June);
            }
            else if (answer == Month.July)
            {
                Console.WriteLine(Month.July);
            }
            else if (answer == Month.August)
            {
                Console.WriteLine(Month.August);
            }
            else if (answer == Month.September)
            {
                Console.WriteLine(Month.September);
            }
            else if (answer == Month.October)
            {
                Console.WriteLine(Month.October);
            }
            else if (answer == Month.November)
            {
                Console.WriteLine(Month.November);
            }
            else if (answer == Month.December)
            {
                Console.WriteLine(Month.December);
            }




            Console.ReadKey();
        }
    }
}
