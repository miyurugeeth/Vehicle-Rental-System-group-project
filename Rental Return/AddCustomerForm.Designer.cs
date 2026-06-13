using System.Drawing;
using System.Windows.Forms;

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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblNIC = new System.Windows.Forms.Label();
            this.txtNIC = new System.Windows.Forms.TextBox();
            this.lblLicense = new System.Windows.Forms.Label();
            this.txtLicense = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(48, 25, 82);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(460, 55);

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Papyrus", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 14);
            this.lblTitle.Text = "👤  Add New Customer";

            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblName.Location = new System.Drawing.Point(15, 72);
            this.lblName.Text = "Full Name *";

            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtName.Location = new System.Drawing.Point(15, 92);
            this.txtName.Size = new System.Drawing.Size(420, 28);

            // 
            // lblNIC
            // 
            this.lblNIC.AutoSize = true;
            this.lblNIC.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblNIC.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblNIC.Location = new System.Drawing.Point(15, 132);
            this.lblNIC.Text = "NIC Number *";

            // 
            // txtNIC
            // 
            this.txtNIC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNIC.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNIC.Location = new System.Drawing.Point(15, 152);
            this.txtNIC.Size = new System.Drawing.Size(195, 28);
            this.txtNIC.MaxLength = 12;

            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblLicense.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblLicense.Location = new System.Drawing.Point(240, 132);
            this.lblLicense.Text = "License No *";

            // 
            // txtLicense
            // 
            this.txtLicense.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLicense.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLicense.Location = new System.Drawing.Point(240, 152);
            this.txtLicense.Size = new System.Drawing.Size(195, 28);

            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblPhone.Location = new System.Drawing.Point(15, 192);
            this.lblPhone.Text = "Phone *";

            // 
            // txtPhone
            // 
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhone.Location = new System.Drawing.Point(15, 212);
            this.txtPhone.Size = new System.Drawing.Size(195, 28);
            this.txtPhone.MaxLength = 10;

            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblAddress.Location = new System.Drawing.Point(15, 252);
            this.lblAddress.Text = "Address";

            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAddress.Location = new System.Drawing.Point(15, 272);
            this.txtAddress.Size = new System.Drawing.Size(420, 28);

            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(102, 51, 153);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(120, 318);
            this.btnSave.Size = new System.Drawing.Size(160, 38);
            this.btnSave.Text = "✔  Save Customer";
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(160, 130, 195);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(295, 318);
            this.btnCancel.Size = new System.Drawing.Size(100, 38);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // 
            // AddCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 242, 250);
            this.ClientSize = new System.Drawing.Size(460, 375);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Customer";

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.pnlHeader, this.lblName, this.txtName, this.lblNIC, this.txtNIC,
                this.lblLicense, this.txtLicense, this.lblPhone, this.txtPhone,
                this.lblAddress, this.txtAddress, this.btnSave, this.btnCancel
            });
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle, lblName, lblNIC, lblLicense, lblPhone, lblAddress;
        private System.Windows.Forms.TextBox txtName, txtNIC, txtLicense, txtPhone, txtAddress;
        private System.Windows.Forms.Button btnSave, btnCancel;
    }
}