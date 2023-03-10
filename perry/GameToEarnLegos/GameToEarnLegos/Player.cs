using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameToEarnLegos.Animate;
using GameToEarnLegos.Tiles;

namespace GameToEarnLegos
{
    public class Player : IDrawable
    {
        public float X;
        public float Y;
        public SolidBrush brush = new SolidBrush(Color.Black);
        public float NormalSpeed = 1.5f;
        public int NAmmo = 50;
        public int WAmmo = 0;
        public int Health = 20;
        public Bitmap image = Resources.Image_Player;
        public float Width = Resources.Image_Player.Width;
        public float Height = Resources.Image_Player.Height;
        public bool IsAlive = true;
        public bool IsRunning = false;
        public bool IsInWater = false;
        public bool CanSwim = true;
        public bool IsShooting = false;
        public bool IsOnFire = false;
        public int BaseCoolDown = 10;
        public int BaseFireCoolDown = 20;
        public int FireCoolDown = 10;
        public int CoolDown = 0;
        public string CurrentTypeOfAmmo = "normal";

        public int MaxNAmmo = 100;
        public int MaxWAmmo = 5;

        public bool GoingUp = false;
        public bool GoingDown = false;
        public bool GoingLeft = false;
        public bool GoingRight = false;
        public bool HasUsed = false;
        public bool UsingKey = false;
        public bool UsingRefillKey = false;
        public string LastWentDirection = "down";

        public Animation currentAnimation = null;
        public int currentFrameIndex = 0;
        public int currentFrameCountdown = 0;
        public int idleTime = 0;

        public void AnimationTick()
        {
            if (currentAnimation != null)
            {
                if (idleTime > 0) idleTime = 0;

                currentFrameCountdown--;
                if (currentFrameCountdown <= 0)
                {
                    currentFrameIndex = currentAnimation.NextIndex(currentFrameIndex);
                    currentFrameCountdown = currentAnimation.Frames[currentFrameIndex].Duration;
                }
            } 
            else
            {
                if (idleTime < 300)
                {
                    idleTime++;
                } 
                else
                {
                    currentAnimation = Animations.PlayerIdle;
                    currentFrameIndex = 0;
                }
            }
        }

        public void UpdateAnimationState()
        {
            Animation newAnimation = null;
            if (GoingLeft)
            {
                if (currentAnimation != Animations.PlayerLeft)
                {
                    newAnimation = Animations.PlayerLeft;
                };
            }
            else if (GoingRight)
            {
                if (currentAnimation != Animations.PlayerRight)
                {
                    newAnimation = Animations.PlayerRight;
                }
            }
            else if (GoingUp)
            {
                if (currentAnimation != Animations.PlayerUp)
                {
                    newAnimation = Animations.PlayerUp;
                }
            }
            else if (GoingDown)
            {
                if (currentAnimation != Animations.PlayerDown)
                {
                    newAnimation = Animations.PlayerDown;
                }
            }
            else
            {
                if (currentAnimation != Animations.PlayerIdle)
                    currentAnimation = null;
            }

            if (newAnimation != null)
            {
                currentAnimation = newAnimation;
                currentFrameIndex = 0;
                currentFrameCountdown = currentAnimation.Frames[currentFrameIndex].Duration;
            }
        }

        public float Speed
        {
            get
            {
                if(IsRunning && IsInWater && CanSwim)
                    return NormalSpeed / 2;
                else if(IsInWater)
                    return NormalSpeed / 4;
                else if (IsRunning)
                    return NormalSpeed * 2;
                else
                    return NormalSpeed;
            }
        }


        /// <summary>
        /// This is the rectangle where we paint the player
        /// </summary>
        /// <param name="scale">the scale factor to multiply everything by.
        /// <returns>a rectangle.</returns>
        public RectangleF Rect(float scale)
        {
            return new RectangleF(X * scale, Y * scale, Width * scale, Height * scale);
        }

        public RectangleF WaterCheckRect(float scale)
        {
            return new RectangleF((X + 4) * scale, (Y + 5) * scale, (Width/2) * scale, (Height / 2) * scale);
        }
        //public RectangleF StationedRect(float scale)
        //{
        //    return new RectangleF(963 * scale, 543 * scale, Width * scale, Height * scale);
        //}
        public Player(int col, int row)
        {
            X = col * Tile.TileSize;
            Y = row * Tile.TileSize;
        }

        Bitmap IDrawable.Image
        {
            get
            {
                if (currentAnimation == null) return this.image;
                else if (IsOnFire)
                {
                    return Resources.Image_BadguyFireAmmo;
                }
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
