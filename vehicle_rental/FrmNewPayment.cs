using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
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

        // 🎨 Form එක Load වෙද්දීම කලින් පසුබිම් වර්ණ සහ අකුරු කළු පාටට හැදීම
        private void FrmNewPayment_Load(object sender, EventArgs e)
        {
            // 1. Form එකේ පසුබිම අර ලස්සන කලින් ලා පර්පල් පාටටම හැදුවා
            this.BackColor = Color.FromArgb(182, 170, 255);

            // 2. Rental ID TextBox එකේ මෝස්තරය (පසුබිම සුදු සහ අකුරු කළු)
            this.txtRentalID.BackColor = Color.White;
            this.txtRentalID.ForeColor = Color.Black;
            this.txtRentalID.FocusedState.ForeColor = Color.Black;

            // 3. Amount TextBox එකේ මෝස්තරය (පසුබිම සුදු සහ අකුරු කළු)
            this.txtAmount.BackColor = Color.White;
            this.txtAmount.ForeColor = Color.Black;
            this.txtAmount.FocusedState.ForeColor = Color.Black;

            // 4. Payment Method ComboBox එකේ මෝස්තරය (පසුබිම සුදු සහ අකුරු කළු)
            this.cmbMethod.BackColor = Color.Transparent; // Guna UI එකක් නම් Transparent දාන්න ඕනේ
            this.cmbMethod.FillColor = Color.White;
            this.cmbMethod.ForeColor = Color.Black;

            // 5. Labels (අයිතම වල නම්) ලස්සනට තද පර්පල් හෝ කළු කරමු පසුබිමට මැච් වෙන්න
            // (ඔයාගේ ඩිසයිනර් එකේ තියෙන labels වල names මේවා නම් ඔටෝම හැදෙනවා)
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label)
                {
                    ctrl.ForeColor = Color.FromArgb(43, 4, 85); // තද වයලට්/කළු පාටක්
                    ctrl.BackColor = Color.Transparent;
                }
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                string rentalID = txtRentalID.Text.Trim();
                string amountInput = txtAmount.Text.Trim();
                string method = cmbMethod.Text.Trim();
                string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                if (string.IsNullOrEmpty(rentalID) || string.IsNullOrEmpty(amountInput) || string.IsNullOrEmpty(method))
                {
                    MessageBox.Show("Please fill in all the details correctly!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!double.TryParse(amountInput, out double amount))
                {
                   
                    MessageBox.Show("Please enter a valid numeric amount!", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ DB එකට insert කරනවා
                string insertQuery = "INSERT INTO Payments (RentalID, PaymentDate, Amount, PaymentMethod, PaymentStatus) VALUES (@RentalID, @Date, @Amount, @Method, 'Completed')";

                SQLiteParameter[] parameters = {
                    new SQLiteParameter("@RentalID", rentalID),
                    new SQLiteParameter("@Date", currentDate),
                    new SQLiteParameter("@Amount", amount),
                    new SQLiteParameter("@Method", method)
                };

                int result = DatabaseHelper.ExecuteNonQuery(insertQuery, parameters);

                if (result <= 0)
                {
                    MessageBox.Show("Payment could not be saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ✅ UC_PaymentsBilling එකට data pass කරනවා
                CreatedRentalID = rentalID;
                CreatedAmount = amount;
                CreatedMethod = method;
                CreatedDate = currentDate;

                MessageBox.Show("Payment Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
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