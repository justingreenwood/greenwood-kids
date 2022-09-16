using System;

namespace DogStructAndStuff
{
    class Program
    {
        static void Main(string[] args)
        {

            Canine spot = new Canine("Spot", "pug");
            Canine bob = spot;
            bob.Name = "Spike";
            bob.Breed = "beakle";
            spot.Speak();

            Dog jake = new Dog("Jake", "poodle");
            Dog betty = jake;
            betty.Name = "Betty";
            betty.Breed = "pit bull";
            jake.Speak();



        }

        public struct Dog
        {

            public string Name { get; set; }
            public string Breed { get; set; }

            public Dog(string name, string breed)
            {
                this.Name = name;
                this.Breed = breed;
            }

            public void Speak()
            {
                Console.WriteLine("My name is {0} and I'm a {1}.", Name, Breed);
            }

        }

        public class Canine
        {

            public string Name { get; set; }
            public string Breed { get; set; }

            public Canine(string name, string breed)
            {
                this.Name = name;
                this.Breed = breed;
            }

            public void Speak()
            {
                Console.WriteLine("My name is {0} and I'm a {1}.", Name, Breed);
            }

        }


    }
}
