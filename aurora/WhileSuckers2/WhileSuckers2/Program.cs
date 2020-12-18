using System;

namespace WhileSuckers2
{
    class Program
    {
        static void Main(string[] args)
        {
            int butt = 1;
            while (butt <= 10)
            {
                int fart = 0;
                while (fart < butt)
                {
                    Console.Write("*");
                    fart++;
                }
                Console.WriteLine();
                butt++;
            }
            butt = 9;
            while (butt > 0)
            {
                int fart = 0;
                while (fart < butt)
                {
                    Console.Write("*");
                    fart++;
                }
                Console.WriteLine();
                butt--;
            }
        }
    }
}
