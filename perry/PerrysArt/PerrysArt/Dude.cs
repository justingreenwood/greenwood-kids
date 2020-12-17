using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerrysArt
{
    public class Dude : DrawableObject
    {
        public static Bitmap DudeImage = new Bitmap("Player.png");
        public const char CharacterLetter = 'P';
        public Dude()
        {
            X = 100;
            Y = 100;
            Size = 15;
        }

        public int Ammo = 50;
        public int Treasure = 0;
        public bool IsRunning = false;
        public bool IsInWater = false;
        public bool IsSneaking = false;
        public int LastKnownDirection = 0;
        public int BaseSpeed = 5;
        public int Speed
        {
            get
            {
                if (IsRunning && IsInWater == false) return BaseSpeed + 5;
                else if (IsRunning && IsInWater == true) return BaseSpeed - 4;
                else if (IsSneaking) return BaseSpeed - 3;
                else if (IsInWater) return BaseSpeed - 4;
                else return BaseSpeed;
            }
        }

        public override void DrawMe(Graphics g, float zoom = 1)
        {
            g.DrawImage(DudeImage, GetRect(zoom));
        }
    }
}
