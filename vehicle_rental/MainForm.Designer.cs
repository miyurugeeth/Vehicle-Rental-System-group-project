namespace vehicle_rental
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uC_DashboardOverview1 = new vehicle_rental.UC_DashboardOverview();
            this.SuspendLayout();
            // 
            // uC_DashboardOverview1
            // 
            this.uC_DashboardOverview1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(27)))), ((int)(((byte)(66)))));
            this.uC_DashboardOverview1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_DashboardOverview1.Location = new System.Drawing.Point(0, 0);
            this.uC_DashboardOverview1.Name = "uC_DashboardOverview1";
            this.uC_DashboardOverview1.Size = new System.Drawing.Size(1085, 620);
            this.uC_DashboardOverview1.TabIndex = 0;
            this.uC_DashboardOverview1.Load += new System.EventHandler(this.uC_DashboardOverview1_Load);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 620);
            this.Controls.Add(this.uC_DashboardOverview1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private UC_DashboardOverview uC_DashboardOverview1;
    }
}