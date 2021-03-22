using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace switchstatements
{
    class Program
    {
        static void Main(string[] args)
        {
            int menuChoice = 3;
            if (menuChoice == 1)
                Console.WriteLine("You chose option #1.");
            else if (menuChoice == 2)
                Console.WriteLine("You chose option #2. I like that one too!");
            else if (menuChoice == 3)
                Console.WriteLine("I can't believe you chose option #3.");
            else if (menuChoice == 4)
                Console.WriteLine("You can do better than 4....");
            else if (menuChoice == 5)
                Console.WriteLine("5? Really? That's what you went with?");
            else
                Console.WriteLine("Hey! that wasn't even an option!");
            switch(menuChoice)
            {
                case 1:
                    Console.WriteLine("I love this number.");
                    break;
                case 2:
                    Console.WriteLine("You chose option #2.");
                    break;
                case 3:
                    Console.WriteLine("I believe you chose option #3.");
                    break;
                case 4:
                    Console.WriteLine("You can do better than 4....");
                    break;
                case 5:
                    Console.WriteLine("My favorite number!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    break;
                default:
                    Console.WriteLine("Hey! that wasn't even an option!");
                    break;
            }
            switch(menuChoice)
            {
                case 1:
                case 2:
                    Console.WriteLine("You choose option 1 or 2.");
                    break;
            }
            Console.WriteLine("Pick case:(1)add,(2)subtract,(3)multiplication,(4)divide,(5)remainder,(6)sutraction op,(7)division op,(8)remainder op,(9)squares");
            Console.WriteLine();
            string cases = Console.ReadLine();
            int operation = Convert.ToInt32(cases);
            Console.WriteLine("pick a num:");
           string X= Console.ReadLine();
            int x = Convert.ToInt32(X);
            Console.WriteLine("Choose a another number:");
          string Y=  Console.ReadLine();
            int y = Convert.ToInt32(Y);
            switch(operation)
            {
                case 1:
                    Console.WriteLine(x+y);
                    break;
                case 2:
                    Console.WriteLine(x-y);
                    break;
                case 3:
                    Console.WriteLine(x*y);
                    break;
                case 4:
                    Console.WriteLine(x/y);
                    break;
                case 5:
                    Console.WriteLine(x%y);
                    break;
                case 6:
                    Console.WriteLine(y-x);
                    break;
                case 7:
                    Console.WriteLine(y/x);
                    break;
                case 8:
                    Console.WriteLine(y%x);
                    break;
                case 9:
                    Console.WriteLine(Math.Pow(x,2)); 
                    Console.WriteLine(Math.Pow(y,2));
                    break;
                default:
                    Console.WriteLine("not option");
                    break;
            }
            Console.ReadKey();
        }
    }
}
