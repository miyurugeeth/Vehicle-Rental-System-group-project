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
            this.label2.ForeColor = Color.Black;
          
            this.label2.Font = new Font("Segoe UI", 14, FontStyle.Bold | FontStyle.Underline);
          
          
         
            // Set grid location further down (Y=260) and adjust the size
            this.dgvPayments.Location = new System.Drawing.Point(25, 260);
            this.dgvPayments.Size = new System.Drawing.Size(1150, 390);

            // Stretch table columns to fill the entire width of the Grid
            this.dgvPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // Main background color of the User Control
            this.BackColor = Color.MediumPurple;

            // Card 01 - Revenue 
            this.guna2Panel1.FillColor = Color.FromArgb(163, 10, 209);
            this.guna2Panel1.BorderRadius = 12;
            this.guna2Panel1.BorderThickness = 0;

            // Card 02 - Pending Balance
            this.guna2Panel2.FillColor = Color.FromArgb(163, 10, 209);
            this.guna2Panel2.BorderRadius = 12;
            this.guna2Panel2.BorderThickness = 0;

            // Card 03 - Transaction Today
            this.guna2Panel3.FillColor = Color.FromArgb(163, 10, 209);
            this.guna2Panel3.BorderRadius = 12;
            this.guna2Panel3.BorderThickness = 0;

           
            // Set the background color of all labels inside the cards to transparent to remove black backgrounds
            foreach (Control card in new Control[] { this.guna2Panel1, this.guna2Panel2, this.guna2Panel3 })
            {
                foreach (Control ctrl in card.Controls)
                {
                    if (ctrl is Label)
                    {
                        ctrl.BackColor = Color.Transparent;
                    }
                }
            }

            // Position and style the Search TextBox on the top right
            this.txtSearchRentalRef.Location = new System.Drawing.Point(520, 15);
            this.txtSearchRentalRef.Size = new System.Drawing.Size(320, 40);
            this.txtSearchRentalRef.AutoRoundedCorners = true;
            this.txtSearchRentalRef.FillColor = Color.SlateBlue;
            this.txtSearchRentalRef.ForeColor = Color.White;
            this.txtSearchRentalRef.BorderThickness = 0;
            this.txtSearchRentalRef.PlaceholderText = "Search Rental Ref what you want see...";
            this.txtSearchRentalRef.PlaceholderForeColor = Color.FromArgb(193, 200, 207);

            // Position and style the Process New Payment Button at the far right edge
            this.guna2Button2.Location = new System.Drawing.Point(860, 15);
            this.guna2Button2.Size = new System.Drawing.Size(220, 40);
            this.guna2Button2.AutoRoundedCorners = true;
            this.guna2Button2.FillColor = Color.FromArgb(0, 120, 215); // Corporate Blue color
            this.guna2Button2.ForeColor = Color.White;
            this.guna2Button2.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.guna2Button2.Text = "+ Process New Payment";

          
            // Grid background and border styling (White background for a clean look)
            this.dgvPayments.BackgroundColor = Color.White;
            this.dgvPayments.GridColor = Color.FromArgb(224, 224, 224); // Light grey grid lines
            this.dgvPayments.BorderStyle = BorderStyle.None;
            this.dgvPayments.RowTemplate.Height = 35; // Increase row spacing

            // Table Header Design (Blue background with white bold text)
            this.dgvPayments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            this.dgvPayments.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvPayments.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.dgvPayments.EnableHeadersVisualStyles = false; // Force custom header styling

            // Table Rows Design (White background with black text)
            this.dgvPayments.DefaultCellStyle.BackColor = Color.White;
            this.dgvPayments.DefaultCellStyle.ForeColor = Color.Black;

            // Highlight color when a row is selected (Light blue background with black text)
            this.dgvPayments.DefaultCellStyle.SelectionBackColor = Color.FromArgb(215, 235, 255);
            this.dgvPayments.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Alternate row styling for Guna UI Grid (White background with black text)
            this.dgvPayments.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dgvPayments.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
        }

        private void LoadPaymentData()
        {
            try
            {
                string query = "SELECT PaymentID AS [Payment ID], RentalID AS [Rental Ref], PaymentDate AS [Date & Time], Amount AS [Amount (LKR)], PaymentMethod AS [Payment Method], PaymentStatus AS [Status] FROM Payments";

                dtPayments = DatabaseHelper.ExecuteQuery(query);

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
                DataTable dtRev = DatabaseHelper.ExecuteQuery(queryRev);
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
                DataTable dtPend = DatabaseHelper.ExecuteQuery(queryPend);
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
                DataTable dtCount = DatabaseHelper.ExecuteQuery(queryCount);
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
                    // fresh reload
                    LoadPaymentData();
                    CalculateSummaryValues();
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