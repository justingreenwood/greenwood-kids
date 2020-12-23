using System.Drawing;

namespace PerrysArt
{
    public class Lava : Tile
    {
        public const char TileLetter = 'L';

        public Lava() : base() { }
        public Lava(int colIndex, int rowIndex) : base(colIndex, rowIndex) { }

        public override Brush TileBrush => Brushes.OrangeRed;
    }
}
