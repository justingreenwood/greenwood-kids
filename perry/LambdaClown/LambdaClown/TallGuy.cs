using System;
using System.Collections.Generic;
using System.Text;

namespace LambdaClown
{
    class TallGuy:IClown
    {

        public string Name;
        public int Height;

        public string FunnyThingsIHave => "Lego Baby and Lego Scooby Doo";

        public void Honk() => Console.WriteLine("Click Crash!");      

        public void TalkAboutYourself()
        {
            Console.WriteLine($"My name is {Name} and I am {Height} inches tall.");
        }

    }

    interface IClown
    {
        string FunnyThingsIHave { get; }
        void Honk();

    }
}
