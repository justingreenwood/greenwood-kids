using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes
{
   public class PracticeList<T> 
    {
        private T[] items;
        public PracticeList()
        {
            items = new T[0];
        }
        public T GetItem(int index)
        {
            return items[index];
        }
        public void Add(T newItem)
        {
            // bigger array
            T[] newItems = new T[items.Length + 1];
            //copy old items
            for (int index = 0; index < items.Length; index++)
                newItems[index] = items[index];
            //new item at end
            newItems[newItems.Length - 1] = newItem;
            //update variable
            items = newItems;
        }
    }
    public class Generics<T>
    {
        private T[] Items;
        public Generics()
        {
            Items = new T[0];
        }
        public T GetItem(int Index)
        {
            return Items[Index];
        }
        public void Add(T newitem)
        { 
            T[] newitems = new T[Items.Length + 1];
            for (int Index = 0; Index < Items.Length; Index++)
            {
                newitems[Index] = Items[Index];
            }
            newitems[newitems.Length - 1] = newitem;
            Items = newitems;
        }
    }
}
