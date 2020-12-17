using System;

namespace ImagineTheAaroniteKidsAsParents
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("The shopping list is:");

            for (int Potato = 0; Potato < ShoppingList.Length; Potato++)
            {
                Console.WriteLine(ShoppingList[Potato]);
        }
            Console.ForegroundColor = ConsoleColor.White;
        }

        static string[] ShoppingList = { "2 Gallons of Milk", "A Dozen Eggs", "Sugar", "Flour", "2 Yellow Potatoes", "3 Large White Onions", "A Pineapple", "Sandwich Meat", "Shredded Cheese", "Hawaiian Rolls", "Large Case of Bottled Water", "Cream Cheese", "Frozen Dinners", "A Bottle of Wine" };
    }
    }

