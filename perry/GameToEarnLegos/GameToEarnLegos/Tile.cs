using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameToEarnLegos
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
        public const float TileSize = 20f;
        public float X;
        public float Y;
        public Bitmap image;
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
    }
    public abstract class Blockers : Tile
    {
        public Blockers(int col, int row, Bitmap img) : base(col, row, img) { }
    }

    public class Tree : Blockers
    {
        public Tree(int col, int row) : base(col, row, Resources.Image_Tree1) { }
    }
    public class Border : Blockers
    {
        public Border(int col, int row) : base(col, row, Resources.Image_Border) { }
    }
    public class Wall : Blockers
    {
        public Wall(int col, int row) : base(col, row, Resources.Image_Wall) { }
    }
    public class Water : Tile
    {
        public Water(int col, int row, Color color) : base(col, row)
        {
            brush = new SolidBrush(color);
        }
    }
    public class Block : Tile
    {
        public Block(int col, int row, Color color) : base(col, row) 
        { 
            brush = new SolidBrush(color);
        }
    }
}
