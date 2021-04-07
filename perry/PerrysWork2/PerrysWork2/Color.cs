using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerrysWork2
{
    public class Color
    {
        private int red;
        private int green;
        private int blue;
        private int alpha;

        public Color(int r, int g, int b, int a)
        {
            red = r;
            green = g;
            blue = b;
            alpha = a;
        }
        public Color(int r, int g, int b)
        {
            red = r;
            green = g;
            blue = b;
            alpha = 255;
        }

        public int GetRed()
        {
            return this.red;
        }
        public void SetRed(int r)
        {
            if (r < 256 && r >= 0)
                this.red = r;
        }
        public int GetGreen()
        {
            return this.green;
        }
        public void SetGreen(int r)
        {
            if (r < 256 && r >= 0)
                this.green = r;
        }
        public int GetBlue()
        {
            return this.blue;
        }
        public void SetBlue(int r)
        {
            if (r < 256 && r >= 0)
                this.blue = r;
        }

        public int Blue
        {
            get
            {
                return this.blue;
            }
            set
            {
                if (value < 256 && value >= 0)
                    this.blue = value;
            }
        }

        public int Red{ get; set; }



        public int GrayScale()
        {
            int gray = (red + blue + green) / 3;
            return gray;
        }


    }
}
