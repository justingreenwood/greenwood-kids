using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PwrsFTw
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(int i in new PowersOFTwo())
            {
                Console.Write($" {i}");
            }

            

        }
    }

    class PowersOFTwo : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            
            for(int i = 0; i < Math.Round(Math.Log(int.MaxValue, 2)); i++)
            {
                yield return (int)Math.Pow(2,i);
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


}
