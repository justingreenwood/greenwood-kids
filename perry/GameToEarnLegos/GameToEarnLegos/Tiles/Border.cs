using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos.Tiles
{
    public class Border : Tile
    {
        public Border(int col, int row) : base(col, row, Resources.Image_Border) { IsBlocker = true; }
    }
}
