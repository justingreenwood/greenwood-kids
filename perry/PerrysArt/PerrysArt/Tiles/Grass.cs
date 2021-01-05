using System.Drawing;

namespace PerrysArt
{
    public class Grass : Tile
    {
        public const char TileLetter = 'G';

        public Grass() : base() { }
        public Grass(int colIndex, int rowIndex) : base(colIndex, rowIndex) { }

        public override Brush TileBrush => Brushes.LimeGreen;
    }
}
