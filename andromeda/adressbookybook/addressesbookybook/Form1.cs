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

namespace addressesbookybook
{
    public partial class addressstuff : Form
    {
        private addoredit _editForm = new addoredit();
        private List<Contact> _contacts = new List<Contact>();

        public addressstuff()
        {
            InitializeComponent();
        }

        private void addressstuff_Load(object sender, EventArgs e)
        {
            LoadAddressesFromFile();
            PutAddressesInCheckBoxList();
        }

        private void buttonsave_Click(object sender, EventArgs e)
        {
            //SaveFileDialog(adresses);

        }

        private void buttonquit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonadd_Click(object sender, EventArgs e)
        {
            
            _editForm.AddNewContact();
            var result = _editForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                this._contacts.Add(_editForm.GetContact());
                this.PutAddressesInCheckBoxList();
            }
        }

        private void buttonremove_Click(object sender, EventArgs e)
        {
            foreach (var _contacts in this.checkBoxListAddresses.CheckedItems)
            {
                    var checkedContact = (Contact)this.checkBoxListAddresses.CheckedItems[0];

                    
                checkedContact.Remove(Contact as _contacts );

                this.PutAddressesInCheckBoxList();
                   
            }
        }

        private void buttonedit_Click(object sender, EventArgs e)
        {
           
            if (this.checkBoxListAddresses.CheckedItems.Count > 0)
            {
                var checkedContact = (Contact)this.checkBoxListAddresses.CheckedItems[0];

                _editForm.EditContact(checkedContact);
                var result = _editForm.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    this.PutAddressesInCheckBoxList();
                }
            }
        }

        private void PutAddressesInCheckBoxList()
        {
            this.checkBoxListAddresses.Items.Clear();
            foreach (var c in _contacts)
            {
                this.checkBoxListAddresses.Items.Add(c);
            }
        }

        private void LoadAddressesFromFile()
        {
            this._contacts.Clear();
            var rows = File.ReadAllLines("AddressBook.txt");
            for (int i = 0; i < rows.Length; i++)
            {
                string row = rows[i];
                var columns = row.Split('~');
                if (columns.Length == 6)
                {
                    var a = new Contact();
                    a.firstname = columns[0];
                    a.lastname = columns[1];
                    a.streetnum = columns[2];
                    a.city = columns[3];
                    a.state = columns[4];
                    a.zip = columns[5];
                    _contacts.Add(a);
                    Console.WriteLine(rows[i]);
                }
            }
        }
    }
}
