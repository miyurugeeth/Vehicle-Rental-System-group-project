namespace vehicle_rental
{
    partial class UC_SystemOverview
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalFleet = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ActiveRentals = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMaintenance = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPendingReturns = new System.Windows.Forms.Label();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label1.Location = new System.Drawing.Point(34, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "System Overview";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Fleet Size";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.lblTotalFleet);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Location = new System.Drawing.Point(41, 165);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(200, 100);
            this.guna2Panel1.TabIndex = 2;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.lblPendingReturns);
            this.guna2Panel2.Controls.Add(this.label8);
            this.guna2Panel2.Location = new System.Drawing.Point(843, 165);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(200, 100);
            this.guna2Panel2.TabIndex = 3;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.lblMaintenance);
            this.guna2Panel3.Controls.Add(this.label6);
            this.guna2Panel3.Location = new System.Drawing.Point(552, 165);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(200, 100);
            this.guna2Panel3.TabIndex = 3;
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.Controls.Add(this.ActiveRentals);
            this.guna2Panel4.Controls.Add(this.label4);
            this.guna2Panel4.Location = new System.Drawing.Point(285, 165);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(200, 100);
            this.guna2Panel4.TabIndex = 3;
            // 
            // lblTotalFleet
            // 
            this.lblTotalFleet.AutoSize = true;
            this.lblTotalFleet.Location = new System.Drawing.Point(75, 59);
            this.lblTotalFleet.Name = "lblTotalFleet";
            this.lblTotalFleet.Size = new System.Drawing.Size(44, 16);
            this.lblTotalFleet.TabIndex = 2;
            this.lblTotalFleet.Text = "label3";
            this.lblTotalFleet.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Active Rentals";
            // 
            // ActiveRentals
            // 
            this.ActiveRentals.AutoSize = true;
            this.ActiveRentals.Location = new System.Drawing.Point(77, 59);
            this.ActiveRentals.Name = "ActiveRentals";
            this.ActiveRentals.Size = new System.Drawing.Size(44, 16);
            this.ActiveRentals.TabIndex = 4;
            this.ActiveRentals.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Pending Returns (Today)";
            // 
            // lblMaintenance
            // 
            this.lblMaintenance.AutoSize = true;
            this.lblMaintenance.Location = new System.Drawing.Point(71, 59);
            this.lblMaintenance.Name = "lblMaintenance";
            this.lblMaintenance.Size = new System.Drawing.Size(44, 16);
            this.lblMaintenance.TabIndex = 6;
            this.lblMaintenance.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Vehicles in Maintenance";
            // 
            // lblPendingReturns
            // 
            this.lblPendingReturns.AutoSize = true;
            this.lblPendingReturns.Location = new System.Drawing.Point(82, 59);
            this.lblPendingReturns.Name = "lblPendingReturns";
            this.lblPendingReturns.Size = new System.Drawing.Size(44, 16);
            this.lblPendingReturns.TabIndex = 8;
            this.lblPendingReturns.Text = "label9";
            // 
            // guna2DataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.guna2DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.guna2DataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.Location = new System.Drawing.Point(55, 362);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.RowHeadersWidth = 51;
            this.guna2DataGridView1.RowTemplate.Height = 24;
            this.guna2DataGridView1.Size = new System.Drawing.Size(1048, 424);
            this.guna2DataGridView1.TabIndex = 4;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 4;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 24;
            // 
            // UC_SystemOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2DataGridView1);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel4);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.label1);
            this.Name = "UC_SystemOverview";
            this.Size = new System.Drawing.Size(1142, 820);
            this.Load += new System.EventHandler(this.UC_SystemOverview_Load_1);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            this.guna2Panel4.ResumeLayout(false);
            this.guna2Panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblTotalFleet;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label lblPendingReturns;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private System.Windows.Forms.Label lblMaintenance;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private System.Windows.Forms.Label ActiveRentals;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
    }
}
