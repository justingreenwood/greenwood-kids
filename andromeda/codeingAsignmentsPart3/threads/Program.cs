using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Dynamic;

namespace threads
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Counttonumber);
            thread1.Start(50);
            Thread thread2 = new Thread(Counttonumber);
            thread2.Start(25);
            Thread thread3 = new Thread(Counttonumber);
            thread3.Start(5);
        }
        public static void Counttonumber(object input)
        {
            for (int index = (int)input; index < 100; index++)
                Console.WriteLine(index + 1);
            Console.ReadKey();
        }
        dynamic expando =new ExpandoObject();
        public const double PI = 3.1415926;
    }
}
