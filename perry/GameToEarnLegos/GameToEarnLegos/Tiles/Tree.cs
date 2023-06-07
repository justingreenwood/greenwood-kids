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
        public int health = 1000;
        public bool isDead = false;
        public Bitmap AliveImage = Resources.Image_Tree1;
        public Bitmap DeadImage = Resources.Image_TreeBurned;
        public Bitmap OnFireImage = Resources.Image_TreeOnFire;

        public Tree(int col, int row, char c) : base(col, row, Resources.Image_Tree1) 
        {
            if (DateTime.Now.Month >= 12)
            {
                AliveImage = Resources.Image_Tree2;
                DeadImage = Resources.Image_Tree2Burned;
                OnFireImage = Resources.Image_Tree2OnFire;
            }
            if (c == 'f')
            {
                isDead = true;
                image = DeadImage;
                health = 0;
            }
            else if(c == 'F')
            {
                isOnFire = true;
                image = OnFireImage;
            }
            else
            {
                image = AliveImage;
            }
            
            IsBlocker = true; 

        }

    }
}
