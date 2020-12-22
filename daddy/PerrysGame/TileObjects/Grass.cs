using System.Drawing;

namespace PerrysGame
{
    public class Grass : Tile
    {
        public const char TileLetter = 'G';

        public Grass() : base() { }
        public Grass(int colIndex, int rowIndex) : base(colIndex, rowIndex) { }

        public override Brush TileBrush => Brushes.Lime;
    }
}
