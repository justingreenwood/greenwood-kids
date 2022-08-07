using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndSuits
{
    class Program
    {
        private static readonly Random random = new Random();


        static Card RandomCard()
        {
             return new Card((Values)random.Next(1, 14), (Suits)random.Next(4));
        }

        static void PrintCards(List<Card> cards)
        {
            foreach (Card card in cards)
            {
                Console.WriteLine(card.Name);
            }
        }

        static void Main(string[] args)
        {

            List<Card> cards = new List<Card>();
            Console.Write("Enter a number of cards: ");          
            if(int.TryParse(Console.ReadLine(),out int numberOfCards)) 
            { 
                for(int i = 0; i<= numberOfCards; i++)
                {
                    cards.Add(RandomCard());
                }
                PrintCards(cards);

                Console.WriteLine("\n... sorting the cards ...\n");

                cards.Sort(new CardComparerByValue());
                PrintCards(cards);

            }

            
            


            //Card card = new Card((Values)random.Next(1, 14), (Suits)random.Next(4));
            //Console.WriteLine(card.Name);

            Console.ReadKey();
        }
    }
}
