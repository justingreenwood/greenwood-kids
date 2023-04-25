using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos.Tiles
{
    public class Sand : Tile
    {
        public string Kind;
        public override string Tag => "sand";
        public override int DrawLevel => 100;
        public Sand(int col, int row, string type) : base(col, row, Resources.Image_Sand) 
        { 
            Kind = type;

        }
    }
}
