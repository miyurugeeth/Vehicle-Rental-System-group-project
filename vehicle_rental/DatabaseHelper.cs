using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace vehicle_rental
{
    public static class DatabaseHelper
    {
        // Location of the database file (Relative Path)
        private static string connectionString = @"Data Source=D:\Vehicle-Rental-System-group-project\vehicle_rental\Database\vehicle_rental.db;Version=3;";

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

        //(Available Cars)
        public static int GetAvailableCarsCount()
        {
            int totalVehicles = GetTotalVehiclesCount();
            int activeRentals = GetActiveRentalsCount();

            // The total number of vehicles currently rented out is subtracted from the remaining number of vehicles.
            return totalVehicles - activeRentals;
        }
        public static DataTable GetRecentTransactions()
        {
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

        // 2. INSERT/UPDATE/DELETE query සඳහා ExecuteQuery Method එක
        public static void ExecuteQuery(string query)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}