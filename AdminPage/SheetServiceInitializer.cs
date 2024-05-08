using Google.Apis.Sheets.v4;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using System.IO;

internal class SheetServiceInitializer
{
    private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
    private static readonly string ApplicationName = "ACICSTANCE CORNER";
    private SheetsService _sheetsService;
    private readonly string _spreadsheetId;


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
    public async Task<IList<IList<object>>> FetchValuesFromSheetAsync(string range)
    {
        if (_sheetsService == null)
        {
            throw new InvalidOperationException("SheetsService is not initialized.");
        }

        try
        {
            var request = _sheetsService.Spreadsheets.Values.Get(_spreadsheetId, range);
            var response = await request.ExecuteAsync();
            return response.Values;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching values from the sheet: {ex.Message}");
            return null;
        }
    }

    public IList<IList<object>> FetchValuesFromSheet(string range)
    {
        if (_sheetsService == null)
        {
            throw new InvalidOperationException("SheetsService is not initialized.");
        }

        try
        {
            var request = _sheetsService.Spreadsheets.Values.Get(_spreadsheetId, range);
            var response = request.Execute(); // Execute synchronously
            return response.Values;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching values from the sheet: {ex.Message}");
            return null;
        }
    }
}
