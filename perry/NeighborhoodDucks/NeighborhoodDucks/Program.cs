using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborhoodDucks
{
    class Program
    {

        public static void PrintDucks(List<Duck> ducks)
        {
            foreach(Duck duck in ducks)
            {
                Console.WriteLine(duck);
            }
        }


        static void Main(string[] args)
        {

            List<Duck> ducks = new List<Duck>()
            {
                new Duck(){Kind = KindOfDuck.Mallard,Size = 17},
                new Duck(){Kind = KindOfDuck.Muscovy,Size = 18},
                new Duck(){Kind = KindOfDuck.Loon,Size = 14},
                new Duck(){Kind = KindOfDuck.Muscovy,Size = 11},
                new Duck(){Kind = KindOfDuck.Mallard,Size = 14},
                new Duck(){Kind = KindOfDuck.Loon,Size = 13},
                new Duck(){Kind = KindOfDuck.Fried,Size = 10},
            };
            ducks.Sort();
            PrintDucks(ducks);
            Console.ReadKey();

        }
    }
}
