using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SloppyJoes
{
    class MenuItem
    {

        public static Random Randomizer = new Random();

        public string[] Meats = { "Beef", "Turkey", "Chicken", "Ham", "Sausage", "Bacon" };

        public string[] Sauces = { "djon mustard", "yellow mustard", "relish", "mayo", "ketchup" };

        public string[] Breads = { "rye", "white", "whole wheat", "a roll", };

        public string Description = "";
        public string Price;

        public void Generate()
        {

            string randomMeat = Meats[Randomizer.Next(Meats.Length)];
            string randomSauces = Sauces[Randomizer.Next(Sauces.Length)];
            string randomBreads = Breads[Randomizer.Next(Breads.Length)];
            Description = randomMeat + " with " + randomSauces + " on " + randomBreads + ".";

            decimal dollars = Randomizer.Next(2, 5);
            decimal cents = Randomizer.Next(1, 99);
            decimal price = dollars + (cents * .01M);
            Price = price.ToString("c");

        }



    }
}
