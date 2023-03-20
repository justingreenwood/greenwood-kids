using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos.Tiles
{
    public class Tree : Tile
    {
        public override string Tag => "tree";
        public bool isOnFire = false;
        public int health = 100;
        public bool isDead = false;
        public Bitmap AliveImage = Resources.Image_Tree1;
        public Bitmap DeadImage = Resources.Image_Tree2;
        public Bitmap OnFireImage = Resources.Image_BadguyFireAmmo;
        public Tree(int col, int row) : base(col, row, Resources.Image_Tree1) { IsBlocker = true; }
        public Tree(int col, int row, char c) : base(col, row, Resources.Image_Tree1) 
        { 
            if(c == 'f')
            {
                isDead = true;
            }
            else
            {
                isOnFire = true;
            }
            IsBlocker = true; 
        }

    }
}
