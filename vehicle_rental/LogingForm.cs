using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace vehicle_rental
{

        public partial class LogingForm : Form
        {
            // වෘත්තීය වර්ණ (Professional Color Palette)
            private Color primaryColor = Color.FromArgb(40, 20, 70); // තද දම්
            private Color accentPurple = Color.FromArgb(60, 30, 100); // මධ්‍යම දම්

            public LogingForm()
            {
                InitializeComponent();

                // ආරක්ෂිතව Controls සොයාගෙන පසුබිම් වර්ණ සහ ශෛලීන් සැකසීම
                StyleFormControls();
            }

            private void StyleFormControls()
            {
                // 1. වම්පස Panel එක සෙවීම සහ වර්ණ ගැන්වීම
                // (ඔබේ Designer එකේ තිබෙන නම කුමක් වුවත් මෙය ක්‍රියා කරයි)
                Control[] leftPanels = this.Controls.Find("panelLeft", true);
                Panel leftPnl = (leftPanels.Length > 0) ? (Panel)leftPanels[0] : null;

                if (leftPnl != null)
                {
                    leftPnl.BackColor = primaryColor;
                    leftPnl.Paint += PanelLeft_Paint;
                }

                // 2. දකුණු පස Panel එක සෙවීම
                Control[] rightPanels = this.Controls.Find("panelRight", true);
                Panel rightPnl = (rightPanels.Length > 0) ? (Panel)rightPanels[0] : null;

                if (rightPnl != null)
                {
                    rightPnl.BackColor = Color.White;

                    // 3. Login Button එක සෙවීම සහ හැඩගැන්වීම
                    Control[] buttons = rightPnl.Controls.Find("btnLogin", true);
                    if (buttons.Length > 0 && buttons[0] is Button btnLogin)
                    {
                        btnLogin.FlatStyle = FlatStyle.Flat;
                        btnLogin.FlatAppearance.BorderSize = 0;
                        btnLogin.BackColor = primaryColor;
                        btnLogin.ForeColor = Color.White;
                        btnLogin.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                        btnLogin.Cursor = Cursors.Hand;

                        btnLogin.MouseEnter += (s, e) => btnLogin.BackColor = accentPurple;
                        btnLogin.MouseLeave += (s, e) => btnLogin.BackColor = primaryColor;
                    }

                    // 4. දකුණු පස ඉහළින් Close (✕) බොත්තම සෑදීම
                    Button btnClose = new Button();
                    btnClose.Text = "✕";
                    btnClose.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    btnClose.ForeColor = Color.FromArgb(150, 150, 150);
                    btnClose.Size = new Size(35, 35);
                    btnClose.Location = new Point(rightPnl.Width - 45, 10);
                    btnClose.FlatStyle = FlatStyle.Flat;
                    btnClose.FlatAppearance.BorderSize = 0;
                    btnClose.Cursor = Cursors.Hand;
                    btnClose.Click += (s, e) => Application.Exit();

                    btnClose.MouseEnter += (s, e) => btnClose.ForeColor = Color.Red;
                    btnClose.MouseLeave += (s, e) => btnClose.ForeColor = Color.FromArgb(150, 150, 150);

                    rightPnl.Controls.Add(btnClose);
                }
            }

            // වම්පස Panel එක මත පාරවල් වැනි Graphics රේඛා ඇඳීම
            private void PanelLeft_Paint(object sender, PaintEventArgs e)
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                using (Pen customPen = new Pen(Color.FromArgb(30, Color.White), 3))
                {
                    customPen.DashStyle = DashStyle.Dash;

                    GraphicsPath path1 = new GraphicsPath();
                    path1.AddArc(-50, 100, 500, 500, 180, 90);
                    g.DrawPath(customPen, path1);

                    GraphicsPath path2 = new GraphicsPath();
                    path2.AddArc(-100, 50, 600, 600, 180, 90);
                    g.DrawPath(customPen, path2);
                }
            }

            // මුළු Form එකේම කොන් වටකුරු කිරීම
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                Rectangle Bounds = new Rectangle(0, 0, this.Width, this.Height);
                int CornerRadius = 16;
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddArc(Bounds.X, Bounds.Y, CornerRadius, CornerRadius, 180, 90);
                    path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y, CornerRadius, CornerRadius, 270, 90);
                    path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
                    path.AddArc(Bounds.X, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
                    path.CloseAllFigures();
                    this.Region = new Region(path);
                }
            }

            // Window එක Mouse එකෙන් Drag කිරීමට අවශ්‍ය කේතයන්
            private bool dragging = false;
            private Point startPoint = new Point(0, 0);

            protected override void OnMouseDown(MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    dragging = true;
                    startPoint = new Point(e.X, e.Y);
                }
            }

            protected override void OnMouseMove(MouseEventArgs e)
            {
                if (dragging)
                {
                    Point p = PointToScreen(e.Location);
                    Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
                }
            }

            protected override void OnMouseUp(MouseEventArgs e)
            {
                dragging = false;
            }
        }
    }