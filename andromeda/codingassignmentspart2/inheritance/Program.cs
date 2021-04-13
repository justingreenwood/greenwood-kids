using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance
{
    class Polygon
    {
        public int NumberOfSide { get; set; }
        public Polygon()
        {
            NumberOfSide = 0;
        }
        public Polygon(int numberOfSides)
        {
            NumberOfSide = numberOfSides;
        }
    }
    class Square : Polygon
    {
        public float Size { get; set; }
        public Square(float size)
        {
            Size = size;
            NumberOfSide = 4;
        }
       // Polygon polygon = new Polygon(3);
        Square square = new Square(4.5f);
        Polygon polygon = new Square(4.5f);
    }
}
