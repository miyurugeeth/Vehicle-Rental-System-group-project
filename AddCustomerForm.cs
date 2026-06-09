using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace VehicleRentSystem
{
    public class AddCustomerForm : Form
    {
        private Panel  pnlHeader, pnlBody, pnlFooter;
        private Label  lblTitle;
        private Label  lblName, lblNic, lblPhone, lblAddress;
        private TextBox txtName, txtNic, txtPhone, txtAddress;
        private Button btnSave, btnCancel;

        public int NewCustomerID { get; private set; } = -1;

        public AddCustomerForm()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text            = "Add New Customer";
            this.Size            = new Size(440, 400);
            this.StartPosition   = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.BackColor       = Color.FromArgb(245, 247, 250);
            this.Font            = new Font("Segoe UI", 9.5f);

            // Header
            pnlHeader = new Panel
            {
                Dock      = DockStyle.Top,
                Height    = 55,
                BackColor = Color.FromArgb(30, 58, 138)
            };
            lblTitle = new Label
            {
                Text      = "👤  Add New Customer",
                ForeColor = Color.White,
                Font      = new Font("Segoe UI", 13f, FontStyle.Bold),
                Location  = new Point(15, 14),
                AutoSize  = true
            };
            pnlHeader.Controls.Add(lblTitle);

            // Body
            pnlBody = new Panel
            {
                Location  = new Point(15, 68),
                Size      = new Size(400, 255),
                BackColor = Color.White,
                Padding   = new Padding(15)
            };

            // Full Name
            lblName = MakeLabel("Full Name *", new Point(20, 18));
            txtName = new TextBox
            {
                Location    = new Point(20, 40),
                Size        = new Size(360, 28),
                BorderStyle = BorderStyle.FixedSingle,
                Font        = new Font("Segoe UI", 10f)
            };

            // NIC
            lblNic = MakeLabel("NIC Number *", new Point(20, 80));
            txtNic = new TextBox
            {
                Location    = new Point(20, 102),
                Size        = new Size(160, 28),
                BorderStyle = BorderStyle.FixedSingle,
                Font        = new Font("Segoe UI", 10f),
                MaxLength   = 12
            };

            // Phone
            lblPhone = MakeLabel("Phone Number *", new Point(210, 80));
            txtPhone = new TextBox
            {
                Location    = new Point(210, 102),
                Size        = new Size(170, 28),
                BorderStyle = BorderStyle.FixedSingle,
                Font        = new Font("Segoe UI", 10f),
                MaxLength   = 10
            };

            // Address
            lblAddress = MakeLabel("Address", new Point(20, 142));
            txtAddress = new TextBox
            {
                Location    = new Point(20, 164),
                Size        = new Size(360, 28),
                BorderStyle = BorderStyle.FixedSingle,
                Font        = new Font("Segoe UI", 10f)
            };

            pnlBody.Controls.AddRange(new Control[] {
                lblName, txtName,
                lblNic,  txtNic,
                lblPhone,txtPhone,
                lblAddress, txtAddress
            });

            // Footer
            pnlFooter = new Panel
            {
                Location  = new Point(15, 335),
                Size      = new Size(400, 45),
                BackColor = Color.FromArgb(245, 247, 250)
            };

            btnSave = new Button
            {
                Text      = "✔  Save Customer",
                Location  = new Point(155, 6),
                Size      = new Size(155, 34),
                BackColor = Color.FromArgb(30, 58, 138),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font      = new Font("Segoe UI", 10f, FontStyle.Bold),
                Cursor    = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button
            {
                Text      = "Cancel",
                Location  = new Point(320, 6),
                Size      = new Size(80, 34),
                BackColor = Color.FromArgb(107, 114, 128),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor    = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            pnlFooter.Controls.AddRange(new Control[] { btnSave, btnCancel });

            this.Controls.AddRange(new Control[] { pnlHeader, pnlBody, pnlFooter });

            // Enter key moves to next field
            txtName.KeyDown    += MoveOnEnter;
            txtNic.KeyDown     += MoveOnEnter;
            txtPhone.KeyDown   += MoveOnEnter;
            txtAddress.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) BtnSave_Click(null, null); };
        }

        private void MoveOnEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private Label MakeLabel(string text, Point loc) =>
            new Label
            {
                Text      = text,
                Location  = loc,
                AutoSize  = true,
                ForeColor = Color.FromArgb(75, 85, 99),
                Font      = new Font("Segoe UI", 9f)
            };

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                ShowError("Please enter the customer's full name."); txtName.Focus(); return;
            }
            if (string.IsNullOrWhiteSpace(txtNic.Text) || txtNic.Text.Length < 9)
            {
                ShowError("Please enter a valid NIC number."); txtNic.Focus(); return;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text) || txtPhone.Text.Length < 9)
            {
                ShowError("Please enter a valid phone number."); txtPhone.Focus(); return;
            }

            // Check duplicate NIC
            var existing = DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM Customers WHERE NIC = @nic",
                new[] { new SQLiteParameter("@nic", txtNic.Text.Trim()) });

            if (Convert.ToInt32(existing) > 0)
            {
                ShowError("A customer with this NIC already exists."); txtNic.Focus(); return;
            }

            // Insert
            DatabaseHelper.ExecuteNonQueryWithParams(
                "INSERT INTO Customers (FullName, NIC, Phone, Address) VALUES (@n, @nic, @ph, @ad)",
                new SQLiteParameter[] {
                    new SQLiteParameter("@n",   txtName.Text.Trim()),
                    new SQLiteParameter("@nic", txtNic.Text.Trim()),
                    new SQLiteParameter("@ph",  txtPhone.Text.Trim()),
                    new SQLiteParameter("@ad",  txtAddress.Text.Trim())
                });

            // Get new ID
            NewCustomerID = Convert.ToInt32(
                DatabaseHelper.ExecuteScalar("SELECT last_insert_rowid()"));

            MessageBox.Show(
                $"✅ Customer added successfully!\n\n{txtName.Text.Trim()}",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ShowError(string msg) =>
            MessageBox.Show(msg, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
