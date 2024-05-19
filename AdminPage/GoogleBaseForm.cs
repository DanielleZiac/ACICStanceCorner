using Google.Apis.Sheets.v4;
using System.Windows.Forms;

namespace AdminPage
{
    public class GoogleBaseForm : Form
    {
        protected SheetsService SheetsService { get; private set; }
        protected GoogleSheetsService GoogleSheetsService { get; private set; }

        public GoogleBaseForm()
        {
            // Initialize Google Sheets service using SheetServiceInitializer
            InitializeSheetsService();
        }

        private void InitializeSheetsService()
        {
            // Retrieve SheetsService instance from SheetServiceInitializer
            SheetsService = SheetServiceInitializer.Instance;
            GoogleSheetsService = new GoogleSheetsService();
        }
    }
}
