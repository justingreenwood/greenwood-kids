﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace LinqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            for(int i = 1; i <= 99; i++)
            {
                numbers.Add(i);
            }
            IEnumerable<int> firstAndLastFive = numbers.Take(5).Concat(numbers.TakeLast(5));

        }
    }
}
