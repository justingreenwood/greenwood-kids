using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos.Tiles
{
    public class DeepWater : Tile
    {
        public override string Tag => "deepwater";
        public override int DrawLevel => 100;
        public DeepWater(int col, int row) : base(col, row, Resources.Image_DeepWater)
        {
            
            IsBlocker = true;
        }
    }
}
