namespace VehicleRentSystem
{
    partial class MainDashboard
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
            pnlRental = new Panel();
            lblRentalArrow = new Label();
            lblRentalDesc = new Label();
            lblRentalTitle = new Label();
            pnlReturn = new Panel();
            lblReturnArrow = new Label();
            lblReturnDesc = new Label();
            lblReturnTitle = new Label();
            pnlStatus = new Panel();
            lblStatus = new Label();
            pnlHeader.SuspendLayout();
            pnlRental.SuspendLayout();
            pnlReturn.SuspendLayout();
            pnlStatus.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(64, 0, 64);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(756, 112);
            pnlHeader.TabIndex = 3;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(156, 163, 175);
            lblSubtitle.Location = new Point(27, 69);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(283, 23);
            lblSubtitle.TabIndex = 0;
            lblSubtitle.Text = "Vehicle Rental Management System";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(25, 19);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(403, 46);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "🚘  Vehicle Rent System";
            // 
            // pnlRental
            // 
            pnlRental.BackColor = Color.Purple;
            pnlRental.Controls.Add(lblRentalArrow);
            pnlRental.Controls.Add(lblRentalDesc);
            pnlRental.Controls.Add(lblRentalTitle);
            pnlRental.Cursor = Cursors.Hand;
            pnlRental.Location = new Point(50, 186);
            pnlRental.Margin = new Padding(3, 4, 3, 4);
            pnlRental.Name = "pnlRental";
            pnlRental.Size = new Size(270, 175);
            pnlRental.TabIndex = 2;
            pnlRental.Click += pnlRental_Click;
            // 
            // lblRentalArrow
            // 
            lblRentalArrow.AutoSize = true;
            lblRentalArrow.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRentalArrow.ForeColor = Color.White;
            lblRentalArrow.Location = new Point(15, 140);
            lblRentalArrow.Name = "lblRentalArrow";
            lblRentalArrow.Size = new Size(68, 20);
            lblRentalArrow.TabIndex = 0;
            lblRentalArrow.Text = "▶  Open";
            lblRentalArrow.Click += pnlRental_Click;
            // 
            // lblRentalDesc
            // 
            lblRentalDesc.Font = new Font("Segoe UI", 8.5F);
            lblRentalDesc.ForeColor = Color.FromArgb(200, 230, 200);
            lblRentalDesc.Location = new Point(15, 69);
            lblRentalDesc.Name = "lblRentalDesc";
            lblRentalDesc.Size = new Size(240, 62);
            lblRentalDesc.TabIndex = 1;
            lblRentalDesc.Text = "Register a new rental\nSelect available vehicles\nAssign to a customer";
            lblRentalDesc.Click += pnlRental_Click;
            // 
            // lblRentalTitle
            // 
            lblRentalTitle.AutoSize = true;
            lblRentalTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblRentalTitle.ForeColor = Color.Black;
            lblRentalTitle.Location = new Point(15, 22);
            lblRentalTitle.Name = "lblRentalTitle";
            lblRentalTitle.Size = new Size(201, 30);
            lblRentalTitle.TabIndex = 2;
            lblRentalTitle.Text = "🚗  Vehicle Rental";
            lblRentalTitle.Click += pnlRental_Click;
            // 
            // pnlReturn
            // 
            pnlReturn.BackColor = Color.Purple;
            pnlReturn.Controls.Add(lblReturnArrow);
            pnlReturn.Controls.Add(lblReturnDesc);
            pnlReturn.Controls.Add(lblReturnTitle);
            pnlReturn.Cursor = Cursors.Hand;
            pnlReturn.Location = new Point(411, 186);
            pnlReturn.Margin = new Padding(3, 4, 3, 4);
            pnlReturn.Name = "pnlReturn";
            pnlReturn.Size = new Size(281, 175);
            pnlReturn.TabIndex = 1;
            pnlReturn.Click += pnlReturn_Click;
            // 
            // lblReturnArrow
            // 
            lblReturnArrow.AutoSize = true;
            lblReturnArrow.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblReturnArrow.ForeColor = Color.White;
            lblReturnArrow.Location = new Point(15, 140);
            lblReturnArrow.Name = "lblReturnArrow";
            lblReturnArrow.Size = new Size(68, 20);
            lblReturnArrow.TabIndex = 0;
            lblReturnArrow.Text = "▶  Open";
            lblReturnArrow.Click += pnlReturn_Click;
            // 
            // lblReturnDesc
            // 
            lblReturnDesc.Font = new Font("Segoe UI", 8.5F);
            lblReturnDesc.ForeColor = Color.FromArgb(200, 230, 200);
            lblReturnDesc.Location = new Point(15, 69);
            lblReturnDesc.Name = "lblReturnDesc";
            lblReturnDesc.Size = new Size(240, 62);
            lblReturnDesc.TabIndex = 1;
            lblReturnDesc.Text = "Process a vehicle return\nCalculate extra day charges\nConfirm payment";
            lblReturnDesc.Click += pnlReturn_Click;
            // 
            // lblReturnTitle
            // 
            lblReturnTitle.AutoSize = true;
            lblReturnTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblReturnTitle.ForeColor = Color.LimeGreen;
            lblReturnTitle.Location = new Point(15, 22);
            lblReturnTitle.Name = "lblReturnTitle";
            lblReturnTitle.Size = new Size(205, 30);
            lblReturnTitle.TabIndex = 2;
            lblReturnTitle.Text = "🔄  Vehicle Return";
            lblReturnTitle.Click += pnlReturn_Click;
            // 
            // pnlStatus
            // 
            pnlStatus.BackColor = Color.FromArgb(17, 24, 39);
            pnlStatus.Controls.Add(lblStatus);
            pnlStatus.Dock = DockStyle.Bottom;
            pnlStatus.Location = new Point(0, 416);
            pnlStatus.Margin = new Padding(3, 4, 3, 4);
            pnlStatus.Name = "pnlStatus";
            pnlStatus.Size = new Size(756, 41);
            pnlStatus.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.FromArgb(107, 114, 128);
            lblStatus.Location = new Point(15, 11);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(318, 20);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "✅  System Ready  |  Database: VehicleRent.db";
            // 
            // MainDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            BackgroundImage = Properties.Resources.Screenshot_2026_06_13_190745;
            ClientSize = new Size(756, 457);
            Controls.Add(pnlStatus);
            Controls.Add(pnlReturn);
            Controls.Add(pnlRental);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "MainDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Vehicle Rent System - Dashboard";
            Load += MainDashboard_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlRental.ResumeLayout(false);
            pnlRental.PerformLayout();
            pnlReturn.ResumeLayout(false);
            pnlReturn.PerformLayout();
            pnlStatus.ResumeLayout(false);
            pnlStatus.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlRental;
        private System.Windows.Forms.Label lblRentalTitle;
        private System.Windows.Forms.Label lblRentalDesc;
        private System.Windows.Forms.Label lblRentalArrow;
        private System.Windows.Forms.Panel pnlReturn;
        private System.Windows.Forms.Label lblReturnTitle;
        private System.Windows.Forms.Label lblReturnDesc;
        private System.Windows.Forms.Label lblReturnArrow;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblStatus;
    }
}