using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace vehicle_rental
{
    public partial class Reports___System_Tools : UserControl
    {
        public Reports___System_Tools()
        {
            InitializeComponent();
        }

        private void Reports___System_Tools_Load(object sender, EventArgs e)
        {
            // ==========================================================
            // 1. MONTHLY INCOME CHART STYLING (චාර්ට් එක ලස්සන කරන කොටස)
            // ==========================================================
            chartIncome.BackColor = Color.Transparent;
            chartIncome.ChartAreas[0].BackColor = Color.Transparent;
            chartIncome.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartIncome.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chartIncome.ChartAreas[0].AxisX.LineColor = Color.Transparent;
            chartIncome.ChartAreas[0].AxisY.LineColor = Color.Transparent;
            chartIncome.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            chartIncome.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
            chartIncome.Legends[0].Enabled = false;
            chartIncome.Series[0].Palette = ChartColorPalette.None;
            chartIncome.Series[0].Color = Color.FromArgb(171, 112, 247);

            // ==========================================================
            // 2. FLEET UTILIZATION CHART STYLING
            // ==========================================================
            chartFleet.BackColor = Color.Transparent;
            chartFleet.ChartAreas[0].BackColor = Color.Transparent;
            chartFleet.Legends[0].Enabled = false;
            chartFleet.Series[0].ChartType = SeriesChartType.Doughnut;
            chartFleet.Palette = ChartColorPalette.None;
            chartFleet.PaletteCustomColors = new Color[] {
                Color.FromArgb(203, 161, 250),
                Color.FromArgb(146, 95, 219),
                Color.FromArgb(94, 43, 168)
            };
            chartFleet.Series[0]["PieRadius"] = "80";
            chartFleet.Series[0]["DoughnutRadius"] = "50";

            // ==========================================================
            // 3. DATABASE එකෙන් ඩේටා අරන් CHART වලට දාන මෙතඩ් එක CALL කිරීම
            // ==========================================================
            LoadChartData();
        }

        // 👈 මේක තමා ඩේටාබේස් එකෙන් ඩේටා අදින අලුත් මෙතඩ් එක
        private void LoadChartData()
        {
            try
            {
                // A. Monthly Income Chart එකට ඩේටා ලෝඩ් කිරීම
                DataTable dtIncome = DatabaseHelper.GetMonthlyIncome();
                chartIncome.Series[0].Points.Clear(); // කලින් තිබ්බ ඩමි දත්ත මකනවා

                foreach (DataRow row in dtIncome.Rows)
                {
                    string month = row["Month"].ToString();
                    double income = Convert.ToDouble(row["Income"]);
                    chartIncome.Series[0].Points.AddXY(month, income); // චාර්ට් එකට දත්ත දානවා
                }

                // B. Fleet Utilization Chart එකට ඩේටා ලෝඩ් කිරීම
                DataTable dtFleet = DatabaseHelper.GetFleetUtilization();
                chartFleet.Series[0].Points.Clear();

                foreach (DataRow row in dtFleet.Rows)
                {
                    string status = row["Status"].ToString();
                    int count = Convert.ToInt32(row["Count"]);
                    chartFleet.Series[0].Points.AddXY(status, count);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading charts: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // පල්ලෙහා තියෙන හිස් Event ටික මකන්න එපා, ඩිසයිනර් එකේ Error එන්න පුළුවන් නිසා
        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e) { }
        private void guna2ShadowPanel1_Paint_1(object sender, PaintEventArgs e) { }
        private void chart2_Click(object sender, EventArgs e) { }
        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e) { }
        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e) { }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // 1. දින වකවානු සහ රිපෝට් වර්ගය ලබාගැනීම
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;
            string reportType = "Rental History Log";

            // 2. ඩේටාබේස් එකෙන් දත්ත ලබාගැනීම
            string query = $"SELECT * FROM Rentals WHERE RentDate BETWEEN '{startDate:yyyy-MM-dd}' AND '{endDate:yyyy-MM-dd}'";
            DataTable dtReport = DatabaseHelper.ExecuteQuery(query, null);

            if (dtReport == null || dtReport.Rows.Count == 0)
            {
                MessageBox.Show("තෝරාගත් දින පරාසය තුළ කිසිදු දත්තයක් නොමැත!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. PDF එක Save කරගන්න Dialog එකක් පෙන්වීම
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF Files (*.pdf)|*.pdf";
            sfd.FileName = "Rental_Report_" + DateTime.Now.ToString("yyyyMMdd") + ".pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 4. PDF Document එකක් නිර්මාණය කිරීම
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 20f, 20f);
                    PdfWriter.GetInstance(pdfDoc, new FileStream(sfd.FileName, FileMode.Create));

                    pdfDoc.Open();

                    // 5. රිපෝට් එකේ ප්‍රධාන මාතෘකාව (Title) ඇතුළත් කිරීම
                    Paragraph title = new Paragraph($"{reportType}\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK));
                    title.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(title);

                    // දින පරාසය දැක්වීම
                    Paragraph period = new Paragraph($"Period: {startDate.ToShortDateString()} To {endDate.ToShortDateString()}\n\n", FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.DARK_GRAY));
                    period.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(period);

                    // 6. PDF Table එකක් සෑදීම (ඩේටාබේස් ටේබල් එකේ තියෙන Columns ගාණට)
                    PdfPTable pdfTable = new PdfPTable(dtReport.Columns.Count);
                    pdfTable.WidthPercentage = 100; // පිටුව පුරාම පේන්න

                    // Table Headers (තීරුවල නම්) ඇතුළත් කිරීම
                    foreach (DataColumn column in dtReport.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)));
                        cell.BackgroundColor = new BaseColor(240, 240, 240); // ලස්සනට අළු පාටක් දානවා
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        pdfTable.AddCell(cell);
                    }

                    // Table Data (ඩේටා පේළි) ඇතුළත් කිරීම
                    foreach (DataRow row in dtReport.Rows)
                    {
                        foreach (var cellValue in row.ItemArray)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(cellValue.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 9)));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            pdfTable.AddCell(cell);
                        }
                    }

                    // 7. ටේබල් එක PDF එකට එකතු කර Document එක Close කිරීම
                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();

                    MessageBox.Show("PDF රිපෝට් එක සාර්ථකව සාදා Save කරන ලදී මචං!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("PDF එක හදද්දී ප්‍රශ්නයක් වුණා: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportCSV_Click_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV Files (*.csv)|*.csv";
            sfd.FileName = "Rental_Report.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Rentals ටේබල් එකේ ඔක්කොම දත්ත ගන්නවා
                DataTable dt = DatabaseHelper.ExecuteQuery("SELECT * FROM Rentals", null);
                StringBuilder sb = new StringBuilder();

                // Column හිස්වැසුම් (Headers) ටික එකතු කිරීම
                IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
                sb.AppendLine(string.Join(",", columnNames));

                // පේළි වල තියෙන දත්ත (Data Rows) එකතු කිරීම
                foreach (DataRow row in dt.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                    sb.AppendLine(string.Join(",", fields));
                }

                System.IO.File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                MessageBox.Show("CSV රිපෝට් එක සාර්ථකව Excel එකක් විදියට සේව් කරා මචං!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}