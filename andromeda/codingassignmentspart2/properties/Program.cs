using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace properties
{
    class Program
    {
        private int score;
        public int Score
        {
            get
            {
             return score;
            }
         private set
         {
            score = value;
            if (score < 0)
                score = 0;
         }
        }  
       
    }
    public class Vector2S
    {
        public double x { get; set; } = 0;
        public double y { get; set; } = 0;
    }


}
