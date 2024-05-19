using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using System;
using System.IO;

namespace AdminPage
{
    internal class SheetServiceInitializer
    {
        public static readonly string SpreadsheetId = "1nFKEsGzUbNaWF4VJ4A1AnDinWDNkyEFlv6UTuwFNU_Y";
        private static readonly Lazy<SheetsService> lazy =
            new Lazy<SheetsService>(() => InitializeSheetsServiceFromEnvVar());

        public static SheetsService Instance => lazy.Value;

        private static SheetsService InitializeSheetsServiceFromEnvVar()
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
                    .CreateScoped(SheetsService.Scope.Spreadsheets);
            }

            return new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "ACICSTANCE CORNER",
            });
        }
    }
}
