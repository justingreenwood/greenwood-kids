using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @interface
{
   public interface IfileWriter
   {
       string Extension { get; }
        void Write(string filename);
   }
    public class AnyOldClass: RandomBaseClass, Iinterface1, Iinterface2
    {
        //..
    }
}
