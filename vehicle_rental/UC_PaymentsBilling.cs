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
            SetupCustomDashboardDesign();
        }

        private void UC_PaymentsBilling_Load(object sender, EventArgs e)
        {
            // Allow DataGridView to display new columns
            dgvPayments.AutoGenerateColumns = true;

            SetupCustomDashboardDesign();
            LoadPaymentData();
            CalculateSummaryValues();
        }

        private void SetupCustomDashboardDesign()
        {
            // Main background color (Deep Dark Purple)
            this.BackColor = Color.FromArgb(24, 18, 36);

            // Colors and styling for Cards (Flat & Clean)
            guna2Panel1.FillColor = Color.FromArgb(42, 31, 64);
            guna2Panel1.BorderRadius = 12;
            guna2Panel1.BorderThickness = 0; // Remove dotted lines

            guna2Panel2.FillColor = Color.FromArgb(42, 31, 64);
            guna2Panel2.BorderRadius = 12;
            guna2Panel2.BorderThickness = 0;

            guna2Panel3.FillColor = Color.FromArgb(42, 31, 64);
            guna2Panel3.BorderRadius = 12;
            guna2Panel3.BorderThickness = 0;

            // DataGridView Styling
            dgvPayments.BackgroundColor = Color.FromArgb(32, 24, 48);
            dgvPayments.GridColor = Color.FromArgb(45, 34, 68);
            dgvPayments.BorderStyle = BorderStyle.None;
            dgvPayments.RowTemplate.Height = 35; // Increase row spacing

            // Table Header Design
            dgvPayments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(56, 41, 84);
            dgvPayments.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(240, 240, 240);
            dgvPayments.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Table Rows Design
            dgvPayments.DefaultCellStyle.BackColor = Color.FromArgb(32, 24, 48);
            dgvPayments.DefaultCellStyle.ForeColor = Color.White;
            dgvPayments.DefaultCellStyle.SelectionBackColor = Color.FromArgb(84, 58, 133);
            dgvPayments.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void LoadPaymentData()
        {
            try
            {
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

                label4.Text = "Pending Balance";

                string queryCount = "SELECT COUNT(PaymentID) FROM Payments WHERE date(PaymentDate) = date('now')";
                DataTable dtCount = DatabaseHelper.GetData(queryCount);
                if (dtCount != null && dtCount.Rows.Count > 0 && dtCount.Rows[0][0] != DBNull.Value)
                {
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

        // Main method to bring data to the top of the Table based on the search term
        private void txtSearchRentalRef_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtPayments != null)
                {
                    string searchText = txtSearchRentalRef.Text.Trim();

                    if (string.IsNullOrEmpty(searchText))
                    {
                        // If the search box is empty, display normally without any filtering or sorting
                        dtPayments.DefaultView.RowFilter = string.Empty;
                        dtPayments.DefaultView.Sort = string.Empty;
                        dgvPayments.DataSource = dtPayments;
                    }
                    else
                    {
                        // 1. Set RowFilter to filter and bring up only the records that match the typed Rental Ref
                        dtPayments.DefaultView.RowFilter = string.Format(
                            "CONVERT([Rental Ref], 'System.String') LIKE '%{0}%'",
                            searchText
                        );

                        // 2. Arrange the relevant data to automatically come to the top of the Table once found
                        dtPayments.DefaultView.Sort = "[Rental Ref] ASC";

                        // 3. Assign the prepared View to the Grid
                        dgvPayments.DataSource = dtPayments.DefaultView;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Button to insert a new Payment
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            using (FrmNewPayment popup = new FrmNewPayment())
            {
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    if (dtPayments == null)
                    {
                        LoadPaymentData();
                    }

                    if (dtPayments != null)
                    {
                        DataRow newRow = dtPayments.NewRow();

                        // Set Payment ID to 0 without quotation marks since it must be a numeric value
                        newRow["Payment ID"] = 0;
                        newRow["Rental Ref"] = popup.CreatedRentalID;
                        newRow["Date & Time"] = popup.CreatedDate;
                        newRow["Amount (LKR)"] = popup.CreatedAmount;
                        newRow["Payment Method"] = popup.CreatedMethod;
                        newRow["Status"] = "Completed";

                        dtPayments.Rows.Add(newRow);

                        dgvPayments.DataSource = null;
                        dgvPayments.DataSource = dtPayments;

                        RecalculateSummaryFromGrid();
                    }
                }
            }
        }

        private void RecalculateSummaryFromGrid()
        {
            try
            {
                double totalRevenue = 0;
                double totalPending = 0;

                foreach (DataRow row in dtPayments.Rows)
                {
                    if (row["Status"] != DBNull.Value && row["Amount (LKR)"] != DBNull.Value)
                    {
                        string status = row["Status"].ToString();
                        double amt = Convert.ToDouble(row["Amount (LKR)"]);

                        if (status == "Completed")
                        {
                            totalRevenue += amt;
                        }
                        else if (status == "Pending" || status == "Pending Balance")
                        {
                            totalPending += amt;
                        }
                    }
                }

                lblRevenue.Text = $"LKR {totalRevenue:N0}";
                lblPending.Text = $"LKR {totalPending:N0}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Summary Update Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Empty Event (Can be deleted if necessary)
        private void txtSearchRentalRef_TextChanged_1(object sender, EventArgs e)
        {
        }
    }
}