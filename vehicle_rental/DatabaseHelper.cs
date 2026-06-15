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
                }
            }
            return count;
        }

        // Get count of rentals that are due to return today
        public static int GetPendingReturnsCount()
        {
            int count = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT COUNT(*) FROM Rentals 
                        WHERE Status = 'Active' 
                        AND CAST(ReturnDate AS DATE) = CAST(GETDATE() AS DATE)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    count = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return count;
        }



        public static DataTable GetRecentTransactions()
        {
            DataTable dt = new DataTable();

         

            using (SQLiteConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    string query = null;
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
    }
}