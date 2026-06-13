using System.Data;
using System.Data.SQLite;

namespace VehicleRentSystem
{
    public partial class RentalForm : Form
    {
        public RentalForm()
        {
            InitializeComponent();
        }

        private void RentalForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadAvailableVehicles();
            LoadActiveRentals();
            dtpRentDate.Value = DateTime.Today;
            dtpExpectedReturn.Value = DateTime.Today.AddDays(1);
        }

        // ── Load Dropdowns ────────────────────────────────────────
        private void LoadCustomers()
        {
            DataTable dt = DatabaseHelper.ExecuteQuery(
                "SELECT CustomerID, Name || ' - ' || NIC AS Display FROM Customers ORDER BY Name");
            cmbCustomer.DataSource = dt;
            cmbCustomer.DisplayMember = "Display";
            cmbCustomer.ValueMember = "CustomerID";
            cmbCustomer.SelectedIndex = -1;
        }

        private void LoadAvailableVehicles()
        {
            DataTable dt = DatabaseHelper.ExecuteQuery(
                "SELECT VehicleID, VehicleNo || ' | ' || Brand || ' ' || Model || ' (Rs.' || RentPrice || '/day)' AS Display, RentPrice " +
                "FROM Vehicles WHERE Status = 'Available' ORDER BY VehicleNo");
            cmbVehicle.DataSource = dt;
            cmbVehicle.DisplayMember = "Display";
            cmbVehicle.ValueMember = "VehicleID";
            cmbVehicle.SelectedIndex = -1;
        }

        private void LoadActiveRentals()
        {
            string sql = @"
                SELECT 
                    '#RNT-' || r.RentalID                    AS [Rental ID],
                    c.Name                                   AS [Customer],
                    v.VehicleNo                              AS [Vehicle No],
                    v.Brand || ' ' || v.Model               AS [Vehicle],
                    r.RentDate                               AS [Rent Date],
                    r.ExpectedReturnDate                     AS [Expected Return],
                    'Rs. ' || CAST(r.TotalAmount AS INT)     AS [Total],
                    CASE 
                        WHEN r.ActualReturnDate IS NOT NULL AND r.ActualReturnDate != '' THEN 'Returned'
                        WHEN r.ExpectedReturnDate < date('now') THEN 'Overdue'
                        ELSE 'Active'
                    END AS [Status]
                FROM Rentals r
                JOIN Customers c ON r.CustomerID = c.CustomerID
                JOIN Vehicles  v ON r.VehicleID  = v.VehicleID
                WHERE r.ActualReturnDate IS NULL OR r.ActualReturnDate = ''
                ORDER BY r.RentalID DESC";

            dgvRentals.DataSource = DatabaseHelper.ExecuteQuery(sql);
            StyleGrid();
        }

        private void StyleGrid()
        {
            dgvRentals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRentals.EnableHeadersVisualStyles = false;
            dgvRentals.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(48, 25, 82);
            dgvRentals.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRentals.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgvRentals.RowsDefaultCellStyle.BackColor = Color.White;
            dgvRentals.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(243, 240, 248);
            dgvRentals.DefaultCellStyle.SelectionBackColor = Color.FromArgb(102, 51, 153);
            dgvRentals.DefaultCellStyle.SelectionForeColor = Color.White;

            foreach (DataGridViewRow row in dgvRentals.Rows)
            {
                if (row.Cells["Status"] != null &&
                    row.Cells["Status"].Value?.ToString() == "Overdue")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                    row.DefaultCellStyle.ForeColor = Color.DarkRed;
                }
            }
        }

        // ── Events ───────────────────────────────────────────────
        private void cmbVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVehicle.SelectedItem is DataRowView row)
            {
                txtDailyRate.Text = row["RentPrice"].ToString();
                CalculateTotal();
            }
        }

        private void dtpRentDate_ValueChanged(object sender, EventArgs e) => CalculateTotal();
        private void dtpExpectedReturn_ValueChanged(object sender, EventArgs e) => CalculateTotal();

        private void CalculateTotal()
        {
            int days = (dtpExpectedReturn.Value.Date - dtpRentDate.Value.Date).Days;
            if (days < 1) days = 1;
            txtDays.Text = days.ToString();

            if (decimal.TryParse(txtDailyRate.Text, out decimal rate))
            {
                decimal total = days * rate;
                txtTotalAmount.Text = total.ToString("N2");
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomerForm frm = new AddCustomerForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadCustomers();
                if (frm.NewCustomerID > 0)
                    cmbCustomer.SelectedValue = frm.NewCustomerID;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedValue == null || cmbCustomer.SelectedIndex < 0)
            { MessageBox.Show("Please select a Customer.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (cmbVehicle.SelectedValue == null || cmbVehicle.SelectedIndex < 0)
            { MessageBox.Show("Please select a Vehicle.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (dtpExpectedReturn.Value.Date <= dtpRentDate.Value.Date)
            { MessageBox.Show("Expected Return Date must be after Rent Date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            int customerID = Convert.ToInt32(cmbCustomer.SelectedValue);
            int vehicleID = Convert.ToInt32(cmbVehicle.SelectedValue);
            string rentDate = dtpRentDate.Value.ToString("yyyy-MM-dd");
            string returnDate = dtpExpectedReturn.Value.ToString("yyyy-MM-dd");
            decimal baseAmount = decimal.TryParse(txtTotalAmount.Text, out var t) ? t : 0;

            string insertSQL = @"
                INSERT INTO Rentals (CustomerID, VehicleID, RentDate, ExpectedReturnDate, BaseAmount, TotalAmount)
                VALUES (@cid, @vid, @rd, @er, @ba, @ta)";

            SQLiteParameter[] p = {
                new SQLiteParameter("@cid", customerID),
                new SQLiteParameter("@vid", vehicleID),
                new SQLiteParameter("@rd",  rentDate),
                new SQLiteParameter("@er",  returnDate),
                new SQLiteParameter("@ba",  baseAmount),
                new SQLiteParameter("@ta",  baseAmount)
            };

            int result = DatabaseHelper.ExecuteNonQuery(insertSQL, p);

            if (result > 0)
            {
                DatabaseHelper.ExecuteNonQuery(
                    "UPDATE Vehicles SET Status = 'Rented' WHERE VehicleID = @vid",
                    new[] { new SQLiteParameter("@vid", vehicleID) });

                MessageBox.Show(
                    $"✅ Rental saved successfully!\n\nTotal Amount: Rs. {baseAmount:N2}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                LoadAvailableVehicles();
                LoadActiveRentals();
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();

        private void ClearForm()
        {
            cmbCustomer.SelectedIndex = -1;
            cmbVehicle.SelectedIndex = -1;
            dtpRentDate.Value = DateTime.Today;
            dtpExpectedReturn.Value = DateTime.Today.AddDays(1);
            txtDays.Text = "";
            txtDailyRate.Text = "";
            txtTotalAmount.Text = "";
            LoadAvailableVehicles();
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void grpActive_Enter(object sender, EventArgs e)
        {

        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvRentals_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
