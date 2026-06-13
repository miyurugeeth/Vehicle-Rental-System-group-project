namespace VehicleRentSystem
{
    public partial class MainDashboard : Form
    {
        public MainDashboard()
        {
            InitializeComponent();

            DatabaseHelper.InitializeDatabase();
        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {
            lblStatus.Text = $"✅  System Ready  |  Database: VehicleRent.db  |  {DateTime.Now:yyyy-MM-dd}";
        }

        private void pnlRental_Click(object sender, EventArgs e)
        {
            OpenRental();
        }

        private void pnlReturn_Click(object sender, EventArgs e)
        {
            OpenReturn();
        }

        private void OpenRental()
        {
            new RentalForm().ShowDialog();
        }

        private void OpenReturn()
        {
            new ReturnForm().ShowDialog();
        }
    }
}