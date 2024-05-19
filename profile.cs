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
    public partial class Profile : Form
    {
        private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        private static readonly string ApplicationName = "ACICStance Corner";
        private static readonly string SpreadsheetId = "1nFKEsGzUbNaWF4VJ4A1AnDinWDNkyEFlv6UTuwFNU_Y";
        private static readonly string SheetName = "UserAccount";
        private SheetsService _sheetsService;
        private const string LoggedInUserFilePath = "loggedInUser.txt";
        private string username;
        private string password;
        public Profile()
        {
            InitializeComponent();
            _sheetsService = SheetServiceInitializer.Instance;
            LoadCredentialsForLoggedInUser();
            this.Width = 408;
            this.Height = 891;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackgroundImage = aCICSistanceCorner.Properties.Resources.bg_;
            InitializeButtons();
            SetTextOnPictureBox(pictureBox1, username, 12);
            SetTextOnPictureBox(pictureBox2, password, 12);
        }
        private void LoadCredentialsForLoggedInUser()
        {
            string loggedInSRCode = File.ReadAllText(LoggedInUserFilePath);
            var range = $"{SheetName}!A:C";
            var request = _sheetsService.Spreadsheets.Values.Get(SpreadsheetId, range);
            var response = request.Execute();
            var values = response.Values;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    if (row.Count >= 3 && row[2].ToString() == loggedInSRCode)
                    {
                        username = row[0].ToString();
                        password = row[2].ToString();
                        break;
                    }
                }
            }
        }
        private void InitializeButtons()
        {
            CreateImageButton(Properties.Resources.log0, Properties.Resources.log0_, new Point(16, 765), logo_Click);
            CreateImageButton(Properties.Resources.pencil, Properties.Resources.pencil_, new Point(90, 765), pencil_Click);
            CreateImageButton(Properties.Resources.basketball, Properties.Resources.basketball_, new Point(160, 765), basketball_Click);
            CreateImageButton(Properties.Resources.paper, Properties.Resources.paper_, new Point(240, 765), paper_Click);
            CreateImageButton(Properties.Resources.account, Properties.Resources.account_, new Point(315, 765), account_Click);
            CreateImageButton(Properties.Resources.signOut, Properties.Resources.signOut_, new Point(36, 650), signOut_Click);
            CreateImageButton(Properties.Resources.log0, Properties.Resources.log0_, new Point(5, 40), tabLogo_Click);
        }
        private void CreateImageButton(Image originalImage, Image clickedImage, Point location, MouseEventHandler clickEventHandler)
        {
            PictureBox button = new PictureBox();
            button.Image = originalImage;
            button.Size = originalImage.Size;
            button.Location = location;
            button.SizeMode = PictureBoxSizeMode.AutoSize;
            button.MouseDown += (sender, e) =>
            {
                button.Image = clickedImage;
            };
            button.MouseUp += (sender, e) =>
            {
                button.Image = originalImage;
                clickEventHandler(sender, e);
            };
            button.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(button);
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
        private void transactions_Click(object sender, EventArgs e)
        {
            transactions.Image = Properties.Resources.transactions_;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += (s, args) =>
            {
                transactions.Image = Properties.Resources.transactions;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
            this.Close();
            transactionstab transactionstab = new transactionstab();
            transactionstab.Show();
        }
        private void SetTextOnPictureBox(PictureBox pictureBox, string text, int fontSize)
        {
            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(System.Drawing.Color.White);
                SizeF textSize = g.MeasureString(text, new Font("Arial", fontSize));
                float x = 10;
                float y = (pictureBox.Height - textSize.Height) / 2;
                g.DrawString(text, new Font("Arial", fontSize), Brushes.Black, new PointF(x, y));
            }
            pictureBox.Image = bitmap;
        }
    }
}
