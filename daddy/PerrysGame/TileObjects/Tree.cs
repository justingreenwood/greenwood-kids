using PerrysGame;
using System;
using System.Drawing;

namespace PerrysGame
{
    public class Tree : Tile
    {
        public const char TileLetter = 'T';

        private int _treeType = Tools.Random.Next(3);

        public Tree() : base() { }
        public Tree(int colIndex, int rowIndex) :base(colIndex, rowIndex) { }

        //public override Brush TileBrush => Brushes.ForestGreen;

        public override void DrawMe(Graphics g, float zoom = 1)
        {
            if (DateTime.Now.Month != 10)
            {
                if (_treeType == 0)
                {
                    //base.DrawMe(g, zoom);
                    g.DrawImage(ImageManager.Tree2, GetRect(zoom));
                }
                else if (_treeType == 1 && DateTime.Now.Month >= 12)
                {
                    //base.DrawMe(g, zoom);
                    g.DrawImage(ImageManager.ChristmasTree, GetRect(zoom));
                }
                else
                {
                    g.DrawImage(ImageManager.Tree1, GetRect(zoom));
                }
            }
            else
            {

                if(_treeType == 0)
                    g.FillRectangle(Brushes.OrangeRed, GetRect(zoom));
                else if (_treeType == 1)
                    g.FillRectangle(Brushes.DarkOrange, GetRect(zoom));
                else
                    g.FillRectangle(Brushes.Orange, GetRect(zoom));
            }
        }
    }
}
