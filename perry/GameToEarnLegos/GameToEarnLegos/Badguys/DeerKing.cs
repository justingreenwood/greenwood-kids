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
            Width = 20;
            Height = 20;
            if (DateTime.Now.Month >= 12)
            {
                animationLeft = Animations.BadguyKingSnowLeft;
                animationRight = Animations.BadguyKingSnowRight;
                animationUp = Animations.BadguyKingSnowUp;
                animationDown = Animations.BadguyKingSnowDown;
                image = Resources.Image_BadguyKing_Snow_Right_1;
                deadImage = Resources.Image_Badguy_King_Snow_Dead;
            }
            else
            {
                animationLeft = Animations.BadguyKingLeft;
                animationRight = Animations.BadguyKingRight;
                animationUp = Animations.BadguyKingUp;
                animationDown = Animations.BadguyKingDown;
                image = Resources.Image_BadguyKing_Right_1;
            }
        }
        public override bool CheckIfNoticed(Player player)
        {

            double distance = GetDistance(new PointF(player.X, player.Y), CenterPoint);
            if (distance <= 60 || NoticedPlayer == true)
            {
                return true;
            }
            else
                return false;

        }
    }
}
