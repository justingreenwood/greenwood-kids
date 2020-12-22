using System.Drawing;

namespace PerrysGame
{
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
