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
        }
        
    }
}
