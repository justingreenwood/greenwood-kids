using System;
using System.Collections.Generic;
using System.Text;

namespace PerrysAdressBook
{
    public class AddressLine
    {
        public string firstname;
        public string lastname;
        public string streetaddress;
        public string city;
        public string state;
        public string zipcode;
        public string phonenumber;
        public string emailaddress;

        public string ToFileLineString()
        {
            return $"{lastname} | {firstname} | {streetaddress} | {city} | {state} | {zipcode} | {phonenumber} | {emailaddress}";
        }

        public override string ToString()
        {
            return (this.lastname + (", ") + this.firstname + ("\r\n") + 
                this.streetaddress + ("\r\n") + 
                this.city + (", ") + this.state + (" ") + this.zipcode + ("\r\n") + 
                this.phonenumber + ("\r\n") + 
                this.emailaddress);
        }

    }
}
