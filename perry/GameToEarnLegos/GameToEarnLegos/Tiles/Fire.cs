using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos.Tiles
{
    public class Fire : Tile
    {
        public Bitmap Out = Resources.Image_FireOut;
        public Bitmap On = Resources.Image_Fire;
        public bool IsOut = false;
        public override string Tag => "fire";
        public Fire(int col, int row) : base(col, row, Resources.Image_Fire)
        {

        }
    }
}
