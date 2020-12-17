using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerrysArt
{
    public abstract class DrawableObject
    {
        public const int StandardTileSize = 20;

        public int X = 0;
        public int Y = 0;
        public int Size = StandardTileSize;
        public bool IsAlive = true;
        public abstract void DrawMe(Graphics g, float zoom = 1);
        public virtual RectangleF GetRectF(float zoom)
        {
            return new RectangleF(X * zoom, Y * zoom, Size * zoom, Size * zoom);
        }
        public virtual Rectangle GetRect(float zoom)
        {
            return new Rectangle(Convert.ToInt32(X * zoom), Convert.ToInt32(Y * zoom), Convert.ToInt32(Size * zoom), Convert.ToInt32(Size * zoom));
        }
        public void SetPosition(int colIndex, int rowIndex)
        {
            X = StandardTileSize * colIndex;
            Y = StandardTileSize * rowIndex;
        }
    }
    public abstract class Tile : DrawableObject
    {
        public Tile() { }

        public Tile (int colIndex, int rowIndex)
        {
            this.SetPosition(colIndex, rowIndex);
        }

        public virtual Brush TileBrush { get { return Brushes.Green; } }

        public override void DrawMe(Graphics g, float zoom = 1)
        {
            g.FillRectangle(TileBrush, GetRect(zoom));
        }
    }
}
