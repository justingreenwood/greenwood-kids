using System;
using System.Collections.Generic;
using System.Text;

namespace JasonCereal
{
    class Outfit
    {
        public string Top { get; set; }
        public string Bottom { get; set; }
        public override string ToString()
        {
            return $"{Top} and {Bottom}";
        }
    }

    class Guy
    {
        public string Name { get; set; }
        public HairStyle Hair { get; set; }
        public Outfit Clothes { get; set; }
        public override string ToString()
        {
            return $"{Name} with {Hair} wearing {Clothes}";
        }
    }

    enum HairColor
    {
        Auburn, Black, Blonde, Golden, Brown, Gray, Platinum, Red, Carrots, White, 
    }

    class HairStyle
    {
        public HairColor Color { get; set; }
        public float Length { get; set; }
        public override string ToString()
        {
            return $"{Length:0.0} inch {Color} hair";
        }

    }

    class Dude
    {
        public string Name { get; set; }
        public HairStyle Hair { get; set; }
    }

}
