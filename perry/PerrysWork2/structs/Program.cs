using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace structs
{
    class Program
    {
        static void Main(string[] args)
        {




        }

    }



    class Polygon
    {

        public int NumberOfSides { get; set; }

        public Polygon()
        {
            NumberOfSides = 0;
        }

        public Polygon(int numberOfSides)
        {
            NumberOfSides = numberOfSides;
        }


    }

    class Square : Polygon
    {

        public float Size { get; set; }

        public Square(float size)
        {
            Size = size;
            NumberOfSides = 4;
        }


    }


}
