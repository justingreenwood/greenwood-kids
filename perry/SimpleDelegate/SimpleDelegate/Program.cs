using System;

namespace SimpleDelegate
{
    class Program
    {
        delegate string IntToString(int i);
        public static string AddNumberSign(int i) => $"#{i}";
        public static string PlusOne(int i) => $"{i} + 1 = {i + 1}.";

        static void Main(string[] args)
        {
            IntToString methodRep = AddNumberSign;
            Console.WriteLine(methodRep(12345));
            methodRep = PlusOne;
            Console.WriteLine(methodRep(12345));

        }
    }
}
