using System;
using System.Collections.Generic;
using System.Text;

namespace FreeAndProud
{
    public class MyFunctions
    {
        public static int AddThreeNumbers(int i, int j, int k)
        {
            return i + j + k;
        }


        public void ShowProblem(int i, int j, string operation)
        {
            var mft = new MyFavoriteThings();
            Console.WriteLine($"{i} {operation} {j} = ?");
        }
      

        public void MOG(int i, int j, int k)
        {

            var True = new MyFunctions();
            Console.WriteLine(" Ugh! Why did they invite boys!");


        }

        public void REN(int i, int j, int k)
        {
            var Love = new MyFunctions();
            Console.WriteLine(" Too many girls at this party! I'm going to hide from them!");

        }
    }
}
