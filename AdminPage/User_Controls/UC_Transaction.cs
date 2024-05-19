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
using static AdminPage.User_Controls.UC_Home;

namespace AdminPage.User_Controls
{
    public partial class UC_Transaction : UserControl
    {
        private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        private static readonly string SpreadsheetId = "1nFKEsGzUbNaWF4VJ4A1AnDinWDNkyEFlv6UTuwFNU_Y";
        private static readonly string SheetName = "TransactionSheet";
        private SheetsService _sheetsService;
        private readonly GoogleSheetsService _googleSheetsService;
        public UC_Transaction()
        {
            InitializeComponent();
            _googleSheetsService = new GoogleSheetsService();
            _sheetsService = _googleSheetsService.GetSheetsService();
        }
        private async void UC_Transaction_LoadAsync(object sender, EventArgs e)
        {
            try
            {
                await PopulateTransactionTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading data: " + ex.Message, "Message info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private async Task PopulateTransactionTable()
        {
            var range = $"{SheetName}!A2:F"; 
            var values = await _googleSheetsService.GetValuesAsync(range);

            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    if (row.Count >= 3)
                    {
                        string Name = row[0]?.ToString() ?? "N/A";
                        string SRCode = row[1]?.ToString() ?? "N/A";
                        string Service = row[2]?.ToString() ?? "N/A";
                        string Details = row[3]?.ToString() ?? "N/A";
                        string adminSRCode = row[4]?.ToString() ?? "N/A";
                        string date = row[5]?.ToString() ?? "N/A";
                        TransactionTable.Rows.Add(Name, SRCode, Service, Details, adminSRCode, date);
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

        private void TransactionTable_SelectionChanged(object sender, EventArgs e)
        {
            if (TransactionTable.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = TransactionTable.SelectedRows[0];
                string srCode = selectedRow.Cells["colSRCode"].Value?.ToString() ?? "";
                string service = selectedRow.Cells["colService"].Value?.ToString() ?? "";
                string itemId = selectedRow.Cells["colItem"].Value?.ToString() ?? "";
                string quantity = selectedRow.Cells["colDetails"].Value?.ToString() ?? "";
                string approved = selectedRow.Cells["colAdminApp"].Value?.ToString() ?? "";
                string date = selectedRow.Cells["colDate"].Value?.ToString() ?? "";

                switch (service)
                {
                    case "1":
                        service = "Resource";
                        break;
                    case "2":
                        service = "Borrow";
                        break;
                    case "3":
                        service = "Print";
                        break;
                    default:
                        break;
                }
                var itemRange = "ItemSheet!A2:D"; 
                var itemRequest = _sheetsService.Spreadsheets.Values.Get(SpreadsheetId, itemRange);
                var itemResponse = itemRequest.Execute();
                var itemValues = itemResponse.Values;

                if (itemValues != null && itemValues.Count > 0)
                {
                    foreach (var itemRow in itemValues)
                    {
                        if (itemRow.Count >= 4)
                        {
                            string id = itemRow[1]?.ToString() ?? "";
                            string item = itemRow[2]?.ToString() ?? "";
                            
                            if (id == itemId)
                            {
                                string details = $"SR Code: {srCode}\n" +
                                                 $"Service: {service}\n" +
                                                 $"Item: {item}\n" +
                                                 $"Quantity: {quantity}\n" +
                                                 $"Approved By: {approved}\n" +
                                                 $"Date: {date}\n"; 
                                detailsLabelTrans.Text = details;
                                return;
                            }
                        }
                    }
                }
                detailsLabelTrans.Text = "Item not found";
            }
            else
            {
                detailsLabelTrans.Text = "";
            }
        }
    }
}
