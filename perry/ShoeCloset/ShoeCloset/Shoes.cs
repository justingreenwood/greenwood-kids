using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeCloset
{
    class Shoes
    {
        public Style Style { get; private set; }
        public string Color { get; private set; }
        public Shoes(Style style, string color)
        {
            Color = color;
            Style = style;
        }
        public string Description
        {
            get { return $"A {Color} {Style}"; }
        }



    }
}
