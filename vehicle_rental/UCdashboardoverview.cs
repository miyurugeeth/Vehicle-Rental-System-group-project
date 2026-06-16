using System;

using System.Collections.Generic;

using System.Data;

using System.Drawing;

using System.Windows.Forms;

using System.Windows.Forms.DataVisualization.Charting;



namespace vehicle_rental

{

    public partial class UCdashboardoverview : UserControl

    {

        private Chart chartVehicleStatus;

        private Chart chartSalesStatus;

        private FlowLayoutPanel headerPanel;



        public UCdashboardoverview()

        {

            InitializeComponent();

            this.BackColor = Color.FromArgb(245, 247, 251);

            this.Dock = DockStyle.Fill;

        }



        private void UCdashboardoverview_Load(object sender, EventArgs e)

        {

            InitializeHeaderStats();

            InitializeFleetStatusChart();

            InitializeSalesChart();

            LoadDashboardRealtimeData();

        }



        private void InitializeHeaderStats()

        {

            headerPanel = new FlowLayoutPanel();

            headerPanel.Location = new Point(15, 15);

            headerPanel.Size = new Size(this.Width - 30, 110);

            headerPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            headerPanel.AutoScroll = true;

            this.Controls.Add(headerPanel);

        }



        private Panel CreateStatCard(string title, string value, Color accentColor)

        {

            Panel card = new Panel();

            card.Size = new Size(185, 85);

            card.BackColor = Color.White;

            card.Margin = new Padding(0, 0, 15, 0);



            card.Paint += (s, e) =>

            {

                ControlPaint.DrawBorder(e.Graphics, card.ClientRectangle, Color.FromArgb(230, 235, 245), ButtonBorderStyle.Solid);

                using (Pen p = new Pen(accentColor, 4))

                {

                    e.Graphics.DrawLine(p, 0, 0, card.Width, 0);

                }

            };



            Label lblTitle = new Label { Text = title, Font = new Font("Segoe UI", 9, FontStyle.Regular), ForeColor = Color.Gray, Location = new Point(15, 15), AutoSize = true };

            Label lblValue = new Label { Text = value, Font = new Font("Segoe UI", 18, FontStyle.Bold), ForeColor = Color.FromArgb(40, 45, 60), Location = new Point(15, 38), AutoSize = true };



            card.Controls.Add(lblTitle);

            card.Controls.Add(lblValue);

            return card;

        }



        private void InitializeFleetStatusChart()

        {

            Panel pnlChart1 = new Panel();

            pnlChart1.Size = new Size(420, 320);

            pnlChart1.Location = new Point(15, 140);

            pnlChart1.BackColor = Color.White;

            pnlChart1.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            pnlChart1.Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, pnlChart1.ClientRectangle, Color.FromArgb(230, 235, 245), ButtonBorderStyle.Solid);



            Label lblTitle = new Label { Text = "Vehicle Status", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(15, 15), AutoSize = true };

            pnlChart1.Controls.Add(lblTitle);



            chartVehicleStatus = new Chart();

            chartVehicleStatus.Size = new Size(390, 250);

            chartVehicleStatus.Location = new Point(15, 50);



            ChartArea area = new ChartArea("MainArea") { BackColor = Color.White };

            chartVehicleStatus.ChartAreas.Add(area);



            Series series = new Series("StatusSeries")

            {

                ChartType = SeriesChartType.Doughnut,

                XValueType = ChartValueType.String,

                YValueType = ChartValueType.Int32

            };



            series["PieLineColor"] = "Transparent";

            series["DoughnutRadius"] = "65";

            chartVehicleStatus.Series.Add(series);



            Legend legend = new Legend("MainLegend") { Docking = Docking.Right, Font = new Font("Segoe UI", 8) };

            chartVehicleStatus.Legends.Add(legend);



            pnlChart1.Controls.Add(chartVehicleStatus);

            this.Controls.Add(pnlChart1);

        }



        private void InitializeSalesChart()

        {

            Panel pnlChart2 = new Panel();

            pnlChart2.Size = new Size(this.Width - 465, 320);

            pnlChart2.Location = new Point(450, 140);

            pnlChart2.BackColor = Color.White;

            pnlChart2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            pnlChart2.Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, pnlChart2.ClientRectangle, Color.FromArgb(230, 235, 245), ButtonBorderStyle.Solid);



            Label lblTitle = new Label { Text = "Sales Status (Monthly Income)", Font = new Font("Segoe UI", 11, FontStyle.Bold), Location = new Point(15, 15), AutoSize = true };

            pnlChart2.Controls.Add(lblTitle);



            chartSalesStatus = new Chart();

            chartSalesStatus.Size = new Size(pnlChart2.Width - 30, 250);

            chartSalesStatus.Location = new Point(15, 50);

            chartSalesStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;



            ChartArea area = new ChartArea("SalesArea") { BackColor = Color.White };

            area.AxisX.MajorGrid.LineColor = Color.FromArgb(240, 240, 240);

            area.AxisY.MajorGrid.LineColor = Color.FromArgb(240, 240, 240);

            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8);

            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8);

            chartSalesStatus.ChartAreas.Add(area);



            Series series = new Series("IncomeSeries")

            {

                ChartType = SeriesChartType.SplineArea,

                BorderWidth = 3,

                Color = Color.FromArgb(180, 52, 152, 219),

                BorderColor = Color.FromArgb(52, 152, 219)

            };

            chartSalesStatus.Series.Add(series);



            pnlChart2.Controls.Add(chartSalesStatus);

            this.Controls.Add(pnlChart2);

        }



        public void LoadDashboardRealtimeData()

        {

            try

            {

                headerPanel.Controls.Clear();

                headerPanel.Controls.Add(CreateStatCard("Total Vehicles", DatabaseHelper.GetTotalVehiclesCount().ToString(), Color.FromArgb(52, 152, 219)));

                headerPanel.Controls.Add(CreateStatCard("Available Cars", DatabaseHelper.GetAvailableCarsCount().ToString(), Color.FromArgb(46, 204, 113)));

                headerPanel.Controls.Add(CreateStatCard("On Rent", DatabaseHelper.GetActiveRentalsCount().ToString(), Color.FromArgb(241, 196, 15)));

                headerPanel.Controls.Add(CreateStatCard("Overdues", DatabaseHelper.GetPendingReturnsCount().ToString(), Color.FromArgb(231, 76, 60)));

                headerPanel.Controls.Add(CreateStatCard("In Service", DatabaseHelper.GetVehiclesInMaintenanceCount().ToString(), Color.FromArgb(155, 89, 182)));

                headerPanel.Controls.Add(CreateStatCard("Total Users", DatabaseHelper.GetTotalUsersCount().ToString(), Color.FromArgb(149, 165, 166)));



                chartVehicleStatus.Series["StatusSeries"].Points.Clear();

                DataTable dtStatus = DatabaseHelper.GetFleetUtilization();

                if (dtStatus != null && dtStatus.Rows.Count > 0)

                {

                    foreach (DataRow row in dtStatus.Rows)

                    {

                        chartVehicleStatus.Series["StatusSeries"].Points.AddXY(row["Status"].ToString(), Convert.ToInt32(row["Count"]));

                    }

                }



                chartSalesStatus.Series["IncomeSeries"].Points.Clear();

                DataTable dtIncome = DatabaseHelper.GetMonthlyIncome();

                if (dtIncome != null && dtIncome.Rows.Count > 0)

                {

                    foreach (DataRow row in dtIncome.Rows)

                    {

                        chartSalesStatus.Series["IncomeSeries"].Points.AddXY(row["Month"].ToString(), Convert.ToDouble(row["Income"]));

                    }

                }

                else

                {

                    chartSalesStatus.Series["IncomeSeries"].Points.AddXY("Jan", 1500);

                    chartSalesStatus.Series["IncomeSeries"].Points.AddXY("Feb", 3200);

                    chartSalesStatus.Series["IncomeSeries"].Points.AddXY("Mar", 2100);

                    chartSalesStatus.Series["IncomeSeries"].Points.AddXY("Apr", 4800);

                }

            }

            catch (Exception ex)

            {

                MessageBox.Show("Error rendering dashboard data: " + ex.Message, "UI Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

    }

}