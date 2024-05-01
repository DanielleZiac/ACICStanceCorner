using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using static AdminPage.User_Controls.UC_Home;

namespace AdminPage
{
    public partial class RegisterPage : Form
    {
        private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        private static readonly string ApplicationName = "ACICSTANCE CORNER";
        private static readonly string SpreadsheetId = "1F9TzHOBa3T9CVMQEZ5hWJJ7T6kJHMg-phlonAfIzKTk";
        private static readonly string SheetName = "AdminDetails";

        private SheetsService _sheetsService;

        public RegisterPage()
        {
            InitializeComponent();

            InitializeSheetsService();
        }

        private void InitializeSheetsService()
        {
            _sheetsService = SheetsServiceInitializer.InitializeSheetsServiceFromEnvVar();
        }


        private void BackLog_Click(object sender, EventArgs e)
        {
            LogInFrm loginPage = new LogInFrm();
            this.Hide();
            loginPage.Show();
        }

        private void Reg_Btn_Click(object sender, EventArgs e)
        {
            string adminName = NameRegBox.Text;
            string adminSRCode = SRRegBox.Text;
            string adminPassword = PassRegBox.Text;

            if (adminSRCode.Length != 8)
            {
                MessageBox.Show("SR code must be 8 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method if validation fails
            }

            if (string.IsNullOrEmpty(adminName) || string.IsNullOrEmpty(adminSRCode) || string.IsNullOrEmpty(adminPassword))
            {
                MessageBox.Show("All fields are required.", "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Check if SR code is already in use
                if (IsSRCodeUnique(adminSRCode))
                {
                    // Hash the password using BCrypt
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(adminPassword);

                    // Construct the values to be written to the spreadsheet
                    var values = new List<IList<object>>
            {
                new List<object> { adminName, adminSRCode, hashedPassword }
            };

                    int rowCount = 100;// Define the range to write to
                    string range = $"{SheetName}!A1:C{rowCount}";

                    // Create a request to write data to the spreadsheet
                    var request = _sheetsService.Spreadsheets.Values.Append(new Google.Apis.Sheets.v4.Data.ValueRange
                    {
                        Values = values
                    }, SpreadsheetId, range);

                    // Execute the request
                    request.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                    var response = request.Execute();

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

        private bool IsSRCodeUnique(string srCode)
        {
            try
            {
                var range = $"{SheetName}!B:B"; // Column B contains the SR codes
                var request = _sheetsService.Spreadsheets.Values.Get(SpreadsheetId, range);
                var response = request.Execute();
                var values = response.Values;

                // Check if any SR code matches the input SR code
                if (values != null)
                {
                    foreach (var row in values)
                    {
                        if (row.Count > 0 && row[0].ToString() == srCode)
                        {
                            return false; // SR code is not unique
                        }
                    }
                }

                return true; // SR code is unique
            }
            catch (Exception ex)
            {
                throw new Exception("Error while checking SR code uniqueness: " + ex.Message);
            }
        }

    }
}
