using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballFanStuff
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<int, RetiredPlayer> retiredYankees = new Dictionary<int, RetiredPlayer>()
            {
                { 3, new RetiredPlayer("Babe Ruth",1948)},
                { 4, new RetiredPlayer("Lou Gehrig",1939)},
                { 5, new RetiredPlayer("Joe DiMaggio",1952)},
                { 7, new RetiredPlayer("Mickey Mantle",1969)},
                { 8, new RetiredPlayer("Yogi Berra",1972)},
                { 10, new RetiredPlayer("Phil Rizzuto",1985)},
                { 23, new RetiredPlayer("Don Mattingly",1997)},
                { 42, new RetiredPlayer("Jakie Robinson",1993)},
                { 44, new RetiredPlayer("Reggie Jackson",1993)},
                { 0, new RetiredPlayer("Chocolate Chip",1776)},
            };

            foreach(int jerseyNumber in retiredYankees.Keys)
            {
                RetiredPlayer player = retiredYankees[jerseyNumber];
                Console.WriteLine($"{player.Name} #{jerseyNumber} retired in {player.YearRetired}");
            }

            Console.ReadKey();

        }
    }
}
