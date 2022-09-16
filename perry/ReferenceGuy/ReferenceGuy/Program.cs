﻿using System;

namespace ReferenceGuy
{
    class Program
    {
        static void ModifyAnIntAndGuy(ref int valueRef, ref Guy guyRef)
        {
            valueRef += 10;
            guyRef.Name = "Bob";
            guyRef.Age = 37;
        }

        static void Main(string[] args)
        {
            var i = 1;
            var guy = new Guy() { Name = "Joe", Age = 26 };
            Console.WriteLine("i is {0} and guy is {1}", i, guy);
            ModifyAnIntAndGuy(ref i, ref guy);
            Console.WriteLine("Now i is {0} and guy is {1}", i, guy);

            Guy Dude;
            Dude = new Guy() { Age = 25 };
            Console.WriteLine($"Dude.Name is {Dude.Name.Length} letters long.");

        }
    }

    class Guy
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString() => $"a {Age}-year-old named {Name}";

    }





}
