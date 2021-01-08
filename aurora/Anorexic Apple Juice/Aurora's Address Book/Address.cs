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
            if (fields.Length == 8)
            {
                this.NAME = fields[0];
                this.Occupation = fields[1];
                this.Address1 = fields[2];
                this.CityStateZip = fields[3];
                this.Phone = fields[6];
                this.Email = fields[7];
            }
            else
            {
                throw new Exception("Not enough data!");
            }
        }
}
