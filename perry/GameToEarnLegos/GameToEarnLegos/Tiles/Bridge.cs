using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos.Tiles
{
    public class Bridge : Tile
    {
        
        private Bitmap ImageUpDown = Resources.Image_BridgeUpDown;
        private Bitmap ImageLeftRight = Resources.Image_BridgeLeftRight;
        private bool LeftRight;
        public override string Tag => "bridge";
        public Bridge(int col, int row, bool leftRight) : base(col, row, Resources.Image_ClosedDoor_Thin)
        {
            LeftRight = leftRight;
            if (leftRight)
            {
                ImageUpDown = ImageLeftRight;
            }
            this.image = ImageUpDown;
        }
    }
}
