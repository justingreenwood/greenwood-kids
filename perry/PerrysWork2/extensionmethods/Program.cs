using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace extensionmethods
{
    class Program
    {
        static void Main(string[] args)
        {
            //string message = "FArt FAt Hosue";
            //Console.WriteLine(message.WordCount());

            //string mesg = "I love you. You are poo. You suck. You are fat.";
            //Console.WriteLine(mesg.SentenceCount());


            Console.ReadKey();
        }
    }

    public static class WordCountExtensionString
    {

        public static int WordCount(this string text)
        {
            var house = text.Split(' ');
            return house.Count();
        }

        public static int SentenceCount(this string text)
        {
            var house = text.Split('.');
            return house.Count() - 1;
        }
        public static int ParagraphCount(this string text)
        {
            var house = text.Split('\n');
            return house.Count() - 1;
        }

    }








}
