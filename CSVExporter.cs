using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace ConsoleApp
{
    public static class CSVExporter
    {

        private static string GetCSVString(DataRow row)
        {
            string result = "";
            foreach (var item in row.ItemArray)
            {
                result += item.ToString() + ';';
            }
            return result;
        }

        public static void ExportToCSV(DataTable table, string path)
        {
            StreamWriter writer = new StreamWriter(path, false);
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    writer.WriteLine(GetCSVString(row));
                }
            }
            finally
            {
                writer.Close();
            }

        }

    }
}
