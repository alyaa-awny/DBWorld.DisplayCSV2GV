using Microsoft.Win32;
using System.Data;
using System.IO;
using System.Windows;


namespace DBWorld.DisplayCSV2GV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = @"Receipts.csv";
            Receipts receiptsInfo = new Receipts();

            string[] receiptsArr;
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Business Unit", typeof(string));
            dataTable.Columns.Add("Receipt Method ID", typeof(string));
            dataTable.Columns.Add("Remittance Bank", typeof(string));
            dataTable.Columns.Add("Remittance Bank Account", typeof(string));
            dataTable.Columns.Add("Receipt Number", typeof(string));
            dataTable.Columns.Add("Receipt Amount", typeof(string));
            dataTable.Columns.Add("Receipt Date", typeof(string));
            dataTable.Columns.Add("Accounting Date", typeof(string));
            dataTable.Columns.Add("Conversion Date", typeof(string));
            dataTable.Columns.Add("Currency", typeof(string));
            dataTable.Columns.Add("Conversion Rate Type", typeof(string));
            dataTable.Columns.Add("Conversion Rate", typeof(string));
            dataTable.Columns.Add("Customer Name", typeof(string));
            dataTable.Columns.Add("Customer Account Number", typeof(string));
            dataTable.Columns.Add("Customer Site Number", typeof(string));
            dataTable.Columns.Add("Invoice Number Reference", typeof(string));
            dataTable.Columns.Add("Invoice Amount", typeof(string));
            dataTable.Columns.Add("Comments", typeof(string));

            using (StreamReader sr = new StreamReader(openFileDialog.FileName))
            {
                while (!sr.EndOfStream)
                {
                    receiptsArr = sr.ReadLine().Split(",");
                    //receiptsInfo.BusinessUnit = receiptsArr[0];
                    //receiptsInfo.ReceiptMethodID = receiptsArr[1];
                    //receiptsInfo.RemittanceBank = receiptsArr[2];
                    //receiptsInfo.RemittanceBankAccount = receiptsArr[3];
                    //receiptsInfo.ReceiptNumber = receiptsArr[4];
                    //receiptsInfo.ReceiptAmount = receiptsArr[5];
                    //receiptsInfo.ReceiptDate = receiptsArr[6];
                    //receiptsInfo.AccountingDate = receiptsArr[7];
                    //receiptsInfo.ConversionDate = receiptsArr[8];
                    //receiptsInfo.Currency = receiptsArr[9];
                    //receiptsInfo.ConversionRateType = receiptsArr[10];
                    //receiptsInfo.ConversionRate = receiptsArr[9];
                    //receiptsInfo.CustomerName = receiptsArr[12];
                    //receiptsInfo.CustomerAccountNumber = receiptsArr[13];
                    //receiptsInfo.CustomerSiteNumber = receiptsArr[14];
                    //receiptsInfo.InvoiceNumberReference = receiptsArr[10];
                    //receiptsInfo.InvoiceAmount = receiptsArr[11];
                    //receiptsInfo.Comments = receiptsArr[17];
                    dataTable.Rows.Add(receiptsArr);
                }
                DataView dataView = new DataView(dataTable);
                dtGridView.ItemsSource = dataView;

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            string csvFilePath = Server.MapPath("~/input.csv");
            string xlsxFilePath = Server.MapPath("~/output.xlsx");

            ConvertCsvToXlsx(csvFilePath, xlsxFilePath);

            FileInfo xlsxFile = new FileInfo(xlsxFilePath);

            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment; filename=output.xlsx");
            Response.BinaryWrite(xlsxFile.GetAsByteArray());
            Response.End();

            return null;


        }
    }
}
