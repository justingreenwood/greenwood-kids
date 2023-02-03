using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos.Tiles
{
    public class Water : Tile
    {
        public override string Tag => "water";
        public bool HasBridge = false;
        public Water(int col, int row) : base(col, row, Resources.Image_Water) { }
    }
}
