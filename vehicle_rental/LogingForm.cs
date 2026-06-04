using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vehicle_rental
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LOGbutton_Click(object sender, EventArgs e)
        {
            // check text box is empty or not
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please Enter Username And Password.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. check user from database (SQL Query )
                string query = "SELECT * FROM Users WHERE Username = @username AND PasswordHash = @password;";

                // 3.SET THE Parameters 
                System.Data.SQLite.SQLiteParameter[] parameters = {
            new System.Data.SQLite.SQLiteParameter("@username", txtUsername.Text.Trim()),
            new System.Data.SQLite.SQLiteParameter("@password", txtPassword.Text.Trim())
        };

                // 4. run db using DatabaseHelper
                System.Data.DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                // 5. if sutable user found then open next form (Dashboard) otherwise show error message
                if (dt != null && dt.Rows.Count > 0)
                {
                    MessageBox.Show("Login Successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // -------------------------------------------------------------
                    // 6. Next, open the Dashboard Form here
                    // -------------------------------------------------------------
                    // DashboardForm dash = new DashboardForm();
                    // dash.Show();
                    // this.Hide(); // Hides the login form
                }
                else
                {
                    MessageBox.Show("The username or password entered is incorrect!", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
