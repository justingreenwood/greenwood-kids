using System;

namespace FreeAndProud
{
    public class MyFavoriteThings
    {

        public string Chocolate;
        public string Perry;
        public string AddictiveChips;

        public void PrintMyFavoriteThings()
        {
            Console.WriteLine($"{this.Chocolate}, {this.Perry}, {this.AddictiveChips}");
        }
    }

}