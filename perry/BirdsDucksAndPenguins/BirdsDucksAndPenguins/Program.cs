using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsDucksAndPenguins
{
    class Program
    {
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
                new Duck(){Kind = KindOfDuck.FriedDuck,Size = 10},
            };
            IEnumerable<Bird> upcastDucks = ducks;
            Bird.FlyAway(upcastDucks.ToList(), "Minnesota");
            Console.ReadKey();
        }
    }
}
