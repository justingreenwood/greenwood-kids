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
    public partial class AddressListForm : Form
    {
        private List<Address> _addresses;
        private EditAddressForm _editForm = new EditAddressForm();

        public AddressListForm()
        {
            InitializeComponent();
        }

        private void AddressListForm_Load(object sender, EventArgs e)
        {
            // load addresses from file.
            _addresses = new List<Address>()
                {
                    new Address
                    {
                        FirstName = "Poop",
                        LastName = "Smith",
                        Email = "poop@poop.com",
                    },
                    new Address
                    {
                        FirstName = "Fart",
                        LastName = "Jones",
                        Email = "fart@fart.com",
                    }
                };


            // bind the addresses to the checkboxlist
            LoadUpList();
        }

        private void LoadUpList()
        {
            checkedListBoxAddresses.Items.Clear();
            foreach (var address in this._addresses) 
            {
                checkedListBoxAddresses.Items.Add(address);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _editForm.AddNewAddress();
            var result = _editForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                _addresses.Add(_editForm.CurrentAddress);
                LoadUpList();
            }
            else
            {
                // revert the changes
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (this.checkedListBoxAddresses.CheckedItems.Count > 0)
            {
                var addresstoEdit = this.checkedListBoxAddresses.CheckedItems[0] as Address;
                _editForm.EditExistingAddress(addresstoEdit);
                var result = _editForm.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    LoadUpList();
                }
                else
                {
                    // revert the changes
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            buttonAdd_Click(sender, e);
        }
    }
}
