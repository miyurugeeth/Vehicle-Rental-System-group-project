using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace vehicle_rental
{
    public static class DatabaseHelper
    {
        // Location of the database file (Relative Path)
        private static string dbPath = System.IO.Path.Combine(Application.StartupPath, "Database", "vehicle_rental.db");
        private static string connectionString = $"Data Source={dbPath};Version=3;";

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


        // A. මුළු වාහන ගණන (Total Vehicles)
        public static int GetTotalVehiclesCount()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM Vehicles"; // ⚠️ ටේබල් නම වෙනස් නම් මාරු කරන්න

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

        // B. දැනට කුලියට දී ඇති වාහන ගණන (Active Rentals)
        public static int GetActiveRentalsCount()
        {
            int count = 0;
            // ⚠️ උඹේ Rentals ටේබල් එකේ Active ඒවා බලන කන්ඩිෂන් එක දාන්න (උදා: Status = 'Active' හෝ 'Rented')
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

        // C. මුළු පාරිභෝගිකයින්/යූසර්ලා ගණන (Total Users)
        public static int GetTotalUsersCount()
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM Users"; // ⚠️ උඹේ Users/Customers ටේබල් එකේ නම දාන්න

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

        // D. දැනට ඉතිරිව ඇති වාහන ගණන (Available Cars)
        public static int GetAvailableCarsCount()
        {
            int totalVehicles = GetTotalVehiclesCount();
            int activeRentals = GetActiveRentalsCount();

            // මුළු වාහන ගණනෙන් දැනට කුලියට දීපුවා අඩු කරාම ඉතිරි වාහන ගණන එනවා
            return totalVehicles - activeRentals;
        }
        public static DataTable GetRecentTransactions()
        {
            DataTable dt = new DataTable();

            // Rentals, Customers, සහ Vehicles ටේබල් 3ම JOIN කරලා අපිට ඕන විස්තර විතරක් ගන්නවා.
            // ORDER BY RentalID DESC දාන්නේ අලුත්ම ට්‍රාන්සැක්ෂන් උඩටම එන්න. LIMIT 5න් අන්තිම 5 විතරක් ගන්නවා.
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

        public static bool AddCustomer(string fullName, string nic, string license, string contact, string status)
        {
            // The query now targets Name, Phone, and the brand new Status column!
            string query = "INSERT INTO Customers (Name, NIC, LicenseNo, Phone, Status) VALUES (@FullName, @NIC, @License, @Contact, @Status)";

            try
            {
                using (var connection = new System.Data.SQLite.SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    connection.Open();
                    using (var command = new System.Data.SQLite.SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", fullName);
                        command.Parameters.AddWithValue("@NIC", nic);
                        command.Parameters.AddWithValue("@License", license);
                        command.Parameters.AddWithValue("@Contact", contact);
                        command.Parameters.AddWithValue("@Status", status); // Status is back!

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static System.Data.DataTable GetAllCustomers()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            // Grab exactly the columns we know exist in the database
            string query = "SELECT CustomerID, Name, NIC, LicenseNo, Phone, Status FROM Customers";

            try
            {
                using (var connection = new System.Data.SQLite.SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    connection.Open();
                    using (var command = new System.Data.SQLite.SQLiteCommand(query, connection))
                    {
                        // A DataAdapter automatically runs the query and fills the DataTable for us
                        using (var adapter = new System.Data.SQLite.SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        public static System.Data.DataTable SearchCustomerByNIC(string searchTerm)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            // The LIKE keyword finds anything containing what you typed!
            string query = "SELECT CustomerID, Name, NIC, LicenseNo, Phone, Status FROM Customers WHERE NIC LIKE @SearchTerm";

            try
            {
                using (var connection = new System.Data.SQLite.SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    connection.Open();
                    using (var command = new System.Data.SQLite.SQLiteCommand(query, connection))
                    {
                        // The '%' on both sides means "find this number ANYWHERE in the NIC"
                        command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                        using (var adapter = new System.Data.SQLite.SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }
    }
}