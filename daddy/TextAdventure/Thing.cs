using System.Collections.Generic;

namespace TextAdventure
{
    public class Thing
    {
        public string Name;
        public string Description;
        public bool HasBeenLookedAt = false;
        public bool CanBeTaken = true;
        public List<string> Synonyms = new List<string>();
        public List<Thing> Things = new List<Thing>();

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
