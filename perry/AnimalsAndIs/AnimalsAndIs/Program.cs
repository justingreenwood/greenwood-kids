using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsAndIs
{
    class Program
    {
        static void Main(string[] args)
        {

            Animal[] animals =
            {
                new Wolf(false),
                new Hippo(),
                new Wolf(true),
                new Wolf(false),
                new Hippo(),
            };

            foreach(Animal animal in animals)
            {
                animal.MakeNoise();
                if(animal is ISwimmer swimmer)
                {
                    swimmer.Swim();
                }
                else if (animal is IPackHunter hunter)
                {
                    hunter.HuntInPack();
                }
                Console.WriteLine();
            }

        }
    }
}
