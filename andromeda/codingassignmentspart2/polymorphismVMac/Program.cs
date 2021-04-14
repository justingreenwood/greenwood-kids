using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polymorphismVMac
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
   class SearchEngine
   {
        public virtual string[] Search(string findThis)
        {
            return new string[0];
        }
        SearchEngine searchEngine1 = new SearchEngine();
        SearchEngine searchEngine3 = new RBsSearchEngine();
        string[] defultResults = searchEngine1.Search("hello");
        string[] rbsResults = searchEngine3.Search("hello");
    }
    class RBsSearchEngine: SearchEngine
    {
        public override string[] Search (string findThis)
        {
            return new string[]
            {
                "I found something.",
                "I found this for you."
            };
        }
    }
    public abstract class Searchengine
    {
        public abstract string[] Search(string findThis);
    }
    public new string[] Search(string findThis)
    {
        //..
    }
}
