using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace methods
{
    class Program
    {
        static void Main(string[] args)
        {

            CountToTen();
            int usersnumber = getnumberfromuser();
            count(5);
            count(15);

            Console.ReadKey();
        }

        static void CountToTen()
        {
            for (int index = 1; index <= 10; index++)
                Console.WriteLine(index);
        }

        static float getrandomnumber()
        {
            return 4.85f;
        }

        static int getnumberfromuser()
        {

            int usersnumber = 0;

            while (usersnumber <1 || usersnumber>10)
            {
                Console.WriteLine("Enter a number between one and ten. ");
                string userinput = Console.ReadLine();
                usersnumber = Convert.ToInt32(userinput);
            }
            return usersnumber;

        }

        static int PlayersScore()
        {

            int livesleft = 3;
            int underlingsdestroyed = 17;
            int minieonsdestroyed = 4;
            int bossesdestroyed = 1;

            if (livesleft == 0) return 0;

            return underlingsdestroyed * 10 + minieonsdestroyed + 100 + bossesdestroyed * 1000;
        }

        static void dosomething()
        {
            int anumber = 1;
            if (anumber == 2)
                return;
        }

        static void count(int numbertocountto)
        {
            for (int current = 1; current <= numbertocountto; current++)
                Console.WriteLine(current);
        }

    }
}
