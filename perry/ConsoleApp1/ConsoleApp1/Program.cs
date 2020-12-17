using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace Banana
{
    class Program
    {
        public const int NOTE_A = 220;
        public const int NOTE_B = 247;
        public const int NOTE_C = 262;
        public const int NOTE_D = 294;
        public const int NOTE_E = 330;
        public const int NOTE_F = 349;
        public const int NOTE_G = 392;
        static void Main(string[] args)
        {
            
            //Console.Beep(262, 1000);c
            //Console.Beep(294, 500);d
            //Console.Beep(330, 1000);e

            Console.Beep(NOTE_C, 750); Console.Beep(NOTE_D, 750); Console.Beep(NOTE_E, 1000); Console.Beep(NOTE_C, 750); Console.Beep(NOTE_D, 750); Console.Beep(NOTE_E, 1000); Console.Beep(NOTE_D, 750); Console.Beep(NOTE_C, 750); Console.Beep(NOTE_D, 750); Console.Beep(NOTE_E, 750); Console.Beep(NOTE_C, 1000); Console.Beep(NOTE_C, 1000);

            GameTools.FightMonster(monsterName: "Belly Button Nose", enemyhealth: 25);
            


            var PerrysSchool = new schoolwork();
            PerrysSchool.name = "Perry F. Greenwood";
            PerrysSchool.age = 13;
            PerrysSchool.reading = "The Three Musketeers";
            PerrysSchool.Programming = "Banana";
            PerrysSchool.colors = ConsoleColor.Green;
            var AndromedasSchool = new schoolwork();
            AndromedasSchool.name = "Andromeda R. Greenwood";
            AndromedasSchool.age = 16;
            AndromedasSchool.reading = "Ivanhoe";
            AndromedasSchool.Programming = "Complicated";
            AndromedasSchool.colors = ConsoleColor.Yellow;
            var SpencersSchool = new schoolwork();
            SpencersSchool.name = "Spencer A. Greenwood";
            SpencersSchool.age = 100;
            SpencersSchool.reading = "History Stuff";
            SpencersSchool.Programming = "nothing";
            SpencersSchool.colors = ConsoleColor.Magenta;
            var MM = new schoolwork();
            MM.name = "Chocobo Cookies";
            MM.age = 1;
            MM.reading = "M&M packaging.";
            MM.Programming = "MM";
            MM.colors = ConsoleColor.DarkGray;
            var Exit = new schoolwork();
            Exit.name = "Adios";
            Exit.age = 13;
            Exit.reading = "Sign";
            Exit.Programming = "Cookie Place";
            Exit.colors = ConsoleColor.Black;

            Console.WriteLine("Welcome to Chocobo Cookies' Magnificent Cookies.");
        beginning:
            Console.WriteLine("The menu is: Chocobo, Chocobo Chip, Triple Chocobo, Highwind, Bunny, Emerald Weapon, and Balogna.");
            var food = Console.ReadLine();
            if (food == "Chocobo")
            {
                Console.WriteLine($"Here is your {food}.");
                Console.WriteLine("It is a chocolate cookie");
            }
            else if (food == "Chocobo Chip")
            {
                Console.WriteLine($"Here is your {food}.");
                Console.WriteLine("It is a chocolate chip cookie");
            }
            else if (food == "Triple Chocobo")
            {
                Console.WriteLine($"Here is your {food}.");
                Console.WriteLine("It is chocolate, chocolate chip filled, and topped with chocolate chips cookie");
            }
            else if (food == "Highwind")
            {
                Console.WriteLine($"Here is your {food}.");
                Console.WriteLine("It is a sugar cookie");
            }
            else if (food == "Bunny")
            {
                Console.WriteLine($"Here is your {food}");
                Console.WriteLine("It is a Ginger cookie");
            }
            else if (food == "Balogna")
            {
                Console.WriteLine($"Here is your {food}.");
                Console.WriteLine("It is a mixture of cookies.");
            }
            else if (food == "Emerald Weapon")
            {
                Console.WriteLine($"Here is your {food}.");
                Console.WriteLine("It is a Andes Candies chocolate chip green mint cookie.");
            }
            else if (food == "Exit")
            {
                Console.WriteLine("Ok, By.");
                Exit.colors = ConsoleColor.Red;
                

            }   
            else
            {
                Console.Write("That is not part of the menu, but ");
                goto beginning;
            }
            GameTools.FightMonster("Toilet Paper Roll", 50);
            var schoolstuff = new schoolwork[] { PerrysSchool, AndromedasSchool, SpencersSchool, MM, Exit };
            foreach (var school in schoolstuff)
            {
                Console.ForegroundColor = school.colors;
                Console.WriteLine(school.Stuff);
                Console.ForegroundColor = ConsoleColor.White;
            }
            GameTools.FightMonster("Brunett Banana Kitten", 75);
           
            var apple = "-2";
            int banana = 3 - 1;
            int cantalope = 1 + 3;
            int durian = 1 * 3;
            var kiwi = 1.0/3.0 ;
            int cherry = 3 / 1;
            Console.WriteLine($"1 - 3 = {apple}");
            Console.WriteLine($"3 - 1 = {banana}");
            Console.WriteLine($"1 + 3 = {cantalope}");
            Console.WriteLine($"1 * 3 = {durian}");
            Console.WriteLine($"1 / 3 = {kiwi}");
            Console.WriteLine($"3 / 1 = {cherry}");

            GameTools.FightMonster();

            Console.Beep(NOTE_E,750);
            Console.Beep(NOTE_G, 750);
            Console.Beep(NOTE_F, 750);

            Console.Beep(NOTE_E, 750);
            Console.Beep(NOTE_G, 750);
            Console.Beep(NOTE_F, 750);

            Console.Beep(NOTE_E, 750);
            Console.Beep(NOTE_G, 750);
            Console.Beep(NOTE_F, 750);

            Console.Beep(NOTE_E, 750);
            Console.Beep(NOTE_D, 750);
            Console.Beep(NOTE_C, 750);

            Console.Beep(NOTE_D, 2250);

            Console.Beep(NOTE_C, 750);
            Console.Beep(NOTE_E, 750);
            Console.Beep(NOTE_G, 750);

            Console.Beep(NOTE_D, 2250);

            Console.Beep(NOTE_C, 2250);

            Console.Beep(NOTE_E, 750);
            Console.Beep(NOTE_G, 750);
            Console.Beep(NOTE_F, 750);

            Console.Beep(NOTE_E, 750);
            Console.Beep(NOTE_G, 750);
            Console.Beep(NOTE_F, 750);

            Console.Beep(NOTE_E, 750);
            Console.Beep(NOTE_G, 750);
            Console.Beep(NOTE_F, 750);

            Console.Beep(NOTE_E, 750);
            Console.Beep(NOTE_D, 750);
            Console.Beep(NOTE_C, 750);

            Console.Beep(NOTE_D, 2250);

            Console.Beep(NOTE_C, 750);
            Console.Beep(NOTE_E, 750);
            Console.Beep(NOTE_G, 750);

            Console.Beep(NOTE_D, 2250);

            Console.Beep(NOTE_C, 2250);


            Console.Beep(NOTE_D, 750);
            Console.Beep(NOTE_E, 750);
            Console.Beep(NOTE_F, 750);

            Console.Beep(NOTE_D, 750);
            Console.Beep(NOTE_E, 750);
            Console.Beep(NOTE_F, 750);

            Console.Beep(NOTE_E, 750);
            Console.Beep(NOTE_D, 750);
            Console.Beep(NOTE_C, 750);

            Console.Beep(NOTE_E, 750);
            Console.Beep(NOTE_D, 750);
            Console.Beep(NOTE_C, 750);

            Console.Beep(NOTE_D, 750);
            Console.Beep(NOTE_E, 750);
            Console.Beep(NOTE_F, 750);

            Console.Beep(NOTE_D, 750);
            Console.Beep(NOTE_E, 750);
            Console.Beep(NOTE_F, 750);

            Console.Beep(NOTE_E, 750);
            Console.Beep(NOTE_D, 750);
            Console.Beep(NOTE_C, 750);

            Console.Beep(NOTE_D, 2250);

            Console.Beep(NOTE_E, 750);
            Console.Beep(NOTE_G, 750);
            Console.Beep(NOTE_F, 750);

            Console.Beep(NOTE_E, 750);
            Console.Beep(NOTE_G, 750);
            Console.Beep(NOTE_F, 750);

            Console.Beep(NOTE_E, 750);
            Console.Beep(NOTE_G, 750);
            Console.Beep(NOTE_F, 750);

            Console.Beep(NOTE_E, 750);
            Console.Beep(NOTE_D, 750);
            Console.Beep(NOTE_C, 750);

            Console.Beep(NOTE_D, 2250);

            Console.Beep(NOTE_C, 750);
            Console.Beep(NOTE_E, 750);
            Console.Beep(NOTE_G, 750);

            Console.Beep(NOTE_D, 750);
            Console.Beep(NOTE_E, 750);
            Console.Beep(NOTE_D, 750);

            Console.Beep(NOTE_C, 2250);


        }
    }
    public class schoolwork
    {
        public string name;
        public int age;
        public string reading;        
        public string Programming;
        public ConsoleColor colors;
        
        public string Stuff
        {
            get
            {
                return $"{name} Age: {age}; Book: {reading}; Program: {Programming}; Favorite Color: {colors};";
            }
        }

    }
}
