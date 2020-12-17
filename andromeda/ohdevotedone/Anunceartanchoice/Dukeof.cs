using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Anunceartanchoice
{
    public class Dukeof
    {
        private static Random rand = new Random();

        public static int GetRandomNumber(int max)
        {
            return rand.Next(max + 1);
        }

        public static int GetRandomNumber(int min, int max)
        {
            return rand.Next(min, max + 1);
        }

        public static void WriteStuff(string text)
        {
            Console.WriteLine(text);
        }
        public static int AddNumbers(int i, int j)
        {
            Console.WriteLine($"{i} + {j} = {i + j}");
            return i + j;
        }
        public static int subtractnumbers(int i, int j) 
        {
            Console.WriteLine($"{i}-{j}={i - j}");
            return i - j;
        }
        public static int multplynumbers(int i, int j) 
        {
            Console.WriteLine($"{i}*{j}={i * j}");
            return i * j;
        }
    }
}
