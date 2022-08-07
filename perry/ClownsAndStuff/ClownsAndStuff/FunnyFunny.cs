using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClownsAndStuff
{
    class FunnyFunny : IClown
    {

        private string funnyThingIHave;
        public string FunnyThingIHave { get {return funnyThingIHave; } }

        public FunnyFunny(string funnyThingIHave)
        {
            this.funnyThingIHave = funnyThingIHave;
        }

        public void Honk()
        {
            Console.WriteLine($"Hi kids! I have a {funnyThingIHave}.");
        }

    }

    class ScaryScary : FunnyFunny, IScaryClown
    {
        private int scaryThingCount;

        public ScaryScary(string funnyThing, int scaryThingCount) : base(funnyThing)
        {
            this.scaryThingCount = scaryThingCount;
        }

        public string ScaryThingIHave { get { return $"{scaryThingCount} spiders"; } }

        public void ScareLittleChildren()
        {

            Console.WriteLine($"Boo! Gotcha! Look at my {ScaryThingIHave}.");

        }

    }

}
