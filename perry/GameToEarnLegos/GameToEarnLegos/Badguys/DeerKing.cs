using GameToEarnLegos.Animate;
using GameToEarnLegos.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos.Badguys
{
    public class DeerKing : Badguy
    {
        public DeerKing(int col, int row) : base(col, row)
        {
            _X = X = col * Tile.TileSize;
            _Y = Y = row * Tile.TileSize;
            BaseSpeed = 2f;
            Health = 30f;
            isWanderer = false;
            IsBoss = true;
            animationLeft = Animations.BadguyKingLeft;
            animationRight = Animations.BadguyKingRight;
            animationUp = Animations.BadguyKingUp;
            animationDown = Animations.BadguyKingDown;
            image = Resources.Image_BadguyKing_Right_1;
        }
    }
}
