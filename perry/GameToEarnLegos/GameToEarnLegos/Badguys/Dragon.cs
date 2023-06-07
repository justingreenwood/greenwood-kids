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
        Animation animationDownLeft;
        Animation animationDownRight;
        Animation animationUpLeft;
        Animation animationUpRight;
        EightWayDirection spriteDirection = EightWayDirection.South;

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
            animationDownLeft = Animations.DragonDownLeft;
            animationDownRight = Animations.DragonDownRight;
            animationUpLeft = Animations.DragonUpLeft;
            animationUpRight = Animations.DragonUpRight;
            image = Resources.Image_DragonStillDown;
            AmmoType = "dragonfire";
        }

        public override void UpdateAnimationState()
        {
            Animation newAnimation = null;
            spriteDirection = Utility.Get8WayDirection(SpeedLeftOrRight, SpeedUpOrDown, spriteDirection);

            switch (spriteDirection)
            {
                case EightWayDirection.North:
                    newAnimation = animationUp;
                    break;
                case EightWayDirection.NorthEast:
                    newAnimation = animationUpRight;
                    break;
                case EightWayDirection.East:
                    newAnimation = animationRight;
                    break;
                case EightWayDirection.SouthEast:
                    newAnimation = animationDownRight;
                    break;
                case EightWayDirection.South:
                    newAnimation = animationDown;
                    break;
                case EightWayDirection.SouthWest:
                    newAnimation = animationDownLeft;
                    break;
                case EightWayDirection.West:
                    newAnimation = animationLeft;
                    break;
                case EightWayDirection.NorthWest:
                    newAnimation = animationUpLeft;
                    break;
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
