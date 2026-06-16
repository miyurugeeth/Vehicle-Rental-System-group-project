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
<<<<<<< HEAD
        private static string connectionString = @"Data Source=C:\Users\Lenovo\Downloads\Vehicle-Rental-System-group-project-main\Vehicle-Rental-System-group-project-main\vehicle_rental\Database\vehicle_rental.db;Version=3;";
=======
        private static string connectionString = @"Data Source=C:\Users\user\OneDrive\Desktop\Our Project\Billing Payement\vehicle_rental\Database\vehicle_rental.db;Version=3;";
>>>>>>> origin/BillingSystem

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

<<<<<<< HEAD
        // 3. Common Function (Select) to read data and return DataTable
=======
        // 3. Common Function (Select) to read data
>>>>>>> origin/BillingSystem
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


<<<<<<< HEAD
        // A. Total Vehicles Count from Vehicles Table
=======
>>>>>>> origin/BillingSystem
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

<<<<<<< HEAD
        // B. Active Rentals Count from Rentals Table
       
=======
>>>>>>> origin/BillingSystem
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

<<<<<<< HEAD
        // C. Total Customers/Users Count
       
         
=======
>>>>>>> origin/BillingSystem
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

<<<<<<< HEAD
        // D. Available Cars Count
=======
>>>>>>> origin/BillingSystem
        //(Available Cars)
        public static int GetAvailableCarsCount()
        {
            int totalVehicles = GetTotalVehiclesCount();
            int activeRentals = GetActiveRentalsCount();

<<<<<<< HEAD
            return totalVehicles - activeRentals;
        }

        // E. Fetch Top 5 Recent Rental Transactions for Dashboard View
        // The total number of vehicles currently rented out is subtracted from the remaining number of vehicles.


=======
            // The total number of vehicles currently rented out is subtracted from the remaining number of vehicles.
            return totalVehicles - activeRentals;
        }

>>>>>>> origin/BillingSystem
        // Get count of vehicles currently in maintenance
        public static int GetVehiclesInMaintenanceCount()
        {
            int count = 0;
<<<<<<< HEAD
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
=======
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT COUNT(*) FROM Vehicles 
                        WHERE Status = 'Maintenance' 
                        OR Status = 'In Repair' 
                        OR Status = 'Under Service'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    count = Convert.ToInt32(cmd.ExecuteScalar());
>>>>>>> origin/BillingSystem
                }
            }
            return count;
        }

        // Get count of rentals that are due to return today
        public static int GetPendingReturnsCount()
        {
            int count = 0;
<<<<<<< HEAD
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
=======
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT COUNT(*) FROM Rentals 
                        WHERE Status = 'Active' 
                        AND CAST(ReturnDate AS DATE) = CAST(GETDATE() AS DATE)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    count = Convert.ToInt32(cmd.ExecuteScalar());
>>>>>>> origin/BillingSystem
                }
            }
            return count;
        }



        public static DataTable GetRecentTransactions()
        {
<<<<<<< HEAD
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
=======
            DataTable dt = new DataTable();

            // We JOIN the Rentals, Customers, and Vehicles tables to get only the details we need.
            // ORDER BY RentalID DESC is used to get the most recent transaction first. LIMIT only gets the last 5 of 5.
            string query = @"SELECT 
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
>>>>>>> origin/BillingSystem
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

<<<<<<< HEAD
        // G. Renamed to avoid loop conflict with the primary ExecuteQuery method
        public static void ExecuteNonQueryLocal(string query)
=======
        // 2. INSERT/UPDATE/DELETE query සඳහා ExecuteQuery Method එක
        public static void ExecuteQuery(string query)
>>>>>>> origin/BillingSystem
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }
<<<<<<< HEAD

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
=======
    }
}
>>>>>>> origin/BillingSystem
