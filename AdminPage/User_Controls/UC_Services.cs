using AdminPage.Users;
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
using System.Windows.Forms.VisualStyles;
using static AdminPage.User_Controls.UC_Home;

namespace AdminPage.User_Controls
{
    public partial class UC_Services : UserControl
    {
        private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        private static readonly string SpreadsheetId = "1nFKEsGzUbNaWF4VJ4A1AnDinWDNkyEFlv6UTuwFNU_Y";
        private static readonly string SheetName = "ApprovalSheet";
        private SheetsService _sheetsService;
        private List<int> updatedRows = new List<int>();
        private bool comboBoxAnswered = false;
        private HashSet<string> appendedTransactions = new HashSet<string>();
        private Dictionary<int, bool> comboBoxAnsweredPerRow = new Dictionary<int, bool>();
        private readonly GoogleSheetsService _googleSheetsService;
        public UC_Services()
        {
            InitializeComponent();
            _googleSheetsService = new GoogleSheetsService();
            _sheetsService = _googleSheetsService.GetSheetsService();
            PopulateApprovalTable(); 
        }

        private void PopulateApprovalTable()
        {
            var range = $"{SheetName}!A2:F"; 
            var values = _googleSheetsService.GetValues(range);

            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    if (row.Count >= 6)
                    {
                        string SRCode = row[0]?.ToString() ?? "N/A";
                        string Service = row[1]?.ToString() ?? "N/A";
                        string Item = row[2]?.ToString() ?? "N/A";
                        string Quantity = row[3]?.ToString() ?? "N/A";
                        string Date = row[4]?.ToString() ?? "N/A";
                        string Status = row[5]?.ToString() ?? "N/A";

                        DataGridViewRow newRow = new DataGridViewRow();
                        newRow.CreateCells(ApprovalTable, SRCode, Service, Item, Quantity, Date, Status);
                        ApprovalTable.Rows.Add(newRow);

                        comboBoxAnsweredPerRow.Add(ApprovalTable.Rows.Count - 1, false);
                    }
                    else
                    {
                        Console.WriteLine("Row does not have enough elements.");
                    }
                }
                DisableComboBoxes();
            }
            else
            {
                Console.WriteLine("No data found in the spreadsheet.", "Message info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ApprovalTable_SelectionChanged(object sender, EventArgs e)
        {
            ShowDetails();
            _ = UpdateDetails();
        }
        private void ShowDetails()
        {
            if (ApprovalTable.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = ApprovalTable.SelectedRows[0];

                string srCode = selectedRow.Cells["colSRCode"].Value?.ToString() ?? "";
                string service = selectedRow.Cells["colService"].Value?.ToString() ?? "";
                string itemId = selectedRow.Cells["colItem"].Value?.ToString() ?? "";
                string quantity = selectedRow.Cells["colDetails"].Value?.ToString() ?? "";
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
                                                 $"Date: {date}\n";
                                detailsLabel.Text = details;
                                return; 
                            }
                        }
                    }
                }
                detailsLabel.Text = "Item not found";
            }
            else
            {
                detailsLabel.Text = "";
            }
        }

        private void submitApproval_Click(object sender, EventArgs e)
        {
            string selectedStatus = StatusCBox.SelectedItem.ToString();

            foreach (DataGridViewRow selectedRow in ApprovalTable.SelectedRows)
            {
                if (!updatedRows.Contains(selectedRow.Index))
                {
                    selectedRow.Cells["colStatus"].Value = selectedStatus;
                    updatedRows.Add(selectedRow.Index);
                    comboBoxAnsweredPerRow[selectedRow.Index] = true;
                }
                _ = UpdateDetails();
            }
            UpdateStatusInGoogleSheet();
            DisableComboBoxes();
        }
        private void UpdateStatusInGoogleSheet()
        {
            try
            {
                SheetsService service = SheetServiceInitializer.Instance;

                string range = $"{SheetName}!F2:F";

                List<IList<object>> newValues = new List<IList<object>>();
                foreach (int rowIndex in updatedRows)
                {
                    string updatedStatus = ApprovalTable.Rows[rowIndex].Cells["colStatus"].Value.ToString();
                    newValues.Add(new List<object> { updatedStatus });
                }
                ValueRange valueRange = new ValueRange { Values = newValues };

                SpreadsheetsResource.ValuesResource.UpdateRequest updateRequest = service.Spreadsheets.Values.Update(valueRange, SpreadsheetId, range);
                updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;

                UpdateValuesResponse response = updateRequest.Execute();
                MessageBox.Show("Status updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating status: {ex.Message}");
            }
        }
        private void ApprovalTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (ApprovalTable.Columns[e.ColumnIndex].Name == "colStatus" && e.RowIndex >= 0)
            {
                string status = e.Value.ToString();

                switch (status)
                {
                    case "Pending":
                        e.CellStyle.BackColor = System.Drawing.Color.Orange;
                        break;
                    case "Approved":
                        e.CellStyle.BackColor = System.Drawing.Color.Green;
                        break;
                    case "Rejected":
                        e.CellStyle.BackColor = System.Drawing.Color.Red;
                        break;
                    default:
                        e.CellStyle.BackColor = ApprovalTable.DefaultCellStyle.BackColor;
                        break;
                }
            }
        }
        private async Task UpdateDetails()
        {
            if (ApprovalTable.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = ApprovalTable.SelectedRows[0];
                string srCode = selectedRow.Cells["colSRCode"].Value?.ToString() ?? "";
                string service = selectedRow.Cells["colService"].Value?.ToString() ?? "";
                string itemId = selectedRow.Cells["colItem"].Value?.ToString() ?? "";
                string quantity = selectedRow.Cells["colDetails"].Value?.ToString() ?? "";
                string status = selectedRow.Cells["colStatus"].Value?.ToString() ?? "";
                Random random = new Random();
                int randomNumber = random.Next(1000, 10000);
                string transactionId = $"{srCode}-{randomNumber}-{service}-{itemId}";

                if (status == "Approved" && !appendedTransactions.Contains(transactionId))
                {
                    string selectedStatus = StatusCBox.SelectedItem.ToString();
                    if (selectedStatus == "Approved")
                    {
                        string loggedAdminSRCode = CurrentUser.LoggedInUser.SRCode;
                        string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

                        await AppendToTransactionSheet(srCode, service, itemId, quantity, loggedAdminSRCode, currentDate);

                        appendedTransactions.Add(transactionId);
                    }
                }
            }
        }



        private async Task AppendToTransactionSheet(string srCode, string service, string itemId, string quantity, string adminSRCode, string date)
        {
            string range = $"TransactionSheet!A2:F";

            IList<IList<object>> rowData = new List<IList<object>>
    {
        new List<object> { srCode, service, itemId, quantity, adminSRCode, date }
    };

            ValueRange valueRange = new ValueRange
            {
                Values = rowData
            };

            try
            {               
                SpreadsheetsResource.ValuesResource.AppendRequest request =
                    _sheetsService.Spreadsheets.Values.Append(valueRange, SpreadsheetId, range);
                request.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                AppendValuesResponse response = await request.ExecuteAsync();
                Console.WriteLine($"{response.Updates.UpdatedCells} cells appended.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void DisableComboBoxes()
        {
            foreach (DataGridViewRow row in ApprovalTable.Rows)
            {
                if (comboBoxAnsweredPerRow.ContainsKey(row.Index) && comboBoxAnsweredPerRow[row.Index])
                {
                    DataGridViewComboBoxCell comboBoxCell = row.Cells["colStatus"] as DataGridViewComboBoxCell;
                    if (comboBoxCell != null)
                    {
                        comboBoxCell.ReadOnly = true;
                    }
                }
            }
        }

    }
}
