using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace structs
{
   struct TimeStruct
    {
        public static void Main(string[] args)
        {
            TimeStruct time = new TimeStruct();
            time.Seconds = 10;
            UpdateTime(time);
        }
        private int seconds;
        public int Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }
        public int CalculateMinutes()
        {
            return seconds / 60;
        }
        public static void UpdateTime(TimeStruct time)
        {
            time.Seconds++;
        }
    }
    class TimeClass
    {
        private int seconds;
        public int Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }
        public int CalculateMinutes()
        {
            return seconds / 60;
        }
    }
    struct S
    {
        public int Value { get; set; }
    }
    class Program
    {
        static void Vain(string[] args)
        {
            S[] values = new S[10];
            S item = values[0];
            item.Value++;
            Console.WriteLine(values[0].Value);
        }
    }
}
