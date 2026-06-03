using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace vehicle_rental
{
    public static class DatabaseHelper
    {
        // ඩේටාබේස් ෆයිල් එක තියෙන තැන (Relative Path)
        // '|DataDirectory|' පාවිච්චි කරාම හැමෝගෙම ලැප් වල පාත් එක ඔටෝම හැදෙනවා
        private static string connectionString = @"Data Source=|DataDirectory|\Database\vehicle_rental.db;Version=3;";

        // 1. ඩේටාබේස් එක කනෙක්ට් කරලා විවෘත කරන Function එක
        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }

        // 2. ඩේටා ඇතුළත් කරන්න, අප්ඩේට් කරන්න සහ මකන්න පොදු Function එක (Insert, Update, Delete)
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
                        return cmd.ExecuteNonQuery(); // බලපෑමක් වුණු පේළි ගණන රිටන් කරයි
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
        }

        // 3. ඩේටාබේස් එකෙන් ඩේටා කියවලා GridView එකකට හෝ ෆෝම් එකකට ගන්න පොදු Function එක (Select)
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
            return dt; // දත්ත ටික Table එකක් විදිහට රිටන් කරයි
        }
    }
}