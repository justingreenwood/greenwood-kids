using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//These are the systems that we are using.

namespace perrysbeginningwork/*This is the name*/
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Hello World is the reason this exists.
             This is a comment.*/
            Console.WriteLine("Hello World, and so is your face.");

            int score;
            score = 0;
            score = 4; 
            score = 11;
            score = -1564;
            int theMeaningOfLive = 42;

            int number = 3;
            Console.WriteLine(number);

            int v = 5;
            int x = 2;
            x = v;
            v = -3;
            Console.WriteLine(v);
            Console.WriteLine(x);

            //int a, b, c;
            //a = b = c = 10;
            byte bite = 34;
            bite = 17;
            short shortPants = 5039;
            shortPants = -4354;
            long long_bow = 123407623402L;
            long_bow = 13;
            ushort yourShortPants = 59845;
            char uselessCharacter = '`';
            uselessCharacter = '~';
            double pi = 3.14159265358979323846;
            float bananPi = 3.1415926f;
            ulong YourLongBow = 17999994367897956789UL;
            decimal highAccuracy = 1.4526m;
            highAccuracy = 14.4m;
            bool True_False = true;
            True_False = false;
            string BeginningWords = "Hello World!";
            BeginningWords = "Purple Monkey Dishwasher";
            sbyte SMine = 23;
            Console.WriteLine(score);
            Console.WriteLine(bite); 
            Console.WriteLine(shortPants);
            Console.WriteLine(long_bow);
            Console.WriteLine(yourShortPants);
            Console.WriteLine(uselessCharacter);
            Console.WriteLine(pi);
            Console.WriteLine(bananPi);
            Console.WriteLine(YourLongBow);
            Console.WriteLine(highAccuracy);
            Console.WriteLine(True_False);
            Console.WriteLine(BeginningWords);
            Console.WriteLine(SMine);
            double triple = 23.234e34;//scientific notation
            int thirteen = 0b00001101;//binary 1s and 0s
            int strangeHex = 0xFF00FF;
            double D_d = 1_345_0.9______46;
            var farts = "Pfff";

            //-----------------------------------------
            int a = 3 + 4;
            int b = 5 - 2;
            a = 9 - 2;
            a = 3 + 3;
            b = 3 + 1;
            b = 1 + 2;
            b = a + 4;
            int c = a - b;
            int result = 1 + 2 - 3 + 4 - 5 + a - b + c;
            float totalcost = 22.54f;
            float tippercent = 0.18f;
            float tipamount = totalcost * tippercent;
            float radius = 4;
            float area = bananPi * radius * radius;
            Console.WriteLine("The area of a circle is " + area);
            float half = 0.5f;
            float bases = 5;
            float hight = 6;
            float halfbaseshight = half * bases * hight;
            Console.WriteLine("The area of a triangle is " + halfbaseshight);
            a = 17;
            b = 4;
            int quotient = a / b;
            int remainder = a % b;
            int stuff = b * quotient + remainder;
            Console.WriteLine(a + "/" + b + "is " + quotient + " remainder " + remainder + " a should be " + stuff);

            int unary = +2;
            unary = -6;
            int binary = 2 + 3;
            binary = 4 - 5;

            double side1 = 5.5;
            double side2 = 3.25;
            double height = 4.6;
            double areOfTrapexoid = (side1 + side2) / 2 * height;

            a += 3;
            b = 7;
            b -= 3;
            b *= 5;
            b /= 4;
            b %= 2;




            //This is what you press when
            //you are ready to quit.
            Console.ReadKey();
        }
    }
}
