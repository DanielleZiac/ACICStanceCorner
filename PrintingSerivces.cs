using Google.Apis.Sheets.v4.Data;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Spire.Pdf;
using System.IO;
using System.Threading;
using Google.Apis.Drive.v3;
using Google.Apis.Util.Store;
using AdminPage;

namespace aCICSistanceCorner
{
    public partial class PrintingSerivces : Form
    {
        private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        private static readonly string ApplicationName = "ACICStance Corner";
        private static readonly string SpreadsheetId = "1nFKEsGzUbNaWF4VJ4A1AnDinWDNkyEFlv6UTuwFNU_Y";
        private static readonly string SheetName = "ApprovalSheet";
        private SheetsService _sheetsService;
        private const string LoggedInUserFilePath = "loggedInUser.txt";
        private const int ServiceIDToDisplay = 3;
        private void DisplayRequests(int textSize)
        {
            string loggedInUser = File.ReadAllText(LoggedInUserFilePath);
            IList<IList<object>> requests = FetchRequests(loggedInUser);
            if (requests != null && requests.Count > 0)
            {
                Panel panel = new Panel();
                panel.Size = new Size(350, 410);
                panel.Location = new Point(17, 190);
                panel.AutoScroll = true;
                panel.BackColor = System.Drawing.Color.FromArgb(100, System.Drawing.Color.White);
                foreach (var request in requests)
                {
                    int serviceId = Convert.ToInt32(request[1]);
                    string approvalStatus = Convert.ToString(request[5]);

                    if (serviceId == ServiceIDToDisplay &&
                        (approvalStatus.Equals("Pending", StringComparison.OrdinalIgnoreCase) ||
                        approvalStatus.Equals("Approved", StringComparison.OrdinalIgnoreCase) ||
                        approvalStatus.Equals("Rejected", StringComparison.OrdinalIgnoreCase)))
                    {
                        Label label = new Label();
                        label.Size = new Size(329, 105);
                        label.TextAlign = ContentAlignment.MiddleLeft;
                        label.Text = $"                                     Filename: {request[6]}\n" +
                                     $"                                     Number of Pages: {request[3]}\n\n\n" +
                                     $"                                     Status: {request[5]}";
                        label.Font = new Font(label.Font.FontFamily, textSize);
                        if (approvalStatus.Equals("Pending", StringComparison.OrdinalIgnoreCase))
                        {
                            label.Image = Properties.Resources.pdfPending;
                        }
                        else if (approvalStatus.Equals("Approved", StringComparison.OrdinalIgnoreCase))
                        {
                            label.Image = Properties.Resources.pdfApproved;
                        }
                        else
                        {
                            label.Image = Properties.Resources.pdfRejected;
                        }
                        label.ImageAlign = ContentAlignment.MiddleLeft;
                        panel.Controls.Add(label);
                        label.Location = new Point(0, (panel.Controls.Count - 1) * (label.Height + 10));

                    }
                }
                Controls.Add(panel);
            }
            else
            {
                MessageBox.Show("No requests found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private IList<IList<object>> FetchRequests(string loggedInUser)
        {
            string range = $"{SheetName}!A:G";
            SpreadsheetsResource.ValuesResource.GetRequest request = _sheetsService.Spreadsheets.Values.Get(SpreadsheetId, range);
            ValueRange response = request.Execute();
            IList<IList<object>> values = response.Values;
            List<IList<object>> userRequests = new List<IList<object>>();
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    if (row.Count >= 7 && row[0].ToString() == loggedInUser)
                    {
                        userRequests.Add(row);
                    }
                }
            }
            return userRequests;
        }
        public PrintingSerivces()
        {
            InitializeComponent();
            _sheetsService = SheetServiceInitializer.Instance;
            this.Width = 408;
            this.Height = 891;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackgroundImage = aCICSistanceCorner.Properties.Resources.PRINT_MAIN;
            InitializeButtons();
            DisplayRequests(6);
        }
        private void InitializeButtons()
        {
            CreateImageButton(Properties.Resources.log0, Properties.Resources.log0_, new Point(16, 765), logo_Click);
            CreateImageButton(Properties.Resources.pencil, Properties.Resources.pencil_, new Point(90, 765), pencil_Click);
            CreateImageButton(Properties.Resources.basketball, Properties.Resources.basketball_, new Point(160, 765), basketball_Click);
            CreateImageButton(Properties.Resources.paper, Properties.Resources.paper_, new Point(240, 765), paper_Click);
            CreateImageButton(Properties.Resources.account, Properties.Resources.account_, new Point(315, 765), account_Click);
            CreateImageButton(Properties.Resources.log0, Properties.Resources.log0_, new Point(5, 40), tabLogo_Click);
        }
        private void CreateImageButton(Image originalImage, Image clickedImage, Point location, MouseEventHandler clickEventHandler)
        {
            PictureBox button = new PictureBox();
            button.Image = originalImage;
            button.Size = originalImage.Size;
            button.Location = location;
            button.SizeMode = PictureBoxSizeMode.AutoSize;
            button.MouseDown += (sender, e) => { button.Image = clickedImage; };
            button.MouseUp += (sender, e) => { button.Image = originalImage; clickEventHandler(sender, e); };
            button.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(button);
            button.BringToFront();

        }
        private void logo_Click(object sender, EventArgs e)
        {
            this.Close();
            HomePage home = new HomePage();
            home.Show();
        }
        private void pencil_Click(object sender, EventArgs e)
        {
            this.Close();
            marketplace marketPlace = new marketplace();
            marketPlace.Show();
        }
        private void basketball_Click(object sender, EventArgs e)
        {
            this.Close();
            BorrowItems borrow = new BorrowItems();
            borrow.Show();
        }
        private void paper_Click(object sender, EventArgs e)
        {
            this.Close();
            PrintingSerivces print = new PrintingSerivces();
            print.Show();
        }
        private void account_Click(object sender, EventArgs e)
        {
            this.Close();
            Profile profile = new Profile();
            profile.Show();
        }
        private void tabLogo_Click(object sender, EventArgs e)
        {
            this.Close();
            HomePage home = new HomePage();
            home.Show();
        }
        private bool isClicked = false;
        private void borrowButton_Click(object sender, EventArgs e)
        {
            addbutton.Image = Properties.Resources.borrowButton_;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += (s, args) =>
            {
                addbutton.Image = Properties.Resources.borrowButton;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }
        private void addbutton_Click(object sender, EventArgs e)
        {
            addbutton.Image = Properties.Resources.add_;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += (s, args) =>
            {
                addbutton.Image = Properties.Resources.add;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
            string loggedInUser = System.IO.File.ReadAllText("loggedInUser.txt");
            int serviceId = GetServiceId("Printing Services");
            if (serviceId == -1)
            {
                return;
            }
            int itemId = GetItemId("Print");
            if (itemId == -1)
            {
                MessageBox.Show("Product not found in the ItemSheet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime currentDate = DateTime.Now;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                string extension = Path.GetExtension(selectedFilePath);
                if (extension != ".pdf")
                {
                    MessageBox.Show("Please select a PDF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string fileName = Path.GetFileName(selectedFilePath);
                try
                {
                    int pageCount = GetPageCount(selectedFilePath);
                    string range = $"{SheetName}!A:F";
                    SpreadsheetsResource.ValuesResource.GetRequest request = _sheetsService.Spreadsheets.Values.Get(SpreadsheetId, range);
                    ValueRange response = request.Execute();
                    IList<IList<object>> values = response.Values;
                    int lastRow = (values != null && values.Count > 0) ? values.Count + 1 : 2;
                    List<ValueRange> updateValues = new List<ValueRange>();
                    ValueRange srCodeValue = new ValueRange(); // Update SRCode
                    srCodeValue.Values = new List<IList<object>> { new List<object> { loggedInUser } };
                    string srCodeRange = $"{SheetName}!A{lastRow}";
                    srCodeValue.Range = srCodeRange;
                    updateValues.Add(srCodeValue);
                    ValueRange serviceIdValue = new ValueRange(); // Update ServiceID
                    serviceIdValue.Values = new List<IList<object>> { new List<object> { serviceId } };
                    string serviceIdRange = $"{SheetName}!B{lastRow}";
                    serviceIdValue.Range = serviceIdRange;
                    updateValues.Add(serviceIdValue);
                    ValueRange itemIdValue = new ValueRange(); // Update ItemID
                    itemIdValue.Values = new List<IList<object>> { new List<object> { itemId } };
                    string itemIdRange = $"{SheetName}!C{lastRow}";
                    itemIdValue.Range = itemIdRange;
                    updateValues.Add(itemIdValue);
                    ValueRange pageCountValue = new ValueRange(); // Update Page Count
                    pageCountValue.Values = new List<IList<object>> { new List<object> { pageCount } };
                    string pageCountRange = $"{SheetName}!D{lastRow}";
                    pageCountValue.Range = pageCountRange;
                    updateValues.Add(pageCountValue);
                    ValueRange dateValue = new ValueRange(); // Update Request Date
                    dateValue.Values = new List<IList<object>> { new List<object> { currentDate.ToString() } };
                    string dateRange = $"{SheetName}!E{lastRow}"; // Use the determined last row
                    dateValue.Range = dateRange;
                    updateValues.Add(dateValue);
                    ValueRange approvalValue = new ValueRange(); // Update For Approval
                    approvalValue.Values = new List<IList<object>> { new List<object> { "Pending" } };
                    string approvalRange = $"{SheetName}!F{lastRow}";
                    approvalValue.Range = approvalRange;
                    updateValues.Add(approvalValue);
                    ValueRange fileNameValue = new ValueRange(); // Update the G column with the filename
                    fileNameValue.Values = new List<IList<object>> { new List<object> { fileName } };
                    string fileNameRange = $"{SheetName}!G{lastRow}";
                    fileNameValue.Range = fileNameRange;
                    updateValues.Add(fileNameValue);
                    BatchUpdateValuesRequest batchUpdateRequest = new BatchUpdateValuesRequest(); // Update the new row with SRCode, ServiceID, ItemID, Page Count, Request Date, For Approval, and FileName
                    batchUpdateRequest.Data = updateValues;
                    batchUpdateRequest.ValueInputOption = "RAW";
                    BatchUpdateValuesResponse batchUpdateResponse = _sheetsService.Spreadsheets.Values.BatchUpdate(batchUpdateRequest, SpreadsheetId).Execute();
                    if (batchUpdateResponse != null && batchUpdateResponse.Responses != null && batchUpdateResponse.Responses.Count > 0)
                    {
                        MessageBox.Show("Data updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to update data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private int GetServiceId(string programName)
        {
            programName = "Printing Services";
            string range = "ServiceSheet!A:B";
            try
            {
                SpreadsheetsResource.ValuesResource.GetRequest request = _sheetsService.Spreadsheets.Values.Get(SpreadsheetId, range);
                ValueRange response = request.Execute();
                IList<IList<object>> values = response.Values;
                if (values != null && values.Count > 0)
                {
                    StringBuilder message = new StringBuilder();
                    foreach (var row in values)
                    {
                        foreach (var cell in row)
                        {
                            message.Append(cell.ToString() + "\n");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No data found in the ServiceSheet.", "Information");
                }
                if (values != null && values.Count > 0)
                {
                    for (int i = 0; i < values.Count; i++)
                    {
                        if (values[i].Count >= 2 && values[i][1].ToString() == programName)
                        {
                            return Convert.ToInt32(values[i][0]);
                        }
                    }
                }
                MessageBox.Show($"Program name '{programName}' not found in the ServiceSheet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching data from ServiceSheet: " + ex.Message, "Error");
                return -1;
            }
        }
        private int GetItemId(string productName)
        {
            productName = "Print Service";
            string range = "ItemSheet!B:C";
            try
            {
                SpreadsheetsResource.ValuesResource.GetRequest request = _sheetsService.Spreadsheets.Values.Get(SpreadsheetId, range);
                ValueRange response = request.Execute();
                IList<IList<object>> values = response.Values;
                if (values != null && values.Count > 0)
                {
                    StringBuilder message = new StringBuilder();
                    foreach (var row in values)
                    {
                        foreach (var cell in row)
                        {
                            message.Append(cell.ToString() + "\n");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No data found in the ItemSheet.", "Information");
                }
                if (values != null && values.Count > 0)
                {
                    for (int i = 0; i < values.Count; i++)
                    {
                        if (values[i].Count >= 2 && values[i][1].ToString() == productName)
                        {
                            return Convert.ToInt32(values[i][0]);
                        }
                    }
                }
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching data from ItemSheet: " + ex.Message, "Error");
                return -1;
            }
        }
        private int GetPageCount(string filePath)
        {
            try
            {
                PdfDocument pdfDoc = new PdfDocument();
                pdfDoc.LoadFromFile(filePath);
                int pageCount = pdfDoc.Pages.Count;
                pdfDoc.Close();

                return pageCount;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while getting the number of pages: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
    }
}

