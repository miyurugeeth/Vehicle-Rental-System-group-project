using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vehicle_rental
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
<<<<<<< HEAD
            AppDomain.CurrentDomain.SetData("DataDirectory", Application.StartupPath);
=======
>>>>>>> origin/BillingSystem
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.SetData("DataDirectory",Application.StartupPath
   );
<<<<<<< HEAD
            Application.Run(new LoginForm());
=======
            Application.Run(new Test2());
>>>>>>> origin/BillingSystem
        }
    }
}
