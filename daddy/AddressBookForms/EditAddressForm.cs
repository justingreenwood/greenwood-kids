using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBookForms
{
    public partial class EditAddressForm : Form
    {
        public EditAddressForm()
        {
            InitializeComponent();
        }

        public Address CurrentAddress;

        public void AddNewAddress()
        {
            CurrentAddress = new Address();
            FillInTheForm();
        }

        public void EditExistingAddress(Address addy)
        {
            CurrentAddress = addy;
            FillInTheForm();
        }

        private void FillInTheForm()
        {
            this.textBoxFirstName.Text = CurrentAddress.FirstName;
            this.textBoxLastName.Text = CurrentAddress.LastName;
            this.textBoxEmail.Text = CurrentAddress.Email;
        }

        private void FillInTheObject()
        {
            CurrentAddress.FirstName = this.textBoxFirstName.Text;
            CurrentAddress.LastName = this.textBoxLastName.Text;
            CurrentAddress.Email = this.textBoxEmail.Text;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            FillInTheObject();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
