namespace vehicle_rental
{
    partial class test
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
            this.sqLiteCommandBuilder1 = new System.Data.SQLite.SQLiteCommandBuilder();
            this.reports___System_Tools1 = new vehicle_rental.Reports___System_Tools();
            this.SuspendLayout();
            // 
            // sqLiteCommandBuilder1
            // 
            this.sqLiteCommandBuilder1.DataAdapter = null;
            this.sqLiteCommandBuilder1.QuoteSuffix = "]";
            // 
            // reports___System_Tools1
            // 
            this.reports___System_Tools1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(0)))), ((int)(((byte)(65)))));
            this.reports___System_Tools1.Location = new System.Drawing.Point(135, 43);
            this.reports___System_Tools1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reports___System_Tools1.Name = "reports___System_Tools1";
            this.reports___System_Tools1.Size = new System.Drawing.Size(1147, 671);
            this.reports___System_Tools1.TabIndex = 0;
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1397, 900);
            this.Controls.Add(this.reports___System_Tools1);
            this.Name = "test";
            this.Text = "test";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.SQLite.SQLiteCommandBuilder sqLiteCommandBuilder1;
        private Reports___System_Tools reports___System_Tools1;
    }
}