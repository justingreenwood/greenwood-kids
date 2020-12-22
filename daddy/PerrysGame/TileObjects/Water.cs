using System.Drawing;

namespace PerrysGame
{
    public class Water : Tile
    {
        public const char TileLetter = 'W';

        public Water() : base() { }
        public Water(int colIndex, int rowIndex) : base(colIndex, rowIndex) { }

        public override Brush TileBrush => Brushes.Aqua;
    }
}
