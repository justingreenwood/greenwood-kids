using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos.Tiles
{
    public class Door : Tile
    {
        public Bitmap closedImage = Resources.Image_ClosedDoor_Thin;
        public Bitmap openImage = Resources.Image_OpenDoor_Thin;
        private Bitmap closedImageWide = Resources.Image_ClosedDoor_Wide;
        private Bitmap openImageWide = Resources.Image_OpenDoor_Wide;
        private bool LeftRight;
        public bool IsClosed = true;
        public bool isBossDoor = false;
        public override string Tag => "door";
        public override int DrawLevel => 300;
        public Door(int col, int row, bool leftRight, char kindOfDoor) : base(col, row, Resources.Image_ClosedDoor_Thin)
        {
            LeftRight = leftRight;
            if (leftRight)
            {
                closedImage = closedImageWide;
                openImage = openImageWide;
            }
            this.image = closedImage;
            if(kindOfDoor == 'B')
                isBossDoor = true;
        }


    }
}
