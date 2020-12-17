using System;

namespace multiplicationtable8_24_2020
{
    class Program
    {
        const int NumRows = 12;
        const int NumColumns = 12;
        static void Main(string[] args)
        {
            Console.WriteLine("Multiplication Table");
            for (var c = 1; c <= NumColumns; c++) Console.Write("----");
            Console.WriteLine();

            var i = 1;
            for(i=1;i<= NumRows; i++)
            {
                var j = 1;
                for(j=1; j<= NumColumns; j++)
                {
                    var answer = (j * i).ToString().PadLeft(3);
                  Console.Write($"{answer} ");
                }
                Console.WriteLine("");
            }

        }
    }
}
