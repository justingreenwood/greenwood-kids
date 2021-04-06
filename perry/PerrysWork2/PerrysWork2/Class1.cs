using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerrysWork2
{
    class Class1
    {
        private string title;
        private string author;
        private int pages;
        private int wordcount;

        public Class1(string title, string author)
        {
            this.title = title;
            this.author = author;
        }
        public Class1(string title, string author, int pages, int wordcount)
        {
            this.title = title;
            this.author = author;
            this.pages = pages;
            this.wordcount = wordcount;
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
            wordcount = text.Split(' ').Length;
        }



    }
}
