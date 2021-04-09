using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerrysWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            Class2 numbers = new Class2();

            bool apple = true;
            bool noOnesWon = true;
            int player = 2;
            string y = "O";

            while (apple == true)
            {                

                if (noOnesWon)
                {

                    int e;
                    string ee;
                    do
                    {
                        Console.WriteLine("Type in your spot choice. ");
                        ee = Console.ReadLine();
                        //e = Convert.ToInt32(ee);

                    } while (!((Convert.ToInt32(ee) < 10 && Convert.ToInt32(ee) > 0)));
                    e = Convert.ToInt32(ee);
                    if (e == 1 && numbers.oneUsed == false)
                    {
                        if (player == 1)
                        {
                            player = 2;
                            y = "O";
                        }
                        else
                        {
                            player = 1;
                            y = "X";
                        }
                        numbers.one = y;
                        numbers.oneUsed = true;
                        numbers.bologna();
                    }
                    else if (e == 2 && numbers.twoUsed == false)
                    {
                        if (player == 1)
                        {
                            player = 2;
                            y = "O";
                        }
                        else
                        {
                            player = 1;
                            y = "X";
                        }
                        numbers.two = y;
                        numbers.twoUsed = true;
                        numbers.bologna();
                    }
                    else if (e == 3 && numbers.threeUsed == false)
                    {
                        if (player == 1)
                        {
                            player = 2;
                            y = "O";
                        }
                        else
                        {
                            player = 1;
                            y = "X";
                        }
                        numbers.three = y;
                        numbers.threeUsed = true;
                        numbers.bologna();
                    }
                    else if (e == 4 && numbers.fourUsed == false)
                    {
                        if (player == 1)
                        {
                            player = 2;
                            y = "O";
                        }
                        else
                        {
                            player = 1;
                            y = "X";
                        }
                        numbers.four = y;
                        numbers.fourUsed = true;
                        numbers.bologna();
                    }
                    else if (e == 5 && numbers.fiveUsed == false)
                    {
                        if (player == 1)
                        {
                            player = 2;
                            y = "O";
                        }
                        else
                        {
                            player = 1;
                            y = "X";
                        }
                        numbers.five = y;
                        numbers.fiveUsed = true;
                        numbers.bologna();
                    }
                    else if (e == 6 && numbers.sixUsed == false)
                    {
                        if (player == 1)
                        {
                            player = 2;
                            y = "O";
                        }
                        else
                        {
                            player = 1;
                            y = "X";
                        }
                        numbers.six = y;
                        numbers.sixUsed = true;
                        numbers.bologna();
                    }
                    else if (e == 7 && numbers.sevenUsed == false)
                    {
                        if (player == 1)
                        {
                            player = 2;
                            y = "O";
                        }
                        else
                        {
                            player = 1;
                            y = "X";
                        }
                        numbers.seven = y;
                        numbers.sevenUsed = true;
                        numbers.bologna();
                    }
                    else if (e == 8 && numbers.eightUsed == false)
                    {
                        if (player == 1)
                        {
                            player = 2;
                            y = "O";
                        }
                        else
                        {
                            player = 1;
                            y = "X";
                        }
                        numbers.eight = y;
                        numbers.eightUsed = true;
                        numbers.bologna();
                    }
                    else if(e == 9 && numbers.nineUsed == false)
                    {
                        if (player == 1)
                        {
                            player = 2;
                            y = "O";
                        }
                        else
                        {
                            player = 1;
                            y = "X";
                        }
                        numbers.nine = y;
                        numbers.nineUsed = true;
                        numbers.bologna();
                    }



                    if((numbers.one == y && numbers.two == y && numbers.three == y) || (numbers.four == y && numbers.five == y && numbers.six == y) 
                        || (numbers.seven == y && numbers.eight == y && numbers.nine == y)
                     || (numbers.one == y && numbers.four == y && numbers.seven == y) || (numbers.five == y && numbers.two == y && numbers.eight == y)
                     || (numbers.nine == y && numbers.six == y && numbers.three == y) ||
                     (numbers.one == y && numbers.five == y && numbers.nine == y) || (numbers.seven == y && numbers.five == y && numbers.three == y)                     )
                    {
                        noOnesWon = false;
                        Console.WriteLine($"Player {player} wins! ");
                    }
                    else if (numbers.nineUsed = true && numbers.eightUsed == true && numbers.sevenUsed == true && numbers.sixUsed == true &&
                    numbers.fiveUsed == true && numbers.fourUsed == true && numbers.threeUsed == true && numbers.twoUsed == true &&
                    numbers.oneUsed == true)
                    {
                        noOnesWon = false;
                        Console.WriteLine($"It is a tie. ");
                    }


                }
                else
                {
                    //Console.WriteLine($"Player {player} wins! ");
                    numbers.nine = " ";
                    numbers.eight = " ";
                    numbers.seven = " ";
                    numbers.six = " ";
                    numbers.five = " ";
                    numbers.four = " ";
                    numbers.three = " ";
                    numbers.two = " ";
                    numbers.one = " ";

                    numbers.nineUsed = false;                    
                    numbers.eightUsed = false;
                    numbers.sevenUsed = false;
                    numbers.sixUsed = false;
                    numbers.fiveUsed = false;
                    numbers.fourUsed = false;
                    numbers.threeUsed = false;
                    numbers.twoUsed = false;
                    numbers.oneUsed = false;

                    noOnesWon = true;
                    Console.WriteLine("Do you want to play again? y/n");
                    var why = Console.ReadKey();
                    if (why.Key == ConsoleKey.N)
                        apple = false;
                    else if (why.Key == ConsoleKey.Y)
                    {
                        Console.WriteLine("Great!");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("That is not valid, so you have to play again.");
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
