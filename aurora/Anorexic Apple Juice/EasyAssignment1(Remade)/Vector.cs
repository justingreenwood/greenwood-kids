using System;
using System.Collections.Generic;
using System.Text;

namespace EasyAssignment1_Remade_
{
    public class Vector
    {
        
        public double X { get; set; }
        public double Y { get; set; }
        public Vector (double x, double y)
        {
            X = x;
            Y = y;
            Vector a = new Vector(23, 4);
            Vector b = new Vector(-8, 6);
            Console.WriteLine(a + b);
        }
       
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }
    }
}
