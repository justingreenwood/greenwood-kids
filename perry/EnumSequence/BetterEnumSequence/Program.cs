using System;
using System.Collections;
using System.Collections.Generic;

namespace BetterEnumSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var sports = new BetterSportSequence();
            foreach (var sport in sports)
            {
                Console.WriteLine(sport);
            }
        }
    }
    enum Sport { Football, Baseball, Basketball, Hockey, Boxing, Rugby, Fencing, }
    class BetterSportSequence : IEnumerable<Sport>
    {
        public IEnumerator<Sport> GetEnumerator()
        {
            int maxEnumValue = Enum.GetValues(typeof(Sport)).Length;
            for(int i = 0; i < maxEnumValue; i++)
            {
                yield return (Sport)i;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
