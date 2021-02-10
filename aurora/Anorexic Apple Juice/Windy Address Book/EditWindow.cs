using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windy_Address_Book
{
    public partial class EditWindow : Form
    {
        public AddressesAndSuch MyAddressToEdit;

        public EditWindow()
        {
            InitializeComponent();
        }

        public void CreateNewAddress()
        {
            MyAddressToEdit = new AddressesAndSuch();
            this.AddressTextBox.Text = "";
            this.NameTextBox.Text = "";
            this.OccupationTextBox.Text = "";
            this.PhoneTextBox.Text = "";
            this.EmailTextBox.Text = "";
        }

        public void EditAddress(AddressesAndSuch selectedAddress)
        {
            MyAddressToEdit = selectedAddress;

            this.AddressTextBox.Text = MyAddressToEdit.Address;
            this.NameTextBox.Text = MyAddressToEdit.Name;
            this.OccupationTextBox.Text = MyAddressToEdit.Occupation;
            this.PhoneTextBox.Text = MyAddressToEdit.Phone;
            this.EmailTextBox.Text = MyAddressToEdit.Email;
        }

        private void EditWindow_Load(object sender, EventArgs e)
        {
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            //I need Dad.
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            //Still need Dad.
            MyAddressToEdit.Address = this.AddressTextBox.Text;
            MyAddressToEdit.Name = this.NameTextBox.Text;
            MyAddressToEdit.Occupation = this.OccupationTextBox.Text;
            MyAddressToEdit.Phone = this.PhoneTextBox.Text;
            MyAddressToEdit.Email = this.EmailTextBox.Text;
        }

        private void NameLabel_Click(object sender, EventArgs e)
        {

        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void OccupationLabel_Click(object sender, EventArgs e)
        {

        }

        private void OccupationTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddressTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddressLabel_Click(object sender, EventArgs e)
        {

        }

        private void EmailLabel_Click(object sender, EventArgs e)
        {

        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PhoneLabel_Click(object sender, EventArgs e)
        {

        }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
