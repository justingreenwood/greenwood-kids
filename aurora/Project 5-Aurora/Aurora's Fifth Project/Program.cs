using System;

namespace Aurora_s_Fifth_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            string MyDumbAuroraness = "(*-*) ";
            int ISuckAtCoding = 1;

            while (ISuckAtCoding <= 10)
            {
                int IfIToldYou = 0;
                while (IfIToldYou < ISuckAtCoding)
                {
                    if (MyDumbAuroraness == "(^=^) ")
                        MyDumbAuroraness = "(^-^) ";
                    else
                        MyDumbAuroraness = "| (^-^) | ";
                    Console.Write(MyDumbAuroraness);
                    IfIToldYou++;
                }

                Console.WriteLine();
                ISuckAtCoding++;
            }
        }
    }
}
