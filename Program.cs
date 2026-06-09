using System;
using System.Windows.Forms;

namespace VehicleRentSystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                DatabaseHelper.InitializeDatabase();
                Application.Run(new MainDashboard());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Startup Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
