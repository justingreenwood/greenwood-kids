using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    public class Address
    {
        public Address()
        {
        }
        public Address(string line)
        {
            var fields = line.Split('|');
            if (fields.Length == 8)
            {
                this.LastName = fields[0];
                this.FirstName = fields[1];
                this.StreetAddress = fields[2];
                this.City = fields[3];
                this.State = fields[4];
                this.ZipCode = fields[5];
                this.Phone = fields[6];
                this.Email = fields[7];
            }
            else
            {
                throw new Exception("Not enough data!");
            }
        }


        public string FirstName;
        public string LastName;
        public string StreetAddress;
        public string City;
        public string State;
        public string ZipCode;
        public string Phone;
        public string Email;

        public string ToFileString()
        {
            return $"{LastName}|{FirstName}|{StreetAddress}|{City}|{State}|{ZipCode}|{Phone}|{Email}";
        }
        public override string ToString()
        {
            return $"{LastName}, {FirstName}\r\n{StreetAddress}\r\n{City}, {State} {ZipCode}\r\n{Phone}\r\n{Email}";
        }
    }
}
