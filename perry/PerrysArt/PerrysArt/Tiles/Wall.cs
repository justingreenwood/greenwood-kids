using System.Drawing;

namespace PerrysArt
{
    public class Wall : Tile
    {
        public const char TileLetter = 'B';

        public Wall() : base() { }
        public Wall(int colIndex, int rowIndex) : base(colIndex, rowIndex) { }

        public override Brush TileBrush => Brushes.SlateGray;
    }
}
