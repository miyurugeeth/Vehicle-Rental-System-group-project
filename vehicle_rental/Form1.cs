using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vehicle_rental
{
    public partial class panelCard : Form
    {
        public panelCard()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            panelCard.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panelCard.Width, panelCard.Height, 20, 20));
        }
    }
}
