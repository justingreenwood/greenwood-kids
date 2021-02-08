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
                    selectedAddresses.Add(row.DataBoundItem as AddressesAndSuch);
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
                MessageBox.Show(firstAddress.Name);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (_editForm.ShowDialog(this) == DialogResult.OK)
            {
                // clicked ok
            } 
            else
            {
                // clicked cancel
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            foreach (var address in SelectedAddresses)
            {
                MessageBox.Show(address.Name);
            }
        }
    }
}
