﻿using System.Drawing;

namespace PerrysGame
{
    public class Door : Tile
    {       
        public const char TileLetter = 'D';

        public Door() : base() { }
        public Door(int colIndex, int rowIndex) : base(colIndex, rowIndex) { }

        public override Brush TileBrush => Brushes.Brown;
    }
}
