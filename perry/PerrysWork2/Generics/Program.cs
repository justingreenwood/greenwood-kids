using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            

        }



        public class PractiseList<T>
        {
            private T[] items;

            public PractiseList()
            {
                items = new T[0];
            }

            public T GetItem(int index)
            {
                return items[index];
            }

            public void Add(T newItem)
            {
                T[] newItems = new T[items.Length + 1];

                for (int index = 0; index < items.Length; index++)
                    newItems[index] = items[index];

                newItems[newItems.Length - 1] = newItem;

                items = newItems;
            }
        }
    }
}
