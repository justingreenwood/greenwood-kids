using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PancakesAndJacks
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Queue<Lumberjack> lumberjackQueue = new Queue<Lumberjack>();
            string name;

            Console.Write("First lumberjack's name: ");
            while((name = Console.ReadLine())!= "")
            {
                Console.Write("Number of pancakes: ");

                if(int.TryParse(Console.ReadLine(),out int number))
                {
                    Lumberjack lumberjack = new Lumberjack(name);
                    for(int i = 0; i < number; i++)
                    {
                        lumberjack.TakePancake((Pancakes)random.Next(0,5));
                    }
                    lumberjackQueue.Enqueue(lumberjack);
                }
                Console.Write("Next lumberjack's name (blank to end): ");
            }

            while (lumberjackQueue.Count > 0)
            {
                Lumberjack next = lumberjackQueue.Dequeue();
                next.EatPancakes();
            }

            Console.ReadKey();

        }
    }
}
