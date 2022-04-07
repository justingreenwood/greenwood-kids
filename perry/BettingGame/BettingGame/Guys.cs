using System;
using System.Collections.Generic;
using System.Text;

namespace BettingGame
{
    class Guys
    {

        public string Name;
        public int Money;

        public void WriteMyInfo()
        {
            Console.WriteLine(Name + " has " + Money + " dollars.");
        }

        public int GiveMoney(int amountOfMoney)
        {
            if (amountOfMoney <= 0)
            {
                Console.WriteLine(Name + " says, '" + amountOfMoney + " is not a valid amount.'");
                return 0;
            }
            if (amountOfMoney > Money)
            {
                Console.WriteLine(Name + " says, 'I do not have enough money to give you " + amountOfMoney + ".'");
                return 0;
            }

            Money -= amountOfMoney;
            return amountOfMoney;

        }

        public void ReceiveMoney(int amountOfMoney)
        {
            if(amountOfMoney <= 0)
            {
                Console.WriteLine(Name + " says, '" + amountOfMoney + " is not an amount I will take.'");
            }
            else
            {
                Money += amountOfMoney;
            }

        }

    }
}
