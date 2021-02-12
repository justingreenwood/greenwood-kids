using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windy_Address_Book
{
    public partial class FormAddressBook : Form
    {
        private List<AddressesAndSuch> _addresses = new List<AddressesAndSuch>();
        private EditWindow _editForm = new EditWindow();

        public FormAddressBook()
        {
            InitializeComponent();
        }

        private List<AddressesAndSuch> SelectedAddresses
        {
            get
            {
                var selectedAddresses = new List<AddressesAndSuch>();
                foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                {
                    if (row.DataBoundItem is AddressesAndSuch)
                    {
                        selectedAddresses.Add(row.DataBoundItem as AddressesAndSuch);
                    }
                }
                return selectedAddresses;
            }
        }

        private void AddressBook_Load(object sender, EventArgs e)
        {
            var linesArray = File.ReadAllLines("AddressTextFile.txt");
            foreach ( var line in linesArray)
            {
                var bodyparts = line.Split('|');
                if (bodyparts.Length == 5)
                {
                    _addresses.Add(new AddressesAndSuch
                    {
                        Name = bodyparts[0],
                        Occupation = bodyparts[1],
                        Address = bodyparts[2],
                        Phone = bodyparts[3],
                        Email = bodyparts[4]

                    });
                }
            }
            

            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = _addresses;
            this.dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FillInSomething()
        {
         
        }

        private void MakeObject()
        {
           
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (SelectedAddresses.Count > 0)
            {
                var firstAddress = SelectedAddresses[0];
                _editForm.EditAddress(firstAddress);
                if (_editForm.ShowDialog(this) == DialogResult.OK)
                {
                    // clicked ok
                    this.dataGridView1.Refresh();
                }
                else
                {
                    //clicked cancel
                }
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            _editForm.CreateNewAddress();
            if (_editForm.ShowDialog(this) == DialogResult.OK)
            {
                // clicked ok
                this._addresses.Add(_editForm.MyAddressToEdit);
                RefreshGrid();
            } 
            else
            {
                //clicked cancel
            }
        }

        public void  RefreshGrid()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = this._addresses;
            this.dataGridView1.Refresh();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            var lines = new List<string>();
            foreach (var address in this._addresses)
            {
                lines.Add(address.ToFileString());
            }
            File.WriteAllLines("AddressTextFile.txt", lines);
            Console.Beep();
            //Perry either cannot or will not help me more!
            MessageBox.Show("Saving complete!");

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var addressesToDelete = SelectedAddresses;
            if (addressesToDelete.Count > 0)
            {
                this.dataGridView1.DataSource = null;
                foreach (var address in addressesToDelete)
                {
                    this._addresses.Remove(address);
                }
                RefreshGrid();
            }
        }
    }
}
