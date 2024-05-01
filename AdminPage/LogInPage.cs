using System;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Util.Store;
using BCrypt;
using System.Collections.Generic;
using static AdminPage.User_Controls.UC_Home;
using AdminPage.Users;

namespace AdminPage
{
    public partial class LogInFrm : Form
    {
        private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        private static readonly string ApplicationName = "ACICSTANCE CORNER";
        private static readonly string SpreadsheetId = "1F9TzHOBa3T9CVMQEZ5hWJJ7T6kJHMg-phlonAfIzKTk";
        private static readonly string SheetName = "AdminDetails";
        private AdminPage.Users.Users LoggedInUser { get; set; }
        private SheetsService _sheetsService;

        public LogInFrm()
        {
            InitializeComponent();
            _sheetsService = SheetsServiceInitializer.InitializeSheetsServiceFromEnvVar();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CreateLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterPage registerpage = new RegisterPage();
            this.Hide();
            registerpage.Show();
        }

        private void ShowPassLog_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPassLog.Checked)
            {
                // Display the actual text in the password textbox
                PassLogBox.UseSystemPasswordChar = false;
            }
            else
            {
                // Mask the text in the password textbox
                PassLogBox.UseSystemPasswordChar = true;
            }
        }

        private void LogInBtn_Click(object sender, EventArgs e)
        {
            string enteredSRCode = SRLogBox.Text;
            string enteredPassword = PassLogBox.Text;

            if (enteredSRCode.Length != 8)
            {
                MessageBox.Show("SR code must be 8 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method if validation fails
            }

            try
            {
                // Retrieve data from Google Sheets
                var range = $"{SheetName}!A:C";
                var request = _sheetsService.Spreadsheets.Values.Get(SpreadsheetId, range);
                var response = request.Execute();
                var values = response.Values;

                if (values != null && values.Count > 0)
                {
                    foreach (var row in values)
                    {
                        if (row.Count >= 3 && row[1].ToString() == enteredSRCode)
                        {
                            string hashedPasswordFromDatabase = row[2].ToString();

                            if (BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPasswordFromDatabase))
                            {
                                // Update last login date
                                var updateValues = new List<IList<object>> { new List<object> { DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") } };
                                var updateRange = $"{SheetName}!D{values.IndexOf(row) + 1}";
                                var updateRequest = new Google.Apis.Sheets.v4.Data.ValueRange { Values = updateValues };
                                var updateUpdateRequest = _sheetsService.Spreadsheets.Values.Update(updateRequest, SpreadsheetId, updateRange);
                                updateUpdateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
                                var updateUpdateResponse = updateUpdateRequest.Execute();

                                string adminName = row[0].ToString();
                                string srCode = row[1].ToString();

                                CurrentUser.LoggedInUser = new Users.Users { AdminName = adminName, SRCode = srCode };

                                DashboardUI dashboard = new DashboardUI(adminName, srCode);
                                this.Hide();
                                dashboard.Show();

                                return;
                            }
                            else
                            {
                                MessageBox.Show("Invalid password. Please try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    MessageBox.Show("Invalid SR code. Please try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("No data found in Google Sheets.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while logging in: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
