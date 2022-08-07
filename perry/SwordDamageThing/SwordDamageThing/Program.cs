using System;

namespace SwordDamageThing
{
    class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            
            SwordDamage swordDamage = new SwordDamage(RollDice());

            while(true)
            {
                Console.Write("Write 0 for no magic or flaming, 1 for magic, 2 for flame, 3 for both, and anything else to quit: ");
                char choice = Console.ReadKey().KeyChar;
                if(choice != '0' && choice != '1' && choice != '2' && choice != '3')
                {
                    return;
                }
                

                swordDamage.Roll = RollDice();
                swordDamage.Magic=(choice == '1' || choice == '3');
                swordDamage.Flaming=(choice == '2' || choice == '3');

                Console.WriteLine($"\nRolled {swordDamage.Roll} for {swordDamage.Damage} HP\n");
                
            }
            
        }

        private static int RollDice()
        {
            return random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
        }

    }
}
