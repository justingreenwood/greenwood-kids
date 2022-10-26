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
        public float Speed=1;
        public Bitmap image = Resources.Image_Player;
        public float Width = Resources.Image_Player.Width;
        public float Height = Resources.Image_Player.Height;
        public bool IsAlive = true;
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
