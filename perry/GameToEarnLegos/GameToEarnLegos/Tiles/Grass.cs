using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos.Tiles
{
    public class Grass : Tile
    {
        public override string Tag => "grass";
        public override int DrawLevel => 100;
        public Grass(int col, int row) : base(col, row, Resources.Image_Grass) 
        {
            if (DateTime.Now.Month >= 12)
            {
                image = Resources.Image_Grass2;
            }
        }
    }
}
