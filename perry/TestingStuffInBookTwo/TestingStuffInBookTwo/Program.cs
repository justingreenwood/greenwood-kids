using System;

namespace TestingStuffInBookTwo
{
    class Program
    {
        static void Main(string[] args)
        {

            float myFloat = 10;
            int myInt = (int) myFloat;
            Console.WriteLine("MyInt is: " + myInt);


            myInt = 10;
            byte myByte = (byte)myInt;
            double myDouble = (double)myByte;
            //bool myBool = (bool)myDouble;
            string myString = "false";
            //myBool = (bool)myString;
            //myString = (string) myInt;
            myString = myInt.ToString();
            //myBool = (bool)myByte;
            //myByte = (byte)myBool;
            short myShort = (short)myInt;
            char myChar = 'X';
            //myString = (string)myChar;
            long myLong = (long)myInt;
            decimal myDecmal = (decimal)myLong;
            myString = myString + myInt + myByte + myDouble + myChar;


        }
    }
}
