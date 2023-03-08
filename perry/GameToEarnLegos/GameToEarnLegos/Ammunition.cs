using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameToEarnLegos.Tiles;

namespace GameToEarnLegos
{
    public class Ammunition:IDrawable
    {
        public float X;
        private SolidBrush brush = new SolidBrush(Color.Black);
        public float Y;
        private int LengthOfDirection = 20;
        private float BaseSpeed = 4f;
        public float SpeedUpOrDown = 0;
        public float SpeedLeftOrRight = 0;
        public bool IsDead = false;
        public bool BadguyAmmo = false;
        private Bitmap image = Resources.Image_Ammo;


        public Bitmap Image => image;

        float IDrawable.X => X;

        float IDrawable.Y => Y;

        public SolidBrush Brush => brush;

        public RectangleF Rect(float scale)
        {
            return new RectangleF(X * scale, Y * scale, 10 * scale, 10 * scale);
        }
        public Ammunition(float x, float y, string direction )
        {
            X = x; 
            Y = y;
            SpeedUpOrDown = 0;
            SpeedLeftOrRight = 0;

            if( direction == "northeast")
            {
                SpeedUpOrDown = -1 * BaseSpeed;
                SpeedLeftOrRight = BaseSpeed;
            }
            else if (direction == "northwest")
            {
                SpeedUpOrDown = -1 * BaseSpeed;
                SpeedLeftOrRight = -1 * BaseSpeed;
            }
            else if (direction == "southwest")
            {
                SpeedUpOrDown = BaseSpeed;
                SpeedLeftOrRight = -1 * BaseSpeed;
            }
            else if (direction == "southeast")
            {
                SpeedUpOrDown = BaseSpeed;
                SpeedLeftOrRight = BaseSpeed;
            }
            else if (direction == "north")
            {
                SpeedUpOrDown = -1 * BaseSpeed;
            }
            else if (direction == "south")
            {
                SpeedUpOrDown = BaseSpeed;
            }
            else if (direction == "west")
            {
                SpeedLeftOrRight = -1 * BaseSpeed;
            }
            else if (direction == "east")
            {
                SpeedLeftOrRight = BaseSpeed;
            }
            else
                SpeedLeftOrRight = BaseSpeed;
        }

        public Ammunition(float x, float y, float leftRight, float upDown)
        {
            SpeedLeftOrRight = leftRight;
            SpeedUpOrDown = upDown;
            X = x;
            Y = y;
            BadguyAmmo = true;
            image = Resources.Image_BadguyFireAmmo;
        }
        public void Move(float scale)
        {



            if (LengthOfDirection <= 0)
            {
                IsDead = true;
            }

            X += SpeedLeftOrRight;
            Y += SpeedUpOrDown;
            LengthOfDirection--;

        }
    }
}
