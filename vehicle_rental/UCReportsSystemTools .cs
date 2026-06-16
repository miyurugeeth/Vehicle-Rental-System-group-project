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
using System.Net;
using System.Net.Mail;

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
            this.BackColor = Color.FromArgb(41, 0, 65);

            // ==========================================================
            // 1. MONTHLY INCOME CHART STYLING
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
            // 2. FLEET UTILIZATION CHART STYLING (FIXED VISIBILITY)
            // ==========================================================
            chartFleet.BackColor = Color.Transparent;
            chartFleet.ChartAreas[0].BackColor = Color.Transparent;
            
            chartFleet.Legends[0].Enabled = true;
            chartFleet.Legends[0].BackColor = Color.Transparent;
            chartFleet.Legends[0].ForeColor = Color.White;
            chartFleet.Legends[0].Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);

            chartFleet.Series[0].ChartType = SeriesChartType.Doughnut;
            chartFleet.Palette = ChartColorPalette.None;
            
            chartFleet.PaletteCustomColors = new Color[] {
                Color.FromArgb(46, 204, 113),  
                Color.FromArgb(155, 89, 182),  
                Color.FromArgb(230, 126, 34)   
            };
            chartFleet.Series[0]["PieRadius"] = "80";
            chartFleet.Series[0]["DoughnutRadius"] = "50";

            chartFleet.Series[0].IsValueShownAsLabel = true;
            chartFleet.Series[0].LabelForeColor = Color.White;
            chartFleet.Series[0].Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Bold);

            if (guna2ComboBox1.Items.Count > 0)
            {
                guna2ComboBox1.SelectedIndex = 0;
            }

            chartIncome.Cursor = Cursors.Default;
            chartFleet.Cursor = Cursors.Default;

            LoadChartData();
        }

        private void LoadChartData()
        {
            try
            {
                DataTable dtIncome = DatabaseHelper.GetMonthlyIncome();
                chartIncome.Series[0].Points.Clear();

                if (dtIncome != null)
                {
                    foreach (DataRow row in dtIncome.Rows)
                    {
                        string month = row["Month"].ToString();
                        double income = Convert.ToDouble(row["Income"]);
                        chartIncome.Series[0].Points.AddXY(month, income);
                    }
                }

                DataTable dtFleet = DatabaseHelper.GetFleetUtilization();
                chartFleet.Series[0].Points.Clear();

                if (dtFleet != null && dtFleet.Rows.Count > 0)
                {
                    foreach (DataRow row in dtFleet.Rows)
                    {
                        string status = row["Status"].ToString();
                        int count = Convert.ToInt32(row["Count"]);
                        
                        int index = chartFleet.Series[0].Points.AddXY(status, count);
                        chartFleet.Series[0].Points[index].LegendText = $"{status} ({count})";
                        chartFleet.Series[0].Points[index].Label = $"{status}: {count}";
                    }
                }
                else
                {
                    int p1 = chartFleet.Series[0].Points.AddXY("Available", 0);
                    chartFleet.Series[0].Points[p1].LegendText = "Available (0)";
                    chartFleet.Series[0].Points[p1].Label = "Available: 0";
                    
                    int p2 = chartFleet.Series[0].Points.AddXY("Rented", 0);
                    chartFleet.Series[0].Points[p2].LegendText = "Rented (0)";
                    chartFleet.Series[0].Points[p2].Label = "Rented: 0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading charts: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // 3. DYNAMIC QUERY GENERATOR
        // ==========================================================
        private string GetCustomQuery(string reportType, DateTime start, DateTime end)
        {
            string query = "";
            string sDate = start.ToString("yyyy-MM-dd");
            string eDate = end.ToString("yyyy-MM-dd");

            string rType = reportType.ToLower().Trim();

            if (rType.Contains("rental history"))
            {
                query = $@"
                    SELECT 
                        r.RentalID AS [Rental ID], 
                        r.CustomerID AS [Customer ID], 
                        c.Name AS [Customer Name], 
                        r.VehicleID AS [Vehicle ID], 
                        r.RentDate AS [Rent Date], 
                        r.ExpectedReturnDate AS [Expected Return], 
                        r.ActualReturnDate AS [Actual Return], 
                        r.TotalAmount AS [Total Amount] 
                    FROM Rentals r
                    INNER JOIN Customers c ON r.CustomerID = c.CustomerID
                    WHERE r.RentDate BETWEEN '{sDate}' AND '{eDate}'";
            }
            else if (rType.Contains("customer register"))
            {
                query = $"SELECT CustomerID, Name, NIC, LicenseNo, Phone, RegisteredDate FROM Customers WHERE RegisteredDate BETWEEN '{sDate}' AND '{eDate}'";
            }
            else if (rType.Contains("maintenance"))
            {
                query = $@"
                    SELECT 
                        v.VehicleID AS [Vehicle ID], 
                        v.VehicleNo AS [Vehicle Number], 
                        v.Brand AS [Brand], 
                        v.Model AS [Model], 
                        v.Status AS [Current Status], 
                        v.RegisteredDate AS [Registration Date],
                        COUNT(r.RentalID) AS [Total Trips Done],
                        CASE 
                            WHEN v.Status = 'Maintenance' THEN 'In Garage'
                            WHEN COUNT(r.RentalID) >= 5 THEN 'Service Due (High Usage)'
                            ELSE 'Good Condition'
                        END AS [Maintenance Evaluation]
                    FROM Vehicles v
                    LEFT JOIN Rentals r ON v.VehicleID = r.VehicleID
                    WHERE v.RegisteredDate BETWEEN '{sDate}' AND '{eDate}'
                    GROUP BY v.VehicleID, v.VehicleNo, v.Brand, v.Model, v.Status, v.RegisteredDate";
            }
            else if (rType.Contains("fleet inventory") || rType.Contains("fleet"))
            {
                query = "SELECT VehicleID, VehicleNo, Brand, Model, Type, FuelType, RentPrice, Status, RegisteredDate FROM Vehicles";
            }
            else if (rType.Contains("earnings") || rType.Contains("revenue"))
            {
                query = $"SELECT RentalID, VehicleID, RentDate, BaseAmount, LateFee, TotalAmount FROM Rentals WHERE TotalAmount > 0 AND RentDate BETWEEN '{sDate}' AND '{eDate}'";
            }
            else if (rType.Contains("overdue"))
            {
                query = $"SELECT RentalID, CustomerID, VehicleID, RentDate, ExpectedReturnDate, TotalAmount FROM Rentals WHERE ActualReturnDate IS NULL AND ExpectedReturnDate < '{DateTime.Now.ToString("yyyy-MM-dd")}'";
            }
            else
            {
                query = $"SELECT RentalID, CustomerID, VehicleID, RentDate, ExpectedReturnDate, ActualReturnDate, TotalAmount FROM Rentals WHERE RentDate BETWEEN '{sDate}' AND '{eDate}'";
            }

            return query;
        }

        // ==========================================================
        // 4. BUTTON: GENERATE PDF REPORT
        // ==========================================================
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a report type first!", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;
            string reportType = guna2ComboBox1.SelectedItem.ToString();

            string query = GetCustomQuery(reportType, startDate, endDate);
            
            // FIXED 🚀: Explicitly uses DatabaseHelper's multi-parameter query pipeline method to avoid data table mismatches
            DataTable dtReport = DatabaseHelper.ExecuteQuery(query, null);

            if (dtReport == null || dtReport.Rows.Count == 0)
            {
                MessageBox.Show("No records found for the selected date range and report type.", "No Data Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF Files (*.pdf)|*.pdf";
            sfd.FileName = reportType.Replace(" ", "_").Trim() + "_" + DateTime.Now.ToString("yyyyMMdd") + ".pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Document pdfDoc;
                    if (dtReport.Columns.Count > 6)
                    {
                        pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 20f, 20f);
                    }
                    else
                    {
                        pdfDoc = new Document(PageSize.A4, 10f, 10f, 20f, 20f);
                    }

                    PdfWriter.GetInstance(pdfDoc, new FileStream(sfd.FileName, FileMode.Create));
                    pdfDoc.Open();

                    Paragraph title = new Paragraph($"{reportType}\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK));
                    title.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(title);

                    Paragraph period = new Paragraph($"Period: {startDate.ToShortDateString()} To {endDate.ToShortDateString()}\n\n", FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.DARK_GRAY));
                    period.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(period);

                    PdfPTable pdfTable = new PdfPTable(dtReport.Columns.Count);
                    pdfTable.WidthPercentage = 100;

                    float[] widths = new float[dtReport.Columns.Count];
                    for (int i = 0; i < dtReport.Columns.Count; i++)
                    {
                        widths[i] = 1f;
                    }
                    pdfTable.SetWidths(widths);

                    foreach (DataColumn column in dtReport.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8)));
                        cell.BackgroundColor = new BaseColor(230, 230, 250);
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell.Padding = 4;
                        pdfTable.AddCell(cell);
                    }

                    foreach (DataRow row in dtReport.Rows)
                    {
                        foreach (var cellValue in row.ItemArray)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(cellValue.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 8)));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell.Padding = 3;
                            pdfTable.AddCell(cell);
                        }
                    }

                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();

                    MessageBox.Show($"{reportType} PDF report exported successfully!", "Export Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while generating the PDF: " + ex.Message, "PDF Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================================
        // 5. BUTTON: EXPORT AS CSV
        // ==========================================================
        private void btnExportCSV_Click_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedItem == null) return;

            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;
            string reportType = guna2ComboBox1.SelectedItem.ToString();

            string query = GetCustomQuery(reportType, startDate, endDate);
            
            // FIXED 🚀: Explicitly routing query through data-table adapter pipeline methods
            DataTable dt = DatabaseHelper.ExecuteQuery(query, null);

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("No data available to export!", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV Files (*.csv)|*.csv";
            sfd.FileName = reportType.Replace(" ", "_").Trim() + "_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().Select(column => $"\"{column.ColumnName}\"");
                    sb.AppendLine(string.Join(",", columnNames));

                    foreach (DataRow row in dt.Rows)
                    {
                        IEnumerable<string> fields = row.ItemArray.Select(field => {
                            string value = field.ToString().Replace("\"", "\"\""); 
                            
                            if (value.Length >= 9 && value.All(char.IsDigit))
                            {
                                return $"\"={value}\""; 
                            }
                            
                            return $"\"{value}\""; 
                        });
                        sb.AppendLine(string.Join(",", fields));
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show($"{reportType} exported as CSV successfully!", "CSV Export Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to export CSV: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================================
        // 6. BUTTON: EMAIL REPORT
        // ==========================================================
        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a report type first!", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;
            string reportType = guna2ComboBox1.SelectedItem.ToString();

            string tempFolder = Path.GetTempPath();
            string fileName = reportType.Replace(" ", "_").Trim() + "_" + DateTime.Now.ToString("yyyyMMdd") + ".pdf";
            string tempFilePath = Path.Combine(tempFolder, fileName);

            try
            {
                string query = GetCustomQuery(reportType, startDate, endDate);
                
                // FIXED 🚀: Corrected background database query stream link logic
                DataTable dtReport = DatabaseHelper.ExecuteQuery(query, null);

                if (dtReport == null || dtReport.Rows.Count == 0)
                {
                    MessageBox.Show("No records found to email.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Document pdfDoc = (dtReport.Columns.Count > 6) ?
                    new Document(PageSize.A4.Rotate(), 10f, 10f, 20f, 20f) :
                    new Document(PageSize.A4, 10f, 10f, 20f, 20f);

                PdfWriter.GetInstance(pdfDoc, new FileStream(tempFilePath, FileMode.Create));
                pdfDoc.Open();

                pdfDoc.Add(new Paragraph($"{reportType}\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18)));
                pdfDoc.Add(new Paragraph($"Period: {startDate.ToShortDateString()} To {endDate.ToShortDateString()}\n\n", FontFactory.GetFont(FontFactory.HELVETICA, 10)));

                PdfPTable pdfTable = new PdfPTable(dtReport.Columns.Count);
                pdfTable.WidthPercentage = 100;
                foreach (DataColumn column in dtReport.Columns)
                {
                    pdfTable.AddCell(new PdfPCell(new Phrase(column.ColumnName, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))));
                }
                foreach (DataRow row in dtReport.Rows)
                {
                    foreach (var cellValue in row.ItemArray)
                    {
                        pdfTable.AddCell(new PdfPCell(new Phrase(cellValue.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 8))));
                    }
                }
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("your_email@gmail.com");            
                mail.To.Add("manager_or_client@gmail.com");                    
                mail.Subject = $"Vehicle Rental System - {reportType}";
                mail.Body = $"Dear User,\n\nPlease find the attached {reportType} report for the period from {startDate.ToShortDateString()} to {endDate.ToShortDateString()}.\n\nBest Regards,\nVehicle Rental System.";

                Attachment attachment = new Attachment(tempFilePath);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new NetworkCredential("your_email@gmail.com", "your_app_password"); 
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail); 

                mail.Dispose();
                if (File.Exists(tempFilePath)) File.Delete(tempFilePath);

                MessageBox.Show($"{reportType} PDF has been emailed successfully!", "Email Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email. Error: " + ex.Message, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // 7. SYSTEM BACKUP & RESTORE MODULES
        // ==========================================================
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Backup Files (*.bak)|*.bak";
            sfd.FileName = "VehicleRental_Backup_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".bak";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string query = $"BACKUP DATABASE [vehicle_rental_db] TO DISK = '{sfd.FileName}'";
                    DatabaseHelper.ExecuteQuery(query, null);
                    MessageBox.Show("Database backup file saved successfully!", "Backup Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Backup failed. Error: " + ex.Message, "Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Backup Files (*.bak)|*.bak";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var result = MessageBox.Show("Are you sure you want to restore this backup? All current modifications will be overwritten.", "Confirm Database Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string query = $"USE master; ALTER DATABASE [vehicle_rental_db] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; RESTORE DATABASE [vehicle_rental_db] FROM DISK = '{ofd.FileName}' WITH REPLACE; ALTER DATABASE [vehicle_rental_db] SET MULTI_USER;";
                        DatabaseHelper.ExecuteQuery(query, null);
                        MessageBox.Show("Database successfully restored to the selected checkpoint!", "Restore Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Database restore operation failed: " + ex.Message, "Restore Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Scheduled Backups functionality will be available in the next version release.", "Feature Updates", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Unused Events to prevent Visual Studio designer crash
        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e) { }
        private void guna2ShadowPanel1_Paint_1(object sender, PaintEventArgs e) { }
        private void chart2_Click(object sender, EventArgs e) { }
        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e) { }
        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e) { }
        private void chartFleet_Click(object sender, EventArgs e) { }
        private void comboBoxReportType_Click(object sender, EventArgs e) { }
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e) { }
        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void guna2Separator1_Click(object sender, EventArgs e) { }
    }
}