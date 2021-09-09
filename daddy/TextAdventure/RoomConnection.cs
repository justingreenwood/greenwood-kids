using System.Collections.Generic;

namespace TextAdventure
{
    public class RoomConnection // like a door, or a thing that can be opened to connect the two rooms.
    {
        public Room FirstRoom;
        public Room SecondRoom;
        public string Name;
        public string Description;
        public string TriggerKey;
        public string State;
        public string OpenState;
        public bool HasBeenLookedAt = false;
        //public string HasNotBeenOpenedDescription;
        public bool CanBeOpenedWithoutKey = false;
        public bool CanBeTaken = true;
        public bool CanBePushed = false;
        public bool CanBeConsumed = false;
        public bool CanBeDestroyed = false;
        public List<string> Synonyms = new List<string>();
        public List<Thing> Things = new List<Thing>();
        public Dictionary<string, ThingState> ThingStates = new Dictionary<string, ThingState>();
        public Dictionary<string, string> Variables = new Dictionary<string, string>();

        public bool HasBeenOpened
        {
            get
            {
                if (OpenState == null) return true;
                else return OpenState == State;
            }
        }

        public void Open()
        {
            if (CanBeOpenedWithoutKey) State = OpenState;
        }

        public bool UseWith(Thing thing)
        {
            if (this.ThingStates.Count == 0) return false;
            else
            {
                foreach (var state in ThingStates.Values)
                {
                    if (state.TriggeredByKey == thing.TriggerKey)
                    {
                        this.State = state.Name;
                        return true;
                    }
                }
            }
            return false;
        }

        public string GetDescription()
        {
            string desc = Description;
            if (ThingStates.Count > 0 && ThingStates.ContainsKey(State))
            {
                if (desc.Length > 0) desc += " ";
                desc += ThingStates[State].Description;
            }
            return desc;
        }

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
