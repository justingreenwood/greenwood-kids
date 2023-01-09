using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameToEarnLegos.Animate;
using GameToEarnLegos.Tiles;

namespace GameToEarnLegos
{
    /// <summary>
    /// This is the bad guy class, when I control bad guy stuff.
    /// </summary>
    public class Badguy : IDrawable
    {
        Random random = new Random();
        public float X;
        public float Y;
        public SolidBrush brush = new SolidBrush(Color.Black);
        public float BaseSpeed = 1.5f;
        public float SpeedUpOrDown = 0;
        public float SpeedLeftOrRight = 0;
        public float WaterSpeedUpOrDown = 0;
        public float WaterSpeedLeftOrRight = 0;
        public float Health = 3f;
        public Bitmap image = Resources.Image_Badguy;
        public float Width = 15;
        public float Height = 15;

        public int UpDownDirection = 0;
        public int RightLeftDirection = 0;
        public int LengthOfDirection = 0;
        public bool IsDead = false;
        public bool IsInWater;

        private bool GoingUp = false;
        private bool GoingDown = false;
        private bool GoingLeft = false;
        private bool GoingRight = false;

        public Animation currentAnimation = null;
        public int currentFrameIndex = 0;
        public int currentFrameCountdown = 0;

        public void AnimationTick()
        {
            if (currentAnimation != null)
            {

                currentFrameCountdown--;
                if (currentFrameCountdown <= 0)
                {
                    currentFrameIndex = currentAnimation.NextIndex(currentFrameIndex);
                    currentFrameCountdown = currentAnimation.Frames[currentFrameIndex].Duration;
                }
            }
        }

        public void UpdateAnimationState()
        {
            Animation newAnimation = null;
            if (GoingLeft)
            {
                if (currentAnimation != Animations.BadguyLeft)
                {
                    newAnimation = Animations.BadguyLeft;
                };
            }
            else if (GoingRight)
            {
                if (currentAnimation != Animations.BadguyRight)
                {
                    newAnimation = Animations.BadguyRight;
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









        public Badguy(int col, int row)
        {
            X = col * Tile.TileSize;
            Y = row * Tile.TileSize;
        }
        public Badguy(int col, int row, float speed, float health)
        {
            X = col * Tile.TileSize;
            Y = row * Tile.TileSize;
            BaseSpeed = speed;
            Health = health;
        }

        public RectangleF Rect(float scale)
        {
            return new RectangleF(X * scale, Y * scale, Width*scale, Height * scale);
        }

        public void Reverse()
        {
            if (GoingRight)
            {
                GoingRight = false;
                GoingLeft = true;
            }
            else if (GoingLeft)
            {
                GoingLeft = false;
                GoingRight = true;
            }
            else if (GoingUp)
            {
                GoingUp = false;
                GoingDown = true;
            }
            else if (GoingDown)
            {
                GoingUp = true;
                GoingDown = false;
            }
            SpeedLeftOrRight *= -1;
             SpeedUpOrDown *= -1;
            LengthOfDirection = 3;
        }
        public void Move(float scale)
        {


            int upOrDown = 0;
            int leftOrRight = 0;
            int length = 0;

            if (LengthOfDirection <= 0)
            {
                GoingUp = false;
                GoingDown = false;
                GoingLeft = false;
                GoingRight = false;

                upOrDown = random.Next(3);
                leftOrRight = random.Next(3);
                length = random.Next(10, 60);
                LengthOfDirection = length;
                UpDownDirection = upOrDown;
                RightLeftDirection = leftOrRight;


                SpeedUpOrDown = 0;
                SpeedLeftOrRight = 0;
                if (upOrDown == 0)
                {
                    SpeedUpOrDown = -1 * BaseSpeed;
                    GoingUp = true;
                }
                else if (upOrDown == 1)
                {
                    SpeedUpOrDown = BaseSpeed;
                    GoingDown = true;
                }
                else
                    SpeedUpOrDown = 0;
                if (leftOrRight == 0)
                {
                    SpeedLeftOrRight = -1 * BaseSpeed;
                    GoingLeft = true;
                }
                else if (leftOrRight == 1)
                {
                    SpeedLeftOrRight = BaseSpeed;
                    GoingRight = true;
                }
                else
                    SpeedLeftOrRight = 0;
            }

            if (IsInWater)
            {
                WaterSpeedLeftOrRight = SpeedLeftOrRight / 2;
                WaterSpeedUpOrDown = SpeedUpOrDown / 2;
            }
            else
            {
                WaterSpeedLeftOrRight = SpeedLeftOrRight;
                WaterSpeedUpOrDown = SpeedUpOrDown;
            }

            X += WaterSpeedLeftOrRight;
            Y += WaterSpeedUpOrDown;
            LengthOfDirection--;

        }

        Bitmap IDrawable.Image
        {
            get
            {
                if (currentAnimation == null) return this.image;
                else
                {
                    return this.currentAnimation.Frames[currentFrameIndex].Image;
                }
            }
        }

        SolidBrush IDrawable.Brush => brush;

        float IDrawable.X => X;

        float IDrawable.Y => Y;
    }
}
