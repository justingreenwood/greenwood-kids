using System.Drawing;

namespace PerrysGame
{
    public class DeepWater : Tile
    {
        public const char TileLetter = 'Q';

        public DeepWater() : base() { }
        public DeepWater(int colIndex, int rowIndex) : base(colIndex, rowIndex) { }

        public override Brush TileBrush => Brushes.Navy;
    }
}
