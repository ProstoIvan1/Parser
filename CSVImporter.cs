using System.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp
{
    public static class CSVImporter
    {
        private static void AddColumns(DataTable table, string header)
        {
            string tableName = "";
            foreach (char c in header)
            {
                if (c == ';' || c == '\n')
                {
                    table.Columns.Add($"[{tableName}]", typeof(string));
                    tableName = "";
                    continue;
                }
                tableName += c;
            }
        }

        private static void AddRow(DataTable table, string strRow)
        {
            string value = "";
            DataRow row = table.NewRow();
            int i = 0;
            foreach (char c in strRow)
            {
                if (c == ';' || c == '\n')
                {
                    row[i] = value;
                    value = "";
                    i++;
                    continue;
                }
                value += c;
            }

            table.Rows.Add(row);
        }

        private static string[] GetLines(this StreamReader reader) => reader.ReadToEnd().Split('\n');

        public static DataTable ImportWithHeader(string csvFilePath)
        {
            DataTable table = new DataTable();
            using (StreamReader reader = new StreamReader(csvFilePath, false))
            {
                try
                {
                    AddColumns(table, reader.ReadLine() + '\n');
                    foreach(string strRow in reader.GetLines())
                    {
                        if(strRow != "") AddRow(table, strRow + '\n');
                    }
                }
                finally
                {
                    reader.Close();
                }

            }
            return table;
        }
    }
}
