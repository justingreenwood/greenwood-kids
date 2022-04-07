using System;

namespace GuyMoneyTraids
{
    class Program
    {
        static void Main(string[] args)
        {
            Guys joe = new Guys() { Money = 50, Name = "Joe" };
            Guys bob = new Guys() { Money = 100, Name = "Bob" };

            while (true)
            {

                bob.WriteMyInfo();
                joe.WriteMyInfo();

                Console.Write("Enter an amount of money: ");
                string howMuchMoney = Console.ReadLine();

                if (howMuchMoney == "") return;
                else if(int.TryParse(howMuchMoney, out int amountOfMoney))
                {

                    Console.Write("Who will give the money: ");
                    string whichGuy = Console.ReadLine();
                    if (whichGuy == "Joe")
                    {
                        int moneyGiven = joe.GiveMoney(amountOfMoney);
                        bob.ReceiveMoney(moneyGiven);
                    }
                    else if(whichGuy == "bob")
                    {
                        int moneyGiven = bob.GiveMoney(amountOfMoney);
                        joe.ReceiveMoney(moneyGiven);
                    }
                    else
                    {
                        Console.WriteLine("Please enter 'Joe' or 'Bob.'");
                    }


                }
                else
                {
                    Console.WriteLine("Please enter an amount of money or nothing to exit. ");
                }
            }

        }



    }
}
