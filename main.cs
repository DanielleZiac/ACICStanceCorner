using AdminPage;
using BCrypt.Net;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace aCICSistanceCorner
{
    public partial class StartingPage : Form
    {
        private readonly string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        private readonly string ApplicationName = "ACICStance Corner";
        private readonly string SpreadsheetId = "1nFKEsGzUbNaWF4VJ4A1AnDinWDNkyEFlv6UTuwFNU_Y";
        private readonly string SheetName = "UserAccount";
        private SheetsService _sheetsService;
        public StartingPage()
        {
            InitializeComponent();
            _sheetsService = SheetServiceInitializer.Instance;
            this.Width = 408;
            this.Height = 891;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackgroundImage = aCICSistanceCorner.Properties.Resources.bg_start;
            this.BackgroundImageLayout = ImageLayout.Center;
            InitializeButtons();
        }
        private bool ValidateCredentials(string srCode, string password)
        {
            int rowCount = 100;
            string range = $"{SheetName}!A1:C{rowCount}";
            var request = _sheetsService.Spreadsheets.Values.Get(SpreadsheetId, range);
            var response = request.Execute();
            foreach (var row in response.Values)
            {
                if (row.Count >= 3 && row[2].ToString() == srCode)
                {
                    string hashedPasswordFromSheet = row[1].ToString();
                    if (BCrypt.Net.BCrypt.Verify(password, hashedPasswordFromSheet))
                    {
                        WriteLoggedInUser(srCode);
                        return true;
                    }
                }
            }
            return false;
        }
        private void WriteLoggedInUser(string srCode)
        {
            string filePath = "loggedInUser.txt";
            File.WriteAllText(filePath, srCode);
        }
        private void InitializeButtons()
        {
            CreateImageButton(Properties.Resources.SignIn, Properties.Resources.SignIn_, new Point(70, 750), SignInButton_Click);
            CreateImageButton(Properties.Resources.CreateAcc, Properties.Resources.CreateAcc_, new Point(70, 670), CreateAccButton_Click);
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
            button.BackColor = Color.Transparent;
            this.Controls.Add(button);
        }
        private void SignInButton_Click(object sender, MouseEventArgs e)
        {
            string srCode = UserName.Text;
            string password = Password.Text;
            if (ValidateCredentials(srCode, password))
            {
                this.Hide();
                HomePage homePage = new HomePage();
                homePage.Show();
            }
            else
            {
                MessageBox.Show("Invalid SRCode or password. Please try again.");
            }
        }
        private void CreateAccButton_Click(object sender, MouseEventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.Show();
        }
    }
}