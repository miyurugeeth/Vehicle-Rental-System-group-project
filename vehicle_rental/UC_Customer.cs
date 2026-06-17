using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using vehicle_rental;

namespace vehicle_rental
{
    public partial class UC_Customer : UserControl
    {
        private int selectedCustomerID = -1; // Edit mode tracking

        public UC_Customer()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        // ─── LOAD ───────────────────────────────────────────────
        private void UC_Customer_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            Panel_Form.Visible = false;
            btnDelete.Visible = false;
            LoadCustomers();
        }

        // ─── GRID ────────────────────────────────────────────────
        private void LoadCustomers()
        {
            DataTable dt = DatabaseHelper.GetAllCustomers();
            SetupGrid(dt);
        }

        private void SetupGrid(DataTable dt)
        {
            dgvCustomers.AutoGenerateColumns = true;
            dgvCustomers.DataSource = dt;

            Color color = Color.FromArgb(30, 30, 30);
            Color backColor = Color.FromArgb(20, 20, 20);

            dgvCustomers.EnableHeadersVisualStyles = false;
           
            dgvCustomers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
           
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.ReadOnly = true;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.BorderStyle = BorderStyle.None;
            dgvCustomers.RowHeadersVisible = false;

            dgvCustomers.CellFormatting += delegate (object s, DataGridViewCellFormattingEventArgs ev)
            {
                if (dgvCustomers.Columns[ev.ColumnIndex].Name == "Status" && ev.Value != null)
                {
                    if (ev.Value.ToString() == "Active")
                        ev.CellStyle.ForeColor = Color.Green;
                    else if (ev.Value.ToString() == "Blacklisted")
                        ev.CellStyle.ForeColor = Color.OrangeRed;
                }
            };
        }

        // ─── SEARCH ──────────────────────────────────────────────
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
                LoadCustomers();
            else
            {
                DataTable dt = DatabaseHelper.SearchCustomers(txtSearch.Text);
                SetupGrid(dt);
            }
        }

        // ─── ADD NEW ─────────────────────────────────────────────
        private void btnAddNewVehicle_Click(object sender, EventArgs e)
        {
            ClearForm();
            selectedCustomerID = -1;
            Panel_Form.Visible = true;
            btnDelete.Visible = false;
        }

        // ─── GRID ROW CLICK → LOAD TO FORM ──────────────────────
        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];

            // ID take from CustomerID column 
            if (row.Cells["CustomerID"].Value == null) return;

            selectedCustomerID = Convert.ToInt32(row.Cells["CustomerID"].Value);

            txtName.Text = row.Cells["Name"].Value?.ToString();
            txtNIC.Text = row.Cells["NIC"].Value?.ToString();
            txtLicenseNo.Text = row.Cells["LicenseNo"].Value?.ToString();
            txtPhone.Text = row.Cells["Phone"].Value?.ToString();
            txtAddress.Text = row.Cells["Address"].Value?.ToString();

            string regDate = row.Cells["RegisteredDate"].Value?.ToString();
            if (!string.IsNullOrEmpty(regDate) && DateTime.TryParse(regDate, out DateTime dt))
                dtpRegisteredDate.Value = dt;

            Panel_Form.Visible = true;
            btnDelete.Visible = true;
        }

        // ─── SAVE (Insert or Update) ──────────────────────────────
        private void btnRegisterCustomer_Click(object sender, EventArgs e)
        {

        }




        // ─── DELETE ──────────────────────────────────────────────
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCustomerID == -1) return;

            DialogResult confirm = MessageBox.Show(
                "Do you want to delete this customer?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                string query = "DELETE FROM Customers WHERE CustomerID=@CustomerID";
                SQLiteParameter[] parameters = {
                    new SQLiteParameter("@CustomerID", selectedCustomerID)
                };

                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Customer Deleted!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    Panel_Form.Visible = false;
                    btnDelete.Visible = false;
                    selectedCustomerID = -1;
                    LoadCustomers();
                }
            }
        }

        // ─── CANCEL ──────────────────────────────────────────────
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
            Panel_Form.Visible = false;
            btnDelete.Visible = false;
            selectedCustomerID = -1;
        }

        // ─── CLEAR FORM ──────────────────────────────────────────
        private void ClearForm()
        {
            txtName.Text = "";
            txtNIC.Text = "";
            txtLicenseNo.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            dtpRegisteredDate.Value = DateTime.Now;
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];

            if (row.Cells["CustomerID"].Value == null) return;

            selectedCustomerID = Convert.ToInt32(row.Cells["CustomerID"].Value);

            txtName.Text = row.Cells["Name"].Value?.ToString() ?? "";
            txtNIC.Text = row.Cells["NIC"].Value?.ToString() ?? "";
            txtLicenseNo.Text = row.Cells["LicenseNo"].Value?.ToString() ?? "";
            txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? "";

            // Address column safely check 
            if (dgvCustomers.Columns["Address"] != null)
                txtAddress.Text = row.Cells["Address"].Value?.ToString() ?? "";

            string regDate = row.Cells["RegisteredDate"].Value?.ToString();
            if (!string.IsNullOrEmpty(regDate) && DateTime.TryParse(regDate, out DateTime dt))
                dtpRegisteredDate.Value = dt;
            else
                dtpRegisteredDate.Value = DateTime.Now;

            Panel_Form.Visible = true;
            btnDelete.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
        string.IsNullOrWhiteSpace(txtNIC.Text) ||
        string.IsNullOrWhiteSpace(txtLicenseNo.Text) ||
        string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Please fill in all required fields: Name, NIC, License Number, and Phone.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int result;

            if (selectedCustomerID != -1)
            {
                // ── UPDATE ──
                string query = @"UPDATE Customers SET 
            Name=@Name, NIC=@NIC, LicenseNo=@LicenseNo, 
            Phone=@Phone, Address=@Address, RegisteredDate=@RegisteredDate
            WHERE CustomerID=@CustomerID";

                SQLiteParameter[] parameters = {
            new SQLiteParameter("@Name",           txtName.Text.Trim()),
            new SQLiteParameter("@NIC",            txtNIC.Text.Trim()),
            new SQLiteParameter("@LicenseNo",      txtLicenseNo.Text.Trim()),
            new SQLiteParameter("@Phone",          txtPhone.Text.Trim()),
            new SQLiteParameter("@Address",        txtAddress.Text.Trim()),
            new SQLiteParameter("@RegisteredDate", dtpRegisteredDate.Value.ToString("yyyy-MM-dd")),
            new SQLiteParameter("@CustomerID",     selectedCustomerID)
        };

                result = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (result > 0)
                    MessageBox.Show("Customer updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Update failed. Please try again.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // ── INSERT ──
                string query = @"INSERT INTO Customers (Name, NIC, LicenseNo, Phone, Address, RegisteredDate, Status)
                         VALUES (@Name, @NIC, @LicenseNo, @Phone, @Address, @RegisteredDate, 'Active')";

                SQLiteParameter[] parameters = {
            new SQLiteParameter("@Name",           txtName.Text.Trim()),
            new SQLiteParameter("@NIC",            txtNIC.Text.Trim()),
            new SQLiteParameter("@LicenseNo",      txtLicenseNo.Text.Trim()),
            new SQLiteParameter("@Phone",          txtPhone.Text.Trim()),
            new SQLiteParameter("@Address",        txtAddress.Text.Trim()),
            new SQLiteParameter("@RegisteredDate", dtpRegisteredDate.Value.ToString("yyyy-MM-dd"))
        };

                result = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (result > 0)
                    MessageBox.Show("Customer registered successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LoadCustomers();
            ClearForm();
            Panel_Form.Visible = false;
            btnDelete.Visible = false;
            selectedCustomerID = -1;
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (selectedCustomerID == -1)
            {
                MessageBox.Show("Please select a customer to delete.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
               "Delete this customer?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                string query = "DELETE FROM Customers WHERE CustomerID=@CustomerID";
                SQLiteParameter[] parameters = {
            new SQLiteParameter("@CustomerID", selectedCustomerID)
        };

                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Customer Delete Succesfully", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadCustomers();
                    ClearForm();
                    Panel_Form.Visible = false;
                    btnDelete.Visible = false;
                    selectedCustomerID = -1;
                }
                else
                {
                    MessageBox.Show("Delete failed. Try again." +
                        ".", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void dgvCustomers_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadCustomers();
                return;
            }

            string query = @"SELECT 
        'CUST-' || printf('%03d', CustomerID) AS DisplayID,
        CustomerID,
        Name,
        NIC,
        LicenseNo,
        Phone,
        Address,
        COALESCE(Status, 'Active') AS Status,
        CAST(RegisteredDate AS TEXT) AS RegisteredDate
    FROM Customers 
    WHERE NIC LIKE @search 
       OR Name LIKE @search 
       OR LicenseNo LIKE @search
       OR Phone LIKE @search
    ORDER BY CustomerID DESC";

            SQLiteParameter[] parameters = {
        new SQLiteParameter("@search", "%" + searchText + "%")
    };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            SetupGrid(dt);

            if (dgvCustomers.Columns["CustomerID"] != null)
                dgvCustomers.Columns["CustomerID"].Visible = false;
        }

        private void Panel_Form_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
    

