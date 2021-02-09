using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace addressesbookybook
{
    public partial class addoredit : Form
    {
        private Contact _contact;

        public addoredit()
        {
            InitializeComponent();
        }


        public Contact GetContact()
        {
            return _contact;
        }

        public void AddNewContact() 
        {
            _contact = new Contact();
            this.textBoxfirst.Text = "";
            this.textBoxlast.Text = "";
        }
        public void EditContact(Contact c)
        {
            _contact = c;
            this.textBoxfirst.Text = _contact.firstname;
            this.textBoxlast.Text = _contact.lastname; 
            this.textBoxstreetnum.Text = _contact.streetnum;
            this.textBoxcity.Text = _contact.city;
            this.textBoxzip.Text = _contact.zip;
        }
        private void addoredit_Load(object sender, EventArgs e)
        {

        }

        private void buttonokay_Click(object sender, EventArgs e)
        {
            _contact.firstname = this.textBoxfirst.Text;
            _contact.lastname = this.textBoxlast.Text;
            _contact.streetnum = this.textBoxstreetnum.Text;
            _contact.city = this.textBoxcity.Text;
            _contact.state = this.textBoxstate.Text;
            _contact.zip= this.textBoxzip.Text;
        }

        private void buttoncancel_Click(object sender, EventArgs e)
        {

        }
    }
}
