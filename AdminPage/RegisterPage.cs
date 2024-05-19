using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;

namespace AdminPage
{
    public partial class RegisterPage : Form
    {
        private static readonly string SpreadsheetId = "1nFKEsGzUbNaWF4VJ4A1AnDinWDNkyEFlv6UTuwFNU_Y";
        private static readonly string SheetName = "AdminDetails";
        private readonly GoogleSheetsService _googleSheetsService;
        private SheetsService _sheetsService;
        public RegisterPage()
        {
            InitializeComponent();
            _googleSheetsService = new GoogleSheetsService();
            _sheetsService = _googleSheetsService.GetSheetsService();
        }
        private void BackLog_Click(object sender, EventArgs e)
        {
            LogInFrm loginPage = new LogInFrm();
            this.Hide();
            loginPage.Show();
        }

        private async void Reg_Btn_Click(object sender, EventArgs e)
        {
            string adminName = NameRegBox.Text;
            string adminSRCode = SRRegBox.Text;
            string adminPassword = PassRegBox.Text;

            if (adminSRCode.Length != 8)
            {
                MessageBox.Show("SR code must be 8 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(adminName) || string.IsNullOrEmpty(adminSRCode) || string.IsNullOrEmpty(adminPassword))
            {
                MessageBox.Show("All fields are required.", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (await IsSRCodeUnique(adminSRCode))
                {
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(adminPassword);

                    var values = new List<IList<object>>
                    {
                        new List<object> { adminName, adminSRCode, hashedPassword }
                    };

                    int rowCount = 100;
                    string range = $"{SheetName}!A1:C{rowCount}";

                    var request = _sheetsService.Spreadsheets.Values.Append(new Google.Apis.Sheets.v4.Data.ValueRange
                    {
                        Values = values
                    }, SpreadsheetId, range);

                    request.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                    var response = await request.ExecuteAsync();

                    MessageBox.Show("Registered Successfully");
                    LogInFrm loginPage = new LogInFrm();
                    this.Hide();
                    loginPage.Show();
                }
                else
                {
                    MessageBox.Show("SR code is already in use.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while registering: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> IsSRCodeUnique(string srCode)
        {
            try
            {
                var range = $"{SheetName}!B:B"; 
                var values = await _googleSheetsService.GetValuesAsync(range);

                if (values != null)
                {
                    foreach (var row in values)
                    {
                        if (row.Count > 0 && row[0].ToString() == srCode)
                        {
                            return false;
                        }
                    }
                }

                return true; 
            }
            catch (Exception ex)
            {
                throw new Exception("Error while checking SR code uniqueness: " + ex.Message);
            }
        }
    }
}
