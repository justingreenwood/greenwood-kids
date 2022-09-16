using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchGame
{
    class IfsForAnimals
    {

        public string NameToAnimal(string name)
        {
            string text = " ";
            if(name == "Chicken")
            {
                text = "🐔";
                return text;
            }
            else if(name == "Panda")
            {
                text = "🐼";
                return text;
            }
            else if (name == "Monkey")
            {
                text = "🐵";
                return text;
            }
            else if (name == "Mouse")
            {
                text = "🐭";
                return text;
            }
            else if (name == "Cat")
            {
                text = "😺";
                return text;
            }
            else if (name == "Pig")
            {
                text = "🐗";
                return text;
            }
            else if (name == "Rabbit")
            {
                text = "🐰";
                return text;
            }
            else
            {
                text = "🦝";
                return text;
            }
        }

    }
}
