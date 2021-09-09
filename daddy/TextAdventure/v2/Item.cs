using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure.v2
{
    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Synonyms { get; set; } = new List<string>();
        public List<ItemState> States { get; set; } = new List<ItemState>();
        public List<Item> ChildItems { get; set; } = new List<Item>();
    }
}
