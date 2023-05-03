using GameToEarnLegos.Animate;
using GameToEarnLegos.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos.Badguys
{
    public class Dragon : Badguy
    {

        public Dragon(int col, int row) : base(col, row)
        {
            _X = X = col * Tile.TileSize;
            _Y = Y = row * Tile.TileSize;
            BaseSpeed = 2.2f;
            Health = 50f;
            IsBoss = true;
            canShoot = true;
            BaseShootingCoolDown = 25;
            Width = 30;
            Height = 30;
            animationLeft = Animations.DragonLeft;
            animationRight = Animations.DragonRight;
            animationUp = Animations.DragonUp;
            animationDown = Animations.DragonDown;
            image = Resources.Image_DragonStillDown;
            AmmoType = "dragonfire";
        }

        public override void UpdateAnimationState()
        {
            Animation newAnimation = null;

            if (SpeedLeftOrRight < -0.5)
            {
                if (currentAnimation != animationLeft)
                {
                    newAnimation = animationLeft;
                };
            }
            else if (SpeedLeftOrRight > 0.5)
            {
                if (currentAnimation != animationRight)
                {
                    newAnimation = animationRight;
                }
            }
            else if (SpeedUpOrDown < 0)
            {
                if (currentAnimation != animationUp)
                {
                    newAnimation = animationUp;
                }
            }
            else if (SpeedUpOrDown > 0)
            {
                if (currentAnimation != animationDown)
                {
                    newAnimation = animationDown;
                }
            }
            else
            {
                currentAnimation = null;
            }

            if (newAnimation != null)
            {
                currentAnimation = newAnimation;
                currentFrameIndex = 0;
                currentFrameCountdown = currentAnimation.Frames[currentFrameIndex].Duration;
            }

        }


    }
}
