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
    public partial class UC_DashboardOverview : UserControl
    {
        public UC_DashboardOverview()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(26, 27, 65);
            this.BackColor = Color.White;
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {
            // Custom paint logic if needed
        }

        private void UC_DashboardOverview_Load(object sender, EventArgs e)
        {

            try
            {
                
                lblTotalVehicles.Text = DatabaseHelper.GetTotalVehiclesCount().ToString();
                lblActiveRentals.Text = DatabaseHelper.GetActiveRentalsCount().ToString();
                lblPendingReturns.Text = DatabaseHelper.GetPendingReturnsCount().ToString();
                lblMaintenance.Text = DatabaseHelper.GetVehiclesInMaintenanceCount().ToString();

                // 2. Recent Transactions DataGridView load 
                DataTable dt = DatabaseHelper.GetRecentTransactions();

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("No recent transactions found.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dgvRecentTransactions.AutoGenerateColumns = false;

                dgvRecentTransactions.Columns["colRentalID"].DataPropertyName = "RentalID";
                dgvRecentTransactions.Columns["colCustomerName"].DataPropertyName = "CustomerName";
                dgvRecentTransactions.Columns["colVehicleNo"].DataPropertyName = "VehicleNo";
                dgvRecentTransactions.Columns["colExpectedReturn"].DataPropertyName = "ReturnDate";
                dgvRecentTransactions.Columns["colStatus"].DataPropertyName = "Status";

                dgvRecentTransactions.DataSource = dt;

                dgvRecentTransactions.CellFormatting += (s, ev) =>
                {
                    if (dgvRecentTransactions.Columns[ev.ColumnIndex].Name == "colStatus" && ev.Value != null)
                    {
                        if (ev.Value.ToString() == "Due Today")
                        {
                            ev.CellStyle.ForeColor = Color.Orange;
                            ev.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        }
                        else if (ev.Value.ToString() == "Active")
                        {
                            ev.CellStyle.ForeColor = Color.Green;
                        }
                    }
                };

                // 3. Styling
                Color designBlue = Color.FromArgb(26, 27, 65);
                Color headerColor = Color.FromArgb(20, 25, 55);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dgvRecentTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Grid cell click interaction logic if needed
        }

        private void pnlRentalInput_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}