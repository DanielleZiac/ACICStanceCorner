using aCICSistanceCorner.Forms.GoogleAPi;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace aCICSistanceCorner
{
    public partial class marketplace : Form
    {
        private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        private static readonly string ApplicationName = "ACICStance Corner";
        private static readonly string SpreadsheetId = "1nFKEsGzUbNaWF4VJ4A1AnDinWDNkyEFlv6UTuwFNU_Y";
        private static readonly string SheetName = "ApprovalSheet";
        private SheetsService _sheetsService;
        public marketplace()
        {
            InitializeComponent();
            _sheetsService = SheetServiceInitializer.Instance;
            this.Width = 408;
            this.Height = 891;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackgroundImage = aCICSistanceCorner.Properties.Resources.SCHOOL_SUPPLIES_MAIN;
            SSpanel.BackColor = System.Drawing.Color.Transparent;
            tabShow.Visible = false;
            InitializeButtons();
        }
        private void InitializeButtons()
        {
            CreateImageButton(Properties.Resources.log0, Properties.Resources.log0_, new Point(16, 765), logo_Click);
            CreateImageButton(Properties.Resources.pencil, Properties.Resources.pencil_, new Point(90, 765), pencil_Click);
            CreateImageButton(Properties.Resources.basketball, Properties.Resources.basketball_, new Point(160, 765), basketball_Click);
            CreateImageButton(Properties.Resources.paper, Properties.Resources.paper_, new Point(240, 765), paper_Click);
            CreateImageButton(Properties.Resources.account, Properties.Resources.account_, new Point(315, 765), account_Click);
            CreateImageButton(Properties.Resources.log0, Properties.Resources.log0_, new Point(5, 40), tabLogo_Click);
            CreateImageButton(Properties.Resources.addtocart, Properties.Resources.addtocart_, new Point(320, 130), cart_Click);
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
            this.Close(); // Hide the current form

            // Show the homepage form
            Profile profile = new Profile();
            profile.Show();
        }
        private void tabLogo_Click(object sender, EventArgs e)
        {
            this.Close();
            HomePage home = new HomePage();
            home.Show();
        }
        private void cart_Click(object sender, EventArgs e)
        {
            this.Hide();
            toreceive recievewindow = new toreceive();
            recievewindow.Show();
        }
        private void SetProductDetails(string productName, Image productImage)
        {
            productimage.Image = productImage;
            productname.Text = productName;
            productname.BackColor = System.Drawing.Color.Transparent;
            int availableStocks = GetAvailableStocks(productName); // Fetch the available stocks dynamically
            availablestocks.Text = "Stocks: " + availableStocks;
            availablestocks.BackColor = System.Drawing.Color.Transparent;
            productname.Font = new Font("Arial", 12, FontStyle.Bold);
            availablestocks.Font = new Font("Arial", 10, FontStyle.Regular);
        }
        private void AnimateAndSetDetails(Button button, Bitmap initialImage, Bitmap finalImage, string productName)
        {
            button.Image = initialImage;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += (s, args) =>
            {
                button.Image = finalImage;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
            tabShow.Visible = true;
            SetProductDetails(productName, finalImage);
        }
        private void pen_Click(object sender, EventArgs e)
        {
            AnimateAndSetDetails(pen, Properties.Resources.pen_, Properties.Resources.pen, "Ballpen");
        }

        private void eraser_Click(object sender, EventArgs e)
        {
            AnimateAndSetDetails(eraser, Properties.Resources.eraser_, Properties.Resources.eraser, "Eraser");
        }

        private void notebook_Click(object sender, EventArgs e)
        {
            AnimateAndSetDetails(notebook, Properties.Resources.notebook_, Properties.Resources.notebook, "Notebook");
        }

        private void sbond_Click(object sender, EventArgs e)
        {
            AnimateAndSetDetails(sbond, Properties.Resources.sbond_, Properties.Resources.sbond, "Short Bond");
        }

        private void lbond_Click(object sender, EventArgs e)
        {
            AnimateAndSetDetails(lbond, Properties.Resources.lbond_, Properties.Resources.lbond, "Long Bond");
        }

        private void ypad_Click(object sender, EventArgs e)
        {
            AnimateAndSetDetails(ypad, Properties.Resources.ypad_, Properties.Resources.ypad, "Yellow Pad");
        }

        private void halfIndex_Click(object sender, EventArgs e)
        {
            AnimateAndSetDetails(halfIndex, Properties.Resources.halfIndex_, Properties.Resources.halfIndex, "1/2 Index");
        }

        private void quarterIndex_Click(object sender, EventArgs e)
        {
            AnimateAndSetDetails(quarterIndex, Properties.Resources.quarterIndex_, Properties.Resources.quarterIndex, "1/4 Index");
        }

        private void cTape_Click(object sender, EventArgs e)
        {
            AnimateAndSetDetails(cTape, Properties.Resources.cTape_, Properties.Resources.cTape, "Correction Tape");
        }

        private void pencilItem_Click(object sender, EventArgs e)
        {
            AnimateAndSetDetails(pencilItem, Properties.Resources.pencilItem_, Properties.Resources.pencilItem, "Pencil");
        }

        private void sharpener_Click(object sender, EventArgs e)
        {
            AnimateAndSetDetails(sharpener, Properties.Resources.sharpener_, Properties.Resources.sharpener, "Sharpener");
        }

        private void paste_Click(object sender, EventArgs e)
        {
            AnimateAndSetDetails(paste, Properties.Resources.paste_, Properties.Resources.paste, "Paste");
        }
        private int GetAvailableStocks(string productName)
        {
            string range = "ItemSheet!B:D";
            try
            {
                SpreadsheetsResource.ValuesResource.GetRequest request = _sheetsService.Spreadsheets.Values.Get(SpreadsheetId, range);
                ValueRange response = request.Execute();
                IList<IList<object>> values = response.Values;
                if (values != null && values.Count > 0)
                {
                    for (int i = 0; i < values.Count; i++)
                    {
                        if (values[i].Count >= 3 && values[i][1].ToString() == productName)
                        {
                            return Convert.ToInt32(values[i][2]);
                        }
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching data from ItemSheet: " + ex.Message, "Error");
                return 0;
            }
        }
        private void addcart_Click(object sender, EventArgs e)
        {
            addcart.Image = Properties.Resources.addcart_;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += (s, args) =>
            {
                addcart.Image = Properties.Resources.addcart;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
            string loggedInUser = File.ReadAllText("loggedInUser.txt");
            int serviceId = GetServiceId("School Supplies");
            if (serviceId == -1)
            {
                return;
            }
            int itemId = GetItemId(productname.Text);
            if (itemId == -1)
            {
                MessageBox.Show("Product not found in the ItemSheet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int quantity = (int)quantityCounter.Value;
            if (quantity == 0)
            {
                MessageBox.Show("Please enter a quantity greater than 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime currentDate = DateTime.Now;
            try
            {
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
                ValueRange stockValue = new ValueRange(); // Update Stock (quantity)
                stockValue.Values = new List<IList<object>> { new List<object> { quantity } };
                string stockRange = $"{SheetName}!D{lastRow}";
                stockValue.Range = stockRange;
                updateValues.Add(stockValue);
                ValueRange dateValue = new ValueRange(); //Update Date
                dateValue.Values = new List<IList<object>> { new List<object> { currentDate.ToString() } };
                string dateRange = $"{SheetName}!E{lastRow}";
                dateValue.Range = dateRange;
                updateValues.Add(dateValue);
                ValueRange approvalValue = new ValueRange(); // Update For Approval
                approvalValue.Values = new List<IList<object>> { new List<object> { "Pending" } };
                string approvalRange = $"{SheetName}!F{lastRow}";
                approvalValue.Range = approvalRange;
                updateValues.Add(approvalValue);
                BatchUpdateValuesRequest batchUpdateRequest = new BatchUpdateValuesRequest(); // Update the new row with SRCode, ServiceID, ItemID, Stock (quantity), Request Date, and For Approval
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
        private int GetServiceId(string programName)
        {
            programName = "School Supplies";
            // Define the range for fetching data from the ServiceSheet
            string range = "ServiceSheet!A:B"; // Assuming ServiceID is in column A and Service is in column B
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
        private void xbutton_Click_1(object sender, EventArgs e)
        {
            xbutton.Image = Properties.Resources.x_;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += (s, args) =>
            {
                xbutton.Image = Properties.Resources.x;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
            tabShow.Visible = false;
        }
    }
}
