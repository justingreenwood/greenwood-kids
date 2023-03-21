using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos.Tiles
{
    public interface IDrawable
    {
        float X { get; }
        float Y { get; }
        Bitmap Image { get; }
        SolidBrush Brush { get; }
        RectangleF Rect(float scale);
    }
    public abstract class Tile : IDrawable
    {
        public virtual string Tag { get; }
        public const float TileSize = 20f;
        public float X;
        public float Y;
        public Bitmap image;
        public bool IsBlocker;
        public SolidBrush brush = new SolidBrush(Color.Black);
        public Tile() { }
        public Tile(int col, int row)
        {
            X = col * TileSize;
            Y = row * TileSize;
        }
        public Tile(int col, int row, Bitmap img) : this(col, row)
        {
            image = img;
        }

        public virtual RectangleF Rect(float scale)
        {
            return new RectangleF(X * scale, Y * scale, TileSize * scale, TileSize * scale);
        }
        Bitmap IDrawable.Image => image;

        SolidBrush IDrawable.Brush => brush;

        float IDrawable.X => X;

        float IDrawable.Y => Y;
        public RectangleF CheckAroundRect(float scale)
        {
            return new RectangleF((X - 5) * scale, (Y - 5) * scale, (TileSize + 10) * scale, (TileSize + 10) * scale);
        }
        public RectangleF CheckLeftRect(float scale)
        {
            return new RectangleF((X - 5) * scale, Y * scale, TileSize * scale, TileSize * scale);
        }
        public RectangleF CheckUpRect(float scale)
        {
            return new RectangleF(X * scale, (Y-5) * scale, TileSize * scale, TileSize * scale);
        }
        public RectangleF CheckDownRect(float scale)
        {
            return new RectangleF(X * scale, (Y + 5) * scale, TileSize * scale, TileSize * scale);
        }
        public RectangleF CheckRightRect(float scale)
        {
            return new RectangleF((X + 5) * scale, Y * scale, TileSize * scale, TileSize * scale);
        }
    }

}
