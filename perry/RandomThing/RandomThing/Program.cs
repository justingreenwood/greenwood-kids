using System;

namespace RandomThing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("So, type what I want you to type.");
            var DUUUDE = Console.ReadLine();

            switch ((DUUUDE))
            {
                case "Que? No papas fritas?! No me gusta!":
                    Console.WriteLine(" Your prize will be received from Aurora if you ask for it. ( Warning: It is rarely the same prize. )");
                    break;
                default:
                    Console.WriteLine("WRONG!");
                    break;
            }

            Console.WriteLine("So, type what I want you to type tomorrow.");
            var Perry = Console.ReadLine();

            switch ((Perry))
            {
                case "Algebra I sucks!":
                    Console.WriteLine(" Your prize will be received from Aurora if you ask for it. ( Warning: It is rarely the same prize. )");
                    break;
                default:
                    Console.WriteLine("WRONG!");
                    break;


            }


            











        }
    }
}
