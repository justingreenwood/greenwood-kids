using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos.Tiles
{
    public class Wall : Tile
    {
        public Wall(int col, int row) : base(col, row, Resources.Image_Wall) { IsBlocker = true; }
    }
}
