using System.Drawing;

namespace PerrysArt
{
    public class Border : Tile
    {
        public const char TileLetter = 'O';

        public Border() : base() { }
        public Border(int colIndex, int rowIndex) : base(colIndex, rowIndex) { }
        public override void DrawMe(Graphics g, float zoom = 1)
        {
            //base.DrawMe(g, zoom);
            g.DrawImage(Drawings.BorderImage, GetRect(zoom));
        }
        public override Brush TileBrush => Brushes.Black;
    }
}
