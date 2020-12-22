using System.Drawing;

namespace PerrysGame
{
    public class Gold : DrawableObject
    {
        public const char GrassTileLetter = 'g';
        public const char NoTileLetter = 't';
        private Brush BackgroundBrush { get { return Brushes.Gold; } }

        public Gold()
        {
            this.Size = 10;
            this.IsAlive = false;
        }

        public int Coins = 100;

        public override void DrawMe(Graphics g, float zoom = 1)
        {
            g.FillEllipse(BackgroundBrush, GetRect(zoom));
        }
    }
}
