using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
// Added for programmatic Charting
using System.Windows.Forms.DataVisualization.Charting;

namespace vehicle_rental
{
    public partial class MainForm : Form
    {
<<<<<<< Updated upstream
        // Class-level chart object so we can access and refresh it anytime
        private Chart dashboardPieChart;

=======
       
>>>>>>> Stashed changes
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Initialize and configure the pie chart programmatically
            InitializeDashboardChart();

<<<<<<< Updated upstream
            // Load all dashboard counts and plot chart when form loads
            LoadDashboardCounts();
        }

        private void InitializeDashboardChart()
        {
            // 1. Create Chart Object
            dashboardPieChart = new Chart();
            dashboardPieChart.Size = new Size(350, 250);     // Set an optimal visual size
            dashboardPieChart.Location = new Point(170, 14); // Your exact requested location

            // 2. Setup Chart Area
            ChartArea chartArea = new ChartArea("MainArea");
            dashboardPieChart.ChartAreas.Add(chartArea);

            // 3. Setup Data Series
            Series series = new Series("StatusSeries");
            series.ChartType = SeriesChartType.Pie;
            dashboardPieChart.Series.Add(series);

            // 4. Set Visual Styling
            series["PieLabelStyle"] = "Outside"; // Show labels pointing outwards
            series.IsValueShownAsLabel = true;    // Show numeric values directly on slices
            dashboardPieChart.Palette = ChartColorPalette.BrightPastel;

            // 5. Add Legend
            Legend legend = new Legend("MainLegend");
            dashboardPieChart.Legends.Add(legend);

            // 6. Inject the dynamic control into the form
            this.Controls.Add(dashboardPieChart);
        }
=======
            // මුලින්ම Dashboard Overview එක පෙන්වයි
           
        }

        // Dashboard Overview එක පූරණය කරන ක්‍රමය
        
>>>>>>> Stashed changes

        private void UpdatePieChart(int onRent, int overdue, int returned, int pending)
        {
            // Clear old data points to prevent stack duplicates on dynamic updates
            dashboardPieChart.Series["StatusSeries"].Points.Clear();

            // Only add data points if there's data to avoid zero-rendering visual glitches
            if (onRent > 0) dashboardPieChart.Series["StatusSeries"].Points.AddXY("On Rent", onRent);
            if (overdue > 0) dashboardPieChart.Series["StatusSeries"].Points.AddXY("Overdue", overdue);
            if (returned > 0) dashboardPieChart.Series["StatusSeries"].Points.AddXY("Returned", returned);
            if (pending > 0) dashboardPieChart.Series["StatusSeries"].Points.AddXY("Pending", pending);

            // Force the UI elements to redraw cleanly
            dashboardPieChart.Invalidate();
        }

        private void LoadDashboardCounts()
        {
            try
            {
                // Get counts from database
                int onRentCount = GetOnRentCount();
                int overduesCount = GetOverduesCount();
                int returnCount = GetReturnCount();
                int pendingPaymentCount = GetPendingPaymentCount();

                // Update labels
                label5.Text = onRentCount.ToString();
                label6.Text = overduesCount.ToString();
                label7.Text = returnCount.ToString();
                label8.Text = pendingPaymentCount.ToString();

                // Update the programmatic Pie Chart dynamically with new DB values
                UpdatePieChart(onRentCount, overduesCount, returnCount, pendingPaymentCount);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 1. Get On Rent Cars count (Currently rented out cars)
        private int GetOnRentCount()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM Rentals WHERE ActualReturnDate IS NULL OR ActualReturnDate = ''";

            using (SQLiteConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        count = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error getting On Rent count: " + ex.Message);
                }
            }
            return count;
        }

        // 2. Get Overdues count (Rentals past return date but not returned)
        private int GetOverduesCount()
        {
            int count = 0;
            string query = @"SELECT COUNT(*) FROM Rentals 
                            WHERE (ActualReturnDate IS NULL OR ActualReturnDate = '')
                            AND DATE(ExpectedReturnDate) < DATE('now')";

            using (SQLiteConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        count = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error getting Overdues count: " + ex.Message);
                }
            }
            return count;
        }

        // 3. Get Return Count (Total number of completed returns - today or all time)
        private int GetReturnCount()
        {
            int count = 0;
            string query = @"SELECT COUNT(*) FROM Rentals 
                            WHERE ActualReturnDate IS NOT NULL 
                            AND ActualReturnDate != ''
                            AND DATE(ActualReturnDate) = DATE('now')";

            using (SQLiteConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        count = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error getting Return count: " + ex.Message);
                }
            }
            return count;
        }

        private int GetAllTimeReturnCount()
        {
            int count = 0;
            string query = @"SELECT COUNT(*) FROM Rentals 
                            WHERE ActualReturnDate IS NOT NULL 
                            AND ActualReturnDate != ''";

            using (SQLiteConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        count = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error getting Return count: " + ex.Message);
                }
            }
            return count;
        }

        // 4. Get Pending Payment count (Rentals with unpaid/partial payment)
        private int GetPendingPaymentCount()
        {
            int count = 0;
            string query = @"SELECT COUNT(DISTINCT r.RentalID) 
                            FROM Rentals r
                            LEFT JOIN Payments p ON r.RentalID = p.RentalID
                            WHERE r.ActualReturnDate IS NULL 
                            AND (p.PaymentID IS NULL OR p.PendingAmount > 0 OR p.Status = 'Pending')";

            using (SQLiteConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        count = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Note: Pending payment feature needs Payments table. Using fallback.");
                    count = GetPendingPaymentFallback();
                }
            }
            return count;
        }

        private int GetPendingPaymentFallback()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM Rentals WHERE ActualReturnDate IS NULL OR ActualReturnDate = ''";

            using (SQLiteConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        count = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in pending payment fallback: " + ex.Message);
                }
            }
            return count;
        }

        // Refresh button click handler
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboardCounts();
        }

        // Timer to auto-refresh every 30 seconds
        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadDashboardCounts();
        }

        private void uC_DashboardOverview1_Load(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void uC_VehicleFleetDashboard1_Load(object sender, EventArgs e) { }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

<<<<<<< Updated upstream
=======
      

>>>>>>> Stashed changes
        private void guna2Button5_Click(object sender, EventArgs e)
        {

<<<<<<< Updated upstream
=======
            // 2. පැනල් එකේ නම panelRight නම්, ඒකේ තියෙන පරණ ඒවා අයින් කරන්න
            // (ඔයාගේ Design එකේ පැනල් එකේ Name එක හරියටම check කරගන්න)
           

            // 4. Control එක උඩට ගන්න
            fleetDash.BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            panalRight.Controls.Clear();

            // 2. ඔයාගේ User Control එකේ Instance එකක් හදන්න
            UC_VehicleFleetDashboard fleetDashboard = new UC_VehicleFleetDashboard();

            // 3. පැනල් එකට එයාව ඇඩ් කරන්න
            fleetDashboard.Dock = DockStyle.Fill; // පැනල් එකේ හැමතැනම පිරෙන්න
            panalRight.Controls.Add(fleetDashboard);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

            panalRight.Controls.Clear();

            // 2. ඔයාගේ User Control එකේ Instance එකක් හදන්න
            Reports___System_Tools fleetDashboard = new Reports___System_Tools();

            // 3. පැනල් එකට එයාව ඇඩ් කරන්න
            fleetDashboard.Dock = DockStyle.Fill; // පැනල් එකේ හැමතැනම පිරෙන්න
            panalRight.Controls.Add(fleetDashboard);
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            panalRight.Controls.Clear();

            // 2. ඔයාගේ User Control එකේ Instance එකක් හදන්න
            UC_DashboardOverview fleetDashboard = new UC_DashboardOverview();

            // 3. පැනල් එකට එයාව ඇඩ් කරන්න
            fleetDashboard.Dock = DockStyle.Fill; // පැනල් එකේ හැමතැනම පිරෙන්න
            panalRight.Controls.Add(fleetDashboard);
           
>>>>>>> Stashed changes
        }
    }
}