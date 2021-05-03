using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverLoadOperator
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }



    public class Vector3d
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector3d(double x, double yl, double z)
        {
            X = x;
            Y = Y;
            Z = z;
        }

        public static Vector3d operator +(Vector3d vI, Vector3d vII)
        {
            return new Vector3d(vI.X + vII.X, vI.Y + vII.Y, vI.Z + vII.Z);
        }

        public static Vector3d operator -(Vector3d vI, Vector3d vII)
        {
            return new Vector3d(vI.X - vII.X, vI.Y - vII.Y, vI.Z - vII.Z);
        }

        public static Vector3d operator -(Vector3d v)
        {
            return new Vector3d(-v.X, -v.Y, -v.Z);
        }

        public static Vector3d operator *(Vector3d v, double scalar)
        {
            return new Vector3d(v.X * scalar, v.Y * scalar, v.Z * scalar);
        }

        public static Vector3d operator /(Vector3d v, double scalar)
        {
            return new Vector3d(v.X / scalar, v.Y / scalar, v.Z / scalar);
        }



    }



}
