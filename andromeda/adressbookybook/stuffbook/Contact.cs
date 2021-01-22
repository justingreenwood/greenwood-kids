using System;
using System.Collections.Generic;
using System.Text;

namespace stuffbook
{
    public class Contact
    {
        public string firstname;
        public string lastname;
        public string streetnum;
        public string city;
        public string state;
        public string zip;
        public string ToFileLineString()
        {
            return $"{lastname} ~ {firstname} ~ {streetnum} ~ {city} ~ {state} ~ {zip} ";
        }

        public override string ToString()
        {
            return (this.lastname + (", ") + this.firstname + ("\r\n") +
                this.streetnum + ("\r\n") +
                this.city + (", ") + this.state + (" ") + this.zip);
        }
    }
}
