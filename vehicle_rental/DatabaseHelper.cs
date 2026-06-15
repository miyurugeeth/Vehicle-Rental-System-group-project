using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace vehicle_rental
{
    public static class DatabaseHelper
    {
        // Location of the database file (Relative Path)
<<<<<<< Updated upstream
        private static string connectionString = @"Data Source=|DataDirectory|\Database\vehicle_rental.db;Version=3;";
=======
        private static string connectionString = @"Data Source=C:\Users\User\Documents\1\Vehicle-Rental-System-group-project\vehicle_rental\Database\vehicle_rental.db;Version=3;";
>>>>>>> Stashed changes

        // 1. The function that connects and opens the database
        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }

        // 2. Common functions for inserting, updating, and deleting data
        public static int ExecuteNonQuery(string query, SQLiteParameter[] parameters = null)
        {
            using (SQLiteConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
        }

        // 3. Common Function (Select) to read data
        public static DataTable ExecuteQuery(string query, SQLiteParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dt;
        }



        // ==========================================
        // 🚗 VEHICLE STATUS FUNCTIONS
        // ==========================================

        // F. Get count of vehicles that are ON RENT (Status = 'Rented' or 'On Rent')
        public static int GetOnRentVehiclesCount()
        {
            int count = 0;

            // Count vehicles where status is 'Rented' or 'On Rent'
            // Adjust the status value based on what you use in your Vehicles table
            string query = "SELECT COUNT(*) FROM Vehicles WHERE Status = 'Rented' OR Status = 'On Rent'";

            // Alternative if you only have one status value:
            // string query = "SELECT COUNT(*) FROM Vehicles WHERE Status = 'Rented'";
            // string query = "SELECT COUNT(*) FROM Vehicles WHERE Status = 'On Rent'";

            using (SQLiteConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        object result = cmd.ExecuteScalar();
                        count = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dashboard Error (On Rent Vehicles): " + ex.Message,
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    count = 0;
                }
            }
            return count;
        }

        // ==========================================
        // 📅 OVERDUE RENTALS FUNCTIONS
        // ==========================================

        // G. Get count of overdue rentals (ExpectedReturnDate < Today AND not returned yet)
        public static int GetOverdueRentalsCount()
        {
            int count = 0;

            // Count rentals where:
            // 1. ExpectedReturnDate is less than today (overdue)
            // 2. ActualReturnDate is NULL or empty (not returned yet)
            string query = @"
                SELECT COUNT(*) 
                FROM Rentals 
                WHERE date(ExpectedReturnDate) < date('now') 
                AND (ActualReturnDate IS NULL OR ActualReturnDate = '')";

            // Alternative if you have a status column:
            // string query = "SELECT COUNT(*) FROM Rentals WHERE Status = 'Overdue'";

            using (SQLiteConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        object result = cmd.ExecuteScalar();
                        count = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dashboard Error (Overdue Rentals): " + ex.Message,
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    count = 0;
                }
            }
            return count;
        }

        // Optional: Get detailed overdue rentals information
        public static DataTable GetOverdueRentalsDetails()
        {
            string query = @"
                SELECT 
                    r.RentalID,
                    c.Name AS CustomerName,
                    v.VehicleNo,
                    r.ExpectedReturnDate,
                    julianday('now') - julianday(r.ExpectedReturnDate) AS DaysOverdue
                FROM Rentals r
                INNER JOIN Customers c ON r.CustomerID = c.CustomerID
                INNER JOIN Vehicles v ON r.VehicleID = v.VehicleID
                WHERE date(r.ExpectedReturnDate) < date('now') 
                AND (r.ActualReturnDate IS NULL OR r.ActualReturnDate = '')
                ORDER BY r.ExpectedReturnDate ASC";

            return ExecuteQuery(query);
        }






        // ==========================================
        // 🔥 DASHBOARD CARDS FUNCTIONS
        // ==========================================

        // A. Total Vehicles
        public static int GetTotalVehiclesCount()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM Vehicles";

            using (SQLiteConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        count = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dashboard Error (Total Vehicles): " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return count;
        }

        // B. Active Rentals
        public static int GetActiveRentalsCount()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM Rentals WHERE ActualReturnDate IS NULL OR ActualReturnDate = ''";

            using (SQLiteConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        count = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dashboard Error (Active Rentals): " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return count;
        }

        // C. Total Users
        public static int GetTotalUsersCount()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM Users";

            using (SQLiteConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        count = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dashboard Error (Total Users): " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return count;
        }

        // D. Available Cars
        public static int GetAvailableCarsCount()
        {
            int totalVehicles = GetTotalVehiclesCount();
            int activeRentals = GetActiveRentalsCount();
            return totalVehicles - activeRentals;
        }

        // Recent Transactions
        public static DataTable GetRecentTransactions()
        {
            DataTable dt = new DataTable();
            string query = @"
        SELECT 
            '#RNT-' || r.RentalID AS [Rental ID],
            c.Name AS [Customer Name],
            v.VehicleNo AS [Vehicle Reg],
            r.ExpectedReturnDate AS [Expected Return],
            CASE 
                WHEN r.ActualReturnDate IS NOT NULL AND r.ActualReturnDate != '' THEN 'Returned'
                WHEN r.ExpectedReturnDate = date('now') THEN 'Due Today'
                ELSE 'Active'
            END AS [Status]
        FROM Rentals r
        INNER JOIN Customers c ON r.CustomerID = c.CustomerID
        INNER JOIN Vehicles v ON r.VehicleID = v.VehicleID
        ORDER BY r.RentalID DESC
        LIMIT 5";

            using (SQLiteConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dashboard Error (Recent Transactions): " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dt;
        }

        // ==========================================
        // 💰 PAYMENT SPECIFIC FUNCTIONS (NEW)
        // ==========================================

        // E. Get count of unpaid payments
        public static int GetUnpaidPaymentsCount()
        {
            int count = 0;

            // Adjust this query based on your actual PaymentStatus values
            string query = "SELECT COUNT(*) FROM Payments WHERE PaymentStatus = 'Not Paid'";

            using (SQLiteConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        object result = cmd.ExecuteScalar();
                        count = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dashboard Error (Unpaid Payments): " + ex.Message,
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    count = 0;
                }
            }
            return count;
        }
    }
}