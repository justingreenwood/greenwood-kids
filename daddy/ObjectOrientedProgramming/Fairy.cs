using System;

namespace ObjectOrientedProgramming
{
    public class Fairy : Character
    {
        private static Random RAND = new Random();

        public Fairy()
        {
            this.Name = "Gwendolyn";
            this.HitPoints = 200;
        }

        public override void Defend(Player player)
        {
            player.Defend(this);
            if (this.HitPoints > 0)
            {
                if (RAND.Next(30) == 1)
                {
                    Console.WriteLine($"{this.Name} lets you go. It's your lucky day!");
                }
                else
                {
                    var damage = RAND.Next(49, 3000);
                    player.HitPoints -= damage;
                    Console.WriteLine($"{this.Name} smacks you for {damage} damage, you idiot!");
                }
            }
        }

        public override void Talk(Player player)
        {
            var bonus = RAND.Next(1, 100);
            player.HitPoints += bonus;
            Console.WriteLine($"{this.Name} blesses you with {bonus} life after a nice chat!");
        }
    }
}
