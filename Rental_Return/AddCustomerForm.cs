using System.Data.SQLite;

namespace VehicleRentSystem
{
    public partial class AddCustomerForm : Form
    {
        public int NewCustomerID { get; private set; }

        public AddCustomerForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter the customer name.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNIC.Text))
            {
                MessageBox.Show("Please enter the NIC number.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = @"INSERT INTO Customers (Name, NIC, Phone)
                           VALUES (@name, @nic, @phone);
                           SELECT last_insert_rowid();";

            SQLiteParameter[] p =
            {
                new SQLiteParameter("@name",  txtName.Text.Trim()),
                new SQLiteParameter("@nic",   txtNIC.Text.Trim()),
                new SQLiteParameter("@phone", txtPhone.Text.Trim())
            };

            object result = DatabaseHelper.ExecuteScalar(sql, p);
            if (result != null && int.TryParse(result.ToString(), out int newId))
            {
                NewCustomerID = newId;
                MessageBox.Show($"✅ Customer '{txtName.Text.Trim()}' added successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Failed to save customer. Please try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
