using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos.Tiles
{
    public class Tree : Tile
    {
        public Tree(int col, int row) : base(col, row, Resources.Image_Tree1) { IsBlocker = true; }
    }
}
