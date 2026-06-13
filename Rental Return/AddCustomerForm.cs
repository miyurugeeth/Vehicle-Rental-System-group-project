using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace VehicleRentSystem
{
    public partial class AddCustomerForm : Form
    {
        public int NewCustomerID { get; private set; } = -1;

        public AddCustomerForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter customer name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNIC.Text) || txtNIC.Text.Trim().Length < 9)
            {
                MessageBox.Show("Please enter a valid NIC.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNIC.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLicense.Text))
            {
                MessageBox.Show("Please enter License Number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLicense.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Please enter Phone Number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            try
            {
                var existing = DatabaseHelper.ExecuteQuery(
                    "SELECT COUNT(*) AS C FROM Customers WHERE NIC=@nic",
                    new[] { new SQLiteParameter("@nic", txtNIC.Text.Trim()) });

                if (existing != null && existing.Rows.Count > 0 && Convert.ToInt32(existing.Rows[0]["C"]) > 0)
                {
                    MessageBox.Show("A customer with this NIC already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int result = DatabaseHelper.ExecuteNonQuery(
                    "INSERT INTO Customers (Name, NIC, LicenseNo, Phone, Address) VALUES (@n,@nic,@lic,@ph,@ad)",
                    new SQLiteParameter[] {
                        new SQLiteParameter("@n",   txtName.Text.Trim()),
                        new SQLiteParameter("@nic", txtNIC.Text.Trim()),
                        new SQLiteParameter("@lic", txtLicense.Text.Trim()),
                        new SQLiteParameter("@ph",  txtPhone.Text.Trim()),
                        new SQLiteParameter("@ad",  txtAddress.Text.Trim())
                    });

                if (result > 0)
                {
                    var idDt = DatabaseHelper.ExecuteQuery("SELECT last_insert_rowid() AS ID");
                    NewCustomerID = Convert.ToInt32(idDt.Rows[0]["ID"]);
                    MessageBox.Show($"✅ Customer added!\n\n{txtName.Text.Trim()}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}