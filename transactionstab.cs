using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using AdminPage;

namespace aCICSistanceCorner
{
    public partial class transactionstab : Form
    {
        private static readonly string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        private static readonly string ApplicationName = "ACICStance Corner";
        private static readonly string SpreadsheetId = "1nFKEsGzUbNaWF4VJ4A1AnDinWDNkyEFlv6UTuwFNU_Y";
        private static readonly string SheetName = "TransactionSheet";
        private SheetsService _sheetsService;
        private const string LoggedInUserFilePath = "loggedInUser.txt";
        private void DisplayRequests(int textSize)
        {
            string loggedInUser = File.ReadAllText(LoggedInUserFilePath);
            IList<IList<object>> requests = FetchRequests(loggedInUser);
            if (requests != null && requests.Count > 0)
            {
                Panel panel = new Panel();
                panel.Size = new Size(350, 537);
                panel.Location = new Point(17, 210);
                panel.AutoScroll = true;
                panel.BackColor = System.Drawing.Color.FromArgb(100, System.Drawing.Color.White);
                foreach (var request in requests)
                {
                    if (request.Count >= 6)
                    {
                        Label label = new Label();
                        label.Size = new Size(329, 105);
                        label.TextAlign = ContentAlignment.MiddleLeft;
                        StringBuilder labelText = new StringBuilder();
                        labelText.AppendLine($"                                     SR-Code:                {request[0]}");
                        labelText.AppendLine($"                                     Service Type:           {GetServiceType(request[1])}");
                        labelText.AppendLine($"                                     Item/Service:           {request[2]}");
                        labelText.AppendLine($"                                     Quantity:                {request[3]}");
                        labelText.AppendLine($"                                     Date Approved:       {request[5]}");
                        label.Text = labelText.ToString();
                        label.Font = new Font(label.Font.FontFamily, textSize);
                        Image image;
                        if (int.TryParse(request[1].ToString(), out int service))
                        {
                            switch (service)
                            {
                                case 1: // Supply service
                                    image = Properties.Resources.supplyApproved;
                                    break;
                                case 2: // Borrow service
                                    image = Properties.Resources.borrowApproved;
                                    break;
                                case 3: // PDF service
                                    image = Properties.Resources.pdfApproved;
                                    break;
                                default: // Default image if service is not recognized
                                    image = null;
                                    break;
                            }
                            if (image != null)
                            {
                                label.Image = image;
                                label.ImageAlign = ContentAlignment.MiddleLeft;
                            }
                        }
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
            string range = $"{SheetName}!A:F";
            SpreadsheetsResource.ValuesResource.GetRequest request = _sheetsService.Spreadsheets.Values.Get(SpreadsheetId, range);
            ValueRange response = request.Execute();
            IList<IList<object>> approvalSheetValues = response.Values;
            string itemRange = "ItemSheet!B:C";
            SpreadsheetsResource.ValuesResource.GetRequest itemRequest = _sheetsService.Spreadsheets.Values.Get(SpreadsheetId, itemRange);
            ValueRange itemResponse = itemRequest.Execute();
            IList<IList<object>> itemSheetValues = itemResponse.Values;
            List<IList<object>> userRequests = new List<IList<object>>();
            if (approvalSheetValues != null && approvalSheetValues.Count > 0)
            {
                foreach (var row in approvalSheetValues)
                {
                    if (row.Count >= 5 && row[0].ToString() == loggedInUser)
                    {
                        string itemId = row[2].ToString();
                        string item = FindItemById(itemId, itemSheetValues);
                        row[2] = item;
                        userRequests.Add(row);
                    }
                }
            }
            return userRequests;
        }
        private string FindItemById(string itemId, IList<IList<object>> itemSheetValues)
        {
            foreach (var row in itemSheetValues)
            {
                if (row.Count >= 2 && row[0].ToString() == itemId)
                {
                    return row[1].ToString();
                }
            }

            return string.Empty;
        }

        private string GetServiceType(object serviceId)
        {
            string serviceType = string.Empty;
            if (int.TryParse(serviceId.ToString(), out int id))
            {
                string range = $"ServiceSheet!A:B";
                SpreadsheetsResource.ValuesResource.GetRequest request = _sheetsService.Spreadsheets.Values.Get(SpreadsheetId, range);
                ValueRange response = request.Execute();
                IList<IList<object>> values = response.Values;
                if (values != null)
                {
                    foreach (var row in values)
                    {
                        if (row.Count >= 2 && row[0].ToString() == serviceId.ToString())
                        {
                            serviceType = row[1].ToString();
                            break;
                        }
                    }
                }
            }
            return serviceType;
        }
        public transactionstab()
        {
            InitializeComponent();
            InitializeButtons();
            _sheetsService = SheetServiceInitializer.Instance;
            this.Width = 408;
            this.Height = 891;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackgroundImage = aCICSistanceCorner.Properties.Resources.TransactionsTab;
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
            CreateImageButton(Properties.Resources.back, Properties.Resources.back_, new Point(5, 115), back_Click);
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
        private void signOut_Click(object sender, EventArgs e)
        {
            this.Close();
            StartingPage start = new StartingPage();
            start.Show();
        }
        private void tabLogo_Click(object sender, EventArgs e)
        {
            this.Close();
            HomePage home = new HomePage();
            home.Show();
        }
        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profile profile = new Profile();
            profile.Show();
        }
    }
}
