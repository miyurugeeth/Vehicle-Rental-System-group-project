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

namespace vehicle_rental
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Load all dashboard counts when form loads
            LoadDashboardCounts();
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
        // This gets today's returns. Change date condition for all time.
        private int GetReturnCount()
        {
            int count = 0;
            // Returns completed today
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

        // Alternative: Get ALL TIME returns (uncomment if you want total returns ever)
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
            // Adjust based on your Payment/Payments table structure
            string query = @"SELECT COUNT(DISTINCT r.RentalID) 
                            FROM Rentals r
                            LEFT JOIN Payments p ON r.RentalID = p.RentalID
                            WHERE r.ActualReturnDate IS NULL 
                            AND (p.PaymentID IS NULL OR p.PendingAmount > 0 OR p.Status = 'Pending')";

            // Alternative simpler query if you have a Status column in Rentals
            // string query = "SELECT COUNT(*) FROM Rentals WHERE PaymentStatus = 'Pending' OR PaymentStatus = 'Unpaid'";

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
                    // If Payments table doesn't exist, use alternative
                    MessageBox.Show("Note: Pending payment feature needs Payments table. Using fallback.");
                    count = GetPendingPaymentFallback();
                }
            }
            return count;
        }

        // Fallback method if Payments table doesn't exist
        private int GetPendingPaymentFallback()
        {
            int count = 0;
            // Count active rentals as pending payment
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

        // Refresh button click handler (optional - add a refresh button to your form)
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboardCounts();
        }

        // Timer to auto-refresh every 30 seconds (optional)
        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadDashboardCounts();
        }

        private void uC_DashboardOverview1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void uC_VehicleFleetDashboard1_Load(object sender, EventArgs e)
        {

        }
    }
}