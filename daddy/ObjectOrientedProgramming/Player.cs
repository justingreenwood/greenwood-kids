using System;

namespace ObjectOrientedProgramming
{
    public class Player
    {
        private static Random RAND = new Random();

        public string Name;
        public int HitPoints = 50;

        public void Defend(Character o)
        {

            if (RAND.Next(10) < 2)
            {
                Console.WriteLine("You miss");
            }
            else
            {
                var damage = RAND.Next(20, 200);
                o.HitPoints -= damage;
                if (o.HitPoints <= 0)
                    Console.WriteLine($"You kill the {o.GetType().Name}");
                else
                    Console.WriteLine($"You hit the {o.GetType().Name} for {damage} damage");
            }
        }
    }
}
