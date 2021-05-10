using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerrysQueries
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameobject = new GameObject();
            IEnumerable<GameObject> fullhealth = from o in gameobject
                                                 where o.CurrentHP is o.MaxHP
                                                 select o;




        }
    }



    public class GameObject
    {
        public int ID { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double MaxHP { get; set; }
        public double CurrentHP { get; set; }
        public int PlayerID { get; set; }
    }


}
