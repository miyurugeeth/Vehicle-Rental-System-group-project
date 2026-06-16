using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vehicle_rental
{
    public partial class UC_CustomerDirectory : UserControl
    {
        public UC_CustomerDirectory()
        {
            InitializeComponent();
            LoadCustomerData();
        }
        public void LoadCustomerData()
        {
            // 1. Wipe the grid clean so we don't get duplicates if we load twice
            dataGridView1.Rows.Clear();

            // 2. Get the data from our helper
            System.Data.DataTable dt = DatabaseHelper.GetAllCustomers();

            // 3. Loop through every row in the database and add it to our visual grid
            foreach (System.Data.DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(
                    row["CustomerID"],
                    row["Name"],
                    row["NIC"],
                    row["LicenseNo"],
                    row["Phone"],
                    row["Status"],
                    "Edit / History" // Placeholder text for your Actions column!
                );
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlAddCustomer.Visible = false;



            // This clears the text boxes if they change their mind
            txtFullName.Clear();
            txtNIC.Clear();
            txtLicense.Clear();
            txtContact.Clear();
        }

        

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            

            // Make the panel visible and push it to the very front!
            pnlAddCustomer.Visible = true;
            pnlAddCustomer.BringToFront();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      

        private void txtLiveSearch_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = txtLiveSearch.Text.Trim();

            // 1. If the text box is empty, load everyone back into the grid!
            if (string.IsNullOrWhiteSpace(searchKeyword))
            {
                LoadCustomerData();
                return;
            }

            // 2. Clear the visual table 
            dataGridView1.Rows.Clear(); // (Change to dataGridView1 if you didn't rename your table)

            // 3. Ask the database for the matching customers
            System.Data.DataTable dt = DatabaseHelper.SearchCustomerByNIC(searchKeyword);

            // 4. Loop through the results and put them in the table
            foreach (System.Data.DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(
                    row["CustomerID"],
                    row["Name"],
                    row["NIC"],
                    row["LicenseNo"],
                    row["Phone"],
                    row["Status"],
                    "Edit / History"
                );
            }
        }

        private void pnlAddCustomer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbl5_Click(object sender, EventArgs e)
        {

        }

        private void txtNIC_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl3_Click(object sender, EventArgs e)
        {

        }

        private void lbl2_Click(object sender, EventArgs e)
        {

        }

        private void lbl1_Click(object sender, EventArgs e)
        {

        }

        private void lbl4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            pnlAddCustomer.Visible = false;

            // (Optional: If you named your text boxes differently, update these names!)
            txtFullName.Clear();
            txtNIC.Clear();
            txtLicense.Clear();
            txtContact.Clear();
            cmbStatus.SelectedIndex = -1;
        }

        private void btnAddCustomer_TextChanged(object sender, EventArgs e)
        {

        }

        private void s(object sender, PaintEventArgs e)
        {

        }

        private void btnSaveCustomer_Click_1(object sender, EventArgs e)
        {
            // 1. Quick Validation: Make sure they didn't leave important fields blank
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtNIC.Text))
            {
                MessageBox.Show("Please enter at least the Full Name and NIC.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Grab the text from the UI
            string name = txtFullName.Text;
            string nic = txtNIC.Text;
            string license = txtLicense.Text;
            string contact = txtContact.Text;
            string status = cmbStatus.Text;

            // 3. Send it to the Database Helper
            bool success = DatabaseHelper.AddCustomer(name, nic, license, contact, status);

            // 4. If it worked, celebrate and clean up!
            if (success)
            {
                MessageBox.Show("Customer saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the form and hide the panel
                txtFullName.Clear();
                txtNIC.Clear();
                txtLicense.Clear();
                txtContact.Clear();
                cmbStatus.SelectedIndex = -1;
                pnlAddCustomer.Visible = false;

                // TODO: Refresh the DataGridView to show the new customer
            }
        }
    }
}
