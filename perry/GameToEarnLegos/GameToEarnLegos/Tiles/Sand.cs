using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos.Tiles
{
    public class Sand : Tile
    {
        public override string Tag => "sand";
        public Sand(int col, int row) : base(col, row, Resources.Image_Sand) { }
    }
}
