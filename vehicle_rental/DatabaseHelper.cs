using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Windows.Forms;

namespace vehicle_rental
{
    public static class DatabaseHelper
    {
        // Location of the database file (Relative Path)
        private static string connectionString = @"Data Source=C:\Users\Lenovo\Downloads\Vehicle-Rental-System-group-project-main\Vehicle-Rental-System-group-project-main\vehicle_rental\Database\vehicle_rental.db;Version=3;";

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

        // 3. Common Function (Select) to read data and return DataTable
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


        // A. Total Vehicles Count from Vehicles Table
        // (Total Vehicles)
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

        // B. Active Rentals Count from Rentals Table
       
        // (Active Rentals)
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

        // C. Total Customers/Users Count
       
         
        // (Total Users)
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

        // D. Available Cars Count
        //(Available Cars)
        public static int GetAvailableCarsCount()
        {
            int totalVehicles = GetTotalVehiclesCount();
            int activeRentals = GetActiveRentalsCount();

            return totalVehicles - activeRentals;
        }

        // E. Fetch Top 5 Recent Rental Transactions for Dashboard View
        // The total number of vehicles currently rented out is subtracted from the remaining number of vehicles.


        // Get count of vehicles currently in maintenance
        public static int GetVehiclesInMaintenanceCount()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM Vehicles WHERE Status = 'Maintenance'";
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
                    MessageBox.Show("Dashboard Error (Maintenance): " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return count;
        }

        // Get count of rentals that are due to return today
        public static int GetPendingReturnsCount()
        {
            int count = 0;
            // SQLite වල GETDATE() නෑ — date('now') use කරනවා
            string query = @"SELECT COUNT(*) FROM Rentals 
                     WHERE Status = 'Active' 
                     AND date(ExpectedReturnDate) = date('now')";
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
                    MessageBox.Show("Dashboard Error (Pending Returns): " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return count;
        }



        public static DataTable GetRecentTransactions()
        {
            string query = @"
    SELECT 
        r.RentalID,
        c.Name AS CustomerName,
        v.VehicleNo,
        r.ExpectedReturnDate AS ReturnDate,
        CASE 
            WHEN (r.ActualReturnDate IS NULL OR r.ActualReturnDate = '')
                 AND date(r.ExpectedReturnDate) = date('now') THEN 'Due Today'
            WHEN (r.ActualReturnDate IS NULL OR r.ActualReturnDate = '') THEN 'Active'
            ELSE 'Returned'
        END AS Status
    FROM Rentals r
    INNER JOIN Customers c ON r.CustomerID = c.CustomerID
    INNER JOIN Vehicles v ON r.VehicleID = v.VehicleID
    WHERE r.ActualReturnDate IS NULL OR r.ActualReturnDate = ''
    ORDER BY r.RentalID DESC
    LIMIT 10";

            return ExecuteQuery(query, null);
        }

        // F. Legacy Support Method to Fetch DataTable Using Custom Row Queries
        public static DataTable GetData(string query)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn);
                da.Fill(dt);
                return dt;
            }
        }

        // G. Renamed to avoid loop conflict with the primary ExecuteQuery method
        public static void ExecuteNonQueryLocal(string query)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        // I. Fetch and Accumulate Aggregated Monthly Incomes for Column Charts
        public static DataTable GetMonthlyIncome()
        {
            string query = @"
        SELECT strftime('%m', RentDate) AS Month, SUM(TotalAmount) AS Income 
        FROM Rentals 
        GROUP BY Month 
        ORDER BY Month ASC;";

            // Explicitly routes to the main parameter-based ExecuteQuery data handler
            return ExecuteQuery(query, null);
        }

        // II. Fetch Dynamic Fleet Utilization Statistics Based on Real-Time Vehicle Status Values
        public static DataTable GetFleetUtilization()
        {
            string query = "SELECT Status, COUNT(*) as Count FROM Vehicles GROUP BY Status";
            return ExecuteQuery(query, null);
        }
    
    public static DataTable GetAllCustomers()
{
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
    ORDER BY CustomerID DESC";
            return ExecuteQuery(query, null);
        }

public static DataTable SearchCustomers(string searchText)
{
    string query = @"SELECT 
        'CUST-' || printf('%03d', CustomerID) AS DisplayID,
        CustomerID,
        Name,
        NIC,
        LicenseNo,
        Phone,
        COALESCE(Status, 'Active') AS Status
    FROM Customers 
    WHERE Name LIKE @search 
       OR NIC LIKE @search 
       OR LicenseNo LIKE @search
    ORDER BY CustomerID DESC";

    SQLiteParameter[] parameters = {
        new SQLiteParameter("@search", "%" + searchText + "%")
    };
    return ExecuteQuery(query, parameters);
}
}}