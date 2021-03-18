using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace math2Perry
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 7;
            int b = 2;
            int result = a/b;
            Console.WriteLine(result);
            float d = 7.0f;
            float e = 2.0f;
            float f = d / e;
            float c = a / b + d / e;

            a = 4049;
            long be = 28440439;
            long some = a + b;

            long super = 34;
            int supper = (int)super;

            double aa = 1.0 + 1 + 1.0f;
            int x = (int)(7 + 3.0 / 4.0 * 20);
            Console.WriteLine((1 + 1) / 2 * 3);

            float bee = float.NaN;

            double radius = 3;
            double area = Math.PI * radius * radius;
            double esquared = Math.E * Math.E;

            int maximum = int.MaxValue;
            int minimum = int.MinValue;

            short aaa = 30000;
            short bees = 30000;
            short sum = (short)(aaa + bees);
            Console.WriteLine(sum);

            a = 3;
            a++;
            int sd = 1;
            sd = ++a;

            Console.ReadKey();
        }
    }
}
