using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos
{
    public class Player : IDrawable
    {
        public float X;
        public float Y;
        public SolidBrush brush = new SolidBrush(Color.Black);
        //public float Speed = 1.5f;
        //public float RunSpeed = 3f;
        public float NormalSpeed = 1.5f;
        public Bitmap image = Resources.Image_Player;
        public float Width = Resources.Image_Player.Width;
        public float Height = Resources.Image_Player.Height;
        public bool IsAlive = true;
        public bool IsRunning = false;
        public bool IsInWater = false;
        public bool CanSwim = true;
        public float Speed
        {
            get
            {
                if(IsRunning && IsInWater && CanSwim)
                    return NormalSpeed;
                else if(IsInWater)
                    return NormalSpeed / 2;
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

        public Player(int col, int row)
        {
            X = col * Tile.TileSize;
            Y = row * Tile.TileSize;
        }

        Bitmap IDrawable.Image => image;

        SolidBrush IDrawable.Brush => brush;

        float IDrawable.X => X;

        float IDrawable.Y => Y;
    }
}
