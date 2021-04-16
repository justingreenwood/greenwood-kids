using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingGenerics
{
    public class ListOfNumbers
    {
        private int[] numbers;
        public ListOfNumbers()
        {
            numbers = new int[0];
        }
        public void AddNumber (int newNumber)
        {
            // some code
            // your number
        }
        public int GetNumber(int index)
        {
            return numbers[index];
        }
    }
    public class list
    {
        private object[] objects;
        public list()
        {
            objects = new object[0];
        }
        public void AddObject(object newObject)
        {
            //new array
            //object in
        }
        public object GetObject(int index)
        {
            return objects[index];
        }
    }
}
