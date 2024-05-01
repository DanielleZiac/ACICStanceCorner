using Google.Apis.Sheets.v4.Data;
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
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using System.IO;
using AdminPage.Users;

namespace AdminPage.User_Controls
{
    public partial class UC_Home : UserControl
    {
        private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        private static readonly string ApplicationName = "ACICSTANCE CORNER";
        private static readonly string SpreadsheetId = "1F9TzHOBa3T9CVMQEZ5hWJJ7T6kJHMg-phlonAfIzKTk";
        private static readonly string SheetName = "AdminDetails";
        private string _currentUserSRCode;

        public static class SheetsServiceInitializer
        {
            private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
            private static readonly string ApplicationName = "ACICSTANCE CORNER";

            public static SheetsService InitializeSheetsServiceFromEnvVar()
            {
                string credentialsFilePath = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");

                if (string.IsNullOrEmpty(credentialsFilePath))
                {
                    throw new Exception("GOOGLE_APPLICATION_CREDENTIALS environment variable is not set.");
                }

                GoogleCredential credential;

                using (var stream = new FileStream(credentialsFilePath, FileMode.Open, FileAccess.Read))
                {
                    credential = GoogleCredential.FromStream(stream)
                        .CreateScoped(Scopes);
                }

                return new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
            }
        }

        private SheetsService _sheetsService;
        public UC_Home()
        {
            InitializeComponent();
            _sheetsService = SheetsServiceInitializer.InitializeSheetsServiceFromEnvVar();
            // Assign the logged-in user's SR code to _currentUserSRCode
            _currentUserSRCode = CurrentUser.LoggedInUser?.SRCode;

            // Load tasks for the current user
            LoadTasksForCurrentUser();
        }

        private void AddTaskBtn_Click(object sender, EventArgs e)
        {
            string taskType = TaskType.Text;

            if (string.IsNullOrEmpty(taskType))
            {
                MessageBox.Show("Task type cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Get the current user's SR code
                string currentUserSRCode = CurrentUser.LoggedInUser.SRCode;

                // Construct the values to be written to the spreadsheet
                var values = new List<IList<object>>
        {
            new List<object> { currentUserSRCode, taskType }
        };

                // Get the number of existing tasks in the AdminTask sheet to determine the next empty row
                var range = "AdminTask!A:A";
                var request = _sheetsService.Spreadsheets.Values.Get(SpreadsheetId, range);
                var response = request.Execute();
                var numRows = response.Values != null ? response.Values.Count : 0;

                // Define the range to write to (start from the next empty row)
                string writeRange = $"AdminTask!A{numRows + 1}:B{numRows + 1}";

                // Create a request to append data to the spreadsheet
                var appendRequest = _sheetsService.Spreadsheets.Values.Append(new ValueRange
                {
                    Values = values
                }, SpreadsheetId, writeRange);

                // Execute the request
                appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                var appendResponse = appendRequest.Execute();

                MessageBox.Show("Task added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaskType.Text = "";
                LoadTasksForCurrentUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while adding task: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaskType_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoadTasksForCurrentUser()
        {
            // Clear existing items in the checkedTask CheckedListBox
            try
            {
                var range = "AdminTask!A:B"; // Assuming the task data is in columns A and B
                var request = _sheetsService.Spreadsheets.Values.Get(SpreadsheetId, range);
                var response = request.Execute();
                var values = response.Values;

                if (values != null && values.Count > 0)
                {
                    CheckedTask.Items.Clear(); // Clear existing items in the checklist box

                    foreach (var row in values)
                    {
                        string taskUserSRCode = row[0].ToString();
                        string taskName = row[1].ToString();

                        if (taskUserSRCode == _currentUserSRCode)
                        {
                            CheckedTask.Items.Add(taskName); // Add the task to the checklist box
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No tasks found for the current user.", "Message Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading tasks: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Call this method whenever you want to load tasks for the current user, such as in the form load event
        private void Form_Load(object sender, EventArgs e)
        {
            LoadTasksForCurrentUser();
        }

        private void CheckedTask_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DoneTask_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the indices of the selected items in the CheckedTask CheckedListBox
                var selectedIndices = CheckedTask.CheckedIndices.Cast<int>().ToList();

                // Delete selected tasks from the Google Sheets AdminTask sheet
                foreach (int index in selectedIndices)
                {
                    // Get the task name from the CheckedTask CheckedListBox
                    string taskName = CheckedTask.Items[index].ToString();

                    // Find the row index of the task in the Google Sheets AdminTask sheet
                    var range = "AdminTask!B:B"; // Assuming task names are in column B
                    var request = _sheetsService.Spreadsheets.Values.Get(SpreadsheetId, range);
                    var response = request.Execute();
                    var values = response.Values;

                    int rowIndex = -1;
                    if (values != null && values.Count > 0)
                    {
                        for (int i = 0; i < values.Count; i++)
                        {
                            if (values[i].Count > 0 && values[i][0].ToString() == taskName)
                            {
                                rowIndex = i + 1; // Google Sheets row index is 1-based
                                break;
                            }
                        }
                    }

                    if (rowIndex != -1)
                    {
                        // Delete the row from the Google Sheets AdminTask sheet
                        var deleteRequest = _sheetsService.Spreadsheets.Values.Clear(new ClearValuesRequest(), SpreadsheetId, $"AdminTask!A{rowIndex}:B{rowIndex}");
                        var deleteResponse = deleteRequest.Execute();
                    }
                }

                // Remove selected tasks from the CheckedTask CheckedListBox
                for (int i = selectedIndices.Count - 1; i >= 0; i--)
                {
                    CheckedTask.Items.RemoveAt(selectedIndices[i]);
                }

                MessageBox.Show("Selected tasks deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting tasks: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
