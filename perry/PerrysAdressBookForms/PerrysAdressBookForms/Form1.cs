using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerrysAdressBookForms
{
    public partial class Form1 : Form
    {
        private List<Addresses> addresses;
        private FormEditAdd editadd = new FormEditAdd();
        public Form1()
        {
            InitializeComponent();
        } 
        private void LoadAddressList()
        {
            addresses = new List<Addresses>()
            {
                new Addresses
                {
                    FirstName = "Your",
                    LastName = "Face",
                    Email = "YourFace@YouSuck.com",
                    HouseAddress = "12345 Crap Dr.",
                    City = "Tihskds",
                    State = "Sasiho",
                    Zip = "09876",
                },
                new Addresses
                {
                    FirstName = "Spider",
                    LastName = "Knee",
                    Email = "SpitKnee@YouSuck.com",
                    HouseAddress = "54321 Carp Road",
                    City = "Tihskds",
                    State = "Sasiho",
                    Zip = "09876",
                }
            };
        }

        private void fillcheckboxlist()
        {
            this.checkedListBox1.Items.Clear();
            foreach(var addr in addresses)
            {
                this.checkedListBox1.Items.Add(addr);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            this.editadd.AddNewAddress();
            var result = this.editadd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                this.addresses.Add(editadd.MyAddress);
                fillcheckboxlist();
            }

        }

        private void Editbutton_Click(object sender, EventArgs e)
        {
            if (this.checkedListBox1.CheckedItems.Count > 0)
            { 
                this.editadd.EditAddress(this.checkedListBox1.CheckedItems[0] as Addresses);
                var result = this.editadd.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    fillcheckboxlist();
                }
            }

        }

        private void Removebutton_Click(object sender, EventArgs e)
        {
            foreach(var stuff in this.checkedListBox1.CheckedItems)
            {
                addresses.Remove(stuff as Addresses);
            }
            fillcheckboxlist();
        }

        private void Exitbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAddressList();
            fillcheckboxlist();
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {

        }
    }
    public class Addresses
    {
        public string FirstName;
        public string LastName;
        public string Email;
        public string HouseAddress;
        public string City;
        public string State;
        public string Zip;

        public override string ToString()
        {
            return $"{LastName}, {FirstName}, {Email}, {HouseAddress} {City}, {State}, {Zip}";
        }
    }
}
