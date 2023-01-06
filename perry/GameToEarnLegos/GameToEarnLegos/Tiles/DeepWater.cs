using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos.Tiles
{
    public class DeepWater : Tile
    {
        public DeepWater(int col, int row, Color color) : base(col, row)
        {
            brush = new SolidBrush(color);
            IsBlocker = true;
        }
    }
}
