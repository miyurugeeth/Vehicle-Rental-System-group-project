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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.lblRentalId = new System.Windows.Forms.Label();
            this.txtRentalId = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblActualReturn = new System.Windows.Forms.Label();
            this.dtpActualReturn = new System.Windows.Forms.DateTimePicker();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.lblCust = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblVeh = new System.Windows.Forms.Label();
            this.txtVehicle = new System.Windows.Forms.TextBox();
            this.lblRD = new System.Windows.Forms.Label();
            this.txtRentDate = new System.Windows.Forms.TextBox();
            this.lblER = new System.Windows.Forms.Label();
            this.txtExpReturn = new System.Windows.Forms.TextBox();
            this.lblBD = new System.Windows.Forms.Label();
            this.txtBookedDays = new System.Windows.Forms.TextBox();
            this.lblDR = new System.Windows.Forms.Label();
            this.txtDailyRate = new System.Windows.Forms.TextBox();
            this.grpSummary = new System.Windows.Forms.GroupBox();
            this.lblBase = new System.Windows.Forms.Label();
            this.txtBaseAmount = new System.Windows.Forms.TextBox();
            this.lblExtra = new System.Windows.Forms.Label();
            this.txtExtraDays = new System.Windows.Forms.TextBox();
            this.lblLate = new System.Windows.Forms.Label();
            this.txtLateFee = new System.Windows.Forms.TextBox();
            this.lblTot = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.grpSearch.SuspendLayout();
            this.grpDetails.SuspendLayout();
            this.grpSummary.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(48, 25, 82);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 88);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(200, 180, 230);
            this.lblSubtitle.Location = new System.Drawing.Point(18, 60);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(361, 21);
            this.lblSubtitle.TabIndex = 0;
            this.lblSubtitle.Text = "Process a vehicle return and calculate final charges";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Papyrus", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(379, 42);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "swiftRent  —  Vehicle Return";
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.lblRentalId);
            this.grpSearch.Controls.Add(this.txtRentalId);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.lblActualReturn);
            this.grpSearch.Controls.Add(this.dtpActualReturn);
            this.grpSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpSearch.ForeColor = System.Drawing.Color.FromArgb(48, 25, 82);
            this.grpSearch.Location = new System.Drawing.Point(12, 100);
            this.grpSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpSearch.Size = new System.Drawing.Size(870, 106);
            this.grpSearch.TabIndex = 1;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "  Search Rental";
            // 
            // lblRentalId
            // 
            this.lblRentalId.AutoSize = true;
            this.lblRentalId.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblRentalId.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblRentalId.Location = new System.Drawing.Point(15, 35);
            this.lblRentalId.Name = "lblRentalId";
            this.lblRentalId.Size = new System.Drawing.Size(77, 21);
            this.lblRentalId.TabIndex = 0;
            this.lblRentalId.Text = "Rental ID:";
            // 
            // txtRentalId
            // 
            this.txtRentalId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRentalId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtRentalId.Location = new System.Drawing.Point(95, 30);
            this.txtRentalId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRentalId.Name = "txtRentalId";
            this.txtRentalId.Size = new System.Drawing.Size(110, 34);
            this.txtRentalId.TabIndex = 1;
            this.txtRentalId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(102, 51, 153);
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(220, 28);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(130, 42);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "🔍  Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblActualReturn
            // 
            this.lblActualReturn.AutoSize = true;
            this.lblActualReturn.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblActualReturn.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblActualReturn.Location = new System.Drawing.Point(400, 35);
            this.lblActualReturn.Name = "lblActualReturn";
            this.lblActualReturn.Size = new System.Drawing.Size(146, 21);
            this.lblActualReturn.TabIndex = 3;
            this.lblActualReturn.Text = "Actual Return Date:";
            // 
            // dtpActualReturn
            // 
            this.dtpActualReturn.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpActualReturn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpActualReturn.Location = new System.Drawing.Point(560, 30);
            this.dtpActualReturn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpActualReturn.Name = "dtpActualReturn";
            this.dtpActualReturn.Size = new System.Drawing.Size(180, 29);
            this.dtpActualReturn.TabIndex = 4;
            this.dtpActualReturn.ValueChanged += new System.EventHandler(this.dtpActualReturn_ValueChanged);
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.lblCust);
            this.grpDetails.Controls.Add(this.txtCustomer);
            this.grpDetails.Controls.Add(this.lblPhone);
            this.grpDetails.Controls.Add(this.txtPhone);
            this.grpDetails.Controls.Add(this.lblVeh);
            this.grpDetails.Controls.Add(this.txtVehicle);
            this.grpDetails.Controls.Add(this.lblRD);
            this.grpDetails.Controls.Add(this.txtRentDate);
            this.grpDetails.Controls.Add(this.lblER);
            this.grpDetails.Controls.Add(this.txtExpReturn);
            this.grpDetails.Controls.Add(this.lblBD);
            this.grpDetails.Controls.Add(this.txtBookedDays);
            this.grpDetails.Controls.Add(this.lblDR);
            this.grpDetails.Controls.Add(this.txtDailyRate);
            this.grpDetails.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpDetails.ForeColor = System.Drawing.Color.FromArgb(48, 25, 82);
            this.grpDetails.Location = new System.Drawing.Point(12, 219);
            this.grpDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpDetails.Size = new System.Drawing.Size(870, 181);
            this.grpDetails.TabIndex = 2;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "  Rental Details";
            this.grpDetails.Visible = false;
            // 
            // lblCust
            // 
            this.lblCust.AutoSize = true;
            this.lblCust.Font = new System.Drawing.Font("Calibri", 9F);
            this.lblCust.ForeColor = System.Drawing.Color.Gray;
            this.lblCust.Location = new System.Drawing.Point(15, 28);
            this.lblCust.Name = "lblCust";
            this.lblCust.Size = new System.Drawing.Size(68, 18);
            this.lblCust.TabIndex = 0;
            this.lblCust.Text = "Customer";
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.FromArgb(243, 240, 248);
            this.txtCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomer.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCustomer.Location = new System.Drawing.Point(15, 50);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(300, 29);
            this.txtCustomer.TabIndex = 1;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Calibri", 9F);
            this.lblPhone.ForeColor = System.Drawing.Color.Gray;
            this.lblPhone.Location = new System.Drawing.Point(335, 28);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(48, 18);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "Phone";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.FromArgb(243, 240, 248);
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPhone.Location = new System.Drawing.Point(335, 50);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(150, 29);
            this.txtPhone.TabIndex = 3;
            // 
            // lblVeh
            // 
            this.lblVeh.AutoSize = true;
            this.lblVeh.Font = new System.Drawing.Font("Calibri", 9F);
            this.lblVeh.ForeColor = System.Drawing.Color.Gray;
            this.lblVeh.Location = new System.Drawing.Point(510, 28);
            this.lblVeh.Name = "lblVeh";
            this.lblVeh.Size = new System.Drawing.Size(54, 18);
            this.lblVeh.TabIndex = 4;
            this.lblVeh.Text = "Vehicle";
            // 
            // txtVehicle
            // 
            this.txtVehicle.BackColor = System.Drawing.Color.FromArgb(243, 240, 248);
            this.txtVehicle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVehicle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtVehicle.Location = new System.Drawing.Point(510, 50);
            this.txtVehicle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVehicle.Name = "txtVehicle";
            this.txtVehicle.ReadOnly = true;
            this.txtVehicle.Size = new System.Drawing.Size(340, 29);
            this.txtVehicle.TabIndex = 5;
            // 
            // lblRD
            // 
            this.lblRD.AutoSize = true;
            this.lblRD.Font = new System.Drawing.Font("Calibri", 9F);
            this.lblRD.ForeColor = System.Drawing.Color.Gray;
            this.lblRD.Location = new System.Drawing.Point(15, 98);
            this.lblRD.Name = "lblRD";
            this.lblRD.Size = new System.Drawing.Size(69, 18);
            this.lblRD.TabIndex = 6;
            this.lblRD.Text = "Rent Date";
            // 
            // txtRentDate
            // 
            this.txtRentDate.BackColor = System.Drawing.Color.FromArgb(243, 240, 248);
            this.txtRentDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRentDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtRentDate.Location = new System.Drawing.Point(15, 120);
            this.txtRentDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRentDate.Name = "txtRentDate";
            this.txtRentDate.ReadOnly = true;
            this.txtRentDate.Size = new System.Drawing.Size(140, 29);
            this.txtRentDate.TabIndex = 7;
            // 
            // lblER
            // 
            this.lblER.AutoSize = true;
            this.lblER.Font = new System.Drawing.Font("Calibri", 9F);
            this.lblER.ForeColor = System.Drawing.Color.Gray;
            this.lblER.Location = new System.Drawing.Point(175, 98);
            this.lblER.Name = "lblER";
            this.lblER.Size = new System.Drawing.Size(110, 18);
            this.lblER.TabIndex = 8;
            this.lblER.Text = "Expected Return";
            // 
            // txtExpReturn
            // 
            this.txtExpReturn.BackColor = System.Drawing.Color.FromArgb(243, 240, 248);
            this.txtExpReturn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExpReturn.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtExpReturn.Location = new System.Drawing.Point(175, 120);
            this.txtExpReturn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtExpReturn.Name = "txtExpReturn";
            this.txtExpReturn.ReadOnly = true;
            this.txtExpReturn.Size = new System.Drawing.Size(140, 29);
            this.txtExpReturn.TabIndex = 9;
            // 
            // lblBD
            // 
            this.lblBD.AutoSize = true;
            this.lblBD.Font = new System.Drawing.Font("Calibri", 9F);
            this.lblBD.ForeColor = System.Drawing.Color.Gray;
            this.lblBD.Location = new System.Drawing.Point(340, 98);
            this.lblBD.Name = "lblBD";
            this.lblBD.Size = new System.Drawing.Size(87, 18);
            this.lblBD.TabIndex = 10;
            this.lblBD.Text = "Booked Days";
            // 
            // txtBookedDays
            // 
            this.txtBookedDays.BackColor = System.Drawing.Color.FromArgb(243, 240, 248);
            this.txtBookedDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBookedDays.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBookedDays.Location = new System.Drawing.Point(340, 120);
            this.txtBookedDays.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBookedDays.Name = "txtBookedDays";
            this.txtBookedDays.ReadOnly = true;
            this.txtBookedDays.Size = new System.Drawing.Size(100, 29);
            this.txtBookedDays.TabIndex = 11;
            this.txtBookedDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDR
            // 
            this.lblDR.AutoSize = true;
            this.lblDR.Font = new System.Drawing.Font("Calibri", 9F);
            this.lblDR.ForeColor = System.Drawing.Color.Gray;
            this.lblDR.Location = new System.Drawing.Point(460, 98);
            this.lblDR.Name = "lblDR";
            this.lblDR.Size = new System.Drawing.Size(70, 18);
            this.lblDR.TabIndex = 12;
            this.lblDR.Text = "Daily Rate";
            // 
            // txtDailyRate
            // 
            this.txtDailyRate.BackColor = System.Drawing.Color.FromArgb(243, 240, 248);
            this.txtDailyRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDailyRate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDailyRate.Location = new System.Drawing.Point(460, 120);
            this.txtDailyRate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDailyRate.Name = "txtDailyRate";
            this.txtDailyRate.ReadOnly = true;
            this.txtDailyRate.Size = new System.Drawing.Size(130, 29);
            this.txtDailyRate.TabIndex = 13;
            this.txtDailyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grpSummary
            // 
            this.grpSummary.Controls.Add(this.lblBase);
            this.grpSummary.Controls.Add(this.txtBaseAmount);
            this.grpSummary.Controls.Add(this.lblExtra);
            this.grpSummary.Controls.Add(this.txtExtraDays);
            this.grpSummary.Controls.Add(this.lblLate);
            this.grpSummary.Controls.Add(this.txtLateFee);
            this.grpSummary.Controls.Add(this.lblTot);
            this.grpSummary.Controls.Add(this.txtTotalAmount);
            this.grpSummary.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpSummary.ForeColor = System.Drawing.Color.FromArgb(48, 25, 82);
            this.grpSummary.Location = new System.Drawing.Point(12, 412);
            this.grpSummary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpSummary.Name = "grpSummary";
            this.grpSummary.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpSummary.Size = new System.Drawing.Size(870, 200);
            this.grpSummary.TabIndex = 3;
            this.grpSummary.TabStop = false;
            this.grpSummary.Text = "  Payment Summary";
            this.grpSummary.Visible = false;
            this.grpSummary.Enter += new System.EventHandler(this.grpSummary_Enter);
            // 
            // lblBase
            // 
            this.lblBase.AutoSize = true;
            this.lblBase.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblBase.Location = new System.Drawing.Point(15, 40);
            this.lblBase.Name = "lblBase";
            this.lblBase.Size = new System.Drawing.Size(156, 21);
            this.lblBase.TabIndex = 0;
            this.lblBase.Text = "Base Rental Amount:";
            // 
            // txtBaseAmount
            // 
            this.txtBaseAmount.BackColor = System.Drawing.Color.FromArgb(243, 240, 248);
            this.txtBaseAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBaseAmount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtBaseAmount.Location = new System.Drawing.Point(300, 35);
            this.txtBaseAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBaseAmount.Name = "txtBaseAmount";
            this.txtBaseAmount.ReadOnly = true;
            this.txtBaseAmount.Size = new System.Drawing.Size(180, 30);
            this.txtBaseAmount.TabIndex = 1;
            this.txtBaseAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblExtra
            // 
            this.lblExtra.AutoSize = true;
            this.lblExtra.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblExtra.Location = new System.Drawing.Point(15, 88);
            this.lblExtra.Name = "lblExtra";
            this.lblExtra.Size = new System.Drawing.Size(181, 21);
            this.lblExtra.TabIndex = 2;
            this.lblExtra.Text = "Extra Days (Late Return):";
            // 
            // txtExtraDays
            // 
            this.txtExtraDays.BackColor = System.Drawing.Color.FromArgb(243, 240, 248);
            this.txtExtraDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExtraDays.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtExtraDays.Location = new System.Drawing.Point(300, 82);
            this.txtExtraDays.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtExtraDays.Name = "txtExtraDays";
            this.txtExtraDays.ReadOnly = true;
            this.txtExtraDays.Size = new System.Drawing.Size(180, 30);
            this.txtExtraDays.TabIndex = 3;
            this.txtExtraDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblLate
            // 
            this.lblLate.AutoSize = true;
            this.lblLate.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblLate.Location = new System.Drawing.Point(15, 135);
            this.lblLate.Name = "lblLate";
            this.lblLate.Size = new System.Drawing.Size(72, 21);
            this.lblLate.TabIndex = 4;
            this.lblLate.Text = "Late Fee:";
            // 
            // txtLateFee
            // 
            this.txtLateFee.BackColor = System.Drawing.Color.FromArgb(243, 240, 248);
            this.txtLateFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLateFee.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtLateFee.Location = new System.Drawing.Point(300, 130);
            this.txtLateFee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLateFee.Name = "txtLateFee";
            this.txtLateFee.ReadOnly = true;
            this.txtLateFee.Size = new System.Drawing.Size(180, 30);
            this.txtLateFee.TabIndex = 5;
            this.txtLateFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTot
            // 
            this.lblTot.AutoSize = true;
            this.lblTot.Font = new System.Drawing.Font("Corbel", 13F, System.Drawing.FontStyle.Bold);
            this.lblTot.ForeColor = System.Drawing.Color.FromArgb(48, 25, 82);
            this.lblTot.Location = new System.Drawing.Point(500, 135);
            this.lblTot.Name = "lblTot";
            this.lblTot.Size = new System.Drawing.Size(162, 27);
            this.lblTot.TabIndex = 6;
            this.lblTot.Text = "Total to Collect:";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.BackColor = System.Drawing.Color.FromArgb(243, 240, 248);
            this.txtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalAmount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.txtTotalAmount.ForeColor = System.Drawing.Color.FromArgb(102, 51, 153);
            this.txtTotalAmount.Location = new System.Drawing.Point(670, 130);
            this.txtTotalAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(175, 39);
            this.txtTotalAmount.TabIndex = 7;
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnProcess
            // 
            this.btnProcess.BackColor = System.Drawing.Color.FromArgb(102, 51, 153);
            this.btnProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcess.FlatAppearance.BorderSize = 0;
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcess.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProcess.ForeColor = System.Drawing.Color.White;
            this.btnProcess.Location = new System.Drawing.Point(300, 630);
            this.btnProcess.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(200, 50);
            this.btnProcess.TabIndex = 8;
            this.btnProcess.Text = "✔  Process Return";
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Visible = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(160, 130, 195);
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(660, 638);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 40);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "↺  Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(180, 0, 0);
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(775, 638);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close  ✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 242, 250);
            this.ClientSize = new System.Drawing.Size(900, 698);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.grpSummary);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "ReturnForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "swiftRent — Vehicle Return";
            this.Load += new System.EventHandler(this.ReturnForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.grpSummary.ResumeLayout(false);
            this.grpSummary.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.GroupBox grpSummary;
        private System.Windows.Forms.Label lblRentalId;
        private System.Windows.Forms.Label lblActualReturn;
        private System.Windows.Forms.TextBox txtRentalId;
        private System.Windows.Forms.DateTimePicker dtpActualReturn;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCust;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblVeh;
        private System.Windows.Forms.Label lblRD;
        private System.Windows.Forms.Label lblER;
        private System.Windows.Forms.Label lblBD;
        private System.Windows.Forms.Label lblDR;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtVehicle;
        private System.Windows.Forms.TextBox txtRentDate;
        private System.Windows.Forms.TextBox txtExpReturn;
        private System.Windows.Forms.TextBox txtBookedDays;
        private System.Windows.Forms.TextBox txtDailyRate;
        private System.Windows.Forms.Label lblBase;
        private System.Windows.Forms.Label lblExtra;
        private System.Windows.Forms.Label lblLate;
        private System.Windows.Forms.Label lblTot;
        private System.Windows.Forms.TextBox txtBaseAmount;
        private System.Windows.Forms.TextBox txtExtraDays;
        private System.Windows.Forms.TextBox txtLateFee;
        private System.Windows.Forms.TextBox txtTotalAmount;
    }
}