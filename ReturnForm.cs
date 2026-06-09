using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace VehicleRentSystem
{
    public class ReturnForm : Form
    {
        private Panel      pnlHeader, pnlSearch, pnlDetails, pnlFooter;
        private Label      lblTitle, lblSubtitle;
        private Label      lblSearchTitle, lblRentalId, lblActualReturn;
        private TextBox    txtRentalId;
        private Button     btnSearch, btnProcessReturn, btnClear, btnClose;

        private Label lblDetCustomer, lblDetVehicle, lblDetRentDate;
        private Label lblDetExpReturn, lblDetDays, lblDetDailyRate;
        private Label lblDetOrigAmount, lblDetExtraDays, lblDetExtraCharge, lblDetFinalAmount;
        private Label valCustomer, valVehicle, valRentDate;
        private Label valExpReturn, valDays, valDailyRate;
        private Label valOrigAmount, valExtraDays, valExtraCharge, valFinalAmount;

        private DateTimePicker dtpActualReturn;
        private Panel pnlSummary;

        private int     _rentalId;
        private int     _vehicleId;
        private decimal _dailyRate;
        private DateTime _rentDate;
        private DateTime _expectedReturn;
        private decimal _originalAmount;

        public ReturnForm()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text            = "Vehicle Return";
            this.Size            = new Size(900, 680);
            this.StartPosition   = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.BackColor       = Color.FromArgb(245, 247, 250);
            this.Font            = new Font("Segoe UI", 9.5f);

            // Header
            pnlHeader = new Panel { Dock = DockStyle.Top, Height = 75, BackColor = Color.FromArgb(5, 122, 85) };

            lblTitle = new Label
            {
                Text      = "🔄  Vehicle Return",
                ForeColor = Color.White,
                Font      = new Font("Segoe UI", 16f, FontStyle.Bold),
                Location  = new Point(20, 12),
                AutoSize  = true
            };
            lblSubtitle = new Label
            {
                Text      = "Process a vehicle return and calculate final charges",
                ForeColor = Color.FromArgb(167, 243, 208),
                Font      = new Font("Segoe UI", 9f),
                Location  = new Point(22, 45),
                AutoSize  = true
            };
            pnlHeader.Controls.AddRange(new Control[] { lblTitle, lblSubtitle });

            // Search Panel
            pnlSearch = new Panel
            {
                Location  = new Point(15, 90),
                Size      = new Size(860, 75),
                BackColor = Color.White
            };
            pnlSearch.Paint += (s, e) => DrawBorder(e.Graphics, pnlSearch);

            lblSearchTitle = new Label
            {
                Text      = "Enter Rental ID to search",
                Font      = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(75, 85, 99),
                Location  = new Point(20, 10),
                AutoSize  = true
            };
            lblRentalId = new Label
            {
                Text      = "Rental ID:",
                Font      = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 41, 55),
                Location  = new Point(20, 34),
                AutoSize  = true
            };
            txtRentalId = new TextBox
            {
                Location    = new Point(100, 30),
                Size        = new Size(120, 28),
                Font        = new Font("Segoe UI", 12f, FontStyle.Bold),
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign   = HorizontalAlignment.Center
            };
            txtRentalId.KeyPress += (s, e) => { if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b') e.Handled = true; };
            txtRentalId.KeyDown  += (s, e) => { if (e.KeyCode == Keys.Enter) BtnSearch_Click(null, null); };

            btnSearch = MakeBtn("🔍  Search", new Point(240, 28), new Size(130, 34), Color.FromArgb(5, 122, 85));
            btnSearch.Click += BtnSearch_Click;

            lblActualReturn = new Label
            {
                Text      = "Actual Return Date:",
                Font      = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 41, 55),
                Location  = new Point(420, 15),
                AutoSize  = true
            };
            dtpActualReturn = new DateTimePicker
            {
                Location = new Point(570, 11),
                Size     = new Size(175, 28),
                Format   = DateTimePickerFormat.Short,
                Value    = DateTime.Today
            };
            dtpActualReturn.ValueChanged += DtpActualReturn_ValueChanged;

            pnlSearch.Controls.AddRange(new Control[] {
                lblSearchTitle, lblRentalId, txtRentalId,
                btnSearch, lblActualReturn, dtpActualReturn
            });

            // Details Panel
            pnlDetails = new Panel
            {
                Location  = new Point(15, 180),
                Size      = new Size(860, 420),
                BackColor = Color.White,
                Visible   = false
            };
            pnlDetails.Paint += (s, e) => DrawBorder(e.Graphics, pnlDetails);
            BuildDetailsPanel();

            // Footer
            pnlFooter = new Panel { Dock = DockStyle.Bottom, Height = 40, BackColor = Color.FromArgb(5, 122, 85) };

            btnProcessReturn = MakeBtn("✔  Process Return", new Point(610, 6), new Size(185, 28), Color.FromArgb(30, 58, 138));
            btnProcessReturn.Click  += BtnProcessReturn_Click;
            btnProcessReturn.Visible = false;

            btnClear = MakeBtn("↺  Clear", new Point(520, 6), new Size(80, 28), Color.FromArgb(107, 114, 128));
            btnClear.Click += (s, e) => ClearAll();

            btnClose = MakeBtn("Close  ✕", new Point(810, 6), new Size(75, 28), Color.FromArgb(220, 38, 38));
            btnClose.Click += (s, e) => this.Close();

            pnlFooter.Controls.AddRange(new Control[] { btnProcessReturn, btnClear, btnClose });

            this.Controls.AddRange(new Control[] { pnlHeader, pnlSearch, pnlDetails, pnlFooter });
        }

        private void BuildDetailsPanel()
        {
            int c1 = 30, c2 = 450;

            var detailLabel = new Label
            {
                Text      = "📄  Rental Details",
                Font      = new Font("Segoe UI", 11f, FontStyle.Bold),
                ForeColor = Color.FromArgb(5, 122, 85),
                Location  = new Point(c1, 15),
                AutoSize  = true
            };

            int r = 50;
            lblDetCustomer = FL("Customer",        new Point(c1, r));
            valCustomer    = VL(new Point(c1, r + 20), 260);
            lblDetVehicle  = FL("Vehicle",          new Point(c2, r));
            valVehicle     = VL(new Point(c2, r + 20), 320);

            r = 110;
            lblDetRentDate  = FL("Rent Date",        new Point(c1, r));
            valRentDate     = VL(new Point(c1, r + 20), 140);
            lblDetExpReturn = FL("Expected Return",  new Point(c2, r));
            valExpReturn    = VL(new Point(c2, r + 20), 140);

            r = 170;
            lblDetDays     = FL("Days Rented",       new Point(c1, r));
            valDays        = VL(new Point(c1, r + 20), 100);
            lblDetDailyRate= FL("Daily Rate (Rs.)",  new Point(c2, r));
            valDailyRate   = VL(new Point(c2, r + 20), 140);

            // Summary box
            pnlSummary = new Panel
            {
                Location    = new Point(30, 220),
                Size        = new Size(800, 175),
                BackColor   = Color.FromArgb(240, 253, 244),
                BorderStyle = BorderStyle.FixedSingle
            };

            var sumTitle = new Label
            {
                Text      = "💰  Payment Summary",
                Font      = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = Color.FromArgb(5, 122, 85),
                Location  = new Point(15, 12),
                AutoSize  = true
            };

            int sy = 42;
            lblDetOrigAmount  = SL("Original Rental Amount:", new Point(15, sy));
            valOrigAmount     = SV(new Point(480, sy));

            sy = 78;
            lblDetExtraDays   = SL("Extra Days (late return):", new Point(15, sy));
            valExtraDays      = SV(new Point(480, sy));

            sy = 114;
            lblDetExtraCharge = SL("Extra Day Charges:", new Point(15, sy));
            valExtraCharge    = SV(new Point(480, sy));

            var divider = new Label { Location = new Point(15, 140), Size = new Size(765, 2), BackColor = Color.FromArgb(5, 122, 85) };

            sy = 148;
            lblDetFinalAmount = new Label
            {
                Text      = "💵  Final Amount to Collect:",
                Font      = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = Color.FromArgb(5, 122, 85),
                Location  = new Point(15, sy),
                AutoSize  = true
            };
            valFinalAmount = new Label
            {
                Location  = new Point(480, sy),
                Size      = new Size(200, 28),
                Font      = new Font("Segoe UI", 14f, FontStyle.Bold),
                ForeColor = Color.FromArgb(220, 38, 38),
                TextAlign = ContentAlignment.MiddleRight
            };

            pnlSummary.Controls.AddRange(new Control[] {
                sumTitle,
                lblDetOrigAmount, valOrigAmount,
                lblDetExtraDays,  valExtraDays,
                lblDetExtraCharge,valExtraCharge,
                divider,
                lblDetFinalAmount,valFinalAmount
            });

            pnlDetails.Controls.AddRange(new Control[] {
                detailLabel,
                lblDetCustomer, valCustomer, lblDetVehicle, valVehicle,
                lblDetRentDate, valRentDate, lblDetExpReturn, valExpReturn,
                lblDetDays,     valDays,     lblDetDailyRate, valDailyRate,
                pnlSummary
            });
        }

        // Label helpers
        private Label FL(string t, Point p) =>
            new Label { Text = t, Location = p, AutoSize = true,
                        ForeColor = Color.FromArgb(107, 114, 128), Font = new Font("Segoe UI", 8.5f) };
        private Label VL(Point p, int w) =>
            new Label { Location = p, Size = new Size(w, 22),
                        Font = new Font("Segoe UI", 10f, FontStyle.Bold), ForeColor = Color.FromArgb(17, 24, 39) };
        private Label SL(string t, Point p) =>
            new Label { Text = t, Location = p, AutoSize = true,
                        Font = new Font("Segoe UI", 10f), ForeColor = Color.FromArgb(55, 65, 81) };
        private Label SV(Point p) =>
            new Label { Location = p, Size = new Size(200, 22),
                        Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                        ForeColor = Color.FromArgb(17, 24, 39), TextAlign = ContentAlignment.MiddleRight };
        private Button MakeBtn(string t, Point p, Size s, Color bg)
        {
            var b = new Button { Text = t, Location = p, Size = s, BackColor = bg,
                                 ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand };
            b.FlatAppearance.BorderSize = 0;
            return b;
        }
        private void DrawBorder(Graphics g, Control c)
        {
            using (var pen = new System.Drawing.Pen(Color.FromArgb(209, 250, 229), 1))
                g.DrawRectangle(pen, 0, 0, c.Width - 1, c.Height - 1);
        }

        // Events
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRentalId.Text))
            {
                MessageBox.Show("Please enter a Rental ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtRentalId.Text);
            string sql = @"
                SELECT R.RentalID, C.FullName, C.NIC,
                       V.VehicleNumber, V.Brand, V.Model, V.DailyRate,
                       R.RentDate, R.ExpectedReturn, R.TotalAmount, R.Status
                FROM Rentals R
                JOIN Customers C ON R.CustomerID = C.CustomerID
                JOIN Vehicles  V ON R.VehicleID  = V.VehicleID
                WHERE R.RentalID = @id";

            var dt = DatabaseHelper.ExecuteQuery(sql, new[] { new SQLiteParameter("@id", id) });

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show($"Rental ID {id} not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pnlDetails.Visible = false;
                btnProcessReturn.Visible = false;
                return;
            }

            DataRow row = dt.Rows[0];

            if (row["Status"].ToString() != "Active")
            {
                MessageBox.Show($"This rental has already been returned. (Status: {row["Status"]})",
                    "Already Returned", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pnlDetails.Visible = false;
                btnProcessReturn.Visible = false;
                return;
            }

            _rentalId       = id;
            _vehicleId      = Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                                  "SELECT VehicleID FROM Rentals WHERE RentalID=@id",
                                  new[] { new SQLiteParameter("@id", id) }));
            _dailyRate      = Convert.ToDecimal(row["DailyRate"]);
            _rentDate       = DateTime.Parse(row["RentDate"].ToString());
            _expectedReturn = DateTime.Parse(row["ExpectedReturn"].ToString());
            _originalAmount = Convert.ToDecimal(row["TotalAmount"]);

            valCustomer.Text  = $"{row["FullName"]}  ({row["NIC"]})";
            valVehicle.Text   = $"{row["VehicleNumber"]} — {row["Brand"]} {row["Model"]}";
            valRentDate.Text  = _rentDate.ToString("yyyy-MM-dd");
            valExpReturn.Text = _expectedReturn.ToString("yyyy-MM-dd");

            int bookedDays    = (_expectedReturn.Date - _rentDate.Date).Days;
            valDays.Text      = $"{bookedDays} days";
            valDailyRate.Text = $"Rs. {_dailyRate:N2}";

            dtpActualReturn.MinDate = _rentDate;
            CalculateReturn();

            pnlDetails.Visible       = true;
            btnProcessReturn.Visible = true;
        }

        private void DtpActualReturn_ValueChanged(object sender, EventArgs e)
        {
            if (pnlDetails.Visible) CalculateReturn();
        }

        private void CalculateReturn()
        {
            DateTime actual     = dtpActualReturn.Value.Date;
            int extraDays       = Math.Max(0, (actual - _expectedReturn.Date).Days);
            decimal extraCharge = extraDays * _dailyRate;
            decimal finalTotal  = _originalAmount + extraCharge;

            valOrigAmount.Text  = $"Rs. {_originalAmount:N2}";
            valExtraDays.Text   = extraDays > 0 ? $"{extraDays} days  ⚠️" : "0 days";
            valExtraCharge.Text = extraDays > 0 ? $"Rs. {extraCharge:N2}  ⚠️" : "Rs. 0.00";
            valFinalAmount.Text = $"Rs. {finalTotal:N2}";

            valExtraDays.ForeColor   = extraDays > 0 ? Color.FromArgb(220, 38, 38) : Color.FromArgb(5, 122, 85);
            valExtraCharge.ForeColor = extraDays > 0 ? Color.FromArgb(220, 38, 38) : Color.FromArgb(5, 122, 85);
        }

        private void BtnProcessReturn_Click(object sender, EventArgs e)
        {
            DateTime actual  = dtpActualReturn.Value.Date;
            int extraDays    = Math.Max(0, (actual - _expectedReturn.Date).Days);
            decimal extra    = extraDays * _dailyRate;
            decimal finalAmt = _originalAmount + extra;

            var confirm = MessageBox.Show(
                $"Process this return?\n\nFinal Amount: Rs. {finalAmt:N2}",
                "Confirm Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            DatabaseHelper.ExecuteNonQueryWithParams(
                "UPDATE Rentals SET ActualReturn=@ar, TotalAmount=@ta, Status='Returned' WHERE RentalID=@rid",
                new SQLiteParameter[] {
                    new SQLiteParameter("@ar",  actual.ToString("yyyy-MM-dd")),
                    new SQLiteParameter("@ta",  finalAmt),
                    new SQLiteParameter("@rid", _rentalId)
                });

            DatabaseHelper.ExecuteNonQueryWithParams(
                "UPDATE Vehicles SET IsAvailable = 1 WHERE VehicleID = @vid",
                new[] { new SQLiteParameter("@vid", _vehicleId) });

            string msg = $"✅ Vehicle returned successfully!\n\nFinal Amount: Rs. {finalAmt:N2}";
            if (extraDays > 0) msg += $"\n⚠️ Late return: {extraDays} extra day(s) charged — Rs. {extra:N2}";

            MessageBox.Show(msg, "Return Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearAll();
        }

        private void ClearAll()
        {
            txtRentalId.Clear();
            dtpActualReturn.Value    = DateTime.Today;
            pnlDetails.Visible       = false;
            btnProcessReturn.Visible = false;
            _rentalId                = 0;
        }
    }
}
