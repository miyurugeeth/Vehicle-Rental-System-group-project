namespace VehicleRentSystem
{
    partial class RentalForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            grpDetails = new GroupBox();
            lblCustomer = new Label();
            cmbCustomer = new ComboBox();
            btnAddCustomer = new Button();
            lblVehicle = new Label();
            cmbVehicle = new ComboBox();
            lblRentDate = new Label();
            dtpRentDate = new DateTimePicker();
            lblExpReturn = new Label();
            dtpExpectedReturn = new DateTimePicker();
            lblDays = new Label();
            txtDays = new TextBox();
            lblRate = new Label();
            txtDailyRate = new TextBox();
            lblTotal = new Label();
            txtTotalAmount = new TextBox();
            btnSave = new Button();
            btnClear = new Button();
            grpActive = new GroupBox();
            dgvRentals = new DataGridView();
            btnClose = new Button();
            pnlHeader.SuspendLayout();
            grpDetails.SuspendLayout();
            grpActive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRentals).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(48, 25, 82);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1100, 88);
            pnlHeader.TabIndex = 0;
            pnlHeader.Paint += pnlHeader_Paint;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Calibri", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(200, 180, 230);
            lblSubtitle.Location = new Point(18, 60);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(208, 21);
            lblSubtitle.TabIndex = 0;
            lblSubtitle.Text = "Register a new vehicle rental";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Papyrus", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(376, 42);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "swiftRent  —  Vehicle Rental";
            // 
            // grpDetails
            // 
            grpDetails.Controls.Add(lblCustomer);
            grpDetails.Controls.Add(cmbCustomer);
            grpDetails.Controls.Add(btnAddCustomer);
            grpDetails.Controls.Add(lblVehicle);
            grpDetails.Controls.Add(cmbVehicle);
            grpDetails.Controls.Add(lblRentDate);
            grpDetails.Controls.Add(dtpRentDate);
            grpDetails.Controls.Add(lblExpReturn);
            grpDetails.Controls.Add(dtpExpectedReturn);
            grpDetails.Controls.Add(lblDays);
            grpDetails.Controls.Add(txtDays);
            grpDetails.Controls.Add(lblRate);
            grpDetails.Controls.Add(txtDailyRate);
            grpDetails.Controls.Add(lblTotal);
            grpDetails.Controls.Add(txtTotalAmount);
            grpDetails.Controls.Add(btnSave);
            grpDetails.Controls.Add(btnClear);
            grpDetails.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpDetails.ForeColor = Color.FromArgb(48, 25, 82);
            grpDetails.Location = new Point(12, 100);
            grpDetails.Margin = new Padding(3, 4, 3, 4);
            grpDetails.Name = "grpDetails";
            grpDetails.Padding = new Padding(3, 4, 3, 4);
            grpDetails.Size = new Size(1072, 288);
            grpDetails.TabIndex = 1;
            grpDetails.TabStop = false;
            grpDetails.Text = "  Rental Details";
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Font = new Font("Calibri", 10F);
            lblCustomer.ForeColor = Color.FromArgb(55, 65, 81);
            lblCustomer.Location = new Point(15, 35);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(90, 21);
            lblCustomer.TabIndex = 0;
            lblCustomer.Text = "Customer *";
            // 
            // cmbCustomer
            // 
            cmbCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCustomer.Font = new Font("Segoe UI", 9.5F);
            cmbCustomer.Location = new Point(15, 62);
            cmbCustomer.Margin = new Padding(3, 4, 3, 4);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(300, 29);
            cmbCustomer.TabIndex = 1;
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.BackColor = Color.FromArgb(102, 51, 153);
            btnAddCustomer.Cursor = Cursors.Hand;
            btnAddCustomer.FlatAppearance.BorderSize = 0;
            btnAddCustomer.FlatStyle = FlatStyle.Flat;
            btnAddCustomer.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnAddCustomer.ForeColor = Color.White;
            btnAddCustomer.Location = new Point(15, 108);
            btnAddCustomer.Margin = new Padding(3, 4, 3, 4);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(145, 35);
            btnAddCustomer.TabIndex = 2;
            btnAddCustomer.Text = "➕  New Customer";
            btnAddCustomer.UseVisualStyleBackColor = false;
            btnAddCustomer.Click += btnAddCustomer_Click;
            // 
            // lblVehicle
            // 
            lblVehicle.AutoSize = true;
            lblVehicle.Font = new Font("Calibri", 10F);
            lblVehicle.ForeColor = Color.FromArgb(55, 65, 81);
            lblVehicle.Location = new Point(345, 35);
            lblVehicle.Name = "lblVehicle";
            lblVehicle.Size = new Size(71, 21);
            lblVehicle.TabIndex = 3;
            lblVehicle.Text = "Vehicle *";
            // 
            // cmbVehicle
            // 
            cmbVehicle.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVehicle.Font = new Font("Segoe UI", 9.5F);
            cmbVehicle.Location = new Point(345, 62);
            cmbVehicle.Margin = new Padding(3, 4, 3, 4);
            cmbVehicle.Name = "cmbVehicle";
            cmbVehicle.Size = new Size(380, 29);
            cmbVehicle.TabIndex = 4;
            cmbVehicle.SelectedIndexChanged += cmbVehicle_SelectedIndexChanged;
            // 
            // lblRentDate
            // 
            lblRentDate.AutoSize = true;
            lblRentDate.Font = new Font("Calibri", 10F);
            lblRentDate.ForeColor = Color.FromArgb(55, 65, 81);
            lblRentDate.Location = new Point(15, 162);
            lblRentDate.Name = "lblRentDate";
            lblRentDate.Size = new Size(90, 21);
            lblRentDate.TabIndex = 5;
            lblRentDate.Text = "Rent Date *";
            // 
            // dtpRentDate
            // 
            dtpRentDate.Font = new Font("Segoe UI", 9.5F);
            dtpRentDate.Format = DateTimePickerFormat.Short;
            dtpRentDate.Location = new Point(15, 190);
            dtpRentDate.Margin = new Padding(3, 4, 3, 4);
            dtpRentDate.Name = "dtpRentDate";
            dtpRentDate.Size = new Size(180, 29);
            dtpRentDate.TabIndex = 6;
            dtpRentDate.ValueChanged += dtpRentDate_ValueChanged;
            // 
            // lblExpReturn
            // 
            lblExpReturn.AutoSize = true;
            lblExpReturn.Font = new Font("Calibri", 10F);
            lblExpReturn.ForeColor = Color.FromArgb(55, 65, 81);
            lblExpReturn.Location = new Point(220, 162);
            lblExpReturn.Name = "lblExpReturn";
            lblExpReturn.Size = new Size(171, 21);
            lblExpReturn.TabIndex = 7;
            lblExpReturn.Text = "Expected Return Date *";
            // 
            // dtpExpectedReturn
            // 
            dtpExpectedReturn.Font = new Font("Segoe UI", 9.5F);
            dtpExpectedReturn.Format = DateTimePickerFormat.Short;
            dtpExpectedReturn.Location = new Point(220, 190);
            dtpExpectedReturn.Margin = new Padding(3, 4, 3, 4);
            dtpExpectedReturn.Name = "dtpExpectedReturn";
            dtpExpectedReturn.Size = new Size(180, 29);
            dtpExpectedReturn.TabIndex = 8;
            dtpExpectedReturn.ValueChanged += dtpExpectedReturn_ValueChanged;
            // 
            // lblDays
            // 
            lblDays.AutoSize = true;
            lblDays.Font = new Font("Calibri", 10F);
            lblDays.ForeColor = Color.FromArgb(55, 65, 81);
            lblDays.Location = new Point(430, 162);
            lblDays.Name = "lblDays";
            lblDays.Size = new Size(89, 21);
            lblDays.TabIndex = 9;
            lblDays.Text = "No. of Days";
            // 
            // txtDays
            // 
            txtDays.BackColor = Color.FromArgb(243, 240, 248);
            txtDays.BorderStyle = BorderStyle.FixedSingle;
            txtDays.Font = new Font("Segoe UI", 9.5F);
            txtDays.Location = new Point(430, 190);
            txtDays.Margin = new Padding(3, 4, 3, 4);
            txtDays.Name = "txtDays";
            txtDays.ReadOnly = true;
            txtDays.Size = new Size(80, 29);
            txtDays.TabIndex = 10;
            txtDays.TextAlign = HorizontalAlignment.Center;
            // 
            // lblRate
            // 
            lblRate.AutoSize = true;
            lblRate.Font = new Font("Calibri", 10F);
            lblRate.ForeColor = Color.FromArgb(55, 65, 81);
            lblRate.Location = new Point(535, 162);
            lblRate.Name = "lblRate";
            lblRate.Size = new Size(113, 21);
            lblRate.TabIndex = 11;
            lblRate.Text = "Daily Rate (Rs.)";
            // 
            // txtDailyRate
            // 
            txtDailyRate.BackColor = Color.FromArgb(243, 240, 248);
            txtDailyRate.BorderStyle = BorderStyle.FixedSingle;
            txtDailyRate.Font = new Font("Segoe UI", 9.5F);
            txtDailyRate.Location = new Point(535, 190);
            txtDailyRate.Margin = new Padding(3, 4, 3, 4);
            txtDailyRate.Name = "txtDailyRate";
            txtDailyRate.ReadOnly = true;
            txtDailyRate.Size = new Size(120, 29);
            txtDailyRate.TabIndex = 12;
            txtDailyRate.TextAlign = HorizontalAlignment.Center;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Calibri", 10F);
            lblTotal.ForeColor = Color.FromArgb(55, 65, 81);
            lblTotal.Location = new Point(680, 162);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(138, 21);
            lblTotal.TabIndex = 13;
            lblTotal.Text = "Total Amount (Rs.)";
            // 
            // txtTotalAmount
            // 
            txtTotalAmount.BackColor = Color.FromArgb(243, 240, 248);
            txtTotalAmount.BorderStyle = BorderStyle.FixedSingle;
            txtTotalAmount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtTotalAmount.ForeColor = Color.FromArgb(102, 51, 153);
            txtTotalAmount.Location = new Point(680, 190);
            txtTotalAmount.Margin = new Padding(3, 4, 3, 4);
            txtTotalAmount.Name = "txtTotalAmount";
            txtTotalAmount.ReadOnly = true;
            txtTotalAmount.Size = new Size(160, 34);
            txtTotalAmount.TabIndex = 14;
            txtTotalAmount.TextAlign = HorizontalAlignment.Center;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(102, 51, 153);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(870, 181);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(175, 50);
            btnSave.TabIndex = 15;
            btnSave.Text = "✔  Save Rental";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(160, 130, 195);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9.5F);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(870, 240);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(175, 38);
            btnClear.TabIndex = 16;
            btnClear.Text = "↺  Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // grpActive
            // 
            grpActive.Controls.Add(dgvRentals);
            grpActive.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpActive.ForeColor = Color.FromArgb(48, 25, 82);
            grpActive.Location = new Point(12, 400);
            grpActive.Margin = new Padding(3, 4, 3, 4);
            grpActive.Name = "grpActive";
            grpActive.Padding = new Padding(3, 4, 3, 4);
            grpActive.Size = new Size(1072, 400);
            grpActive.TabIndex = 2;
            grpActive.TabStop = false;
            grpActive.Text = "  Active Rentals";
            grpActive.Enter += grpActive_Enter;
            // 
            // dgvRentals
            // 
            dgvRentals.AllowUserToAddRows = false;
            dgvRentals.AllowUserToDeleteRows = false;
            dgvRentals.BackgroundColor = Color.White;
            dgvRentals.BorderStyle = BorderStyle.None;
            dgvRentals.ColumnHeadersHeight = 35;
            dgvRentals.Font = new Font("Segoe UI", 9F);
            dgvRentals.Location = new Point(8, 28);
            dgvRentals.Margin = new Padding(3, 4, 3, 4);
            dgvRentals.Name = "dgvRentals";
            dgvRentals.ReadOnly = true;
            dgvRentals.RowHeadersVisible = false;
            dgvRentals.RowHeadersWidth = 51;
            dgvRentals.RowTemplate.Height = 28;
            dgvRentals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRentals.Size = new Size(1055, 356);
            dgvRentals.TabIndex = 0;
            dgvRentals.CellContentClick += dgvRentals_CellContentClick;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(180, 0, 0);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9.5F);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(984, 812);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 40);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close  ✕";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // RentalForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 242, 250);
            ClientSize = new Size(1100, 869);
            Controls.Add(pnlHeader);
            Controls.Add(grpDetails);
            Controls.Add(grpActive);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "RentalForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "swiftRent — Vehicle Rental";
            Load += RentalForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            grpDetails.ResumeLayout(false);
            grpDetails.PerformLayout();
            grpActive.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRentals).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle, lblSubtitle;
        private System.Windows.Forms.GroupBox grpDetails, grpActive;
        private System.Windows.Forms.Label lblCustomer, lblVehicle, lblRentDate, lblExpReturn, lblDays, lblRate, lblTotal;
        private System.Windows.Forms.ComboBox cmbCustomer, cmbVehicle;
        private System.Windows.Forms.DateTimePicker dtpRentDate, dtpExpectedReturn;
        private System.Windows.Forms.TextBox txtDays, txtDailyRate, txtTotalAmount;
        private System.Windows.Forms.Button btnSave, btnClear, btnClose, btnAddCustomer;
        private System.Windows.Forms.DataGridView dgvRentals;
    }
}
