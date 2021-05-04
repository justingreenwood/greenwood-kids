using System;
using System.Collections.Generic;

namespace Dictionary_with_Perry
{
    class Program
    {

        static void Main(string[] args)
        {
            var senorperryesmimaestro = new DICTIONARY();

            senorperryesmimaestro["apple"] = "A red fruit that when squished makes me think of crushing Perry's overly intelligent pea brain.";
            Console.WriteLine("Let us just say it works and be done with this.");





        }

    }

    public class DICTIONARY
    {
        private List<Dictionary> banana = new List<Dictionary>();

        private Dictionary Figurethingsout(string whateveryoudlikeanything)
        {

            foreach (var anythingyouwanttotypeinthere in banana)
            {
                if (anythingyouwanttotypeinthere.Word == whateveryoudlikeanything) return anythingyouwanttotypeinthere;
            }
            return null;

        }

        public string this [string burrito]
        {
            get
            {
                
                var howabouthiswhateveryouwanttosay = Figurethingsout(burrito);
                if (howabouthiswhateveryouwanttosay == null) return null;
                else return howabouthiswhateveryouwanttosay.Definition;

            }
            set
            {

                var howabouthiswhateveryouwanttosay = Figurethingsout(burrito);
                if (howabouthiswhateveryouwanttosay == null)
                    banana.Add(new Dictionary(burrito, value));
                else howabouthiswhateveryouwanttosay.Definition = value;



            }
        }
        


    }
    public class Dictionary
    {
        public Dictionary(string word, string definition) 
        {
            this.Word = word;
            this.Definition = definition;
        }

        public string Word { get; set; }
        public string Definition { get; set; }
    }
}
