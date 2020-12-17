using System;
using System.Runtime.CompilerServices;

namespace Anunceartanchoice
{
    class Program
    {
      public const string Bennit = "Bennit";
      public const string Colin = "Colin";
      public const string Derrik = "Derik";
      public const string rose = "Rose";
      public const string juliana = "Juliana";
      public const string sabine = "Sabine";


        static void Main(string[] args)
        {
           var line = (Bennit,"I tend to bore people");
            var line1 = (Colin, "I like Strawberys");
            var line2 = (Derrik, "At least i have the mutt");
            var heart = (sabine, "Me to");
            var heart1 = (juliana, "Hay bail head");
            var heart2 = (rose, "My Lord");
            Console.WriteLine(line);
            Console.WriteLine(heart);
            Console.WriteLine(line1);
            Console.WriteLine(heart1);
            Console.WriteLine(line2);
            Console.WriteLine(heart2);
            Dukeof.AddNumbers(Dukeof.GetRandomNumber(25), Dukeof.GetRandomNumber(1,25));
            Dukeof.subtractnumbers(Dukeof.GetRandomNumber(25), Dukeof.GetRandomNumber(1, 25));
            Dukeof.multplynumbers(Dukeof.GetRandomNumber(25), Dukeof.GetRandomNumber(1, 25));
            Dukeof.WriteStuff("coat of arms");
        }
    }

}
