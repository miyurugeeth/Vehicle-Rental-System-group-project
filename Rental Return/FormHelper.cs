using System.Drawing;
using System.Windows.Forms;

namespace VehicleRentSystem
{
    public static class FormHelper
    {
        // AddCustomerForm එකේ තිබුණු lbl function එක
        public static void SetupLabel(Label l, string text, Point location)
        {
            l.AutoSize = true;
            l.Font = new Font("Calibri", 10F);
            l.ForeColor = Color.FromArgb(55, 65, 81);
            l.Location = location;
            l.Text = text;
        }

        // AddCustomerForm එකේ තිබුණු txt function එක
        public static void SetupTextBox(TextBox t, Point location, int width)
        {
            t.BorderStyle = BorderStyle.FixedSingle;
            t.Font = new Font("Segoe UI", 10F);
            t.Location = location;
            t.Size = new Size(width, 28);
        }

        // ReturnForm එකේ තිබුණු ro (ReadOnly) function එක
        public static int SetupReadOnlyTextBox(TextBox tb)
        {
            tb.ReadOnly = true;
            tb.BackColor = Color.FromArgb(243, 240, 248);
            tb.BorderStyle = BorderStyle.FixedSingle;
            tb.Font = new Font("Segoe UI", 9.5F);
            return 0;
        }
    }
}