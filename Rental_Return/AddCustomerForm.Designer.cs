namespace VehicleRentSystem
{
    partial class AddCustomerForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader  = new Panel();
            lblTitle   = new Label();
            lblSub     = new Label();
            grpInfo    = new GroupBox();
            lblName    = new Label();
            txtName    = new TextBox();
            lblNIC     = new Label();
            txtNIC     = new TextBox();
            lblPhone   = new Label();
            txtPhone   = new TextBox();
            btnSave    = new Button();
            btnCancel  = new Button();

            pnlHeader.SuspendLayout();
            grpInfo.SuspendLayout();
            SuspendLayout();

            // ── pnlHeader ─────────────────────────────────────────
            pnlHeader.BackColor = Color.FromArgb(48, 25, 82);
            pnlHeader.Controls.Add(lblSub);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(480, 78);

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Papyrus", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 8);
            lblTitle.Text = "swiftRent  —  New Customer";

            lblSub.AutoSize = true;
            lblSub.Font = new Font("Calibri", 9.5F);
            lblSub.ForeColor = Color.FromArgb(200, 180, 230);
            lblSub.Location = new Point(18, 50);
            lblSub.Text = "Add a new customer to the system";

            // ── grpInfo ───────────────────────────────────────────
            grpInfo.Controls.Add(lblName);
            grpInfo.Controls.Add(txtName);
            grpInfo.Controls.Add(lblNIC);
            grpInfo.Controls.Add(txtNIC);
            grpInfo.Controls.Add(lblPhone);
            grpInfo.Controls.Add(txtPhone);
            grpInfo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpInfo.ForeColor = Color.FromArgb(48, 25, 82);
            grpInfo.Location = new Point(12, 90);
            grpInfo.Name = "grpInfo";
            grpInfo.Padding = new Padding(3, 4, 3, 4);
            grpInfo.Size = new Size(456, 220);
            grpInfo.TabStop = false;
            grpInfo.Text = "  Customer Information";

            // Name
            lblName.AutoSize = true;
            lblName.Font = new Font("Calibri", 10F);
            lblName.ForeColor = Color.FromArgb(55, 65, 81);
            lblName.Location = new Point(15, 32);
            lblName.Text = "Full Name *";

            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(15, 56);
            txtName.Name = "txtName";
            txtName.Size = new Size(420, 32);
            txtName.TabIndex = 0;
            txtName.PlaceholderText = "e.g. Kamal Perera";

            // NIC
            lblNIC.AutoSize = true;
            lblNIC.Font = new Font("Calibri", 10F);
            lblNIC.ForeColor = Color.FromArgb(55, 65, 81);
            lblNIC.Location = new Point(15, 102);
            lblNIC.Text = "NIC Number *";

            txtNIC.BorderStyle = BorderStyle.FixedSingle;
            txtNIC.Font = new Font("Segoe UI", 10F);
            txtNIC.Location = new Point(15, 126);
            txtNIC.Name = "txtNIC";
            txtNIC.Size = new Size(200, 32);
            txtNIC.TabIndex = 1;
            txtNIC.PlaceholderText = "e.g. 901234567V";

            // Phone
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Calibri", 10F);
            lblPhone.ForeColor = Color.FromArgb(55, 65, 81);
            lblPhone.Location = new Point(240, 102);
            lblPhone.Text = "Phone";

            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(240, 126);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(195, 32);
            txtPhone.TabIndex = 2;
            txtPhone.PlaceholderText = "e.g. 0771234567";

            // ── Buttons ───────────────────────────────────────────
            btnSave.BackColor = Color.FromArgb(102, 51, 153);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(12, 328);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(200, 44);
            btnSave.TabIndex = 3;
            btnSave.Text = "✔  Save Customer";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;

            btnCancel.BackColor = Color.FromArgb(180, 0, 0);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9.5F);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(360, 328);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(108, 44);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel  ✕";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;

            // ── Form ──────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 242, 250);
            ClientSize = new Size(480, 390);
            Controls.Add(pnlHeader);
            Controls.Add(grpInfo);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AddCustomerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "swiftRent — Add Customer";

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            ResumeLayout(false);
        }

        private Panel    pnlHeader;
        private Label    lblTitle, lblSub;
        private GroupBox grpInfo;
        private Label    lblName, lblNIC, lblPhone;
        private TextBox  txtName, txtNIC, txtPhone;
        private Button   btnSave, btnCancel;
    }
}
