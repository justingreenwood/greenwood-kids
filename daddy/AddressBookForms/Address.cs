using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookForms
{
    public class Address
    {
        public string FirstName;
        public string LastName;
        public string Email;

        public override string ToString()
        {
            return $"{FirstName} {LastName} {Email}";
        }
    }
}
