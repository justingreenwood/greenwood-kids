using System.Drawing;

namespace PerrysArt
{
    public class Wall : Tile
    {
        public const char TileLetter = 'B';

        public Wall() : base() { }
        public Wall(int colIndex, int rowIndex) : base(colIndex, rowIndex) { }
        public override void DrawMe(Graphics g, float zoom = 1)
        {
            //base.DrawMe(g, zoom);
            g.DrawImage(Drawings.WallImage, GetRect(zoom));
        }
        public override Brush TileBrush => Brushes.SlateGray;
    }
}
