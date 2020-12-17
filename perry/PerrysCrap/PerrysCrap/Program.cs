using System;

namespace PerrysCrap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Console.ForegroundColor = ConsoleColor.Red;");
            Console.WriteLine(@"Console.WriteLine(""-------------------------------------------"");");
            Console.WriteLine("Console.ForegroundColor = ConsoleColor.Yellow;");
            Console.WriteLine("for (int i = 1; i <= 5; i++)");
            Console.WriteLine("{");
            Console.WriteLine("     int j = 1;");
            Console.WriteLine("     for (j = 1; j <= i; j++)");
            Console.WriteLine("     {");
            Console.WriteLine(@"         Console.Write(""banana "");");
            Console.WriteLine("     }");
            Console.WriteLine("     Console.WriteLine();");
            Console.WriteLine("}");

            Console.WriteLine("int x = 1;");
            Console.WriteLine("while (x <= 5)"); 
            Console.WriteLine("{");
            Console.WriteLine("     int a = 5;");
            Console.WriteLine("     while (a > x)");
            Console.WriteLine("     {");
            Console.WriteLine(@"        Console.Write(""banana "");");
            Console.WriteLine("        a--;");
            Console.WriteLine("     }");
            Console.WriteLine("     Console.WriteLine();");
            Console.WriteLine("     x++;");
            Console.WriteLine("}");

            Console.WriteLine("Console.ForegroundColor = ConsoleColor.White;");



            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            for ( int i = 1; i <= 5; i++)
            {
                int j = 1;
                for(j = 1; j <= i; j++)
                {
                    Console.Write("banana ");
                }
                Console.WriteLine();
            }

            int x = 1;
            while (x <= 5)
            {
                int a = 5;
                while (a > x)
                {
                    Console.Write("banana ");
                    a--;
                }
                Console.WriteLine();
                x++;
            }
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
