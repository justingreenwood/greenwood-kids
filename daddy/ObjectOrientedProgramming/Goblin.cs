using System;

namespace ObjectOrientedProgramming
{
    public class Goblin : Character
    {
        private static Random RAND = new Random();

        public Goblin()
        {
            this.Name = "Bob";
            this.HitPoints = 50;
        }

        public override void Defend(Player player)
        {
            player.Defend(this);

            if (this.HitPoints > 0)
            {
                if (RAND.Next(10) < 5)
                {
                    Console.WriteLine("The Goblin Misses! YAY");
                }
                else
                {
                    var damage = RAND.Next(5, 20);
                    player.HitPoints -= damage;
                    Console.WriteLine($"The Goblin hits you for {damage} damage");
                }
            }
        }
        public override void Talk(Player player)
        {
            var damage = RAND.Next(15, 30);
            player.HitPoints -= damage;
            Console.WriteLine($"Goblins don't like to chat! You get hit for {damage} damage");
        }
    }
}
