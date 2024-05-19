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
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Forms.DataVisualization.Charting;

namespace AdminPage.User_Controls
{
    public partial class UC_Home : UserControl
    {
        private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        private static readonly string SpreadsheetId = "1nFKEsGzUbNaWF4VJ4A1AnDinWDNkyEFlv6UTuwFNU_Y";
        private string _currentUserSRCode;
        private SheetsService _sheetsService;
        private readonly GoogleSheetsService _googleSheetsService;
        private readonly PieChartManager _pieChartManager;

        public UC_Home()
        {
            _sheetsService = SheetServiceInitializer.Instance;
            _googleSheetsService = new GoogleSheetsService(); 
            InitializeComponent();
            _currentUserSRCode = CurrentUser.LoggedInUser?.SRCode;
            _ = LoadTasksForCurrentUserAsync();
            UpdateCountLabel("TransactionSheet", ApprovedLabel);
            UpdateCountLabel("ApprovalSheet", PendingLabel, "Pending");
            UpdateCountLabel("UserAccount", UserLabel);
            UpdatePieChart();
        }
        public class PieChartManager
        {
            private readonly LiveCharts.WinForms.PieChart _chart; 

            public PieChartManager(LiveCharts.WinForms.PieChart chart)
            {
                _chart = chart;
            }
        }
        private async void AddTaskBtn_Click(object sender, EventArgs e)
        {
            string taskType = TaskType.Text;

            if (string.IsNullOrEmpty(taskType))
            {
                MessageBox.Show("Task type cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string currentUserSRCode = CurrentUser.LoggedInUser.SRCode;
                var values = new List<IList<object>>
                {
                    new List<object> { currentUserSRCode, taskType }
                };

                var range = "AdminTask!A:A";
                var request = _sheetsService.Spreadsheets.Values.Get(SpreadsheetId, range);
                var response = await request.ExecuteAsync();
                var numRows = response.Values != null ? response.Values.Count : 0;

                string writeRange = $"AdminTask!A{numRows + 1}:B{numRows + 1}";
                var appendRequest = _sheetsService.Spreadsheets.Values.Append(new ValueRange
                {
                    Values = values
                }, SpreadsheetId, writeRange);

                appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                var appendResponse = await appendRequest.ExecuteAsync();

                MessageBox.Show("Task added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaskType.Text = "";
                await LoadTasksForCurrentUserAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while adding task: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadTasksForCurrentUserAsync()
        {
            try
            {
                var range = "AdminTask!A:B"; 
                var values = await _googleSheetsService.GetValuesAsync(range);

                if (values != null && values.Count > 0)
                {
                    CheckedTask.Items.Clear(); 

                    foreach (var row in values)
                    {
                        string taskUserSRCode = row[0].ToString();
                        string taskName = row[1].ToString();

                        if (taskUserSRCode == _currentUserSRCode)
                        {
                            CheckedTask.Items.Add(taskName); 
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

        private void DoneTask_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedIndices = CheckedTask.CheckedIndices.Cast<int>().ToList();

                foreach (int index in selectedIndices)
                {
                    string taskName = CheckedTask.Items[index].ToString();

                    var range = "AdminTask!B:B"; 
                    var values = _googleSheetsService.GetValues(range);

                    int rowIndex = -1;
                    if (values != null && values.Count > 0)
                    {
                        for (int i = 0; i < values.Count; i++)
                        {
                            if (values[i].Count > 0 && values[i][0].ToString() == taskName)
                            {
                                rowIndex = i + 1; 
                                break;
                            }
                        }
                    }

                    if (rowIndex != -1)
                    {
                        var deleteRequest = _sheetsService.Spreadsheets.Values.Clear(new ClearValuesRequest(), SpreadsheetId, $"AdminTask!A{rowIndex}:B{rowIndex}");
                        var deleteResponse = deleteRequest.Execute();
                    }
                }
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

        private void UpdateCountLabel(string sheetName, Label label)
        {
            try
            {
                string range = $"{sheetName}!A:A";
                var values = _googleSheetsService.GetValues(range);

                if (values != null && values.Count > 0)
                {
                    label.Text = (values.Count - 1).ToString(); 
                }
                else
                {
                    label.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving row count from {sheetName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCountLabel(string sheetName, Label label, string status)
        {
            try
            {
                string range = $"{sheetName}!F:F"; 
                var values = _googleSheetsService.GetValues(range);

                if (values != null && values.Count > 0)
                {
                    int count = values.Count(row => row.Count > 0 && row[0].ToString().ToLower() == status.ToLower());
                    label.Text = count.ToString();
                }
                else
                {
                    label.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving row count from {sheetName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task UpdatePieChartFromApprovalSheetAsync()
        {
            try
            {
                string range = "ApprovalSheet!F:F"; 
                var values = await _googleSheetsService.GetValuesAsync(range);

                int approvedCount = 0;
                int pendingCount = 0;
                int rejectedCount = 0;

                if (values != null && values.Count > 0)
                {
                    foreach (var row in values)
                    {
                        if (row.Count > 0)
                        {
                            string status = row[0].ToString().ToLower();
                            if (status == "approved")
                            {
                                approvedCount++;
                            }
                            else if (status == "pending")
                            {
                                pendingCount++;
                            }
                            else if (status == "rejected")
                            {
                                rejectedCount++;
                            }
                        }
                    }
                }

                StatusPie.Series.Clear();
                LiveCharts.SeriesCollection statusPieSeries = new LiveCharts.SeriesCollection
            {
                new PieSeries
                {
                    Title = "Approved",
                    Values = new ChartValues<int> { approvedCount },
                    Fill = System.Windows.Media.Brushes.Green
                },
                new PieSeries
                {
                    Title = "Pending",
                    Values = new ChartValues<int> { pendingCount },
                    Fill = System.Windows.Media.Brushes.Orange
                },
                new PieSeries
                {
                    Title = "Rejected",
                    Values = new ChartValues<int> { rejectedCount },
                    Fill = System.Windows.Media.Brushes.Red
                }
            };

                StatusPie.Series = statusPieSeries;
                panelStatusPie.Controls.Add(StatusPie);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving data from ApprovalSheet: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task UpdateServicePieChartFromTransactionSheetAsync()
        {
            try
            {
                string range = "TransactionSheet!B:B";
                var values = await _googleSheetsService.GetValuesAsync(range);

                int resourceCount = 0;
                int borrowCount = 0;
                int printCount = 0;

                if (values != null && values.Count > 0)
                {
                    foreach (var row in values)
                    {
                        if (row.Count > 0)
                        {
                            string serviceType = row[0].ToString().ToLower();
                            if (serviceType == "1")
                            {
                                resourceCount++;
                            }
                            else if (serviceType == "2")
                            {
                                borrowCount++;
                            }
                            else if (serviceType == "3")
                            {
                                printCount++;
                            }
                        }
                    }
                }
                ServicePie.Series.Clear();
                LiveCharts.SeriesCollection servicePieSeries = new LiveCharts.SeriesCollection
            {
                new PieSeries
                {
                    Title = "Resource",
                    Values = new ChartValues<int> { resourceCount },
                    Fill = System.Windows.Media.Brushes.Blue
                },
                new PieSeries
                {
                    Title = "Borrow",
                    Values = new ChartValues<int> { borrowCount },
                    Fill = System.Windows.Media.Brushes.Violet
                },
                new PieSeries
                {
                    Title = "Print",
                    Values = new ChartValues<int> { printCount },
                    Fill = System.Windows.Media.Brushes.Purple
                }
            };

                ServicePie.Series = servicePieSeries;
                panelServicePie.Controls.Add(ServicePie);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving data from TransactionSheet: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void UpdatePieChart()
        {
            await UpdatePieChartFromApprovalSheetAsync();
            await UpdateServicePieChartFromTransactionSheetAsync();
        }
    }
}