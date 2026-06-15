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
    public partial class UC_SystemOverview : UserControl
    {
       

        public UC_SystemOverview()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
       

        private void UC_SystemOverview_Load_1(object sender, EventArgs e)
        {
            int fleetCount = DatabaseHelper.GetTotalVehiclesCount();
            lblTotalFleet.Text = fleetCount.ToString();

            // 2. Active Rentals එක පෙන්වන්න
            int activeRentals = DatabaseHelper.GetActiveRentalsCount();
            ActiveRentals.Text = activeRentals.ToString();

        }
    }
    }


