using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Learning
{
    public struct Rectangle
    {
        public Rectangle(int x, int y, int w, int h) { X = x; Y = y; H = h; W = w; }
        public int X;
        public int Y;
        public int H;
        public int W;
    }
}
