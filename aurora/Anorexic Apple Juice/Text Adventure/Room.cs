using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Adventure
{
    class Room
    {
        public string Name;
        public string Description;

        public List<Thing> ThingsInTheRoom = new List<Thing>();
        public List<Room> Connections = new List<Room>();
    }
}
