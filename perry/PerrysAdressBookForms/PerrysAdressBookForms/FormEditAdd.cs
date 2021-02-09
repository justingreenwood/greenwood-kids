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
    public partial class FormEditAdd : Form
    {
        public FormEditAdd()
        {
            InitializeComponent();
        }

        public Addresses MyAddress;

        public void AddNewAddress()
        {
            this.MyAddress = new Addresses();
            SetTheControls();
        }
        public void EditAddress(Addresses a)
        {
            this.MyAddress = a;
            SetTheControls();
        }
        public void removeAddress()
        {
            
        }

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxHouseAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxState_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxZip_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            SetTheObjects();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

        private void SetTheControls()
        {
            this.textBoxFirstName.Text = this.MyAddress.FirstName;
            this.textBoxLastName.Text = this.MyAddress.LastName;
            this.textBoxCity.Text = this.MyAddress.City;
            this.textBoxState.Text = this.MyAddress.State;
            this.textBoxEmail.Text = this.MyAddress.Email;
            this.textBoxHouseAddress.Text = this.MyAddress.HouseAddress;
            this.textBoxZip.Text = this.MyAddress.Zip;

        }

        private void SetTheObjects()
        {
            this.MyAddress.FirstName = this.textBoxFirstName.Text;
            this.MyAddress.LastName = this.textBoxLastName.Text;
            this.MyAddress.City = this.textBoxCity.Text;
            this.MyAddress.State = this.textBoxState.Text;
            this.MyAddress.Email = this.textBoxEmail.Text;
            this.MyAddress.HouseAddress = this.textBoxHouseAddress.Text;
            this.MyAddress.Zip = this.textBoxZip.Text;
        }

        private void FormEditAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
