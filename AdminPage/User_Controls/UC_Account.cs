using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
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
        private static readonly string SpreadsheetId = "1nFKEsGzUbNaWF4VJ4A1AnDinWDNkyEFlv6UTuwFNU_Y";
        private static readonly string SheetName = "AdminDetails";
        private static readonly string SheetName1 = "UserAccount";
        private SheetServiceInitializer _sheetServiceInitializer;
        private SheetsService _sheetsService;

        public UC_Account()
        {
            InitializeComponent();
            InitializeSheetService();
        }
        private void InitializeSheetService()
        {
            try
            {
                _sheetsService = SheetServiceInitializer.InitializeSheetsServiceFromEnvVar();
                _sheetServiceInitializer = new SheetServiceInitializer();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing Sheet Service: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void UC_Account_Load(object sender, EventArgs e)
        {
            try
            {
                await PopulateDataGridViewAsync();
                await PopulateUserAccountTableAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading data: " + ex.Message, "Message info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task PopulateDataGridViewAsync()
        {
            var range = $"{SheetName}!A2:D"; // Adjust the range based on your spreadsheet structure
            var values = await _sheetServiceInitializer.FetchValuesFromSheetAsync(range);

            // Clear existing data in DataGridView
            dataGridView1.Rows.Clear();

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
                Console.WriteLine("No data found in the spreadsheet.", "Message info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task PopulateUserAccountTableAsync()
        {
            var range = $"{SheetName1}!A2:C"; // Adjust the range based on your spreadsheet structure
            var values = await _sheetServiceInitializer.FetchValuesFromSheetAsync(range);

            // Clear existing data in UserAccountTbl
            UserAccountTbl.Rows.Clear();

            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    // Check if the row has enough elements
                    if (row.Count >= 3)
                    {
                        string userName = row[0]?.ToString() ?? "N/A";
                        string userSRCode = row[2]?.ToString() ?? "N/A";

                        // Add name, srcode, and an empty string for transactions to the DataGridView
                        UserAccountTbl.Rows.Add(userName, userSRCode, "");
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
                Console.WriteLine("No data found in the spreadsheet.", "Message info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Method to manually reload the data when needed
        private async void ReloadData()
        {
            try
            {
                await PopulateDataGridViewAsync();
                await PopulateUserAccountTableAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while reloading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Call ReloadData() whenever you need to reload the page data

        private void reload_Click(object sender, EventArgs e)
        {
            ReloadData();
        }
    }
}
