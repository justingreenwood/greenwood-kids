using System;

namespace Aurora_s_Sixth_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            string PerryIsAPickle = "| (*-*) |";
            var Pickle = 1;

            while (Pickle < 10)
            {
                int Perry = 0;
                while (Perry < Pickle)
                {
                    if (PerryIsAPickle == "| (*=*) |")
                        PerryIsAPickle = "| (*-*) |";
                    Console.Write(PerryIsAPickle);
                    Perry++;
                }
             
                Console.WriteLine();
                Pickle++;
            }

            string BananaKitten = "| (*-*) |";
            var Kitten = 10;

            while (Kitten > 1)
            {
                int Banana = 0;
                while (Banana < Kitten)
                {
                    if (BananaKitten == "| (*-*) |")
                        BananaKitten = "| (>_<) |";
                    Console.Write(BananaKitten);
                    Banana++;
                }

                Console.WriteLine();
                Kitten--;

            }

        }

    }
}
