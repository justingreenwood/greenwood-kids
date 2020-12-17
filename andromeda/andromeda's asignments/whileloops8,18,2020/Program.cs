using System;

namespace whileloops8_18_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            while (i <= 25)
            {
                int j = 1;
                while (j <= i) 
                {
                    Console.Write("*");
                    j++;
                }
                Console.WriteLine();
                i++;
            }
           
            while(i>= 1)
            {
                int j = 1;
                while (j <= i)
                {
                    Console.Write("*");
                    j++;
                }
                Console.WriteLine();
                i--;

            }

            int l = 4;
            while (l <= 20)
            {
                Console.WriteLine(l);
                l++;
            }

        }
    }
}
