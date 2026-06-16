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
// Added for programmatic Charting
using System.Windows.Forms.DataVisualization.Charting;
using static Guna.UI2.Native.WinApi;

namespace vehicle_rental
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // Form එක මුලින්ම පූරණය වන විට (Load)
        private void MainForm_Load(object sender, EventArgs e)
        {
            // 🎯 [කේතයෙන්ම පැනලය සෙට් කිරීම] 
            // Form එක Maximize වන විට guna2CustomGradientPanel1 එකත් Form එක පුරාම ලස්සනට ලොකු වෙන්න Dock එක Fill කරනවා
            guna2CustomGradientPanel1.Dock = DockStyle.Fill;

            // මුලින්ම Dashboard Overview එක පෙන්වයි
            LoadDashboardUserControl();
        }

        // Dashboard Overview එක පූරණය කරන ක්‍රමය
        private void LoadDashboardUserControl()
        {
            UC_DashboardOverview ucDashboard = new UC_DashboardOverview();
            guna2CustomGradientPanel1.Controls.Clear();
            ucDashboard.Dock = DockStyle.Fill;
            guna2CustomGradientPanel1.Controls.Add(ucDashboard);
            ucDashboard.BringToFront();
        }

        // 🎯 [ඔබ ඇසිය යුතු ප්‍රධාන කොටස] - guna2Button1 ක්ලික් කළ විට ක්‍රියාත්මක වන කොටස
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // 1. අලුත් Vehicle Fleet Dashboard එකෙහි Object එකක් මතකය තුළ සාදා ගන්නවා
            UC_VehicleFleetDashboard ucFleet = new UC_VehicleFleetDashboard();

            // 2. පැනලයේ දැනට පවතින පැරණි User Control එක (DashboardOverview) සම්පූර්ණයෙන්ම ඉවත් කරයි
            guna2CustomGradientPanel1.Controls.Clear();

            // 3. අලුත් කන්ට්‍රෝල් එක පැනලයේ ප්‍රමාණයටම හැඩගැසීමට DockStyle.Fill ලබා දෙයි
            ucFleet.Dock = DockStyle.Fill;

            // 4. අලුත් කන්ට්‍රෝල් එක පැනලය ඇතුළට එකතු කර ඉදිරියටම රැගෙන එයි
            guna2CustomGradientPanel1.Controls.Add(ucFleet);
            ucFleet.BringToFront();
        }

        // --- හිස් ඉවෙන්ට් ප්ලේස්හෝල්ඩර්ස් (Design View බිඳ වැටීම වැළැක්වීමට පමණි) ---
        private void uC_DashboardOverview1_Load(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void uC_VehicleFleetDashboard1_Load(object sender, EventArgs e) { }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clicked!");
            UC_VehicleFleetDashboard fleetDash = new UC_VehicleFleetDashboard();

            // 2. පැනල් එකේ නම panelRight නම්, ඒකේ තියෙන පරණ ඒවා අයින් කරන්න
            // (ඔයාගේ Design එකේ පැනල් එකේ Name එක හරියටම check කරගන්න)
            panelRight.Controls.Clear();

            // 3. UserControl එක පැනල් එකට Add කරන්න
            fleetDash.Dock = DockStyle.Fill; // පැනල් එක පුරාවටම Control එක පේන්න
            panelRight.Controls.Add(fleetDash);

            // 4. Control එක උඩට ගන්න
            fleetDash.BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clicked!");
            Reports___System_Tools fleetDash = new Reports___System_Tools();

            // 2. පැනල් එකේ නම panelRight නම්, ඒකේ තියෙන පරණ ඒවා අයින් කරන්න
            // (ඔයාගේ Design එකේ පැනල් එකේ Name එක හරියටම check කරගන්න)
            panelRi1ght.Controls.Clear();

            // 3. UserControl එක පැනල් එකට Add කරන්න
            fleetDash.Dock = DockStyle.Fill; // පැනල් එක පුරාවටම Control එක පේන්න
            panelRight.Controls.Add(fleetDash);

            // 4. Control එක උඩට ගන්න
            fleetDash.BringToFront();
        }
    }
}