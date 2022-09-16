using System;

namespace LambdaClown
{
    class Program
    {
        static void Main(string[] args)
        {
            TallGuy tallGuy = new TallGuy() { Height = 76, Name = "Zack" };
            tallGuy.TalkAboutYourself();
            Console.WriteLine($"The tall guy has {tallGuy.FunnyThingsIHave}");
            tallGuy.Honk();
        }
    }
}
