using System.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp
{
    public static class TextFileImporter
    {
        public static char RowSpliter { get; set; }
        public static char ValueSpliter { get; set; }
        public static List<char> SkipingSymbols { get; } = new List<char>();
        private static void AddColumns(DataTable table, string header)
        {
            string columnName = "";
            bool isNewColumn = true;
            foreach (char c in header)
            {
                if (c == ValueSpliter || c == RowSpliter)
                {
                    table.Columns.Add($"[{columnName}]", typeof(string));
                    columnName = "";
                    isNewColumn = true;
                    continue;
                }
                if (!(SkipingSymbols.Contains(c) || (isNewColumn && c == ' ') || c == '\r'))
                {
                    columnName += c;
                    isNewColumn = false;
                }
            }
        }

        private static void AddRow(DataTable table, string strRow)
        {
            string value = "";
            DataRow row = table.NewRow();
            int i = 0;
            bool isNewValue = true;
            foreach (char c in strRow)
            {
                if (c == ValueSpliter || c == RowSpliter)
                {
                    row[i] = value;
                    value = "";
                    i++;
                    isNewValue = true;
                    continue;
                }
                if (!(SkipingSymbols.Contains(c) || (isNewValue && c == ' ') || c == '\r'))
                {
                    value += c;
                    isNewValue = false;
                }
            }

            table.Rows.Add(row);
        }

        private static string[] GetLines(this StreamReader reader) => reader.ReadToEnd().Split(RowSpliter);

        public static DataTable ImportWithHeader(string textFilePath)
        {
            DataTable table = new DataTable();
            using (StreamReader reader = new StreamReader(textFilePath, false))
            {
                try
                {
                    AddColumns(table, reader.ReadLine() + RowSpliter);
                    foreach(string strRow in reader.GetLines())
                    {
                        if(strRow != "") AddRow(table, strRow + RowSpliter);
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
