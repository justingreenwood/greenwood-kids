using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace extensionMethods
{
    public static class StringExtensiona
    {
        private static Random random = new Random();
        public static string ToRandomCase(this string text)
        {
            string result = "";
            for(int index = 0; index < text.Length; index++)
            {
                if (random.Next(2) == 0)
                    result += text.Substring(index, 1).ToUpper();
                else
                    result += text.Substring(index, 1).ToLower();
            }
            return result;
        }
    }
}
