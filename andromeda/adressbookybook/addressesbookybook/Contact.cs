using System;
using System.Collections.Generic;
using System.Text;

namespace addressesbookybook
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
            return (this.firstname + (" ") + this.lastname + (", ") +
                this.streetnum + (", ") +
                this.city + (", ") + this.state + (" ") + this.zip);
        }
    }
}
