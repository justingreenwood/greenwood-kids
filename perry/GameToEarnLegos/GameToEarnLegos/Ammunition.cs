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
        public string TypeOfAmmo = "normal";
        public int Damage = 3;
        private int _drawLevel = 250;
        public virtual int DrawLevel => _drawLevel;

        public Bitmap Image => image;

        float IDrawable.X => X;

        float IDrawable.Y => Y;

        public SolidBrush Brush => brush;

        public RectangleF Rect()
        {
            return new RectangleF(X, Y, 10, 10);
        }
        public Ammunition(float x, float y, string direction, string type )
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


            if(type == "water")
            {
                image = Resources.Image_WaterAmmo;
                TypeOfAmmo = type;
                LengthOfDirection = 15;
                Damage = 6;
            }


        }

        public Ammunition(float x, float y, float leftRight, float upDown)
        {
            SpeedLeftOrRight = leftRight;
            SpeedUpOrDown = upDown;
            X = x;
            Y = y;
            BadguyAmmo = true;
            TypeOfAmmo = "fire";
            image = Resources.Image_BadguyFireAmmo;
        }
        public void Move()
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
