using GameToEarnLegos.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos.Badguys
{
    public class FlameTower: Badguy
    {
        public FlameTower(int col, int row) : base(col, row)
        {
            _X = X = col * Tile.TileSize;
            _Y = Y = row * Tile.TileSize;

            canMove = false;
            Health = 12f;
            canShoot = true;
            image = Resources.Image_TowerBadguy;
            deadImage = Resources.Image_DeadTowerBadguy;
            typeOfBadguy = "tower";
            Width = 20;
            Height = 20;


        }
    }
}
