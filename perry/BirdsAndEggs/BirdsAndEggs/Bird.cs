using System;
using System.Collections.Generic;
using System.Text;

namespace BirdsAndEggs
{
    abstract class Bird
    {

        public static Random random = new Random();
        public abstract Egg[] LayEggs(int numberOfEggs);

    }

    class Pigeon : Bird
    {

        public override Egg[] LayEggs(int numberOfEggs)
        {
            Egg[] eggs = new Egg[numberOfEggs];
            for(int i=0; i < numberOfEggs; i++)
            {
                if (Bird.random.Next(4) == 0)
                    eggs[i] = new BrokenEgg("white");
                else
                    eggs[i] = new Egg(Bird.random.NextDouble() * 2 + 1, "white");
            }
            return eggs;

        }

    }

    class Ostrich : Bird
    {

        public override Egg[] LayEggs(int numberOfEggs)
        {
            Egg[] eggs = new Egg[numberOfEggs];
            for (int i = 0; i < numberOfEggs; i++)
            {
                eggs[i] = new Egg(Bird.random.NextDouble() +12, "speckled");
            }
            return eggs;

        }

    }




}
