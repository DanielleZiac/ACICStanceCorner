using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminPage
{
    public class GoogleSheetsService
    {
        private readonly SheetsService _sheetsService;

        public GoogleSheetsService()
        {
            _sheetsService = SheetServiceInitializer.Instance;
        }
        public SheetsService GetSheetsService()
        {
            return _sheetsService;
        }

        public async Task<IList<IList<object>>> GetValuesAsync(string range)
        {
            // Retrieve values from a specified range in the Google Sheet
            var request = _sheetsService.Spreadsheets.Values.Get(SheetServiceInitializer.SpreadsheetId, range);
            var response = await request.ExecuteAsync();
            return response.Values;
        }
        public IList<IList<object>> GetValues(string range)
        {
            // Retrieve values from a specified range in the Google Sheet
            var request = _sheetsService.Spreadsheets.Values.Get(SheetServiceInitializer.SpreadsheetId, range);
            var response = request.Execute();
            return response.Values;
        }

        public async Task AppendDataAsync(string range, IList<IList<object>> values)
        {
            // Append data to the specified range in the Google Sheet
            var appendRequest = _sheetsService.Spreadsheets.Values.Append(new ValueRange { Values = values }, SheetServiceInitializer.SpreadsheetId, range);
            appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            await appendRequest.ExecuteAsync();
        }

        public async Task ClearValuesAsync(string range)
        {
            // Clear values from the specified range in the Google Sheet
            var clearRequest = _sheetsService.Spreadsheets.Values.Clear(new ClearValuesRequest(), SheetServiceInitializer.SpreadsheetId, range);
            await clearRequest.ExecuteAsync();
        }

        // Add more methods as needed, such as updating values, deleting rows, etc.
    }
}
