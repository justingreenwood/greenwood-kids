using System;
using System.Collections.Generic;

namespace EnumerableStuff
{
    class Program
    {
        static IEnumerable<string> SimpleEnumerable()
        {
            yield return "Apples";
            yield return "Oranges";
            yield return "Bananas";
            yield return "Unicorns";

        }



        static void Main(string[] args)
        {
            foreach(var s in SimpleEnumerable())
            Console.WriteLine(s);
        }
    }
}
