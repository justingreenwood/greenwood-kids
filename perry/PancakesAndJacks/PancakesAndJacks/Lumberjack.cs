using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PancakesAndJacks
{
    class Lumberjack
    {
        public string Name { get; private set; }
        public Lumberjack(string name)
        {
            Name = name;
        }
        private Stack<Pancakes> pancakeStack = new Stack<Pancakes>();

        public void TakePancake(Pancakes pancake)
        {
            pancakeStack.Push(pancake);
        }

        public void EatPancakes()
        {
            Console.WriteLine($"{Name} is eating pancakes");
            while (pancakeStack.Count > 0)
            {
                Console.WriteLine($"{Name} ate a {pancakeStack.Pop().ToString().ToLower()} pancake.");
            }
        }

    }

    enum Pancakes
    {
        Crispy,
        Soggy,
        Browned,
        Banana,
        Chocolate,
    }

}
