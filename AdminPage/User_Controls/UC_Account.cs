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
        private SheetsService _sheetsService;
        private readonly GoogleSheetsService _googleSheetsService;
        public UC_Account()
        {
            InitializeComponent();
            _googleSheetsService = new GoogleSheetsService();
            _sheetsService = _googleSheetsService.GetSheetsService();
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
            var range = $"{SheetName}!A2:D"; 
            var values = await _googleSheetsService.GetValuesAsync(range);
            dataGridView1.Rows.Clear();

            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    if (row.Count >= 4)
                    {
                        string adminName = row[0]?.ToString() ?? "N/A";
                        string adminSRCode = row[1]?.ToString() ?? "N/A";
                        DateTime adminLastLog;

                        if (DateTime.TryParse(row[3]?.ToString(), out adminLastLog))
                        {
                            dataGridView1.Rows.Add(adminName, adminSRCode, adminLastLog);
                        }
                        else
                        {
                            dataGridView1.Rows.Add(adminName, adminSRCode, "");
                        }
                    }
                    else
                    {
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
            var userAccountRange = $"{SheetName1}!A2:C";
            var userAccountValues = await _googleSheetsService.GetValuesAsync(userAccountRange);

            var transactionRange = $"TransactionSheet!A2:B"; 
            var transactionValues = await _googleSheetsService.GetValuesAsync(transactionRange);

            UserAccountTbl.Rows.Clear();

            if (userAccountValues != null && userAccountValues.Count > 0)
            {
                foreach (var userAccountRow in userAccountValues)
                {
                    if (userAccountRow.Count >= 3)
                    {
                        string userName = userAccountRow[0]?.ToString() ?? "N/A";
                        string userSRCode = userAccountRow[2]?.ToString() ?? "N/A";

                        // Count occurrences of SR code in transaction sheet
                        int transactionCount = CountTransactionOccurrences(userSRCode, transactionValues);

                        // Add name, srcode, and transaction count to the DataGridView
                        UserAccountTbl.Rows.Add(userName, userSRCode, transactionCount);
                    }
                    else
                    {
                        Console.WriteLine("Row does not have enough elements.");
                    }
                }
            }
            else
            {
                Console.WriteLine("No data found in the user account spreadsheet.", "Message info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private int CountTransactionOccurrences(string userSRCode, IList<IList<object>> transactionValues)
        {
            if (transactionValues != null)
            {
                int count = 0;
                foreach (var transactionRow in transactionValues)
                {
                    if (transactionRow.Count > 0 && transactionRow[0]?.ToString() == userSRCode)
                    {
                        count++;
                    }
                }
                return count;
            }
            return 0;
        }
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

        private void reload_Click(object sender, EventArgs e)
        {
            ReloadData();
        }
    }
}