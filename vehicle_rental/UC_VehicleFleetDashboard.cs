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
    public partial class UC_VehicleFleetDashboard : UserControl
    {
        // Flag used to identify whether the form is in Edit Mode
        bool isEditMode = false;

        private string selectedVehicleNo = "";

        public UC_VehicleFleetDashboard()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Show the registration panel
            Panel_Form.Visible = true;

            // Hide the Delete button when adding a new vehicle
            btnDelete.Visible = false;

            ClearFields();
        }

        private void UC_VehicleFleetDashboard_Load(object sender, EventArgs e)
        {
            {
                if (this.DesignMode) return;

                LoadVehicleData();
            }
        }

        private void LoadVehicleData()
        {
            string query = "SELECT * FROM Vehicles";

            DataTable dt = DatabaseHelper.GetData(query);

            // Clear existing data and reload data into the grid
            dgvVehicles.DataSource = null;
            dgvVehicles.DataSource = dt;

            dgvVehicles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVehicles.EnableHeadersVisualStyles = false;

            dgvVehicles.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dgvVehicles.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvVehicles.RowsDefaultCellStyle.BackColor = Color.White;
            dgvVehicles.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;

            dgvVehicles.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dgvVehicles.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvVehicles.Refresh();
        }

        private void ClearFields()
        {
            txtRegNumber.Clear();
            txtBrand.Clear();
            txtModel.Clear();
            txtType.Clear();
            txtFuelType.SelectedIndex = -1;
            txtDailyRent.Clear();
            cmbStatus.SelectedIndex = -1;
            dtpInsuranceExpiry.Value = DateTime.Now;
        }

        // Save vehicle details to the database
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            btnDelete.Visible = false;

            // Validation
            if (string.IsNullOrWhiteSpace(txtRegNumber.Text) ||
                string.IsNullOrWhiteSpace(txtBrand.Text))
            {
                MessageBox.Show(
                    "Please enter the Registration Number and Brand!",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                string query = "";

                if (isEditMode) // Update existing vehicle
                {
                    query = $"UPDATE Vehicles SET " +
                            $"VehicleNo='{txtRegNumber.Text}', " +
                            $"Brand='{txtBrand.Text}', " +
                            $"Model='{txtModel.Text}', " +
                            $"Type='{txtType.Text}', " +
                            $"FuelType='{txtFuelType.Text}', " +
                            $"RentPrice='{txtDailyRent.Text}', " +
                            $"Status='{cmbStatus.Text}', " +
                            $"InsuranceExpiry='{dtpInsuranceExpiry.Value:yyyy-MM-dd}' " +
                            $"WHERE VehicleNo='{selectedVehicleNo}'";

                    DatabaseHelper.ExecuteQuery(query);

                    MessageBox.Show("Vehicle details updated successfully!");
                }
                else // Insert new vehicle
                {
                    query = $"INSERT INTO Vehicles (VehicleNo, Brand, Type, FuelType, Model, RentPrice, Status, InsuranceExpiry) " +
                            $"VALUES ('{txtRegNumber.Text}', '{txtBrand.Text}', '{txtType.Text}', " +
                            $"'{txtFuelType.Text}', '{txtModel.Text}', {txtDailyRent.Text}, " +
                            $"'{cmbStatus.Text}', '{dtpInsuranceExpiry.Value.ToString("yyyy-MM-dd")}')";

                    DatabaseHelper.ExecuteQuery(query);

                    MessageBox.Show("New vehicle added successfully!");
                }

                // Refresh after completing the operation
                LoadVehicleData();
                ClearFields();

                isEditMode = false; // Turn off Edit Mode
                btnDelete.Visible = false; // Hide Delete button
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            // Search only matching Vehicle Numbers
            string query = "SELECT * FROM Vehicles WHERE VehicleNo LIKE '%" + searchText + "%'";

            // Update the grid
            dgvVehicles.DataSource = DatabaseHelper.GetData(query);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                // Reload all data if the search box is empty
                LoadVehicleData();
            }
        }

        private void dgvVehicles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Execute only when a valid row is selected
            {
                Panel_Form.Visible = true;
                isEditMode = true;

                btnDelete.Visible = true;

                DataGridViewRow row = dgvVehicles.Rows[e.RowIndex];

                selectedVehicleNo = row.Cells["VehicleNo"].Value.ToString();

                // Populate controls with selected row data
                txtRegNumber.Text = row.Cells["VehicleNo"].Value.ToString();
                txtBrand.Text = row.Cells["Brand"].Value.ToString();
                txtModel.Text = row.Cells["Model"].Value.ToString();
                txtType.Text = row.Cells["Type"].Value.ToString();
                txtFuelType.Text = row.Cells["FuelType"].Value.ToString();
                txtDailyRent.Text = row.Cells["RentPrice"].Value.ToString();
                cmbStatus.Text = row.Cells["Status"].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Are you sure you want to delete this vehicle?",
                "Confirm",
                MessageBoxButtons.YesNo);

            if (confirm == DialogResult.No)
            {
                return;
            }

            // Get the currently selected row
            if (dgvVehicles.SelectedRows.Count > 0)
            {
                // First selected row
                string vehicleNo = dgvVehicles.SelectedRows[0]
                    .Cells["VehicleNo"]
                    .Value
                    .ToString();

                string query =
                    $"DELETE FROM Vehicles WHERE VehicleNo='{vehicleNo}'";

                DatabaseHelper.ExecuteQuery(query);

                MessageBox.Show("Vehicle deleted successfully!");

                LoadVehicleData();
                ClearFields();

                btnDelete.Visible = false;
            }
            else
            {
                MessageBox.Show(
                    "Please select a row that you want to delete.");
            }
        }

        private void text_Click(object sender, EventArgs e)
        {

        }

        private void Panel_Form_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtDailyRent_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpInsuranceExpiry_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtModel_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void dgvVehicles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();

            isEditMode = false;

            MessageBox.Show(
                "Operation cancelled.",
                "Cancel",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}