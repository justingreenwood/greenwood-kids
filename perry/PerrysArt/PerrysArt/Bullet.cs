using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerrysArt
{
    public class Bullet
    {
        
        public int X = 0;
        public int Y = 0;
        public int HorizontalSpeed = 0;
        public int VerticalSpeed = 0;
        public int Distance = 0;
        public int Size = 7;
        public bool IsDead = false;

        public void SetDirectionAndSpeed(int direction, int speed)
        {
            switch (direction)
            {
                case 0: HorizontalSpeed = speed; break;
                case 45: HorizontalSpeed = speed; VerticalSpeed = -1 * speed; break;
                case 90: VerticalSpeed = -1 * speed; break;
                case 135: HorizontalSpeed = -1 * speed; VerticalSpeed = -1 * speed; break;
                case 180: HorizontalSpeed = -1 * speed; break;
                case 225: HorizontalSpeed = -1 * speed; VerticalSpeed = speed; break;
                case 270: VerticalSpeed = speed; break;
                case 315: HorizontalSpeed = speed; VerticalSpeed = speed; break;
            }
        }

        public void Move()
        {
            this.X += HorizontalSpeed;
            this.Y += VerticalSpeed;
            this.Distance += Math.Abs(HorizontalSpeed) + Math.Abs(VerticalSpeed);
        }
        public virtual RectangleF GetRectF(float zoom)
        {
            return new RectangleF(X * zoom, Y * zoom, Size * zoom, Size * zoom);
        }
        public virtual Rectangle GetRect(float zoom)
        {
            return new Rectangle(Convert.ToInt32(X * zoom), Convert.ToInt32(Y * zoom), Convert.ToInt32(Size * zoom), Convert.ToInt32(Size * zoom));
        }
        public void DrawMe(Graphics g, float zoom = 1)
        {
            g.DrawImage(Drawings.BulletImage, GetRect(zoom));
        }
    }
}
