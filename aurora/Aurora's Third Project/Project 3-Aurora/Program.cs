using System;
using System.Reflection;

namespace Project_3_Aurora
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Make me a sammich!");
            Console.WriteLine(" Or......");
            Console.WriteLine(" Would you rather answer some questions?(y or n)");

            var NotImportantButStillFunToMake = Console.ReadLine();

            switch (NotImportantButStillFunToMake)
            {
                case "y":
                    Console.WriteLine("Wise choice, child that is not mine because if you were that would just be disgusting and weird.");
                    break;
                default:
                    Console.WriteLine(" I pity the fool, because only 'y' was an option!!!!");
                    break;
            }
            Console.WriteLine(" Remember you are here because you were caught illegally not making me a sammich.");
            Console.WriteLine(" Shall we begin? Yes, we shall.");

            Console.WriteLine(" First off, what is your name?");
            var Name = Console.ReadLine();

            Console.WriteLine(" Ok, I can tell your gender as I'm looking straight at your face, but I may as well ask. Are you male or female?");
            var Gender = Console.ReadLine();


            Console.WriteLine("Ok, last and very quick question. How old are you?");
            var age = Console.ReadLine();

            Console.WriteLine($" Well, your name is clearly {Name} and you are clearly {Gender}. But your age is a lie. You look like you are SIXTY!");

        }
    }
}
