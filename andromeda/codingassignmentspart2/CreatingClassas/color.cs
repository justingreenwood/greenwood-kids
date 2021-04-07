using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingClassas
{
    public class color
    {
        private int r;
        private int g;
        private int b;
        private int Alpha;
        public color(int r,int g, int b,int Alpha)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.Alpha = Alpha;
        }
        public color(int r, int g, int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            Alpha = 255;
        }

        public int GetRed()
        {
            return this.r;
        }
        public void SetRed(int c)
        {
            if (c < 256 && c >= 0)
                this.r = c;
        }
        public int GetGreen()
        {
            return this.g;
        }
        public void SetGreen(int c)
        {
            if (c < 256 && c >= 0)
                this.g = c;
        }
        public int GetBlue()
        {
            return this.b;
        }
        public void SetBlue(int c)
        {
            if (c < 256 && c >= 0)
                this.b = c;
        }

        public int Blue
        {
            get
            {
                return this.b;
            }
            set
            {
                if (value < 256 && value >= 0)
                    this.b = value;
            }
        }

        public int Red { get; set; }



        public int GrayScale()
        {
            int gray = (r + b + g) / 3;
            return gray;
        }

    }
}
