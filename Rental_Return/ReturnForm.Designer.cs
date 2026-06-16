using System.Drawing;
using System.Windows.Forms;

namespace VehicleRentSystem
{
    partial class ReturnForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader       = new Panel();
            lblTitle        = new Label();
            lblSubtitle     = new Label();

            grpSearch       = new GroupBox();
            lblRentalId     = new Label();
            txtRentalId     = new TextBox();
            btnSearch       = new Button();
            lblActualReturn = new Label();
            dtpActualReturn = new DateTimePicker();

            grpDetails      = new GroupBox();
            lblCust         = new Label();
            txtCustomer     = new TextBox();
            lblPhone        = new Label();
            txtPhone        = new TextBox();
            lblVeh          = new Label();
            txtVehicle      = new TextBox();
            lblRD           = new Label();
            txtRentDate     = new TextBox();
            lblER           = new Label();
            txtExpReturn    = new TextBox();
            lblBD           = new Label();
            txtBookedDays   = new TextBox();
            lblDR           = new Label();
            txtDailyRate    = new TextBox();

            grpSummary      = new GroupBox();
            lblBase         = new Label();
            txtBaseAmount   = new TextBox();
            lblExtra        = new Label();
            txtExtraDays    = new TextBox();
            lblLate         = new Label();
            txtLateFee      = new TextBox();
            lblTot          = new Label();
            txtTotalAmount  = new TextBox();

            btnProcess      = new Button();
            btnClear        = new Button();
            btnClose        = new Button();

            pnlHeader.SuspendLayout();
            grpSearch.SuspendLayout();
            grpDetails.SuspendLayout();
            grpSummary.SuspendLayout();
            SuspendLayout();

            // ── pnlHeader ─────────────────────────────────────────
            pnlHeader.BackColor = Color.FromArgb(48, 25, 82);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(960, 88);
            pnlHeader.TabIndex = 0;
            pnlHeader.Paint += pnlHeader_Paint;

            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Calibri", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(200, 180, 230);
            lblSubtitle.Location = new Point(18, 60);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Text = "Process a vehicle return and calculate final charges";

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Papyrus", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "swiftRent  —  Vehicle Return";

            // ── grpSearch ─────────────────────────────────────────
            grpSearch.Controls.Add(lblRentalId);
            grpSearch.Controls.Add(txtRentalId);
            grpSearch.Controls.Add(btnSearch);
            grpSearch.Controls.Add(lblActualReturn);
            grpSearch.Controls.Add(dtpActualReturn);
            grpSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpSearch.ForeColor = Color.FromArgb(48, 25, 82);
            grpSearch.Location = new Point(12, 100);
            grpSearch.Name = "grpSearch";
            grpSearch.Padding = new Padding(3, 4, 3, 4);
            grpSearch.Size = new Size(930, 106);
            grpSearch.TabStop = false;
            grpSearch.Text = "  🔍  Search Rental";

            lblRentalId.AutoSize = true;
            lblRentalId.Font = new Font("Calibri", 10F);
            lblRentalId.ForeColor = Color.FromArgb(55, 65, 81);
            lblRentalId.Location = new Point(15, 35);
            lblRentalId.Name = "lblRentalId";
            lblRentalId.Text = "Rental ID *";

            txtRentalId.BorderStyle = BorderStyle.FixedSingle;
            txtRentalId.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtRentalId.Location = new Point(105, 30);
            txtRentalId.Name = "txtRentalId";
            txtRentalId.Size = new Size(110, 34);
            txtRentalId.TabIndex = 1;
            txtRentalId.TextAlign = HorizontalAlignment.Center;
            txtRentalId.PlaceholderText = "e.g. 5";

            btnSearch.BackColor = Color.FromArgb(102, 51, 153);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(235, 26);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(140, 42);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "🔍  Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;

            lblActualReturn.AutoSize = true;
            lblActualReturn.Font = new Font("Calibri", 10F);
            lblActualReturn.ForeColor = Color.FromArgb(55, 65, 81);
            lblActualReturn.Location = new Point(430, 35);
            lblActualReturn.Name = "lblActualReturn";
            lblActualReturn.Text = "Actual Return Date *";

            dtpActualReturn.Font = new Font("Segoe UI", 9.5F);
            dtpActualReturn.Format = DateTimePickerFormat.Short;
            dtpActualReturn.Location = new Point(590, 30);
            dtpActualReturn.Name = "dtpActualReturn";
            dtpActualReturn.Size = new Size(200, 29);
            dtpActualReturn.TabIndex = 3;
            dtpActualReturn.ValueChanged += dtpActualReturn_ValueChanged;

            // ── grpDetails ────────────────────────────────────────
            grpDetails.Controls.Add(lblCust);
            grpDetails.Controls.Add(txtCustomer);
            grpDetails.Controls.Add(lblPhone);
            grpDetails.Controls.Add(txtPhone);
            grpDetails.Controls.Add(lblVeh);
            grpDetails.Controls.Add(txtVehicle);
            grpDetails.Controls.Add(lblRD);
            grpDetails.Controls.Add(txtRentDate);
            grpDetails.Controls.Add(lblER);
            grpDetails.Controls.Add(txtExpReturn);
            grpDetails.Controls.Add(lblBD);
            grpDetails.Controls.Add(txtBookedDays);
            grpDetails.Controls.Add(lblDR);
            grpDetails.Controls.Add(txtDailyRate);
            grpDetails.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpDetails.ForeColor = Color.FromArgb(48, 25, 82);
            grpDetails.Location = new Point(12, 220);
            grpDetails.Name = "grpDetails";
            grpDetails.Padding = new Padding(3, 4, 3, 4);
            grpDetails.Size = new Size(930, 200);
            grpDetails.TabStop = false;
            grpDetails.Text = "  📋  Rental Details";
            grpDetails.Visible = false;

            // Row 1 labels
            int col1 = 15, col2 = 340, col3 = 560, col4 = 740;
            int row1lbl = 28, row1txt = 50, row2lbl = 110, row2txt = 132;

            lblCust.AutoSize = true;
            lblCust.Font = new Font("Calibri", 9F);
            lblCust.ForeColor = Color.Gray;
            lblCust.Location = new Point(col1, row1lbl);
            lblCust.Text = "Customer";

            txtCustomer.BackColor = Color.FromArgb(243, 240, 248);
            txtCustomer.BorderStyle = BorderStyle.FixedSingle;
            txtCustomer.Font = new Font("Segoe UI", 9.5F);
            txtCustomer.Location = new Point(col1, row1txt);
            txtCustomer.ReadOnly = true;
            txtCustomer.Size = new Size(300, 29);

            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Calibri", 9F);
            lblPhone.ForeColor = Color.Gray;
            lblPhone.Location = new Point(col2, row1lbl);
            lblPhone.Text = "Phone";

            txtPhone.BackColor = Color.FromArgb(243, 240, 248);
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Segoe UI", 9.5F);
            txtPhone.Location = new Point(col2, row1txt);
            txtPhone.ReadOnly = true;
            txtPhone.Size = new Size(180, 29);

            lblVeh.AutoSize = true;
            lblVeh.Font = new Font("Calibri", 9F);
            lblVeh.ForeColor = Color.Gray;
            lblVeh.Location = new Point(col3, row1lbl);
            lblVeh.Text = "Vehicle";

            txtVehicle.BackColor = Color.FromArgb(243, 240, 248);
            txtVehicle.BorderStyle = BorderStyle.FixedSingle;
            txtVehicle.Font = new Font("Segoe UI", 9.5F);
            txtVehicle.Location = new Point(col3, row1txt);
            txtVehicle.ReadOnly = true;
            txtVehicle.Size = new Size(350, 29);

            // Row 2
            lblRD.AutoSize = true;
            lblRD.Font = new Font("Calibri", 9F);
            lblRD.ForeColor = Color.Gray;
            lblRD.Location = new Point(col1, row2lbl);
            lblRD.Text = "Rent Date";

            txtRentDate.BackColor = Color.FromArgb(243, 240, 248);
            txtRentDate.BorderStyle = BorderStyle.FixedSingle;
            txtRentDate.Font = new Font("Segoe UI", 9.5F);
            txtRentDate.Location = new Point(col1, row2txt);
            txtRentDate.ReadOnly = true;
            txtRentDate.Size = new Size(170, 29);

            lblER.AutoSize = true;
            lblER.Font = new Font("Calibri", 9F);
            lblER.ForeColor = Color.Gray;
            lblER.Location = new Point(col2, row2lbl);
            lblER.Text = "Expected Return";

            txtExpReturn.BackColor = Color.FromArgb(243, 240, 248);
            txtExpReturn.BorderStyle = BorderStyle.FixedSingle;
            txtExpReturn.Font = new Font("Segoe UI", 9.5F);
            txtExpReturn.Location = new Point(col2, row2txt);
            txtExpReturn.ReadOnly = true;
            txtExpReturn.Size = new Size(170, 29);

            lblBD.AutoSize = true;
            lblBD.Font = new Font("Calibri", 9F);
            lblBD.ForeColor = Color.Gray;
            lblBD.Location = new Point(col3, row2lbl);
            lblBD.Text = "Booked Days";

            txtBookedDays.BackColor = Color.FromArgb(243, 240, 248);
            txtBookedDays.BorderStyle = BorderStyle.FixedSingle;
            txtBookedDays.Font = new Font("Segoe UI", 9.5F);
            txtBookedDays.Location = new Point(col3, row2txt);
            txtBookedDays.ReadOnly = true;
            txtBookedDays.Size = new Size(140, 29);
            txtBookedDays.TextAlign = HorizontalAlignment.Center;

            lblDR.AutoSize = true;
            lblDR.Font = new Font("Calibri", 9F);
            lblDR.ForeColor = Color.Gray;
            lblDR.Location = new Point(col4, row2lbl);
            lblDR.Text = "Daily Rate";

            txtDailyRate.BackColor = Color.FromArgb(243, 240, 248);
            txtDailyRate.BorderStyle = BorderStyle.FixedSingle;
            txtDailyRate.Font = new Font("Segoe UI", 9.5F);
            txtDailyRate.Location = new Point(col4, row2txt);
            txtDailyRate.ReadOnly = true;
            txtDailyRate.Size = new Size(160, 29);
            txtDailyRate.TextAlign = HorizontalAlignment.Right;

            // ── grpSummary ────────────────────────────────────────
            grpSummary.Controls.Add(lblBase);
            grpSummary.Controls.Add(txtBaseAmount);
            grpSummary.Controls.Add(lblExtra);
            grpSummary.Controls.Add(txtExtraDays);
            grpSummary.Controls.Add(lblLate);
            grpSummary.Controls.Add(txtLateFee);
            grpSummary.Controls.Add(lblTot);
            grpSummary.Controls.Add(txtTotalAmount);
            grpSummary.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpSummary.ForeColor = Color.FromArgb(48, 25, 82);
            grpSummary.Location = new Point(12, 434);
            grpSummary.Name = "grpSummary";
            grpSummary.Padding = new Padding(3, 4, 3, 4);
            grpSummary.Size = new Size(930, 200);
            grpSummary.TabStop = false;
            grpSummary.Text = "  💰  Payment Summary";
            grpSummary.Visible = false;

            int sCol1 = 15, sCol2 = 300, sCol3 = 560, sCol4 = 730;
            int sLbl = 28, sTxt = 50;

            lblBase.AutoSize = true;
            lblBase.Font = new Font("Calibri", 10F);
            lblBase.ForeColor = Color.FromArgb(55, 65, 81);
            lblBase.Location = new Point(sCol1, sLbl);
            lblBase.Text = "Base Amount:";

            txtBaseAmount.BackColor = Color.FromArgb(243, 240, 248);
            txtBaseAmount.BorderStyle = BorderStyle.FixedSingle;
            txtBaseAmount.Font = new Font("Segoe UI", 10F);
            txtBaseAmount.Location = new Point(sCol1, sTxt);
            txtBaseAmount.ReadOnly = true;
            txtBaseAmount.Size = new Size(200, 30);
            txtBaseAmount.TextAlign = HorizontalAlignment.Right;

            lblExtra.AutoSize = true;
            lblExtra.Font = new Font("Calibri", 10F);
            lblExtra.ForeColor = Color.FromArgb(55, 65, 81);
            lblExtra.Location = new Point(sCol2, sLbl);
            lblExtra.Text = "Extra Days (Late Return):";

            txtExtraDays.BackColor = Color.FromArgb(243, 240, 248);
            txtExtraDays.BorderStyle = BorderStyle.FixedSingle;
            txtExtraDays.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtExtraDays.Location = new Point(sCol2, sTxt);
            txtExtraDays.ReadOnly = true;
            txtExtraDays.Size = new Size(200, 30);
            txtExtraDays.TextAlign = HorizontalAlignment.Right;

            lblLate.AutoSize = true;
            lblLate.Font = new Font("Calibri", 10F);
            lblLate.ForeColor = Color.FromArgb(55, 65, 81);
            lblLate.Location = new Point(sCol1, 110);
            lblLate.Text = "Late Fee:";

            txtLateFee.BackColor = Color.FromArgb(243, 240, 248);
            txtLateFee.BorderStyle = BorderStyle.FixedSingle;
            txtLateFee.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtLateFee.Location = new Point(sCol1, 132);
            txtLateFee.ReadOnly = true;
            txtLateFee.Size = new Size(200, 30);
            txtLateFee.TextAlign = HorizontalAlignment.Right;

            lblTot.AutoSize = true;
            lblTot.Font = new Font("Corbel", 13F, FontStyle.Bold);
            lblTot.ForeColor = Color.FromArgb(48, 25, 82);
            lblTot.Location = new Point(sCol3, 110);
            lblTot.Text = "Total to Collect:";

            txtTotalAmount.BackColor = Color.FromArgb(243, 240, 248);
            txtTotalAmount.BorderStyle = BorderStyle.FixedSingle;
            txtTotalAmount.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            txtTotalAmount.ForeColor = Color.FromArgb(102, 51, 153);
            txtTotalAmount.Location = new Point(sCol4, 105);
            txtTotalAmount.ReadOnly = true;
            txtTotalAmount.Size = new Size(180, 42);
            txtTotalAmount.TextAlign = HorizontalAlignment.Right;

            // ── Buttons ───────────────────────────────────────────
            btnProcess.BackColor = Color.FromArgb(102, 51, 153);
            btnProcess.Cursor = Cursors.Hand;
            btnProcess.FlatAppearance.BorderSize = 0;
            btnProcess.FlatStyle = FlatStyle.Flat;
            btnProcess.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnProcess.ForeColor = Color.White;
            btnProcess.Location = new Point(300, 650);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new Size(210, 50);
            btnProcess.TabIndex = 10;
            btnProcess.Text = "✔  Process Return";
            btnProcess.UseVisualStyleBackColor = false;
            btnProcess.Visible = false;
            btnProcess.Click += btnProcess_Click;

            btnClear.BackColor = Color.FromArgb(160, 130, 195);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9.5F);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(730, 658);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 40);
            btnClear.TabIndex = 11;
            btnClear.Text = "↺  Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;

            btnClose.BackColor = Color.FromArgb(180, 0, 0);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9.5F);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(845, 658);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 40);
            btnClose.TabIndex = 12;
            btnClose.Text = "Close  ✕";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;

            // ── Form ──────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 242, 250);
            ClientSize = new Size(960, 720);
            Controls.Add(pnlHeader);
            Controls.Add(grpSearch);
            Controls.Add(grpDetails);
            Controls.Add(grpSummary);
            Controls.Add(btnProcess);
            Controls.Add(btnClear);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ReturnForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "swiftRent — Vehicle Return";
            Load += ReturnForm_Load;

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            grpSearch.ResumeLayout(false);
            grpSearch.PerformLayout();
            grpDetails.ResumeLayout(false);
            grpDetails.PerformLayout();
            grpSummary.ResumeLayout(false);
            grpSummary.PerformLayout();
            ResumeLayout(false);
        }

        private Panel     pnlHeader;
        private Label     lblTitle, lblSubtitle;

        private GroupBox  grpSearch;
        private Label     lblRentalId, lblActualReturn;
        private TextBox   txtRentalId;
        private DateTimePicker dtpActualReturn;
        private Button    btnSearch;

        private GroupBox  grpDetails;
        private Label     lblCust, lblPhone, lblVeh, lblRD, lblER, lblBD, lblDR;
        private TextBox   txtCustomer, txtPhone, txtVehicle,
                          txtRentDate, txtExpReturn, txtBookedDays, txtDailyRate;

        private GroupBox  grpSummary;
        private Label     lblBase, lblExtra, lblLate, lblTot;
        private TextBox   txtBaseAmount, txtExtraDays, txtLateFee, txtTotalAmount;

        private Button    btnProcess, btnClear, btnClose;
    }
}
