using OfficeOpenXml;
using System.IO;

namespace DBWorld.DisplayCSV2GV
{
    public class Receipts
    {
        public string BusinessUnit { get; set; } = string.Empty;
        public string ReceiptMethodID { get; set; } = string.Empty;
        public string RemittanceBank { get; set; } = string.Empty;
        public string RemittanceBankAccount { get; set; } = string.Empty;
        public string ReceiptNumber { get; set; } = string.Empty;
        public string ReceiptAmount { get; set; } = string.Empty;
        public string ReceiptDate { get; set; } = string.Empty;
        public string AccountingDate { get; set; } = string.Empty;
        public string ConversionDate { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string ConversionRateType { get; set; } = string.Empty;
        public string ConversionRate { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerAccountNumber { get; set; } = string.Empty;
        public string CustomerSiteNumber { get; set; } = string.Empty;
        public string InvoiceNumberReference { get; set; } = string.Empty;
        public string InvoiceAmount { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;

        public Receipts()
        {

        }
        static void ConvertCsvToXlsx(string csvFilePath, string xlsxFilePath)
        {
            FileInfo csvFile = new FileInfo(csvFilePath);
            FileInfo xlsxFile = new FileInfo(xlsxFilePath);

            using (ExcelPackage package = new ExcelPackage(xlsxFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
                int row = 1;

                using (StreamReader reader = new StreamReader(csvFile.FullName))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] csvLine = reader.ReadLine().Split(',');
                        for (int col = 1; col <= csvLine.Length; col++)
                        {
                            worksheet.Cells[row, col].Value = csvLine[col - 1];
                        }
                        row++;
                    }
                }

                package.Save();
            }
        }


    }

}

