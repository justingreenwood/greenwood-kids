using System;
using System.IO;

namespace Objectville
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamWriter sw = new StreamWriter("secret_plan.txt");
            sw.WriteLine("How I will defeat Goodguy");
            sw.WriteLine("Another secret plan by The Badguy");
            sw.WriteLine("I will unleash my army of Sandwiches upon the citizens of Ojectville.");

            string location = "the mall";
            for (int i = 0; i <= 5; i++)
            {
                sw.WriteLine("Sandwich #{0} attacks {1}", i, location);
                location = (location == "the mall") ? "downtown" : "the mall";
            }
            sw.Close();

        }
    }
}
