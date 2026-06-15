using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;

namespace vehicle_rental
{
    public partial class UC_PaymentsBilling : UserControl
    {
        private DataTable dtPayments;

        public UC_PaymentsBilling()
        {
            InitializeComponent();
        }

        private void UC_PaymentsBilling_Load(object sender, EventArgs e)
        {
            SetupCustomDashboardDesign();
            LoadPaymentData();
            CalculateSummaryValues();
        }

        private void SetupCustomDashboardDesign()
        {
            this.BackColor = Color.FromArgb(35, 25, 50);

            guna2Panel1.FillColor = Color.FromArgb(52, 40, 75);
            guna2Panel1.BorderRadius = 15;

            guna2Panel2.FillColor = Color.FromArgb(52, 40, 75);
            guna2Panel2.BorderRadius = 15;

            guna2Panel3.FillColor = Color.FromArgb(52, 40, 75);
            guna2Panel3.BorderRadius = 15;

            dgvPayments.BackgroundColor = Color.FromArgb(40, 28, 58);
            dgvPayments.GridColor = Color.FromArgb(55, 42, 78);
            dgvPayments.BorderStyle = BorderStyle.None;
            dgvPayments.EnableHeadersVisualStyles = false;

            dgvPayments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 40, 75);
            dgvPayments.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPayments.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            dgvPayments.DefaultCellStyle.BackColor = Color.FromArgb(40, 28, 58);
            dgvPayments.DefaultCellStyle.ForeColor = Color.White;
            dgvPayments.DefaultCellStyle.SelectionBackColor = Color.FromArgb(65, 48, 90);
            dgvPayments.DefaultCellStyle.SelectionForeColor = Color.White;

            guna2TextBox1.BackColor = Color.Transparent;
            guna2TextBox1.FillColor = Color.FromArgb(48, 35, 65);
            guna2TextBox1.ForeColor = Color.White;
        }

        private void LoadPaymentData()
        {
            try
            {
                // Fixed column names according to your SQLite database schema
                string query = "SELECT PaymentID AS [Payment ID], RentalID AS [Rental Ref], PaymentDate AS [Date & Time], Amount AS [Amount (LKR)], PaymentMethod AS [Payment Method], PaymentStatus AS [Status] FROM Payments";

                dtPayments = DatabaseHelper.GetData(query);

                if (dtPayments != null)
                {
                    dgvPayments.DataSource = dtPayments;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data Load Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateSummaryValues()
        {
            try
            {
                string queryRev = "SELECT SUM(Amount) FROM Payments WHERE PaymentStatus='Completed'";
                DataTable dtRev = DatabaseHelper.GetData(queryRev);
                if (dtRev != null && dtRev.Rows.Count > 0 && dtRev.Rows[0][0] != DBNull.Value)
                {
                    double rev = Convert.ToDouble(dtRev.Rows[0][0]);
                    lblRevenue.Text = $"LKR {rev:N0}";
                }
                else
                {
                    lblRevenue.Text = "LKR 0";
                }
                lblRevenue.ForeColor = Color.LimeGreen;

                string queryPend = "SELECT SUM(Amount) FROM Payments WHERE PaymentStatus='Pending' OR PaymentStatus='Pending Balance'";
                DataTable dtPend = DatabaseHelper.GetData(queryPend);
                if (dtPend != null && dtPend.Rows.Count > 0 && dtPend.Rows[0][0] != DBNull.Value)
                {
                    double pend = Convert.ToDouble(dtPend.Rows[0][0]);
                    lblPending.Text = $"LKR {pend:N0}";
                }
                else
                {
                    lblPending.Text = "LKR 0";
                }
                lblPending.ForeColor = Color.Orange;

                // FIXED: We now explicitly force label4 to keep its correct title text
                label4.Text = "Pending Balance";

                string queryCount = "SELECT COUNT(PaymentID) FROM Payments WHERE date(PaymentDate) = date('now')";
                DataTable dtCount = DatabaseHelper.GetData(queryCount);
                if (dtCount != null && dtCount.Rows.Count > 0 && dtCount.Rows[0][0] != DBNull.Value)
                {
                    // Transaction Today count should go to the 3rd card's big number label. 
                    // If your 3rd card's big number label has a different name, change 'label_TodayCount' to that name.
                    if (this.Controls.Find("label_TodayCount", true).Length > 0)
                    {
                        ((Label)this.Controls.Find("label_TodayCount", true)[0]).Text = dtCount.Rows[0][0].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Summary Calculation Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (dtPayments != null)
            {
                // Convert columns to string to allow the 'LIKE' filter to work with numbers without crashing
                dtPayments.DefaultView.RowFilter = string.Format(
                    "CONVERT([Payment ID], 'System.String') LIKE '%{0}%' OR CONVERT([Rental Ref], 'System.String') LIKE '%{0}%'",
                    guna2TextBox1.Text
                );
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string rentalID = guna2TextBox1.Text;
                string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                if (string.IsNullOrEmpty(rentalID) || rentalID == "Search Invoice or Rental ID...")
                {
                    MessageBox.Show("Please enter a valid Rental ID in the text box!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = $@"
            PRAGMA foreign_keys = OFF;
            INSERT INTO Payments (RentalID, Amount, PaymentDate, PaymentMethod, PaymentStatus) 
            VALUES ({rentalID}, 25000, '{currentDate}', 'Cash', 'Completed');
            PRAGMA foreign_keys = ON;";

                DatabaseHelper.ExecuteNonQuery(query);

                MessageBox.Show("Payment Processed Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                guna2TextBox1.Clear();

                LoadPaymentData();
                CalculateSummaryValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lblRevenue_Click(object sender, EventArgs e) { }
        private void lblPending_Click(object sender, EventArgs e) { }
        private void guna2Panel2_Paint(object sender, PaintEventArgs e) { }
        private void guna2Panel3_Paint(object sender, PaintEventArgs e) { }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void dgvPayments_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}