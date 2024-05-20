using aCICSistanceCorner.Forms.GoogleAPi;
using BCrypt.Net;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace aCICSistanceCorner
{
    public partial class Register : Form
    {
        private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        private static readonly string ApplicationName = "ACICSTANCE CORNER";
        private static readonly string SpreadsheetId = "1nFKEsGzUbNaWF4VJ4A1AnDinWDNkyEFlv6UTuwFNU_Y";
        private static readonly string SheetName = "UserAccount";
        private SheetsService _sheetsService;
        public Register()
        {
            InitializeComponent();
            _sheetsService = SheetServiceInitializer.Instance;
            this.Width = 408;
            this.Height = 891;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackgroundImage = aCICSistanceCorner.Properties.Resources.MAIN_REGISTER;
            UserName.BorderStyle = BorderStyle.None;
            srcode.BorderStyle = BorderStyle.None;
            password.BorderStyle = BorderStyle.None;
        }
        private void createAcc_Click(object sender, EventArgs e)
        {
            createAcc.Image = Properties.Resources.CreateAccount_;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += (s, args) =>
            {
                createAcc.Image = Properties.Resources.CreateAccount;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
            string username = UserName.Text;
            string srCode = srcode.Text;
            string plainPassword = this.password.Text;
            try
            {
                var existingUser = CheckExistingUser(username, srCode);
                if (existingUser != null)
                {
                    MessageBox.Show("An account with the same credentials already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword);
                var valueRange = new ValueRange
                {
                    Values = new List<IList<object>>
            {
                new List<object> { username, hashedPassword, srCode }
            }
                };
                int rowCount = 100;
                string range = $"{SheetName}!A1:C{rowCount}";
                var request = _sheetsService.Spreadsheets.Values.Append(valueRange, SpreadsheetId, range);
                request.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                var response = request.Execute();
                MessageBox.Show("Credentials saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private IList<object> CheckExistingUser(string username, string srCode)
        {
            string range = $"{SheetName}!A:C";
            var request = _sheetsService.Spreadsheets.Values.Get(SpreadsheetId, range);
            var response = request.Execute();
            IList<IList<object>> values = response.Values;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    if (row.Count >= 3 && row[0].ToString() == username && row[2].ToString() == srCode)
                    {
                        return row;
                    }
                }
            }

            return null;
        }
        private void backmain_Click(object sender, EventArgs e)
        {
            backmain.Image = Properties.Resources.backmain_;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += (s, args) =>
            {
                backmain.Image = Properties.Resources.backmain;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
            this.Close();
            StartingPage main = new StartingPage();
            main.Show();
        }
    }
}