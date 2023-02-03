using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos.Tiles
{
    public class Gold : Tile
    {
        public bool IsPickedUp = false;
        public override string Tag => "gold";

        public Gold(int col, int row) : base(col, row, Resources.Image_Treasure) { }
    }
}
