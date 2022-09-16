using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRoster.ViewModel
{
    class PlayerViewModel
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public PlayerViewModel(int number, string name)
        {
            Number = number;
            Name = name;
        }
        public override string ToString()
        {
            return $"{Name} (#{Number})";
        }
    }
}
