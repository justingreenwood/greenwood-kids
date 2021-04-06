using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerrysWork2
{
    class ball
    {
        private int throws;
        private string color;
        private int size = 1;

        public int Throw()
        {
            if (this.size != 0)
            {
                this.throws++;
            }
            return throws;
        }

        public void Pop()
        {
            this.size = 0;
            
        }

        public void Throws()
        {
            Console.WriteLine(throws);
        }




    }
}
