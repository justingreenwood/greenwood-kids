using System.Drawing;

namespace PerrysArt
{
    public class Sand : Tile
    {
        public const char TileLetter = 'S';

        public Sand() : base() { }
        public Sand(int colIndex, int rowIndex) : base(colIndex, rowIndex) { }

        public override Brush TileBrush => Brushes.Tan;
    }
}
