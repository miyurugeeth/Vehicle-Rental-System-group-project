using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace VehicleRentSystem
{
    public class RentalForm : Form
    {
        private Panel      pnlHeader, pnlForm, pnlGrid, pnlFooter;
        private Label      lblTitle, lblSubtitle;
        private Label      lblCustomer, lblVehicle, lblRentDate, lblReturnDate, lblDays, lblRate, lblTotal;
        private ComboBox   cmbCustomer, cmbVehicle;
        private DateTimePicker dtpRentDate, dtpReturnDate;
        private TextBox    txtDays, txtDailyRate, txtTotalAmount;
        private Button     btnSave, btnClear, btnClose;
        private DataGridView dgvRentals;
        private Label      lblGridTitle;

        public RentalForm()
        {
            InitializeUI();
            LoadCustomers();
            LoadAvailableVehicles();
            LoadActiveRentals();
        }

        private void InitializeUI()
        {
            this.Text            = "Vehicle Rental";
            this.Size            = new Size(1000, 720);
            this.StartPosition   = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.BackColor       = Color.FromArgb(245, 247, 250);
            this.Font            = new Font("Segoe UI", 9.5f);

            // Header
            pnlHeader = new Panel { Dock = DockStyle.Top, Height = 75, BackColor = Color.FromArgb(30, 58, 138) };

            lblTitle = new Label
            {
                Text      = "🚗  Vehicle Rental",
                ForeColor = Color.White,
                Font      = new Font("Segoe UI", 16f, FontStyle.Bold),
                Location  = new Point(20, 12),
                AutoSize  = true
            };

            lblSubtitle = new Label
            {
                Text      = "Register a new vehicle rental",
                ForeColor = Color.FromArgb(165, 180, 252),
                Font      = new Font("Segoe UI", 9f),
                Location  = new Point(22, 45),
                AutoSize  = true
            };

            pnlHeader.Controls.AddRange(new Control[] { lblTitle, lblSubtitle });

            // Form Panel
            pnlForm = new Panel
            {
                Location  = new Point(15, 90),
                Size      = new Size(965, 220),
                BackColor = Color.White,
                Padding   = new Padding(20)
            };
            pnlForm.Paint += (s, e) => DrawBorder(e.Graphics, pnlForm);

            // Row 1
            lblCustomer = MakeLabel("Customer *", new Point(20, 18));
            cmbCustomer = new ComboBox
            {
                Location      = new Point(20, 42),
                Size          = new Size(280, 28),
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle     = FlatStyle.Flat,
                BackColor     = Color.FromArgb(249, 250, 251)
            };

            lblVehicle = MakeLabel("Vehicle *", new Point(330, 18));
            cmbVehicle = new ComboBox
            {
                Location      = new Point(330, 42),
                Size          = new Size(320, 28),
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle     = FlatStyle.Flat,
                BackColor     = Color.FromArgb(249, 250, 251)
            };
            cmbVehicle.SelectedIndexChanged += CmbVehicle_SelectedIndexChanged;

            // Row 2
            lblRentDate = MakeLabel("Rent Date *", new Point(20, 88));
            dtpRentDate = new DateTimePicker
            {
                Location = new Point(20, 112),
                Size     = new Size(200, 28),
                Format   = DateTimePickerFormat.Short,
                Value    = DateTime.Today
            };
            dtpRentDate.ValueChanged += CalculateDays;

            lblReturnDate = MakeLabel("Expected Return Date *", new Point(240, 88));
            dtpReturnDate = new DateTimePicker
            {
                Location = new Point(240, 112),
                Size     = new Size(200, 28),
                Format   = DateTimePickerFormat.Short,
                Value    = DateTime.Today.AddDays(1)
            };
            dtpReturnDate.ValueChanged += CalculateDays;

            // Row 3
            lblDays = MakeLabel("Number of Days", new Point(20, 158));
            txtDays = MakeReadOnlyBox(new Point(20, 180), new Size(100, 28));

            lblRate = MakeLabel("Daily Rate (Rs.)", new Point(150, 158));
            txtDailyRate = MakeReadOnlyBox(new Point(150, 180), new Size(130, 28));

            lblTotal = MakeLabel("Total Amount (Rs.)", new Point(310, 158));
            txtTotalAmount = MakeReadOnlyBox(new Point(310, 180), new Size(150, 28));
            txtTotalAmount.Font      = new Font("Segoe UI", 11f, FontStyle.Bold);
            txtTotalAmount.ForeColor = Color.FromArgb(30, 58, 138);

            // Buttons
            btnSave = new Button
            {
                Text      = "✔  Save Rental",
                Location  = new Point(510, 170),
                Size      = new Size(180, 38),
                BackColor = Color.FromArgb(30, 58, 138),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font      = new Font("Segoe UI", 10f, FontStyle.Bold),
                Cursor    = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;

            btnClear = new Button
            {
                Text      = "↺  Clear",
                Location  = new Point(705, 170),
                Size      = new Size(100, 38),
                BackColor = Color.FromArgb(107, 114, 128),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor    = Cursors.Hand
            };
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Click += (s, e) => ClearForm();

            pnlForm.Controls.AddRange(new Control[] {
                lblCustomer, cmbCustomer, lblVehicle, cmbVehicle,
                lblRentDate, dtpRentDate, lblReturnDate, dtpReturnDate,
                lblDays, txtDays, lblRate, txtDailyRate, lblTotal, txtTotalAmount,
                btnSave, btnClear
            });

            // Grid Panel
            pnlGrid = new Panel
            {
                Location  = new Point(15, 325),
                Size      = new Size(965, 310),
                BackColor = Color.White
            };
            pnlGrid.Paint += (s, e) => DrawBorder(e.Graphics, pnlGrid);

            lblGridTitle = new Label
            {
                Text      = "📋  Active Rentals",
                Font      = new Font("Segoe UI", 11f, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 58, 138),
                Location  = new Point(15, 12),
                AutoSize  = true
            };

            dgvRentals = new DataGridView
            {
                Location              = new Point(10, 40),
                Size                  = new Size(945, 258),
                ReadOnly              = true,
                AllowUserToAddRows    = false,
                AllowUserToDeleteRows = false,
                BackgroundColor       = Color.White,
                BorderStyle           = BorderStyle.None,
                RowHeadersVisible     = false,
                AutoSizeColumnsMode   = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode         = DataGridViewSelectionMode.FullRowSelect,
                Font                  = new Font("Segoe UI", 9f),
                GridColor             = Color.FromArgb(229, 231, 235)
            };
            StyleGrid(dgvRentals);

            pnlGrid.Controls.AddRange(new Control[] { lblGridTitle, dgvRentals });

            // Footer
            pnlFooter = new Panel { Dock = DockStyle.Bottom, Height = 40, BackColor = Color.FromArgb(30, 58, 138) };
            btnClose = new Button
            {
                Text      = "Close  ✕",
                Size      = new Size(100, 28),
                Location  = new Point(880, 6),
                BackColor = Color.FromArgb(220, 38, 38),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor    = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => this.Close();
            pnlFooter.Controls.Add(btnClose);

            this.Controls.AddRange(new Control[] { pnlHeader, pnlForm, pnlGrid, pnlFooter });
        }

        private Label MakeLabel(string text, Point loc) =>
            new Label { Text = text, Location = loc, AutoSize = true,
                        ForeColor = Color.FromArgb(75, 85, 99), Font = new Font("Segoe UI", 9f) };

        private TextBox MakeReadOnlyBox(Point loc, Size size) =>
            new TextBox { Location = loc, Size = size, ReadOnly = true,
                          BackColor = Color.FromArgb(243, 244, 246),
                          BorderStyle = BorderStyle.FixedSingle,
                          TextAlign = HorizontalAlignment.Center };

        private void StyleGrid(DataGridView dgv)
        {
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 58, 138);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgv.ColumnHeadersHeight                     = 36;
            dgv.EnableHeadersVisualStyles               = false;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(239, 246, 255);
            dgv.DefaultCellStyle.SelectionBackColor       = Color.FromArgb(99, 140, 220);
            dgv.DefaultCellStyle.SelectionForeColor       = Color.White;
            dgv.RowTemplate.Height                        = 30;
        }

        private void DrawBorder(Graphics g, Control ctrl)
        {
            using (var pen = new System.Drawing.Pen(Color.FromArgb(229, 231, 235), 1))
                g.DrawRectangle(pen, 0, 0, ctrl.Width - 1, ctrl.Height - 1);
        }

        private void LoadCustomers()
        {
            var dt = DatabaseHelper.ExecuteQuery(
                "SELECT CustomerID, FullName || ' - ' || NIC AS Display FROM Customers ORDER BY FullName");
            cmbCustomer.DataSource    = dt;
            cmbCustomer.DisplayMember = "Display";
            cmbCustomer.ValueMember   = "CustomerID";
        }

        private void LoadAvailableVehicles()
        {
            var dt = DatabaseHelper.ExecuteQuery(
                "SELECT VehicleID, VehicleNumber || ' | ' || Brand || ' ' || Model || ' (Rs.' || DailyRate || '/day)' AS Display, DailyRate " +
                "FROM Vehicles WHERE IsAvailable = 1 ORDER BY VehicleNumber");
            cmbVehicle.DataSource    = dt;
            cmbVehicle.DisplayMember = "Display";
            cmbVehicle.ValueMember   = "VehicleID";
        }

        private void LoadActiveRentals()
        {
            string sql = @"
                SELECT R.RentalID       AS 'ID',
                       C.FullName       AS 'Customer',
                       V.VehicleNumber  AS 'Vehicle No',
                       V.Brand || ' ' || V.Model AS 'Vehicle',
                       R.RentDate       AS 'Rent Date',
                       R.ExpectedReturn AS 'Expected Return',
                       'Rs. ' || CAST(R.TotalAmount AS INT) AS 'Total (Rs.)',
                       R.Status         AS 'Status'
                FROM Rentals R
                JOIN Customers C ON R.CustomerID = C.CustomerID
                JOIN Vehicles  V ON R.VehicleID  = V.VehicleID
                WHERE R.Status = 'Active'
                ORDER BY R.RentalID DESC";
            dgvRentals.DataSource = DatabaseHelper.ExecuteQuery(sql);
        }

        private void CmbVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVehicle.SelectedItem is DataRowView row)
            {
                txtDailyRate.Text = row["DailyRate"].ToString();
                CalculateDays(null, null);
            }
        }

        private void CalculateDays(object sender, EventArgs e)
        {
            int days = (dtpReturnDate.Value.Date - dtpRentDate.Value.Date).Days;
            if (days < 1) days = 1;
            txtDays.Text = days.ToString();
            if (decimal.TryParse(txtDailyRate.Text, out decimal rate))
                txtTotalAmount.Text = (days * rate).ToString("N2");
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedValue == null || cmbVehicle.SelectedValue == null)
            {
                MessageBox.Show("Please select a Customer and a Vehicle.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtpReturnDate.Value.Date <= dtpRentDate.Value.Date)
            {
                MessageBox.Show("Return date must be after the Rent date.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int     customerId = Convert.ToInt32(cmbCustomer.SelectedValue);
            int     vehicleId  = Convert.ToInt32(cmbVehicle.SelectedValue);
            string  rentDate   = dtpRentDate.Value.ToString("yyyy-MM-dd");
            string  returnDate = dtpReturnDate.Value.ToString("yyyy-MM-dd");
            decimal total      = decimal.TryParse(txtTotalAmount.Text, out var t) ? t : 0;

            string sql = @"INSERT INTO Rentals (CustomerID, VehicleID, RentDate, ExpectedReturn, TotalAmount, Status)
                           VALUES (@cid, @vid, @rd, @er, @ta, 'Active')";

            DatabaseHelper.ExecuteNonQueryWithParams(sql, new SQLiteParameter[] {
                new SQLiteParameter("@cid", customerId),
                new SQLiteParameter("@vid", vehicleId),
                new SQLiteParameter("@rd",  rentDate),
                new SQLiteParameter("@er",  returnDate),
                new SQLiteParameter("@ta",  total)
            });

            DatabaseHelper.ExecuteNonQueryWithParams(
                "UPDATE Vehicles SET IsAvailable = 0 WHERE VehicleID = @vid",
                new[] { new SQLiteParameter("@vid", vehicleId) });

            MessageBox.Show($"✅ Rental saved successfully!\n\nTotal Amount: Rs. {total:N2}",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearForm();
            LoadAvailableVehicles();
            LoadActiveRentals();
        }

        private void ClearForm()
        {
            dtpRentDate.Value   = DateTime.Today;
            dtpReturnDate.Value = DateTime.Today.AddDays(1);
            txtDays.Text        = "";
            txtDailyRate.Text   = "";
            txtTotalAmount.Text = "";
            LoadAvailableVehicles();
        }
    }
}
