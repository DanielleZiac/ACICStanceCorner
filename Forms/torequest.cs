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
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using aCICSistanceCorner.Forms.GoogleAPi;

namespace aCICSistanceCorner
{
    public partial class borrow_tr : Form
    {
        private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        private static readonly string ApplicationName = "ACICStance Corner";
        private static readonly string SpreadsheetId = "1nFKEsGzUbNaWF4VJ4A1AnDinWDNkyEFlv6UTuwFNU_Y";
        private static readonly string SheetName = "ApprovalSheet";
        private SheetsService _sheetsService;
        private const string LoggedInUserFilePath = "loggedInUser.txt";
        private const int ServiceIDToDisplay = 2;
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
                        label.Text = $"                                     Item: {request[2]}\n" +
                                     $"                                     Number of Requested Item/s: {request[3]}\n\n\n" +
                                     $"                                     Status: {request[5]}";
                        label.Font = new Font(label.Font.FontFamily, textSize);
                        if (approvalStatus.Equals("Pending", StringComparison.OrdinalIgnoreCase))
                        {
                            label.Image = Properties.Resources.borrowPending;
                        }
                        else if (approvalStatus.Equals("Approved", StringComparison.OrdinalIgnoreCase))
                        {
                            label.Image = Properties.Resources.borrowApproved;
                        }
                        else
                        {
                            label.Image = Properties.Resources.borrowRejected;
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
                    if (row.Count >= 6 && row[0].ToString() == loggedInUser)
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
        public borrow_tr()
        {
            InitializeComponent();
            _sheetsService = SheetServiceInitializer.Instance;
            this.Width = 408;
            this.Height = 891;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackgroundImage = aCICSistanceCorner.Properties.Resources.SPORTS_EQUIPMENT_MAIN_2;
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
        private void tabLogo_Click(object sender, EventArgs e)
        {
            this.Close();
            HomePage home = new HomePage();
            home.Show();
        }
        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            BorrowItems borrowItems = new BorrowItems();
            borrowItems.Show();
        }
    }
}
