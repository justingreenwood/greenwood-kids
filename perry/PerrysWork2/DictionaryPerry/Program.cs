using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryPerry
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary();


            Console.ReadKey();


            var holder = new NameHolderThingy();
            Console.WriteLine(holder.GetNameAtIndex(0));
            Console.WriteLine(holder.GetNameAtIndex(1));
            holder.SetNameAtIndex(1, "Bob");
            Console.WriteLine(holder.GetNameAtIndex(0));
            Console.WriteLine(holder.GetNameAtIndex(1));


            Console.WriteLine(holder[0]);
            Console.WriteLine(holder[1]);
            holder[1] = "Tim";
            Console.WriteLine(holder[0]);
            Console.WriteLine(holder[1]);


            var namer = new NumberNamer();
            Console.WriteLine(namer.GetNameOfNumber(3));
            Console.WriteLine(namer[3]);
            Console.WriteLine(namer[3, 4]);
            Console.WriteLine(namer["zero"]);
            Console.ReadKey();


            





        }
    }




    public class Dictionary
    {
        private List<DictionaryEntry> entries = new List<DictionaryEntry>();


        private DictionaryEntry FindEntry(string word)
        {
            foreach (var entry in entries)
            {
                if (entry.Word == word) return entry;
            }
            return null;
        }

        public string this[string word]
        {
            get
            {
                var entry = FindEntry(word);
                if (entry == null) return null;
                else return entry.Definition;
            }
            set
            {
                var entry = FindEntry(word);
                if (entry == null)
                    entries.Add(new DictionaryEntry(word, value));
                else
                    entry.Definition = value;              
            }
        }

    }

    public class DictionaryEntry
    {
        public DictionaryEntry(string word, string def)
        {
            this.Word = word;
            this.Definition = def;
        }
        public string Word { get; set; }
        public string Definition { get; set; }
    }



    public class NameHolderThingy
    {
        private string[] _names = new string[] { "Jon", "Ted" };


        public string this[int index]
        {
            get
            {
                return _names[index];
            }
            set
            {
                _names[index] = value;
            }
        }

        public string GetNameAtIndex(int index)
        {
            return _names[index];
        }

        public void SetNameAtIndex(int index, string name)
        {
            _names[index] = name;
        }
    }


    public class NumberNamer
    {
        public string GetNameOfNumber(int n)
        {
            switch (n)
            {
                case 0: return "Zero";
                case 1: return "One";
                case 2: return "Two";
                case 3: return "Three";
                case 4: return "Four";
                default: return "?";
            }
        }

        public string this[int index]
        {
            get
            {
                return GetNameOfNumber(index);
            }
        }

        public string this[int index1, int index2]
        {
            get
            {
                return $"{GetNameOfNumber(index1)} {GetNameOfNumber(index2)}";
            }
        }

        public int this[string name]
        {
            get
            {
                switch (name.ToLower())
                {
                    case "zero": return 0;
                    case "one": return 1;
                    case "two": return 2;
                    case "three": return 3;
                    case "four": return 4;
                    default: return -1;
                }
            }
        }
    }

}
