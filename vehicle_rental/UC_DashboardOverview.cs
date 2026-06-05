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
    public partial class UC_DashboardOverview : UserControl
    {
        public UC_DashboardOverview()
        {
            InitializeComponent();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {
            // Custom paint logic if needed
        }

        private void UC_DashboardOverview_Load(object sender, EventArgs e)
        {
            // 1. Load data into top dashboard stat counters
            lblTotalVehicles.Text = DatabaseHelper.GetTotalVehiclesCount().ToString();
            lblActiveRentals.Text = DatabaseHelper.GetActiveRentalsCount().ToString();
            lblTotalUsers.Text = DatabaseHelper.GetTotalUsersCount().ToString();
            lblAvailableCars.Text = DatabaseHelper.GetAvailableCarsCount().ToString();

            try
            {
                // 2. Bind database data to the Guna DataGridView
                dgvRecentTransactions.DataSource = DatabaseHelper.GetRecentTransactions();

                // 3. Configure column header visibility and sizing
                dgvRecentTransactions.ColumnHeadersVisible = true;
                dgvRecentTransactions.ColumnHeadersHeight = 35;
                dgvRecentTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                // 4. Force grid background to match your exact dark blue design color
                Color designBlue = Color.FromArgb(26, 27, 65); // Your exact design color
                dgvRecentTransactions.EnableHeadersVisualStyles = false;

                // A. Style the Column Headers & FIX THE CLICK HIGHLIGHT ISSUE
                Color headerColor = Color.FromArgb(20, 25, 55);
                dgvRecentTransactions.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
                dgvRecentTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvRecentTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                // 🔥 This removes the blue background highlight when clicking a column header
                dgvRecentTransactions.ColumnHeadersDefaultCellStyle.SelectionBackColor = headerColor;
                dgvRecentTransactions.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

                // B. Fix the black grid issue by enforcing designBlue color on runtime rows and background
                dgvRecentTransactions.BackgroundColor = designBlue;                 // Main grid area background
                dgvRecentTransactions.ThemeStyle.RowsStyle.BackColor = designBlue;  // Data rows background color
                dgvRecentTransactions.RowsDefaultCellStyle.BackColor = designBlue;  // Alternate rows fallback background
                dgvRecentTransactions.ThemeStyle.RowsStyle.ForeColor = Color.White; // Data text color

                // C. Configure the cell selection behavior and color (Electric Violet Highlight)
                dgvRecentTransactions.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(99, 88, 248);
                dgvRecentTransactions.ThemeStyle.RowsStyle.SelectionForeColor = Color.White;

                // 5. Explicitly rename column headers to clean formatting
                if (dgvRecentTransactions.Columns.Count > 0)
                {
                    dgvRecentTransactions.Columns[0].HeaderText = "Rental ID";
                    dgvRecentTransactions.Columns[1].HeaderText = "Customer Name";
                    dgvRecentTransactions.Columns[2].HeaderText = "Vehicle Number";
                    dgvRecentTransactions.Columns[3].HeaderText = "Return Date";
                    dgvRecentTransactions.Columns[4].HeaderText = "Current Status";

                    // 🔏 Disables column reordering and sorting when clicking headers
                    foreach (DataGridViewColumn col in dgvRecentTransactions.Columns)
                    {
                        col.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }

                // 6. Grid security controls and UI enhancements (Read-Only mode)
                dgvRecentTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvRecentTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selects entire row on click
                dgvRecentTransactions.ReadOnly = true;             // Prevents direct user cell editing
                dgvRecentTransactions.AllowUserToAddRows = false;    // Removes the empty trailing row input
                dgvRecentTransactions.AllowUserToDeleteRows = false; // Disables row deletion via keyboard keys
                dgvRecentTransactions.BorderStyle = BorderStyle.None;
            }
            catch (Exception ex)
            {
                // Displays error window if database mapping fails
                MessageBox.Show("Error loading data grid: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRecentTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Grid cell click interaction logic if needed
        }
    }
}