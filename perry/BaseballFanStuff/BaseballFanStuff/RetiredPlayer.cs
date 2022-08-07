using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballFanStuff
{
    class RetiredPlayer
    {

        public int YearRetired { get; set; }
        public string Name { get; set; }

        public RetiredPlayer(string player, int yearRetired)
        {
            Name = player;
            YearRetired = yearRetired;
        }

    }
}
