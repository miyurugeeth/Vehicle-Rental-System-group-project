using System;
using System.Drawing;
using System.Windows.Forms;

namespace VehicleRentSystem
{
    public class MainDashboard : Form
    {
        public MainDashboard()
        {
            InitializeUI();
            DatabaseHelper.InitializeDatabase();
        }

        private void InitializeUI()
        {
            this.Text            = "Vehicle Rent System - Dashboard";
            this.Size            = new Size(700, 480);
            this.StartPosition   = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.BackColor       = Color.FromArgb(245, 247, 250);

            var pnlHeader = new Panel
            {
                Dock      = DockStyle.Top,
                Height    = 90,
                BackColor = Color.FromArgb(17, 24, 39)
            };

            var lblTitle = new Label
            {
                Text      = "🚘  Vehicle Rent System",
                ForeColor = Color.White,
                Font      = new Font("Segoe UI", 20f, FontStyle.Bold),
                Location  = new Point(25, 15),
                AutoSize  = true
            };

            var lblSub = new Label
            {
                Text      = "Vehicle Rental Management System",
                ForeColor = Color.FromArgb(156, 163, 175),
                Font      = new Font("Segoe UI", 10f),
                Location  = new Point(27, 55),
                AutoSize  = true
            };

            pnlHeader.Controls.AddRange(new Control[] { lblTitle, lblSub });

            int cardY = 120;
            int cardH = 140;

            var pnlRental = MakeCard(
                new Point(50, cardY), new Size(270, cardH),
                "🚗  Vehicle Rental",
                "Register a new rental\nSelect available vehicles\nAssign to a customer",
                Color.FromArgb(30, 58, 138)
            );
            pnlRental.Click += (s, e) => OpenRental();
            foreach (Control c in pnlRental.Controls) c.Click += (s, e) => OpenRental();

            var pnlReturn = MakeCard(
                new Point(370, cardY), new Size(270, cardH),
                "🔄  Vehicle Return",
                "Process a vehicle return\nCalculate extra day charges\nConfirm payment",
                Color.FromArgb(5, 122, 85)
            );
            pnlReturn.Click += (s, e) => OpenReturn();
            foreach (Control c in pnlReturn.Controls) c.Click += (s, e) => OpenReturn();

            var pnlStatus = new Panel
            {
                Dock      = DockStyle.Bottom,
                Height    = 35,
                BackColor = Color.FromArgb(17, 24, 39)
            };

            var lblStatus = new Label
            {
                Text      = $"✅  System Ready  |  Database: VehicleRent.db  |  {DateTime.Now:yyyy-MM-dd}",
                ForeColor = Color.FromArgb(107, 114, 128),
                Font      = new Font("Segoe UI", 9f),
                Location  = new Point(15, 9),
                AutoSize  = true
            };
            pnlStatus.Controls.Add(lblStatus);

            this.Controls.AddRange(new Control[] { pnlHeader, pnlRental, pnlReturn, pnlStatus });
        }

        private Panel MakeCard(Point loc, Size size, string title, string desc, Color color)
        {
            var pnl = new Panel { Location = loc, Size = size, BackColor = color, Cursor = Cursors.Hand };

            var lblTitle = new Label
            {
                Text      = title,
                ForeColor = Color.White,
                Font      = new Font("Segoe UI", 13f, FontStyle.Bold),
                Location  = new Point(15, 18),
                AutoSize  = true
            };

            var lblDesc = new Label
            {
                Text      = desc,
                ForeColor = Color.FromArgb(200, 230, 200),
                Font      = new Font("Segoe UI", 8.5f),
                Location  = new Point(15, 55),
                Size      = new Size(240, 70)
            };

            var lblArrow = new Label
            {
                Text      = "▶  Open",
                ForeColor = Color.White,
                Font      = new Font("Segoe UI", 9f, FontStyle.Bold),
                Location  = new Point(15, 112),
                AutoSize  = true
            };

            pnl.Controls.AddRange(new Control[] { lblTitle, lblDesc, lblArrow });
            return pnl;
        }

        private void OpenRental() { new RentalForm().ShowDialog(); }
        private void OpenReturn() { new ReturnForm().ShowDialog(); }
    }
}
