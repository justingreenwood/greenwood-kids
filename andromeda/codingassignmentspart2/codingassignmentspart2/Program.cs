using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codingassignmentspart2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int arandomnum = random.Next();
            int dieRoll = random.Next(6) + 1;
            bool anser = true;
            while (anser== !false)
            {
                Console.WriteLine("How many dice do you want to roll");
                var reading = Console.ReadLine();
                int Reading = Convert.ToInt32(reading);
                int bro = 0;
                for (int r=0;r<Reading;r++)
                {
                    int die = random.Next(6) + 1;
                    bro+=die;
                }
                Console.WriteLine(bro);
                Console.WriteLine("Would you like to continue.|n|");
               var ans= Console.ReadKey();
                if (ans.Key == ConsoleKey.N)
                {
                   anser= false;
                }
            }

        }
    }
}
