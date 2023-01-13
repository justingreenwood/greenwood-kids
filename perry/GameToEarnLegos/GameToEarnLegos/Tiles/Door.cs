using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos.Tiles
{
    public class Door : Tile
    {
        public Bitmap closedImage = Resources.Image_ClosedDoor_Thin;
        public Bitmap openImage = Resources.Image_Player;
        public Bitmap closedImageWide = Resources.Image_ClosedDoor_Wide;
        public Bitmap openImageWide = Resources.Image_Player;

        public override string Tag => "door";
        public Door(int col, int row) : base(col, row, Resources.Image_ClosedDoor_Thin) 
        {
            IsBlocker = true; 
        }
    }
}
