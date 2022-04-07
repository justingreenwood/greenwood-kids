using System;

namespace ChooseRandomCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of cards to pick: ");
            string line = Console.ReadLine();

            if(int.TryParse(line, out int numberOfCards))
            {
                CardPickers.PickSomeCards(numberOfCards);

                foreach(string card in CardPickers.PickSomeCards(numberOfCards))
                {
                    Console.WriteLine(card);
                }

            }
            else
            {
                Console.WriteLine("That is not a valid number.");
            }


        }
    }
}
