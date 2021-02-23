using System.Collections.Generic;

namespace TextAdventure
{
    public class Player
    {
        public Room CurrentRoom;
        public List<Thing> Inventory = new List<Thing>();
        public bool IsReadyToQuit = false;

    }
}
