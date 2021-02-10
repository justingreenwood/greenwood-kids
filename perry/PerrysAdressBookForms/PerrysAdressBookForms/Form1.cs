using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadFromFile();
            fillcheckboxlist();
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

        private void Savebutton_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        public void LoadFromFile()
        {
            this.addresses = new List<Addresses>();
            var lines = File.ReadAllLines("Addresses.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                var columns = line.Split('|');
                if (columns.Length == 7)
                {
                    var a = new Addresses();
                    a.LastName = columns[0].Trim();
                    a.FirstName = columns[1].Trim();
                    a.HouseAddress = columns[2].Trim();
                    a.City = columns[3].Trim();
                    a.State = columns[4].Trim();
                    a.Zip = columns[5].Trim();
                    a.Email = columns[6].Trim();
                    //Console.WriteLine(lines[i]);
                    this.addresses.Add(a);
                }
            }
        }

        public void SaveToFile()
        {
            var lines = new List<string>();
            foreach (var addr in this.addresses)
            {
                lines.Add(addr.ToFileLineString());
            }

            File.WriteAllLines("Addresses.txt", lines);
            MessageBox.Show("Done Saving Your Addresses.");
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

        public string ToFileLineString()
        {
            return $"{LastName} | {FirstName} | {HouseAddress} | {City} | {State} | {Zip} | {Email}";
        }

        public override string ToString()
        {
            return $"{LastName}, {FirstName}, {Email}, {HouseAddress} {City}, {State}, {Zip}";
        }
    }
}
