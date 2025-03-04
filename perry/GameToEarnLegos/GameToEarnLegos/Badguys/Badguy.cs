﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using GameToEarnLegos.Animate;
using GameToEarnLegos.Tiles;

namespace GameToEarnLegos.Badguys
{
    /// <summary>
    /// This is the bad guy class, when I control bad guy stuff.
    /// </summary>
    public abstract class Badguy : IDrawable
    {
        Random random = new Random();
        private int _drawLevel = 200;
        public int DrawLevel => _drawLevel;
        public float X;
        public float Y;
        public float _X;
        public float _Y;
        public SolidBrush brush = new SolidBrush(Color.Black);
        public float BaseSpeed = 1.7f;
        public float SpeedUpOrDown = 0;
        public float SpeedLeftOrRight = 0;
        public float WaterSpeedUpOrDown = 0;
        public float WaterSpeedLeftOrRight = 0;
        public float Health = 3f;
        public Bitmap image = Resources.Image_Badguy;
        public Bitmap deadImage = Resources.Image_DeadBadguy;
        public float Width = 15;
        public float Height = 15;
        public bool IsBoss = false;
        public string AmmoType = "fire";
        public int type = 1;

        public int UpDownDirection = 0;
        public int RightLeftDirection = 0;
        public int LengthOfDirection = 0;
        public bool IsDead = false;
        public bool IsInWater;
        public bool isFollower = true;
        public bool isFollowing = false;
        public bool isWanderer = true;
        public bool NoticedPlayer = false;
        public bool lineOfSightIsBlocked = false;
        public bool canMove = true;
        public bool canShoot = false;
        public int ShootingCoolDown = 0;
        public int BaseShootingCoolDown = 15;
        public int BossCoolDown = 15;

        public string typeOfBadguy = "normal";

        private bool GoingUp = false;
        private bool GoingDown = false;
        private bool GoingLeft = false;
        private bool GoingRight = false;

        private float distanceX;
        private float distanceY;
        private float distanceF;

        private float AmmoSpeed = 4f;


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

        protected Animation animationLeft = Animations.BadguyLeft;
        protected Animation animationRight = Animations.BadguyRight;
        protected Animation animationUp = Animations.BadguyUp;
        protected Animation animationDown = Animations.BadguyDown;
        public virtual void UpdateAnimationState()
        {
            Animation newAnimation = null;
            if (image == Resources.Image_DragonStillDown)
            {
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
            }
            else
            {
                if (SpeedLeftOrRight < -0.7)
                {
                    if (currentAnimation != animationLeft)
                    {
                        newAnimation = animationLeft;
                    };
                }
                else if (SpeedLeftOrRight > 0.7)
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

        public RectangleF Rect()
        {
            return new RectangleF(X, Y, Width, Height);
        }
        public PointF CenterPoint => new PointF(X + Width / 2, Y + Height / 2);
        public RectangleF InspectRect(float scale)
        {
            return new RectangleF(CenterPoint.X * scale - 0.5f * (20 * scale * 8), CenterPoint.Y * scale - 0.5f * (20 * scale * 8), 20 * scale * 8, 20 * scale * 8);
        }
        protected static double GetDistance(PointF p1, PointF p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }
        private static float FractionMath(float distance1, float distance2, float speed)
        {
            float y = distance2 * speed;
            float x = y / distance1;
            return x;
        }
        public void RevertMove()
        {

            X = _X;
            Y = _Y;
        }
        public void Reverse()
        {
            if (isFollowing == false)
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
                WaterSpeedLeftOrRight *= -1;
                WaterSpeedUpOrDown *= -1;
                SpeedLeftOrRight *= -1;
                SpeedUpOrDown *= -1;
            }
            else
            {
                X = _X;
                Y = _Y;
            }

        }
        public void Move(Player player)
        {

            double distance = GetDistance(new PointF(player.X, player.Y), CenterPoint);
            if (CheckIfNoticed(player) && lineOfSightIsBlocked == false)
            {

                if (isFollower)
                {
                    isFollowing = true;
                    //NoticedPlayer = true;
                }
            }
            else if (CheckIfNoticed(player) == false && isFollowing)
            {
                isFollowing = false;
                LengthOfDirection = 0;
            }
            if (isFollowing == false && isWanderer == true)
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


                LengthOfDirection--;
            }
            else if (isFollowing == true)
            {
                distanceX = player.X - X;
                distanceY = player.Y - Y;
                distanceF = (float)distance;

                SpeedLeftOrRight = FractionMath(distanceF, distanceX, BaseSpeed);
                SpeedUpOrDown = FractionMath(distanceF, distanceY, BaseSpeed);



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

            _X = X;
            _Y = Y;
            X += WaterSpeedLeftOrRight;
            Y += WaterSpeedUpOrDown;
        }


        public Ammunition Shoot(Player player)
        {
            float AmmoSpeedLeftOrRight = 0f;
            float AmmoSpeedUpOrDown = 0f;

            double distance = GetDistance(new PointF(player.X, player.Y), CenterPoint);
            distanceX = player.X - X;
            distanceY = player.Y - Y;
            distanceF = (float)distance;

            AmmoSpeedLeftOrRight = FractionMath(distanceF, distanceX, AmmoSpeed);
            AmmoSpeedUpOrDown = FractionMath(distanceF, distanceY, AmmoSpeed);
            Ammunition ammo = new Ammunition(X, Y, AmmoSpeedLeftOrRight, AmmoSpeedUpOrDown, AmmoType);
            return ammo;

        }

        public virtual bool CheckIfNoticed(Player player)
        {

            double distance = GetDistance(new PointF(player.X, player.Y), CenterPoint);
            if (distance <= 120 || NoticedPlayer == true)
            {
                return true;
            }
            else
                return false;

        }

        Bitmap IDrawable.Image
        {
            get
            {
                if (IsDead == false)
                {
                    if (currentAnimation == null) return image;
                    else
                    {
                        return currentAnimation.Frames[currentFrameIndex].Image;
                    }
                }
                else
                {
                    return deadImage;
                }
            }
        }

        SolidBrush IDrawable.Brush => brush;

        float IDrawable.X => X;

        float IDrawable.Y => Y;
    }
}
