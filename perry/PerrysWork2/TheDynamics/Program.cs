using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace TheDynamics
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Something : DynamicObject
    {
        private Dictionary<string, string> data;

        public Something(string[]names, string[] age)
        {
            data = new Dictionary<string, string>();

            for (int i = 0; i < names.Length; i++)
            {
                data[names[i]] = age[i];
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (data.ContainsKey(binder.Name))
            {
                result = data[binder.Name];
                return true;
            }
            else
            {
                result = null;
                return false;
            }

        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (!data.ContainsKey(binder.Name))
            {
                return false;
            }

            data[binder.Name] = value.ToString();
            return true;
        }

    }
}
