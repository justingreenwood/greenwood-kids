using System;

namespace DelegateChefs
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Adrian adrian = new Adrian();
            Harper harper = new Harper();
            GetSecretIngredient addSecretIngredient = null;

            while (true)
            {

                Console.WriteLine("A for Adrian, H for Harper, or amount: ");
                string choice = Console.ReadLine();
                if (choice == "a" || choice == "A")
                {
                    Console.WriteLine("Selected Adrian");
                    addSecretIngredient = adrian.MySecretIngredientMethod;

                }
                else if (choice == "h" || choice == "H")
                {
                    Console.WriteLine("Selected Harper");
                    addSecretIngredient = harper.HarpersSecretIngredientMethod;
                }
                else if (int.TryParse(choice, out int amount)) 
                {
                    if(addSecretIngredient is null)
                    {
                        Console.WriteLine("Select a chef!");
                    }
                    else
                    {
                        Console.WriteLine(addSecretIngredient(amount));
                    }
                }
                else
                {
                    return;
                }

            }

        }
    }
}
