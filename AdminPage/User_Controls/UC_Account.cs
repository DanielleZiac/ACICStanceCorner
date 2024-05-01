using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using static AdminPage.User_Controls.UC_Home;

namespace AdminPage.User_Controls
{
    public partial class UC_Account : UserControl
    {
        private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        private static readonly string ApplicationName = "ACICSTANCE CORNER";
        private static readonly string SpreadsheetId = "1F9TzHOBa3T9CVMQEZ5hWJJ7T6kJHMg-phlonAfIzKTk";
        private static readonly string SheetName = "AdminDetails";

        private SheetsService _sheetsService;

        public UC_Account()
        {
            InitializeComponent();

            _sheetsService = SheetsServiceInitializer.InitializeSheetsServiceFromEnvVar();
        }

        private void UC_Account_Load(object sender, EventArgs e)
        {
            try
            {
                var range = $"{SheetName}!A2:D"; // Adjust the range based on your spreadsheet structure
                var request = _sheetsService.Spreadsheets.Values.Get(SpreadsheetId, range);
                var response = request.Execute();
                var values = response.Values;

                if (values != null && values.Count > 0)
                {
                    foreach (var row in values)
                    {
                        // Check if the row has enough elements
                        if (row.Count >= 4)
                        {
                            string adminName = row[0]?.ToString() ?? "N/A";
                            string adminSRCode = row[1]?.ToString() ?? "N/A";
                            DateTime adminLastLog;

                            // Parse the last login date from string to DateTime
                            if (DateTime.TryParse(row[3]?.ToString(), out adminLastLog))
                            {
                                // Add name, srcode, and last login date to the DataGridView
                                dataGridView1.Rows.Add(adminName, adminSRCode, adminLastLog);
                            }
                            else
                            {
                                // If parsing fails, add empty string for the last login date
                                dataGridView1.Rows.Add(adminName, adminSRCode, "");
                            }
                        }
                        else
                        {
                            // Log a warning if the row doesn't have enough elements
                            Console.WriteLine("Row does not have enough elements.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No data found in the spreadsheet.", "Message info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading data: " + ex.Message, "Message info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
