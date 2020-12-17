using System;
using System.Threading;

namespace ohdevotedone
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("O Devoted One!");
            Console.WriteLine("write a female name");
            var name1 = Console.ReadLine();
            Console.WriteLine("write a male name");
            var name2 = Console.ReadLine();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{name1} is dating {name2}.");
            Thread.Sleep(1000);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
        jane:
            Console.WriteLine("which book do you prefer");
            Console.WriteLine("(a)My invisible enemy(b)All fair in love, war, and Highschool(c)IVANHOE");
            var sharp = Console.ReadLine();
            if (sharp == "a")
                Console.WriteLine("hilarios");
            else if (sharp == "b")
                Console.WriteLine("AURORA AGREES");
            else if (sharp == "c")
                Console.WriteLine("You must like good litature");
            else
            {
                goto jane;
            }
            Thread.Sleep(1000);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            silencer:
            Console.WriteLine("which show do you prefer");
            Console.WriteLine("(p)layfull kiss(h)ealer(m)asters sun");
            var stormyweather = Console.ReadLine();
            if (stormyweather == "p")
                Console.WriteLine("I agree");
            else if (stormyweather == "h")
                Console.WriteLine("you like action");
            else if (stormyweather == "m")
                Console.WriteLine("you like semi scary shows");
            else
            {
                goto silencer;
            }
            Thread.Sleep(1000);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
        Luka:
            Console.WriteLine("which westearn movie do you perfer");
            Console.WriteLine("(o)pen range(M)ckintock(t)rue grit");
            var Auroraborial = Console.ReadLine();
            if (Auroraborial == "o")
                Console.WriteLine("sad");
            else if (Auroraborial == "M")
                Console.WriteLine("man power");
            else if (Auroraborial == "t")
                Console.WriteLine("?");
            else
            {
                goto Luka;
            }
            Thread.Sleep(1000);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
        lizander:
            Console.WriteLine("which movie series do you prefer");
            Console.WriteLine("(P)irates of the caribean(T)hin man(z)Mission imposible");
            var chord = Console.ReadLine();
            if (chord == "P")
                Console.WriteLine("you like pirate themed stuff");
            else if (chord == "T")
                Console.WriteLine("you like mysteries");
            else if (chord == "z")
                Console.WriteLine("you like silly action");
            else
            {
                goto lizander;
            }
        }
    }
}
