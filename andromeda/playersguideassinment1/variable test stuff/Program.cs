using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace variable_test_stuff
{
    class Program
    {
        static void Main(string[] args)
        {
            int score;
            score = 0;
            score = 4; 
            score = 11; 
            score = -1564;
            int theMeaningOfLife = 42;
            int number = 3;
            Console.WriteLine(number); //console write line is usefull
            int a = 5;
            int b = 2;
            b = a;
            a = -3;
            Console.WriteLine(a); 
            Console.WriteLine(b);
            Console.ReadKey();
           
            /*fri start*/
            int w, s, d;
            w = s = d = 10;
            byte aSingeByte = 34;
            aSingeByte = 17;
            short aNumber = 5039;
            aNumber = -4354;
            long AVeryBigNumber = 395904282569;
            AVeryBigNumber = 13;
            ushort anUnsignedShortVariable = 59485; //normal short's can't hold this number they can only hold -32_768 to 32_767
            char favoriteLetter = 'c'; //Because c is for cookie. That's good enough for me.
            favoriteLetter = '&';

            /*mon March,15 start*/
            double pi = 3.14159265358979323846;
            float anotherPi = 3.1415926f;
            long aBigNumber = 39358593258529L;
            ulong bigOne = 2985925802580508UL;
            decimal numer = 1.495m;
            numer = 14.4m;
            bool itWorked = true;
            itWorked = false;
            string message = "Hello World!";
            message = "Purple Monkey Dishwasher";

        }
    }
}
