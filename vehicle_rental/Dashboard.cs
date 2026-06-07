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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
<<<<<<< Updated upstream
        }

=======

            // Load the unpaid payments count when form loads
            LoadUnpaidPaymentsCount();
        }

        private void LoadUnpaidPaymentsCount()
        {
            try
            {
                // Get unpaid payments count for label17
                int unpaidCount = DatabaseHelper.GetUnpaidPaymentsCount();
                label17.Text = unpaidCount.ToString();

                // Get on-rent vehicles count for label15
                int onRentCount = DatabaseHelper.GetOnRentVehiclesCount();
                label15.Text = onRentCount.ToString();

                // Get overdue rentals count for label16
                int overdueCount = DatabaseHelper.GetOverdueRentalsCount();
                label16.Text = overdueCount.ToString();

                // Optional: Color coding for visual feedback

                // Label15 (On Rent) - Always orange/yellow
                label15.ForeColor = Color.Red;
                label15.Font = new Font(label15.Font, FontStyle.Bold);

                // Label16 (Overdue) - Red if any overdue, Green if none
                if (overdueCount > 0)
                {
                    label16.ForeColor = Color.Red;
                    label16.Font = new Font(label16.Font, FontStyle.Bold);
                }
                else
                {
                    label16.ForeColor = Color.Green;
                }

                // Label17 (Unpaid) - Red if any unpaid, Green if none
                if (unpaidCount > 0)
                {
                    label17.ForeColor = Color.Red;
                    label17.Font = new Font(label17.Font, FontStyle.Bold);
                }
                else
                {
                    label17.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard data: " + ex.Message,
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Set default values on error
                label15.Text = "0";
                label16.Text = "0";
                label17.Text = "0";
            }
        }

        // Optional: Add a refresh method you can call from other forms
        public void RefreshUnpaidCount()
        {
            LoadUnpaidPaymentsCount();
        }

        // Your existing event handlers
>>>>>>> Stashed changes
        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
<<<<<<< Updated upstream
    }
}
=======

        private void label17_Click(object sender, EventArgs e)
        {
            // Optional: Show details when clicking on the label
            int unpaidCount = DatabaseHelper.GetUnpaidPaymentsCount();
            MessageBox.Show($"Total Unpaid Payments: {unpaidCount}\n\nThese payments have not been marked as 'Paid' in the system.",
                          "Payment Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label16_Click(object sender, EventArgs e)
        {
            int overdueCount = DatabaseHelper.GetOverdueRentalsCount();
            if (overdueCount > 0)
            {
                DialogResult result = MessageBox.Show(
                    $"Overdue Rentals: {overdueCount}\n\nWould you like to see the overdue rental details?",
                    "Overdue Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Show overdue rentals details
                    DataTable overdueTable = DatabaseHelper.GetOverdueRentalsDetails();
                    if (overdueTable.Rows.Count > 0)
                    {
                        string details = "Overdue Rentals:\n\n";
                        foreach (DataRow row in overdueTable.Rows)
                        {
                            details += $"ID: {row["RentalID"]} - {row["CustomerName"]} - {row["VehicleNo"]}\n";
                            details += $"Due Date: {row["ExpectedReturnDate"]} - Overdue: {row["DaysOverdue"]} days\n\n";
                        }
                        MessageBox.Show(details, "Overdue Rental Details",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("No overdue rentals found. All rentals are on time!",
                              "Good News", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void label15_Click(object sender, EventArgs e)
        {
            int onRentCount = DatabaseHelper.GetOnRentVehiclesCount();
            MessageBox.Show($"Vehicles Currently On Rent: {onRentCount}\n\nThese vehicles are currently rented out to customers.",
                          "Vehicle Status", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
>>>>>>> Stashed changes
