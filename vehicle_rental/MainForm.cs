using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using static Guna.UI2.Native.WinApi;

namespace vehicle_rental
{
    public partial class MainForm : Form
    {
        private UC_VehicleFleetDashboard fleetDash = new UC_VehicleFleetDashboard();
        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadDashboardUserControl();

            guna2CustomGradientPanel1.Dock = DockStyle.Fill;



        }

        private void LoadDashboardUserControl()
        {
            UC_DashboardOverview dashboard = new UC_DashboardOverview();

            panelRight.Controls.Clear();

            dashboard.Dock = DockStyle.Fill;

            panelRight.Controls.Add(dashboard);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UC_VehicleFleetDashboard ucFleet = new UC_VehicleFleetDashboard();

            guna2CustomGradientPanel1.Controls.Clear();

            ucFleet.Dock = DockStyle.Fill;


            guna2CustomGradientPanel1.Controls.Add(ucFleet);
            ucFleet.BringToFront();
        }


        private void uC_DashboardOverview1_Load(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void uC_VehicleFleetDashboard1_Load(object sender, EventArgs e) { }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void guna2Button5_Click(object sender, EventArgs e)
        {
            

            UC_VehicleFleetDashboard fleetDash = new UC_VehicleFleetDashboard();

            // Clear any existing controls from the panel
            // (Make sure the panel name matches the one used in your Designer)
            panelRight.Controls.Clear();

            // Add the UserControl to the panel
            fleetDash.Dock = DockStyle.Fill; // Display the UserControl across the entire panel
            panelRight.Controls.Add(fleetDash);

            // Bring the UserControl to the front
            fleetDash.BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
           
            Reports___System_Tools fleetDash = new Reports___System_Tools();


            panelRight.Controls.Clear();


            fleetDash.Dock = DockStyle.Fill;
            panelRight.Controls.Add(fleetDash);


            fleetDash.BringToFront();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {

          
            UC_Customer fleetDash = new UC_Customer();


            panelRight.Controls.Clear();


            fleetDash.Dock = DockStyle.Fill;
            panelRight.Controls.Add(fleetDash);


            fleetDash.BringToFront();

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
           
            panelRight.Controls.Clear();

            UCRental_Return uc = new UCRental_Return();


            uc.Dock = DockStyle.Fill;


            panelRight.Controls.Add(uc);

        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
        
            panelRight.Controls.Clear();


            UC_DashboardOverview ucd = new UC_DashboardOverview();


            ucd.Dock = DockStyle.Fill;


            panelRight.Controls.Add(ucd);

        }

        private void panelRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
        "Do you want to log out?", "Confirm Log Out",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                // Login form  open
                LoginForm loginForm = new LoginForm();
                loginForm.Show();

                // Current  close 
                this.Close();
            }
        }
    }
}