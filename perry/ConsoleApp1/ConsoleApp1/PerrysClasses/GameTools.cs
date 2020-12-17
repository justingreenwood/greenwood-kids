using Microsoft.VisualBasic.CompilerServices;
using System;

namespace Banana
{
    public class GameTools
    {
        private static Random MyRandomThingy = new Random();
        public static void FightMonster(string monsterName = "booty spider", int enemyhealth = 200)
        {
            bool fighting = true;
            int playerhealth = 100;
            
            Console.WriteLine($"You are fighting a {monsterName}.");
            while (fighting == true)
            {
                if (playerhealth < 1)
                {
                    fighting = false;
                    Console.WriteLine("You Suck");
                    goto Bot;
                }
                Console.WriteLine("(P)unch, (K)ick, or (R)un");
                string isattacking = Console.ReadLine();
                isattacking = isattacking.ToUpper();
                if (isattacking == "P")
                {
                    //enemyhealth = enemyhealth - 5;
                    enemyhealth -= 5;
                }
                else if (isattacking == "K")
                {
                    enemyhealth = enemyhealth - (enemyhealth / 7);
                }
                else if (isattacking == "R")
                {
                    if (!(monsterName == "booty spider"))
                    {
                        fighting = false;
                        enemyhealth = 0;
                        Console.WriteLine("Wimp!");
                    }
                        
                    else
                    {
                        Console.WriteLine("You can't escape");
                        playerhealth -= 5;
                        Console.WriteLine($"It hit you. Your health is {playerhealth}");
                        goto Bot;
                    }
                        
                }                
                else
                {
                    Console.WriteLine("????");
                    goto Bot;
                }
                //if (!(enemyhealth <= 0))
                if (enemyhealth > 0)
                {
                    Console.WriteLine($"Enemies health is {enemyhealth}");
                    Console.WriteLine("enemy's turn");
                    playerhealth = playerhealth - 5;
                    Console.WriteLine($"Your health is {playerhealth}.");
                }
                else
                {
                    Console.WriteLine("You Win!!!");
                    fighting = false;
                }
                    
                Bot:;
            }
            
        }
    }
    

}
