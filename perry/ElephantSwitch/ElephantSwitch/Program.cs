using System;

namespace ElephantSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            Elephant pinky = new Elephant() { Name = "Pinky", Ears = 36 };
            Elephant twizzler = new Elephant() { Name = "Twizzler", Ears = 41 };
            Elephant brain = new Elephant() { Name = "Brain", Ears = 50 };

            while (true)
            {

                Console.WriteLine("Press 1 for Pinky, press 2 for Twizzler, press 3 for swap, and anything else to exit.");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    pinky.WhoAmI();
                }
                else if (choice == "2")
                {
                    twizzler.WhoAmI();
                }
                else if (choice == "3")
                {
                    brain = twizzler;
                    twizzler = pinky;
                    pinky = brain;
                    Console.WriteLine("They have been swapped.");
                }
                else
                {
                    return;
                }

            }
        

        }
    }
}
