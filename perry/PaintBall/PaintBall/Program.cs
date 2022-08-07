using System;

namespace PaintBall
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBalls = ReadInt(20, "Number of balls");
            int magazineSize = ReadInt(16, "Magazine Size");
            Console.Write($"Loaded[false]: ");
            bool.TryParse(Console.ReadLine(), out bool isLoaded);

            PaintballGun gun = new PaintballGun(numberOfBalls,magazineSize,isLoaded);
            while (true)
            {

                Console.WriteLine($"{gun.Balls} balls, {gun.ballsLoaded} loaded.");
                if (gun.IsEmpty())
                {
                    Console.WriteLine("You are out of ammo.");
                }
                Console.WriteLine("Space to shoot, r to reload, + to add ammo, and q to quit.");
                char key = Console.ReadKey().KeyChar;
                if(key==' ')
                {
                    Console.WriteLine($"Shooting returned {gun.Shoot()}");
                }
                else if(key == 'r')
                {
                    gun.Reload();
                }
                else if (key == '+')
                {
                    gun.Balls += gun.magazineSize;
                }
                else if (key == 'q')
                {
                    return;
                }

            }
            static int ReadInt(int lastUsedValue, string prompt)
            {

                Console.Write(prompt + " [" + lastUsedValue + "]: ");
                string line = Console.ReadLine();
                if (int.TryParse(line, out int value))
                {
                    Console.WriteLine("   using value" + value);
                    return value;
                }
                else
                {
                    Console.WriteLine("   using default value" + lastUsedValue);
                    return lastUsedValue;
                }

            }

        }
    }
}
