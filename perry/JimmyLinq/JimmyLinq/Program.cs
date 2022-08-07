using System;
using System.Collections.Generic;
using System.Linq;

namespace JimmyLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var done = false;
            while (!done)
            {
                Console.WriteLine("\nPress G to group comics by price, R to get reviews, any other key to quit\n");
                switch (Console.ReadKey(true).KeyChar.ToString().ToUpper())
                {
                    case "G":
                        done = GroupComicsByPrice();
                        break;
                    case "R":
                        done = GetReviews();
                        break;
                    default:
                        done = true;
                        break;

                }

            }
        }

        private static bool GroupComicsByPrice()
        {
            var groups = ComicAnalyzer.GroupComicsByPrice(Comic.Catalog, Comic.Prices);
        }



    }
}
