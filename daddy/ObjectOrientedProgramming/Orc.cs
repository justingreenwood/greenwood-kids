using System;

namespace ObjectOrientedProgramming
{
    public class Orc : Character
    {
        private static Random RAND = new Random();

        public Orc()
        {
            this.Name = "Joe";
            this.HitPoints = 100;
        }

        public override void Defend(Player player)
        {
            player.Defend(this);
            if (this.HitPoints > 0)
            {
                if (RAND.Next(10) < 3)
                {
                    Console.WriteLine("The Orc Misses! YAY");
                }
                else
                {
                    var damage = RAND.Next(5, 30);
                    player.HitPoints -= damage;
                    Console.WriteLine($"The orc hits you for {damage} damage");
                }
            }
        }
        public override void Talk(Player player)
        {
            var damage = RAND.Next(15, 40);
            player.HitPoints -= damage;
            Console.WriteLine($"Orcs don't like to chat! You get hit for {damage} damage");
        }
    }
}
