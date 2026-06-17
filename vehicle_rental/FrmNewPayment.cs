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
    public partial class FrmNewPayment : Form
    {
        // Public Properties used to pass data back to the first Form (UC_PaymentsBilling)
        public string CreatedRentalID { get; private set; }
        public double CreatedAmount { get; private set; }
        public string CreatedMethod { get; private set; }
        public string CreatedDate { get; private set; }

        public FrmNewPayment()
        {
            InitializeComponent();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                string rentalID = txtRentalID.Text.Trim();
                string amountInput = txtAmount.Text.Trim();
                string method = cmbMethod.Text.Trim();
                string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                // Check if all details have been filled out
                if (string.IsNullOrEmpty(rentalID) || string.IsNullOrEmpty(amountInput) || string.IsNullOrEmpty(method))
                {
                    MessageBox.Show("Please fill in all the details correctly!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if the Amount is numeric (to prevent application crashing)
                if (!double.TryParse(amountInput, out double amount))
                {
                    MessageBox.Show("Please enter a valid numeric amount!", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // --- All SQL Validation and UPDATE parts have been removed from here ---

                // Assign the data to Properties (to be retrieved by UC_PaymentsBilling)
                CreatedRentalID = rentalID;
                CreatedAmount = amount;
                CreatedMethod = method;
                CreatedDate = currentDate;

                MessageBox.Show("Payment Added to List Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK; // Notify the first Form that the operation was successful
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtRentalID_TextChanged(object sender, EventArgs e)
        {
        }
    }
}