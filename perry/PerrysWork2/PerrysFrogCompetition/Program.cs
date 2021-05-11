using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PerrysFrogCompetition
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread frogI = new Thread(Jump10);
            frogI.Start();
            Thread frogII = new Thread(Jump10);
            frogII.Start();
            Thread frogIII = new Thread(Jump10);
            frogIII.Start();

            Console.WriteLine($"Frog {} won.");
        }
        public static void Jump10(object j)
        {
            string n = (string)j;
            for (int i = 1; i <= 10; i++)
            {
                if(i == 10)
                {
                    n = $"{j}";
                }
            }
                
        }
    }

}
