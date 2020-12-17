using System;

namespace list_mytodo_
{
  class Program
  {
    static void Main(string[] args)
    {
     Console.WriteLine("The grocery list is:");
     for (int i = 0; i < grocery.Length; i++)
     {
      Console.WriteLine(grocery[i]);
     }
     Console.WriteLine("");
     Console.WriteLine("The clothing shoping list is:");
     for (int i = 0; i < clothing.Length; i++)
     {
      Console.WriteLine(clothing[i]);
     }
     Console.WriteLine("");
     Console.WriteLine("The craft shoping list is:");
     for (int i = 0; i < craft.Length; i++)
     {
     Console.WriteLine(craft[i]);
     }
     Console.WriteLine("");
     Console.WriteLine("The todo list is:");
     for (int i = 0; i < todo.Length; i++)
     {
      Console.WriteLine(todo[i]);
     }
     while (true)
     {
                Console.WriteLine("Algebra Expresion Program");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                Console.WriteLine("y=mx+b");
                Console.WriteLine("a=hz+d");
            num:
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                Console.WriteLine("enter a value for m");
                var e = Console.ReadLine();
                if (!double.TryParse(e, out double m))
                {
                    Console.WriteLine($"{e} is not a valid integer - DUMDUM!");
                    goto num;
                }
            num1:
                Console.WriteLine("enter the value for x");
                var a = Console.ReadLine();
                if (!double.TryParse(a, out double x))
                {
                    Console.WriteLine($"{a} is not a valid integer - silly!");
                    goto num1;
                }
            num2:
                Console.WriteLine("enter the value for b");
                var s = Console.ReadLine();
                if (!double.TryParse(s, out double b))
                {
                    Console.WriteLine($"{s} is not a valid integer - funny!");
                    goto num2;
                }
               num3:
                Console.Write("enter a value for h");
                var i = Console.ReadLine();
                if (!double.TryParse(i, out double h))
                {
                    Console.WriteLine($"{i} is not a valid integer - weirdo!");
                    goto num3;
                }
            num4:
                Console.Write("enter the value for z");
                var c = Console.ReadLine();
                if (!double.TryParse(c, out double z))
                {
                    Console.WriteLine($"{c} is not a valid integer - DUMDUM!");
                    goto num4;
                }
            num5:
                Console.Write("enter the value for d");
                var w = Console.ReadLine();
                if (!double.TryParse(w, out double d))
                {
                    Console.WriteLine($"{w} is not a valid integer - DUMDUM!");
                    goto num5;
                }
                Console.WriteLine($"the answer is y={m * x + b}");
                Console.WriteLine($"the answer is a={h * z + d}");
            perry:
                Console.WriteLine("would you like to play again (y/n)");
                var ans = Console.ReadKey();
                if (ans.Key == ConsoleKey.N)
                    break;
                else if (ans.Key == ConsoleKey.Y)
                    Console.WriteLine("OKAY");
                else
                {
                    Console.WriteLine("Your idiotic");
                    goto perry;
                }
     }
    }
   static string[] grocery = { "Apples", "Apple Juice", "Apple Cider", "Soynut Butter", "Sparkling Grape Juice", "Paper Towels", "Apple Butter", "Yogert", "Raspberries", "Blackberries", "Blueberries", "Strawberies" };
   static string[] clothing = { "Pants", "Earings", "Scarf", "Snowboots", "Dress" };
   static string[] craft = { "Rubberbands", "Meltingbeads", "Fabrics", "Thread", "Needles", "Oragomy Paper" };
   static string[] todo = { "Wake up", "Eat", "Schoolwork", "Sleep" };
  }
}
    
   
