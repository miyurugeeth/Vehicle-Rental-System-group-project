using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
<<<<<<< HEAD
=======
using System.Windows.Forms.DataVisualization.Charting;
>>>>>>> origin/BillingSystem

namespace vehicle_rental
{
    public partial class UC_DashboardOverview : UserControl
    {
        public UC_DashboardOverview()
        {
            InitializeComponent();
<<<<<<< HEAD
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(26, 27, 65);
            this.BackColor = Color.White;
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {
            // Custom paint logic if needed
=======
>>>>>>> origin/BillingSystem
        }

        private void UC_DashboardOverview_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD

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
=======
            // Load top dashboard counters
            lblTotalVehicles.Text = DatabaseHelper.GetTotalVehiclesCount().ToString();
            lblActiveRentals.Text = DatabaseHelper.GetActiveRentalsCount().ToString();
            lblTotalUsers.Text = DatabaseHelper.GetTotalUsersCount().ToString();
            lblAvailableCars.Text = DatabaseHelper.GetAvailableCarsCount().ToString();

            // Load the pie chart with ONLY 3 items (using existing DatabaseHelper methods)
            LoadThreeItemPieChart();

            // Load recent transactions grid
            LoadRecentTransactionsGrid();
        }

        private void LoadThreeItemPieChart()
        {
            try
            {
                // Get values using existing DatabaseHelper methods
                int activeRentals = DatabaseHelper.GetActiveRentalsCount();
                int pendingReturns = GetPendingReturnsCount(); // Using local method
                int maintenance = GetVehiclesInMaintenanceCount(); // Using local method

                // Clear existing chart data
                chart1.Series.Clear();
                chart1.Titles.Clear();

                // Create pie chart series
                Series series = new Series("Status");
                series.ChartType = SeriesChartType.Pie;
                series.IsValueShownAsLabel = true;
                series.Label = "#PERCENT{P0}";
                series.LabelForeColor = Color.White;
                series.Font = new Font("Segoe UI", 9, FontStyle.Bold);

                // Add ONLY 3 data points
                if (activeRentals > 0)
                {
                    DataPoint point = series.Points.Add(activeRentals);
                    point.LegendText = "Active Rentals";
                    point.Color = Color.FromArgb(52, 152, 219); // Blue
                }

                if (pendingReturns > 0)
                {
                    DataPoint point = series.Points.Add(pendingReturns);
                    point.LegendText = "Pending Returns";
                    point.Color = Color.FromArgb(241, 196, 15); // Yellow
                }

                if (maintenance > 0)
                {
                    DataPoint point = series.Points.Add(maintenance);
                    point.LegendText = "Maintenance";
                    point.Color = Color.FromArgb(231, 76, 60); // Red
                }

                // If all values are 0, show a message
                if (series.Points.Count == 0)
                {
                    DataPoint point = series.Points.Add(1);
                    point.LegendText = "No Data";
                    point.Color = Color.Gray;
                    point.Label = "No Data";
                }

                // Add series to chart
                chart1.Series.Add(series);

                // Customize chart appearance
                chart1.BackColor = Color.FromArgb(26, 27, 65);
                chart1.ForeColor = Color.White;

                // Add title
                Title title = new Title("Fleet Status Overview", Docking.Top, new Font("Segoe UI", 12, FontStyle.Bold), Color.White);
                chart1.Titles.Add(title);

                // Customize legend
                chart1.Legends.Clear();
                Legend legend = new Legend();
                legend.BackColor = Color.FromArgb(26, 27, 65);
                legend.ForeColor = Color.White;
                legend.Font = new Font("Segoe UI", 9);
                legend.Docking = Docking.Right;
                chart1.Legends.Add(legend);

                // Enable 3D effect for better look
                chart1.ChartAreas.Clear();
                ChartArea chartArea = new ChartArea();
                chartArea.BackColor = Color.FromArgb(26, 27, 65);
                chartArea.Area3DStyle.Enable3D = true;
                chartArea.Area3DStyle.LightStyle = LightStyle.Realistic;
                chart1.ChartAreas.Add(chartArea);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading pie chart: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Local method to get pending returns (without modifying DatabaseHelper)
        private int GetPendingReturnsCount()
        {
            int count = 0;
            string query = @"SELECT COUNT(*) FROM Rentals 
                            WHERE ActualReturnDate IS NULL 
                            AND DATE(ExpectedReturnDate) = DATE('now')";

            using (var conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (var cmd = new System.Data.SQLite.SQLiteCommand(query, conn))
                    {
                        count = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error getting pending returns: " + ex.Message);
                }
            }
            return count;
        }

        // Local method to get maintenance count (without modifying DatabaseHelper)
        private int GetVehiclesInMaintenanceCount()
        {
            int count = 0;
            string query = @"SELECT COUNT(*) FROM Vehicles 
                            WHERE Status = 'Maintenance' 
                            OR Status = 'In Repair' 
                            OR Status = 'Under Service'";

            using (var conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (var cmd = new System.Data.SQLite.SQLiteCommand(query, conn))
                    {
                        count = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error getting maintenance count: " + ex.Message);
                }
            }
            return count;
        }

        private void LoadRecentTransactionsGrid()
        {
            try
            {
                // Bind database data to the Guna DataGridView
                dgvRecentTransactions.DataSource = DatabaseHelper.GetRecentTransactions();

                // Configure column header visibility and sizing
                dgvRecentTransactions.ColumnHeadersVisible = true;
                dgvRecentTransactions.ColumnHeadersHeight = 35;
                dgvRecentTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                // Force grid background to match your exact dark blue design color
                Color designBlue = Color.FromArgb(26, 27, 65);
                dgvRecentTransactions.EnableHeadersVisualStyles = false;

                // Style the Column Headers
                Color headerColor = Color.FromArgb(20, 25, 55);
                dgvRecentTransactions.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
                dgvRecentTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvRecentTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvRecentTransactions.ColumnHeadersDefaultCellStyle.SelectionBackColor = headerColor;
                dgvRecentTransactions.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

                // Fix black grid issue
                dgvRecentTransactions.BackgroundColor = designBlue;
                dgvRecentTransactions.RowsDefaultCellStyle.BackColor = designBlue;
                dgvRecentTransactions.RowsDefaultCellStyle.ForeColor = Color.White;
                dgvRecentTransactions.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(35, 36, 75);
                dgvRecentTransactions.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;

                // Configure cell selection
                dgvRecentTransactions.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(99, 88, 248);
                dgvRecentTransactions.RowsDefaultCellStyle.SelectionForeColor = Color.White;

                // Rename column headers
                if (dgvRecentTransactions.Columns.Count > 0)
                {
                    if (dgvRecentTransactions.Columns.Count > 0) dgvRecentTransactions.Columns[0].HeaderText = "Rental ID";
                    if (dgvRecentTransactions.Columns.Count > 1) dgvRecentTransactions.Columns[1].HeaderText = "Customer Name";
                    if (dgvRecentTransactions.Columns.Count > 2) dgvRecentTransactions.Columns[2].HeaderText = "Vehicle Number";
                    if (dgvRecentTransactions.Columns.Count > 3) dgvRecentTransactions.Columns[3].HeaderText = "Return Date";
                    if (dgvRecentTransactions.Columns.Count > 4) dgvRecentTransactions.Columns[4].HeaderText = "Current Status";

                    // Disable sorting
                    foreach (DataGridViewColumn col in dgvRecentTransactions.Columns)
                    {
                        col.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }

                // Grid settings
                dgvRecentTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvRecentTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvRecentTransactions.ReadOnly = true;
                dgvRecentTransactions.AllowUserToAddRows = false;
                dgvRecentTransactions.AllowUserToDeleteRows = false;
                dgvRecentTransactions.BorderStyle = BorderStyle.None;
                dgvRecentTransactions.RowHeadersVisible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data grid: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Keep your existing empty event handlers
        private void guna2Panel2_Paint(object sender, PaintEventArgs e) { }
        private void dgvRecentTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void chart1_Click(object sender, EventArgs e) { }
        private void lblTotalVehicles_Click(object sender, EventArgs e) { }
        private void lblActiveRentals_Click(object sender, EventArgs e) { }
        private void lblTotalUsers_Click(object sender, EventArgs e) { }
        private void lblAvailableCars_Click(object sender, EventArgs e) { }
>>>>>>> origin/BillingSystem
    }
}