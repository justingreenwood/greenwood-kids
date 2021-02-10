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
            _addresses.Add(new AddressesAndSuch
            {
                Name = "Felix Joel Riddle",
                Occupation = "Teacher",
                Address = "Thea Romanov's School for Gifted Twerps",
                Phone = "(808)337-3045",
                Email = "felix.the.cat@gmail.com"

            }); ;

            _addresses.Add(new AddressesAndSuch
            {
                Name = "Aubriella 'Brie' Narcissa Riddle",
                Occupation = "District Attorney",
                Address = "3128 Moldy Lane, Riddleton, England 28930",
                Phone = "(808)234-3842",
                Email = "brie.cheese@gmail.com"

            });

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
