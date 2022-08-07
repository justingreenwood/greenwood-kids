using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeCloset
{
    class Program
    {
        static ClosetOfTheShoes shoeCloset = new ClosetOfTheShoes();

        static void Main(string[] args)
        {

            while (true)
            {
                shoeCloset.PrintShoes();
                Console.Write("\nPress 'a' to add or 'r' to remove a shoe: ");
                char key = Console.ReadKey().KeyChar;

                switch (key)
                {
                    case 'a':
                    case 'A':
                        shoeCloset.AddShoe();
                        break;
                    case 'r':
                    case 'R':
                        shoeCloset.RemoveShoe();
                        break;
                    default:
                        return;
                }

            }


        }
    }
}
