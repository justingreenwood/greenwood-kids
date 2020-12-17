using System;

namespace familylistwitharrays9_2_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Family");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < name.Length; i++)
            {
                Console.WriteLine(name[i]);
            }
            Console.WriteLine("");
            Console.WriteLine(""); 
            Console.WriteLine("");
            Console.WriteLine("YOUNGEST TO OLDEST");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < name1.Length; i++)
            {
                Console.WriteLine(name1[i]);
            }
            Console.WriteLine("");
            Console.WriteLine(""); 
            Console.WriteLine("");
            Console.WriteLine("OLDEST TO YOUNGEST");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < name2.Length; i++)
            {
                Console.WriteLine(name2[i]);
            }
        }
        static string[] name = { "Justin", "Kelly", "Whitney", "Spencer", "Andromeda", "Aurora", "Perry" };
        static string[] name1 = { "Perry", "Aurora", "Andromeda", "Spencer", "Whitney", "Kelly", "Justin" };
        static string[] name2 = { "Justin", "Kelly", "Whitney", "Spencer", "Andromeda", "Aurora", "Perry" };
    }
}
