using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesAndStuff
{

    class TallGuy : IClown
    {
        public string Name;
        public int Height;

        public void TalkAboutYourSelf()
        {
            Console.WriteLine($"My name is {Name} and I am {Height} inches tall.");
        }

        public string FunnyThingIHave { get { return "big shoes"; } }
        public void Honk()
        {
            Console.WriteLine("Honk honk!");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            TallGuy tallGuy = new TallGuy() { Height = 76, Name = "Jimmy" };
            tallGuy.TalkAboutYourSelf();
            Console.WriteLine($"The tall guy has {tallGuy.FunnyThingIHave}.");
            tallGuy.Honk();

        }
    }
}
