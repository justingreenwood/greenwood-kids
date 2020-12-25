using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerrysGame
{
    public static class Tools
    {
        public static Random Random = new Random();

        public static Color RandomColor()
        {
            return Color.FromArgb(Random.Next(256), Random.Next(256), Random.Next(256));
        }
    }
}
