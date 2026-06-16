namespace vehicle_rental
{
    partial class test2
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
            this.ucRental_Return1 = new vehicle_rental.UCRental_Return();
            this.SuspendLayout();
            // 
            // ucRental_Return1
            // 
            this.ucRental_Return1.Location = new System.Drawing.Point(50, 12);
            this.ucRental_Return1.Name = "ucRental_Return1";
            this.ucRental_Return1.Size = new System.Drawing.Size(1299, 798);
            this.ucRental_Return1.TabIndex = 0;
            // 
            // test2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 851);
            this.Controls.Add(this.ucRental_Return1);
            this.Name = "test2";
            this.Text = "test2";
            this.ResumeLayout(false);

        }

        #endregion

        private UCRental_Return ucRental_Return1;
    }
}