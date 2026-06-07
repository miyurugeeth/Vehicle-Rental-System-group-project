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
            this.uC_VehicleFleetDashboard1 = new vehicle_rental.UC_VehicleFleetDashboard();
            this.SuspendLayout();
            // 
            // uC_VehicleFleetDashboard1
            // 
            this.uC_VehicleFleetDashboard1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.uC_VehicleFleetDashboard1.Location = new System.Drawing.Point(3, 1);
            this.uC_VehicleFleetDashboard1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uC_VehicleFleetDashboard1.Name = "uC_VehicleFleetDashboard1";
            this.uC_VehicleFleetDashboard1.Size = new System.Drawing.Size(1104, 779);
            this.uC_VehicleFleetDashboard1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 784);
            this.Controls.Add(this.uC_VehicleFleetDashboard1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private UC_VehicleFleetDashboard uC_VehicleFleetDashboard1;
    }
}