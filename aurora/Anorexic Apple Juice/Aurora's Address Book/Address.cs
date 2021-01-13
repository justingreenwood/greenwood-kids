using System;
using System.Collections.Generic;
using System.Text;

namespace Aurora_s_Address_Book
{
    class Address
    {
        public Address()
        {

        }

        public Address(string line)
        {
            var fields = line.Split('|');
            if (fields.Length == 6)
            {
                this.NAME = fields[0];
                this.Occupation = fields[1];
                this.Address1 = fields[2];
                this.CityStateZip = fields[3];
                this.Phone = fields[4];
                this.Email = fields[5];
            }
            else
            {
                throw new Exception("FIRE! FIRE! FIRE!");
            }
        }

        public string NAME;
        public string Occupation;
        public string Address1;
        public string CityStateZip;
        public string Phone;
        public string Email;

        public string ToFileString()
        {
            return $"{NAME}|{Occupation}|{Address1}|{CityStateZip}|{Phone}|{Email}";
        }
        public override string ToString()
        {
            return $"{NAME}\r\n{Occupation}\r\n{Address1}\r\n{CityStateZip}\r\n{Phone}\r\n{Email}";
        }
    }
}
