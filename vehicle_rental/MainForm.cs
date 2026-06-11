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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            uC_CustomerDirectory1.BringToFront();
            uC_CustomerDirectory1.Visible = true;

        }

        private void uC_DashboardOverview1_Load(object sender, EventArgs e)
        {

        }
    }
}
