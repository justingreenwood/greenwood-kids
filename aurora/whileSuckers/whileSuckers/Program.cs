using System;

namespace whileSuckers
{
    class Program
    {
        static void Main(string[] args)
        {
            string lastword = "Are ";
            int butt = 1;
            while (butt <= 10)
            {
                int fart = 0;
                while (fart < butt)
                {
                    if (lastword == "Awesome! ")
                        lastword = "Legos ";
                    else if (lastword == "Legos ")
                        lastword = "Are ";
                    else
                        lastword = "Awesome! ";
                    Console.Write(lastword);
                    fart++;
                }
                Console.WriteLine();
                butt++;
            }
        }
    }
}
