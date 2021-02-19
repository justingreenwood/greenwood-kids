using System.Collections.Generic;

namespace TextAdventure
{
    public class Room
    {
        public string Name;
        public string Description;

        public List<Thing> ThingsInTheRoom = new List<Thing>();
        public List<Room> Connections = new List<Room>();
        public List<string> Synonyms = new List<string>();

        public bool IsMatchingName(string text)
        {
            if (Name.Equals(text.Trim(), System.StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
            foreach (var alternateName in Synonyms)
            {
                if (alternateName.ToLower() == text.Trim().ToLower())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
