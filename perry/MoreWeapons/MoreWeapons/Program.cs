using System;

namespace MoreWeapons
{
    class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            ArrowDamage arrowDamage = new ArrowDamage(RollDice(1));
            SwordDamage swordDamage = new SwordDamage(RollDice(3));


            while (true)
            {
                Console.Write("Write 0 for no magic or flaming, 1 for magic, 2 for flame, 3 for both, and anything else to quit: ");
                char choice = Console.ReadKey().KeyChar;
                if (choice != '0' && choice != '1' && choice != '2' && choice != '3')
                {
                    return;
                }

                Console.Write("\nS for sword, A for arrow, and anything else to quit: ");
                char weaponKey = Char.ToUpper(Console.ReadKey().KeyChar);

                switch (weaponKey)
                {
                    case 'S':
                        swordDamage.Roll = RollDice(3);
                        swordDamage.Magic = (choice == '1' || choice == '3');
                        swordDamage.Flaming = (choice == '2' || choice == '3');
                        Console.WriteLine($"\nRolled {swordDamage.Roll} for {swordDamage.Damage} HP\n");

                        break;
                    case 'A':
                        arrowDamage.Roll = RollDice(1);
                        arrowDamage.Magic = (choice == '1' || choice == '3');
                        arrowDamage.Flaming = (choice == '2' || choice == '3');
                        Console.WriteLine($"\nRolled {arrowDamage.Roll} for {arrowDamage.Damage} HP\n");
                        break;
                    default:
                        return;

                }

            }

        }

        private static int RollDice(int rolls)
        {
            int total = 0;
            for(int i = 0; i < rolls; i++)
            {
                total += random.Next(1, 7);
            }
            return total;
        }


    }
}
