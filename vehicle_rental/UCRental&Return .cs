using Guna.UI2.WinForms;
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

namespace vehicle_rental
{
    public partial class UCRental_Return : UserControl
    {
        decimal dailyRent = 0;
        private void UC_RentalReturn_Load(object sender, EventArgs e)
        {
            try
            {
                string query = @"SELECT R.RentalID, C.Name AS CustomerName, V.VehicleNo, R.RentDate, R.ExpectedReturnDate, R.TotalAmount,
       CASE 
           WHEN R.ActualReturnDate IS NOT NULL THEN 'Completed'
           WHEN R.ExpectedReturnDate < DATE('now') THEN 'Overdue'
           ELSE 'Active'
       END AS Status
FROM Rentals R
INNER JOIN Customers C ON R.CustomerID = C.CustomerID
INNER JOIN Vehicles V ON R.VehicleID = V.VehicleID";

                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dgv.DataSource = dt;

                LoadCustomersToComboBox();
                LoadVehiclesToComboBox();
                AddActionColumn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }

        }
        private void AddActionColumn()
        {
            // ActionColumn kiyala aluth column ekak hadanawa
            if (dgv.Columns["ActionColumn"] == null)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.HeaderText = "Actions"; // Column header text
                btn.Name = "ActionColumn";
                btn.Text = "Process"; //  // Default button text
                btn.UseColumnTextForButtonValue = true; // Display button text
                dgv.Columns.Add(btn); // Add column to DataGridView
            }
        }
        private void LoadCustomersToComboBox()
        {
            // Retrieve CustomerID and Name from database
            string query = "SELECT CustomerID, Name FROM Customers";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            // Bind data to ComboBox
            custcmb.DataSource = dt;

            // Column displayed to the user
            custcmb.DisplayMember = "Name";

            // Value stored internally
            custcmb.ValueMember = "CustomerID";
            custcmb.SelectedIndex = -1;
        }


        private void LoadVehiclesToComboBox()
        {
            // Retrieve VehicleID and Vehicle Number from database
            string query = "SELECT VehicleID, VehicleNo FROM Vehicles WHERE Status = 'Available'";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            // Bind data to ComboBox
            cmbVehicle.DataSource = dt;
            cmbVehicle.DisplayMember = "VehicleNo"; // Display vehicle number to the user
            cmbVehicle.ValueMember = "VehicleID";   // Display vehicle number to the user
            cmbVehicle.SelectedIndex = -1;
        }
        

        public UCRental_Return()
        {
            InitializeComponent();
            this.Load += UC_RentalReturn_Load;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddNewVehicle_Click(object sender, EventArgs e)
        {
            pnlRentalInput.Visible = true;
            // Bring the panel to the front if required
            pnlRentalInput.BringToFront();
        }

        private void dgvVehicles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv.Columns["ActionColumn"].Index && e.RowIndex >= 0)
            {
                string rentalId = dgv.Rows[e.RowIndex].Cells["RentalID"].Value.ToString();
                string status = dgv.Rows[e.RowIndex].Cells["Status"].Value.ToString();

                if (status == "Active" || status == "Overdue")
                {
                    // Update ActualReturnDate with today's date
                    string updateRental = "UPDATE Rentals SET ActualReturnDate = DATE('now') WHERE RentalID = @rid";

                    // Set vehicle status back to Available
                    string updateVehicle = "UPDATE Vehicles SET Status = 'Available' WHERE VehicleID = (SELECT VehicleID FROM Rentals WHERE RentalID = @rid)";

                    DatabaseHelper.ExecuteNonQuery(updateRental, new SQLiteParameter[] { new SQLiteParameter("@rid", rentalId) });
                    DatabaseHelper.ExecuteNonQuery(updateVehicle, new SQLiteParameter[] { new SQLiteParameter("@rid", rentalId) });

                    // Refresh the DataGridView                    UC_RentalReturn_Load(sender, e);
                    MessageBox.Show("Vehicle returned successfully!");
                }
            }
        }

        private void cmbVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Retrieve RentPrice for the selected vehicle
            string query = "SELECT RentPrice FROM Vehicles WHERE VehicleID = @vid";
            SQLiteParameter p = new SQLiteParameter("@vid", cmbVehicle.SelectedValue);
            DataTable dt = DatabaseHelper.ExecuteQuery(query, new SQLiteParameter[] { p });

            if (dt.Rows.Count > 0)
            {
                // Store the value in the dailyRent variable
                dailyRent = Convert.ToDecimal(dt.Rows[0]["RentPrice"]);

                CalculateTotal(); // Recalculate total amount
            }
        }

        private void CalculateTotal()
        {
            if (dailyRent == 0) return;
            // Calculate the difference between selected dates

            TimeSpan duration = dtpReturnDate.Value.Date - dtpRentDate.Value.Date;
            int days = duration.Days;

            if (days > 0)
            {
                decimal total = days * dailyRent;
                txtAmount.Text = total.ToString("0.00"); // Display total amount
            }
            else
            {
                txtAmount.Text = "0.00";
            }
        }

        private void dtpRentDate_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void dtpReturnDate_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void text_Click(object sender, EventArgs e)
        {

        }

        private void pnlRentalInput_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. take Inputs 
                int customerId = Convert.ToInt32(custcmb.SelectedValue);
                int vehicleId = Convert.ToInt32(cmbVehicle.SelectedValue);
                string rentDate = dtpRentDate.Value.ToString("yyyy-MM-dd");
                string returnDate = dtpReturnDate.Value.ToString("yyyy-MM-dd");
                decimal totalAmount = decimal.Parse(txtAmount.Text);

                // 2. SQL Query
                string query = "INSERT INTO Rentals (CustomerID, VehicleID, RentDate, ExpectedReturnDate, TotalAmount) " +
                               "VALUES (@cid, @vid, @rdate, @exdate, @amt)";

                // 3. make Parameters 
                SQLiteParameter[] p = {
            new SQLiteParameter("@cid", customerId),
            new SQLiteParameter("@vid", vehicleId),
            new SQLiteParameter("@rdate", rentDate),
            new SQLiteParameter("@exdate", returnDate),
            new SQLiteParameter("@amt", totalAmount)
        };

                // 4. Save 
                int result = DatabaseHelper.ExecuteNonQuery(query, p);

                if (result > 0)
                {
                    // Update vehicle status to 'Booked' (Required)
                    string updateStatus = "UPDATE Vehicles SET Status = 'Booked' WHERE VehicleID = @vid";
                    DatabaseHelper.ExecuteNonQuery(updateStatus, new SQLiteParameter[] { new SQLiteParameter("@vid", vehicleId) });

                    MessageBox.Show("Booking completed successfully!");

                    // 6. page Refresh 
                    UC_RentalReturn_Load(sender, e);
                    pnlRentalInput.Visible = false; //palen close
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {// 1. hide the panel
            MessageBox.Show(
                "Operation cancelled.",
                "Cancel",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            pnlRentalInput.Visible = false;

            // 2. Clear all control values
            custcmb.SelectedIndex = -1; // Customer combobox reset 
            cmbVehicle.SelectedIndex = -1; // Vehicle combobox  reset 
            dtpRentDate.Value = DateTime.Now; // Reset to current date
            dtpReturnDate.Value = DateTime.Now;
            txtAmount.Clear(); // Clear amount textbox

        }
        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                // Execute only if the Status column exists in the DataGridView                if (row.Cells["Status"].Value.ToString() == "Completed")
                {
                    DataGridViewButtonCell cell = (DataGridViewButtonCell)row.Cells["ActionColumn"];
                    cell.Value = "View Invoice"; // Change button text
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            // Search only matching vehicle numbers
            string query = "SELECT * FROM Vehicles WHERE VehicleNo LIKE '%" + searchText + "%'";

            // Update the grid
            dgv.DataSource = DatabaseHelper.GetData(query);
        }

        private void custcmb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
