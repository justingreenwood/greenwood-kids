using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerrysArt
{
    public class BadGuy : DrawableObject
    {
        private static Random _rand = new Random();
        

        public const char CharacterLetter = 'V';
        
        public BadGuy()
        {
            X = 100;
            Y = 100;
            Size = 15;
        }

        public bool WasHit = false;
        public int LastKnownDirection = 0;
        public int health = 45;
        public int DistanceToWalk = 0;
        public int VerticalDice = 0;
        public int HorizontalDice = 0;

        public bool IsInWater = false;
        public int BaseSpeed = 4;
        public int Speed
        {
            get
            {
                
                if (IsInWater && BaseSpeed > 3)
                    return BaseSpeed - 3;
                else if (IsInWater)
                    return BaseSpeed - 2;
                else return BaseSpeed;
            }
        }

        public void ReverseAndMoveOut(float zoom, int screenWidth, int screenHeight, Rectangle rect)
        {
            if (HorizontalDice == 0) HorizontalDice = 2;
            else if (HorizontalDice == 2) HorizontalDice = 0;
            
            if (VerticalDice == 0) VerticalDice = 2;
            else if (VerticalDice == 2 || (VerticalDice == 1 && HorizontalDice == 1)) VerticalDice = 0;

            do
            {
                Move(screenWidth, screenHeight, true);
            } while (this.GetRect(zoom).IntersectsWith(rect));
        }

        public void Move(int screenWidth, int screenHeight, bool skipIntelligentMovement = false)
        {
            int HorizontalSpeed = 0, 
                VerticalSpeed = 0;

            if (!skipIntelligentMovement)
            {
                if (DistanceToWalk <= 0)
                {
                    DistanceToWalk = _rand.Next(10, 100);
                    HorizontalDice = _rand.Next(3);
                    VerticalDice = _rand.Next(3);
                }
            }

            //if (X > screenWidth)
            //{
            //    HorizontalSpeed = -1 * Speed;
            //}
            //else if (X < 0)
            //{
            //    HorizontalSpeed = Speed;
            //}
            //else
            //{
                if (HorizontalDice == 0) HorizontalSpeed = -1 * Speed;
                else if (HorizontalDice == 1) HorizontalSpeed = 0;
                else if (HorizontalDice == 2) HorizontalSpeed = Speed;
            //}

            //if (Y > screenHeight)
            //{
            //    VerticalSpeed = -1 * Speed;
            //}
            //else if (Y < 0)
            //{
            //    VerticalSpeed = Speed;
            //}
            //else
            //{
                if (VerticalDice == 0) VerticalSpeed = -1 * Speed;
                else if (VerticalDice == 1 && HorizontalSpeed != 0) VerticalSpeed = 0;
                else VerticalSpeed = Speed;
            //}

            X += HorizontalSpeed;
            Y += VerticalSpeed;

            if (!skipIntelligentMovement)
            {
                DistanceToWalk -= Math.Abs(HorizontalSpeed) + Math.Abs(VerticalSpeed);
            }
        }

        public override void DrawMe(Graphics g, float zoom = 1)
        {
            if (IsAlive)
            {
                if (DateTime.Now.Day == 29 && DateTime.Now.Month == 06)
                {
                    g.FillRectangle(Brushes.Black, GetRect(zoom));
                }
                else if (DateTime.Now.Month == 12) 
                {
                    g.DrawImage(Drawings.BadguyImage, GetRect(zoom));
                }
                else if (DateTime.Now.Month == 10)
                {
                    g.FillRectangle(Brushes.HotPink, GetRect(zoom));
                }
                else
                {
                    g.DrawImage(Drawings.BadguyImage, GetRect(zoom));
                }
            }
            else
            {
                g.DrawEllipse(Pens.Red, this.GetRect(zoom));
            }
        }
    }
}
