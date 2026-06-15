namespace vehicle_rental
{
    partial class Test2
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
            this.uC_PaymentsBilling1 = new vehicle_rental.UC_PaymentsBilling();
            this.SuspendLayout();
            // 
            // uC_PaymentsBilling1
            // 
            this.uC_PaymentsBilling1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(25)))), ((int)(((byte)(50)))));
            this.uC_PaymentsBilling1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uC_PaymentsBilling1.ForeColor = System.Drawing.Color.White;
            this.uC_PaymentsBilling1.Location = new System.Drawing.Point(33, -2);
            this.uC_PaymentsBilling1.Margin = new System.Windows.Forms.Padding(4);
            this.uC_PaymentsBilling1.Name = "uC_PaymentsBilling1";
            this.uC_PaymentsBilling1.Size = new System.Drawing.Size(1088, 704);
            this.uC_PaymentsBilling1.TabIndex = 0;
            // 
            // Test2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 704);
            this.Controls.Add(this.uC_PaymentsBilling1);
            this.Name = "Test2";
            this.Text = "Test2";
            this.ResumeLayout(false);

        }

        #endregion

        private UC_PaymentsBilling uC_PaymentsBilling1;
    }
}