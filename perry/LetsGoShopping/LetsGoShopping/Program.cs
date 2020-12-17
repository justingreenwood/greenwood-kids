using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;

namespace LetsGoShopping
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The shopping list is:");
            for (int i = 0; i < ShoppingList.Length; i++)
            {
                Console.WriteLine(ShoppingList[i]);
            }
            Console.ReadKey();
            Console.Clear();
            while (true)
            {

                Console.WriteLine("What is the fifth item in the list.");
                string a = Console.ReadLine();
                a = a.ToLower();
                if (a == "peach")
                    Console.WriteLine("You are correct.");
                else
                {
                    Console.WriteLine("You are incorrect.");
                    break;
                }
                Console.WriteLine("What is the seventh item in the list.");
                a = Console.ReadLine();
                a = a.ToLower();
                if (a == "pineapple")
                    Console.WriteLine("You are correct.");
                else
                {
                    Console.WriteLine("You are incorrect.");
                    break;
                }
                Console.WriteLine("What is the fourteenth item in the list.");
                a = Console.ReadLine();
                a = a.ToLower();
                if (a == "lime")
                    Console.WriteLine("You are correct.");
                else
                {
                    Console.WriteLine("You are incorrect.");
                    break;
                }
                Console.WriteLine("You are good at memorizing!");
                break;

            }

            for (int r = 0; r < names.Length; r++)
            {
                Console.WriteLine(names[r]);
            }
            Console.WriteLine("Youngest to Oldest");
            Program.Lame();
            Console.WriteLine("Oldest to Youngest");
            Program.Lamer();

            /*Console.WriteLine("Banana");*/
            //Console.WriteLine("Banana");
            bool abby = false;

            while(abby == false)
            {
                Console.WriteLine("Banana");
                abby = true;
            }

        }
        static string[] Name = { "Jack", "John", "Jill", "Jane", "James", "Jim", "Julia" };
        static string[] ShoppingList = { "Banana", "Apple", "Kiwi", "Orange", "Peach", "Pear", "Pineapple","Tomatoes", "Grapes", "Cantalope", "Water Melon", "Cucumber", "Lemon", "Lime","Grapefruit"};
        static string[] names = { "Dad", "M.O.M.", "Leelando", "Billy Bob Baggy Pants", "Roberto", "Scary Mary", "Andy's Candies", "Aurora", "Perry", "Whit Spit", "Spenceer", };
        public static void Lame()
        {
            for (int x = 0; x < Name.Length; x++)
            {
                Console.WriteLine(Name[x]);
            }
        }
        public static void Lamer()
        {  
            for (int y = 6; y >= 0; y--)
            {
                Console.WriteLine(Name[y]);
            }
        }

    }
}
