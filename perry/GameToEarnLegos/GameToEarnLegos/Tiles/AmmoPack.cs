using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos.Tiles
{
    public class AmmoPack : IDrawable
    {
        public bool IsPickedUp = false;
        public int ammountOfAmmo = 10;
        public float X;
        public float Y;
        public SolidBrush brush = new SolidBrush(Color.Black);
        public Bitmap image = Resources.Image_AmmoPack;
        public RectangleF Rect(float scale)
        {
            return new RectangleF(X * scale, Y * scale, 10 * scale, 10 * scale);
        }
        public AmmoPack(int col, int row)
        {
            X = col * 20;
            Y = row * 20;
        }
        float IDrawable.X => X;

        float IDrawable.Y => Y;

        public Bitmap Image => image;

        public SolidBrush Brush => brush;


    }
}
