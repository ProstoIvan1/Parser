
using DocumentFormat.OpenXml.Spreadsheet;
using System.Data;

namespace ConsoleApp
{
    public static class XLSXExporter
    {
        public static string FilePath { get; set; }

        public static void ExportToDB(string listName, string tableName)
        {

        }

        //public static DataTable ExportToDataTable(string listName)
        //{
        //    Workbook workbook = new Workbook(FilePath);
        //    Worksheet worksheet = workbook.Worksheets[0];
        //    foreach (var i in workbook.cell)
        //    {

        //    }
        //}
    }
}
