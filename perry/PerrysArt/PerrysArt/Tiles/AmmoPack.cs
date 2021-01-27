using System.Drawing;

namespace PerrysArt
{
    public class AmmoPack : DrawableObject
    {
        public const char TileLetter = 'A';
        private Brush BackgroundBrush { get { return Brushes.Green; } }
        private Pen OutlinePen { get { return Pens.Black; } }

        public AmmoPack() 
        {
            this.Size = 10;
            this.IsAlive = false;
        }

        public int Ammo = 50;
        public int ReviveAmmo = 0;

        public override void DrawMe(Graphics g, float zoom = 1)
        {
            //g.FillRectangle(BackgroundBrush, GetRect(zoom));
            //g.DrawRectangle(OutlinePen, GetRect(zoom));
            g.DrawImage(Drawings.AmmopackImage, GetRect(zoom));
        }
    }
}
