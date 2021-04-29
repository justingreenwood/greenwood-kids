using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codeingAsignmentsPart3
{
    class Program
    {
        static void Main(string[] args)
        {
            int Add(int a, int b)
            {
                return a + b;
            }
            Console.WriteLine(Add(1, 1));
            Console.WriteLine(Add(2, 2));
            Console.WriteLine(Add(3, 7));
        }
    }
    //april 22
    public class HighScore
    {
        public string Name { get; set; }
        public int Score { get; set; }

    }
    public class AteTooManyHamburgersException : Exception
    {
        public int HamburgersEaten { get; set; }
    }
    // april 28
    public delegate int MathDelegate(int a, int b);
    //april 29
    public class Point
    {
        private double x;
        private double y;
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public event EventHandler PointChanged;
    }
}
