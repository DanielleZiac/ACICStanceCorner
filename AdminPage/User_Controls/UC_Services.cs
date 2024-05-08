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
        public UC_Services()
        {
            InitializeComponent();
            _sheetsService = SheetsServiceInitializer.InitializeSheetsServiceFromEnvVar();
            PopulateApprovalTable(); // Populate the approval table once when the control is created
        }

        private void PopulateApprovalTable()
        {
            var range = $"{SheetName}!A2:F"; // Adjust the range based on your spreadsheet structure
            var request = _sheetsService.Spreadsheets.Values.Get(SpreadsheetId, range);
            var response = request.Execute();
            var values = response.Values;

            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    // Check if the row has enough elements
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

                        // Add entry for combo box answered state per row
                        comboBoxAnsweredPerRow.Add(ApprovalTable.Rows.Count - 1, false);
                    }
                    else
                    {
                        // Log a warning if the row doesn't have enough elements
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
                // Get the selected row
                DataGridViewRow selectedRow = ApprovalTable.SelectedRows[0];

                // Extract values from the selected row
                string srCode = selectedRow.Cells["colSRCode"].Value?.ToString() ?? "";
                string service = selectedRow.Cells["colService"].Value?.ToString() ?? "";
                string itemId = selectedRow.Cells["colItem"].Value?.ToString() ?? "";
                string quantity = selectedRow.Cells["colDetails"].Value?.ToString() ?? "";
                string date = selectedRow.Cells["colDate"].Value?.ToString() ?? "";

                // Translate service ID to service name
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
                        // Handle any other cases here, if needed
                        break;
                }

                // Load the data from the "itemSheet"
                var itemRange = "ItemSheet!A2:D"; // Adjust the range based on your spreadsheet structure
                var itemRequest = _sheetsService.Spreadsheets.Values.Get(SpreadsheetId, itemRange);
                var itemResponse = itemRequest.Execute();
                var itemValues = itemResponse.Values;

                if (itemValues != null && itemValues.Count > 0)
                {
                    // Iterate through each row in the "itemSheet"
                    foreach (var itemRow in itemValues)
                    {
                        // Check if the current row has enough elements
                        if (itemRow.Count >= 4)
                        {
                            // Extract the values of the "id" and "item" columns
                            string id = itemRow[1]?.ToString() ?? "";
                            string item = itemRow[2]?.ToString() ?? "";

                            // Check if the "id" matches the itemId from the selected row
                            if (id == itemId)
                            {
                                // Display the corresponding item in the details label
                                string details = $"SR Code: {srCode}\n" +
                                                 $"Service: {service}\n" +
                                                 $"Item: {item}\n" +
                                                 $"Quantity: {quantity}\n" +
                                                 $"Date: {date}\n";
                                detailsLabel.Text = details;
                                return; // Exit the loop once a match is found
                            }
                        }
                    }
                }

                // If no matching item is found, display a message in the details label
                detailsLabel.Text = "Item not found";
            }
            else
            {
                // If no row is selected, clear the details label
                detailsLabel.Text = "";
            }
        }

        private void submitApproval_Click(object sender, EventArgs e)
        {
            // Get the selected status from the combo box
            string selectedStatus = StatusCBox.SelectedItem.ToString();

            // Iterate through each selected row in the approval table
            foreach (DataGridViewRow selectedRow in ApprovalTable.SelectedRows)
            {
                // Check if the row has already been updated
                if (!updatedRows.Contains(selectedRow.Index))
                {
                    // Update the status column value of the selected row
                    selectedRow.Cells["colStatus"].Value = selectedStatus;

                    // Add the row index to the list of updated rows
                    updatedRows.Add(selectedRow.Index);

                    // Mark the combo box as answered for this row
                    comboBoxAnsweredPerRow[selectedRow.Index] = true;
                }
                _ = UpdateDetails();
            }

            // Update the status in the ApprovalSheet using the Google Sheets API
            UpdateStatusInGoogleSheet();

            // Disable combo boxes for rows where it has been answered
            DisableComboBoxes();
        }
        private void UpdateStatusInGoogleSheet()
        {
            try
            {
                // Create the service object
                SheetsService service = SheetsServiceInitializer.InitializeSheetsServiceFromEnvVar();

                // Define the range to update (e.g., "ApprovalSheet!F2:F")
                string range = $"{SheetName}!F2:F"; // Adjust the range based on your spreadsheet structure

                // Create the value range object with the updated status value
                List<IList<object>> newValues = new List<IList<object>>();
                foreach (int rowIndex in updatedRows)
                {
                    // Get the updated status value from the DataGridView
                    string updatedStatus = ApprovalTable.Rows[rowIndex].Cells["colStatus"].Value.ToString();
                    newValues.Add(new List<object> { updatedStatus });
                }
                ValueRange valueRange = new ValueRange { Values = newValues };

                // Prepare the update request
                SpreadsheetsResource.ValuesResource.UpdateRequest updateRequest = service.Spreadsheets.Values.Update(valueRange, SpreadsheetId, range);
                updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;

                // Execute the update request
                UpdateValuesResponse response = updateRequest.Execute();
                Console.WriteLine("Status updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating status: {ex.Message}");
            }
        }
        private void ApprovalTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the current cell is in the status column and is not a header cell
            if (ApprovalTable.Columns[e.ColumnIndex].Name == "colStatus" && e.RowIndex >= 0)
            {
                // Get the status value from the cell
                string status = e.Value.ToString();

                // Set the background color based on the status
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
                        // Set default background color for other statuses
                        e.CellStyle.BackColor = ApprovalTable.DefaultCellStyle.BackColor;
                        break;
                }
            }
        }
        private async Task UpdateDetails()
        {
            // Check if any row is selected
            if (ApprovalTable.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = ApprovalTable.SelectedRows[0];

                // Extract values from the selected row
                string srCode = selectedRow.Cells["colSRCode"].Value?.ToString() ?? "";
                string service = selectedRow.Cells["colService"].Value?.ToString() ?? "";
                string itemId = selectedRow.Cells["colItem"].Value?.ToString() ?? "";
                string quantity = selectedRow.Cells["colDetails"].Value?.ToString() ?? "";
                string status = selectedRow.Cells["colStatus"].Value?.ToString() ?? "";
                Random random = new Random();
                int randomNumber = random.Next(1000, 10000); // Adjust the range as needed

                // Concatenate srCode, random number, and service
                string transactionId = $"{srCode}-{randomNumber}-{service}-{itemId}";
                // Check if the status is "approved" and if the transaction has not been appended before
                if (status == "Approved" && !appendedTransactions.Contains(transactionId))
                {
                    // Get the SR code of the logged admin from CurrentUser.LoggedInUser
                    string loggedAdminSRCode = CurrentUser.LoggedInUser.SRCode;

                    // Get the current date
                    string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

                    // Append the details to the "TransactionSheet" with the current date and logged admin's SR code
                    await AppendToTransactionSheet(srCode, service, itemId, quantity, loggedAdminSRCode, currentDate);

                    // Add the transaction ID to the list of appended transactions
                    appendedTransactions.Add(transactionId);
                }
            }
        }


        private async Task AppendToTransactionSheet(string srCode, string service, string itemId, string quantity, string adminSRCode, string date)
        {
            // Create a range for the new row
            string range = $"TransactionSheet!A2:F";

            // Create the new row data
            IList<IList<object>> rowData = new List<IList<object>>
    {
        new List<object> { srCode, service, itemId, quantity, adminSRCode, date }
    };

            // Create the value range object
            ValueRange valueRange = new ValueRange
            {
                Values = rowData
            };

            try
            {
                // Append the new row data to the "TransactionSheet"
                SpreadsheetsResource.ValuesResource.AppendRequest request =
                    _sheetsService.Spreadsheets.Values.Append(valueRange, SpreadsheetId, range);
                request.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                AppendValuesResponse response = await request.ExecuteAsync();
                MessageBox.Show($"{response.Updates.UpdatedCells} cells appended.");
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
