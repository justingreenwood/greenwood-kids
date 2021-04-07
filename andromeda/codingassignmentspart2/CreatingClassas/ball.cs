using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingClassas
{
    class ball
    {  
       private int poped;
      private  int thrown;
        // public ball.color(color)

        private ball(int poped,int thrown)
        {
            this.poped = poped;
            this.thrown = thrown;
        }
        private ball(int thrown)
        {
            this.thrown = thrown;
            poped = 0;
        }
    }
}
