﻿using System;
using System.Drawing;

namespace PerrysArt
{
    public class Tree : Tile
    {
        public static Random _rand = new Random();
      
        public const char TileLetter = 'T';

        private int _treeType = _rand.Next(3);

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
                    g.DrawImage(Drawings.treeImage, GetRect(zoom));
                }
                else if (_treeType == 1 && DateTime.Now.Month >= 12)
                {
                    //base.DrawMe(g, zoom);
                    g.DrawImage(Drawings.tree2Image, GetRect(zoom));
                }
                else
                {
                    g.DrawImage(Drawings.tree1Image, GetRect(zoom));
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
