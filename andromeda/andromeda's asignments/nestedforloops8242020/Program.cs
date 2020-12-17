using System;

namespace nestedforloops8242020
{
  class Program
  {
   static void Main(string[] args)
   {
        num1:
            Console.Write("Enter start value for x:");
            var startX = Console.ReadLine();
            if (!int.TryParse(startX, out int sx))
            {
                Console.WriteLine($"{startX} is not a valid integer - DUMDUM!");
                goto num1;
            }
        num2:
            Console.Write("Enter end value for x:");
            var endX = Console.ReadLine();
            if (!int.TryParse(endX, out int ex))
            {
                Console.WriteLine($"{endX} is not a valid integer - idiot!");
                goto num2;
            }
            while (sx <= ex)
            {
                int answer = (4 * sx + 2);
                Console.WriteLine($"Answer is:{answer}");
                sx = sx + 1;
            }
                Console.WriteLine("The shopping list is:");
    for (int i = 0; i < groceries.Length; i++)
    {
                Console.WriteLine(groceries[i]);
    }
   }        
            static string[] groceries = { "Apples", "Oranges", "Bread", "Soynut Butter", "Grapes", "Paper Towels" };
  } 
}
