using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreMath
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 7;
            int b = 2;
            int results = a / b;
            Console.WriteLine(results);
            int c = a / b;
            float d = 7.0f;
            float e = 2.0f;
            float f = d / e;
            d = 4;
            e = 3;
            float result = a / b + d / e;
            a = 4094;
            long B = 284404039;
            long sum = a + B;
            a = 7;
            d = 2;
            float Results = a / d;
            long A = 3;
            b = (int)A;
            Results = (float)(3.0 / 5.0) + 1;
            double aa = double.PositiveInfinity;
            e = float.PositiveInfinity;
            aa = double.NaN;
            e = float.NaN;
            double radius = 3;
            double area = Math.PI * radius * radius;
            double eSquared = Math.E * Math.E;
            int maximum = int.MaxValue;
            int minimum = int.MinValue;
            short AA = 30000;
            short BB = 30000;
            sum = (AA + BB);
            a = 3;
            a = a + 1;
            a = 3;
            a += 1;
            a = 3;
            a++;
            a = 3;
            b = ++a;
            c = 3;
            int D = c++;
            a = 3;
            a++;
            b = a;
            c = 3;
            D = c;
            c++;
        }
    }
}
