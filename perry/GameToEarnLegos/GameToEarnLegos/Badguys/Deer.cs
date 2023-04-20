using GameToEarnLegos.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos.Badguys
{
    public class Deer : Badguy
    {
        public Deer(int col, int row, int level) : base(col, row)
        {
            _X = X = col * Tile.TileSize;
            _Y = Y = row * Tile.TileSize;
            if (level == 2)
            {
                Health = 6f;
                BaseSpeed = 2f;
            }

        }
    }
}
