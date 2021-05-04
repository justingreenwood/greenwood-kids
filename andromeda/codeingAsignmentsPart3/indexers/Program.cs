using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace indexers
{
    class Program
    { 
        public double this[int index]
        {
            get
            {
                if(index==0) { return X; }
                else if (index == 1) { return Y; }
                else { throw new IndexOutOfRangeException(); }
            }
            set
            {
                if (index == 0) { X=value; }
                else if (index == 1) {  Y=value; }
                else { throw new IndexOutOfRangeException(); }
            }
           
        }
        Vector v = new Vector(5, 2);
        double xComponant = v[0]; 
        double yComponant = v[1];
        Dictionary dictionary = new Dictionary()
        {
            ["apple"] = "A particularly delicious pomaceous fruit of the genus Malus.",
            ["broccoli"] = "tasty with cheese sause."
        };


    }
}
