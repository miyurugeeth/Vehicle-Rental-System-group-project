using System.Data;
using System.Data.SQLite;

namespace VehicleRentSystem
{
    public partial class ReturnForm : Form
    {
        private int _rentalId;
        private int _vehicleId;
        private decimal _dailyRate;
        private DateTime _expectedReturn;
        private decimal _baseAmount;

        public ReturnForm()
        {
            InitializeComponent();
        }

        private int ro(System.Windows.Forms.TextBox tb)
        {
            tb.ReadOnly = true;
            tb.BackColor = System.Drawing.Color.FromArgb(243, 240, 248);
            tb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tb.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            return 0;
        }

        private void ReturnForm_Load(object sender, EventArgs e)
        {
            dtpActualReturn.Value = DateTime.Today;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRentalId.Text))
            { MessageBox.Show("Please enter a Rental ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (!int.TryParse(txtRentalId.Text, out int id))
            { MessageBox.Show("Rental ID must be a number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            string sql = @"
                SELECT r.*, c.Name, c.NIC, c.Phone,
                       v.VehicleNo, v.Brand, v.Model, v.RentPrice, v.VehicleID AS VID
                FROM Rentals r
                JOIN Customers c ON r.CustomerID = c.CustomerID
                JOIN Vehicles  v ON r.VehicleID  = v.VehicleID
                WHERE r.RentalID = @id";

            DataTable dt = DatabaseHelper.ExecuteQuery(sql,
                new[] { new SQLiteParameter("@id", id) });

            if (dt.Rows.Count == 0)
            { MessageBox.Show($"Rental ID #{id} not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning); HideDetails(); return; }

            DataRow row = dt.Rows[0];

            if (!string.IsNullOrEmpty(row["ActualReturnDate"]?.ToString()))
            { MessageBox.Show($"Rental #{id} has already been returned on {row["ActualReturnDate"]}.", "Already Returned", MessageBoxButtons.OK, MessageBoxIcon.Information); HideDetails(); return; }

            _rentalId = id;
            _vehicleId = Convert.ToInt32(row["VID"]);
            _dailyRate = Convert.ToDecimal(row["RentPrice"]);
            _expectedReturn = DateTime.Parse(row["ExpectedReturnDate"].ToString());
            _baseAmount = Convert.ToDecimal(row["BaseAmount"]);

            txtCustomer.Text = $"{row["Name"]}  (NIC: {row["NIC"]})";
            txtPhone.Text = row["Phone"].ToString();
            txtVehicle.Text = $"{row["VehicleNo"]} — {row["Brand"]} {row["Model"]}";
            txtRentDate.Text = row["RentDate"].ToString();
            txtExpReturn.Text = _expectedReturn.ToString("yyyy-MM-dd");
            txtDailyRate.Text = $"Rs. {_dailyRate:N2}";

            int bookedDays = (_expectedReturn.Date - DateTime.Parse(row["RentDate"].ToString()).Date).Days;
            txtBookedDays.Text = $"{bookedDays} days";

            dtpActualReturn.MinDate = DateTime.Parse(row["RentDate"].ToString());
            CalculateReturn();
            ShowDetails();
        }

        private void dtpActualReturn_ValueChanged(object sender, EventArgs e)
        {
            if (grpDetails.Visible) CalculateReturn();
        }

        private void CalculateReturn()
        {
            DateTime actual = dtpActualReturn.Value.Date;
            int extraDays = Math.Max(0, (actual - _expectedReturn.Date).Days);
            decimal lateFee = extraDays * _dailyRate;
            decimal total = _baseAmount + lateFee;

            txtBaseAmount.Text = $"Rs. {_baseAmount:N2}";
            txtExtraDays.Text = extraDays > 0 ? $"{extraDays} days  ⚠️" : "0 days";
            txtLateFee.Text = extraDays > 0 ? $"Rs. {lateFee:N2}  ⚠️" : "Rs. 0.00";
            txtTotalAmount.Text = $"Rs. {total:N2}";

            Color okColor = Color.FromArgb(5, 130, 80);
            Color lateColor = Color.FromArgb(180, 0, 0);
            txtExtraDays.ForeColor = extraDays > 0 ? lateColor : okColor;
            txtLateFee.ForeColor = extraDays > 0 ? lateColor : okColor;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            int extraDays = Math.Max(0, (dtpActualReturn.Value.Date - _expectedReturn.Date).Days);
            decimal lateFee = extraDays * _dailyRate;
            decimal total = _baseAmount + lateFee;

            string msg = $"Process return for Rental #{_rentalId}?\n\nTotal to collect: Rs. {total:N2}";
            if (extraDays > 0) msg += $"\n⚠️ Late by {extraDays} day(s) — Late fee: Rs. {lateFee:N2}";

            if (MessageBox.Show(msg, "Confirm Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            DatabaseHelper.ExecuteNonQuery(
                @"UPDATE Rentals SET ActualReturnDate=@ar, LateFee=@lf, TotalAmount=@ta, Status='Returned' WHERE RentalID=@rid",
                new SQLiteParameter[] {
                    new SQLiteParameter("@ar",  dtpActualReturn.Value.ToString("yyyy-MM-dd")),
                    new SQLiteParameter("@lf",  lateFee),
                    new SQLiteParameter("@ta",  total),
                    new SQLiteParameter("@rid", _rentalId)
                });

            DatabaseHelper.ExecuteNonQuery(
                "UPDATE Vehicles SET Status = 'Available' WHERE VehicleID = @vid",
                new[] { new SQLiteParameter("@vid", _vehicleId) });

            string successMsg = $"✅ Vehicle returned successfully!\n\nRental ID:       #{_rentalId}\nTotal Collected: Rs. {total:N2}";
            if (extraDays > 0) successMsg += $"\nLate Fee:        Rs. {lateFee:N2}";

            MessageBox.Show(successMsg, "Return Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearAll();
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearAll();
        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void ShowDetails()
        {
            grpDetails.Visible = true;
            grpSummary.Visible = true;
            btnProcess.Visible = true;
        }

        private void HideDetails()
        {
            grpDetails.Visible = false;
            grpSummary.Visible = false;
            btnProcess.Visible = false;
        }

        private void ClearAll()
        {
            txtRentalId.Clear();
            dtpActualReturn.Value = DateTime.Today;
            HideDetails();
            _rentalId = 0;
        }

        private void grpSummary_Enter(object sender, EventArgs e)
        {

        }
    }
}