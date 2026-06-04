using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace vehicle_rental
{
    public static class DatabaseHelper
    {
        // Location of the database file (Relative Path)
        // '|DataDirectory|' When used, the path is automatically created on everyone's lap.
        private static string connectionString = @"Data Source=|DataDirectory|\Database\vehicle_rental.db;Version=3;";

        // 1. The function that connects and opens the database
        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }

        // 2. Common functions for inserting, updating, and deleting data (Insert, Update, Delete)
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

        // 3. Common Function (Select) to read data from the database and get it into a GridView or a form
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
            return dt; // Returns the data as a table
        }
    }
}