using System;

namespace randomloopsPERRY
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("6(x-1)");
            string firstx;
            double Firstx;
            do
            {
                Console.Write("Type in first number for x. ");
                firstx = Console.ReadLine();
            } while (!double.TryParse(firstx, out Firstx));
            Console.WriteLine();

            string lastx;
            double Lastx;
            do
            {
                Console.Write("Type in last number for x. ");
                lastx = Console.ReadLine();
            } while (!double.TryParse(lastx, out Lastx) || (Lastx <= Firstx));
            Console.WriteLine();

            while(Firstx <= Lastx)
            {
                Console.WriteLine(6 * (Firstx - 1));
                Firstx++;
            }
        }
    }
}
