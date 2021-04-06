using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingClassas
{
    public class book
    {
        private string title;
        private string author;
        private int pages;
        private int wordCount;
        public book(string title, string author)
        {
            this.title = title;
            this.author = author;
        }
        public book(string title, string author,int pages,int wordCount)
        {
            this.title = title;
            this.author = author;
            this.pages = pages;
            this.wordCount = wordCount;
        }
        public string GetTitle()
        {
            return title;
        }
        public void SetTitle(string title)
        {
            this.title = title;
        }
        public void AssignWordCountFromText(string text)
        {
            wordCount = text.Split(' ').Length;
        }
        
        public void DoSomething()
        {
            for (int x = 0; x < 10; x++)
                Console.WriteLine(x);
            for (int x = 50; x < 60; x++)
                Console.WriteLine(x);
        }

    }
}
