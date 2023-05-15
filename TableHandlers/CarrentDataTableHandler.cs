using System.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.TableHandlers
{
    abstract public class CarrentDataTableHandler
    {
        protected abstract DataTable TableTemplate { get; }
        public DataTable GetNewTable(DataTable sourseTable)
        {
            DataTable resultTable = TableTemplate;
            if (resultTable.Rows.Count > 0)
            {
                throw new Exception("Table is already fill");
            }

            for (int i = 0; i < sourseTable.Rows.Count; i++)
            {
                resultTable.Rows.Add(GetNewRow(sourseTable, i));
            }


            return resultTable;
        }

        protected abstract DataRow GetNewRow(DataTable sourseTable, int id);
        private static string CutNonnumericSymbols(string str)
        {
            string result = "";
            foreach (char c in str)
            {
                if('0' <= c && c <= '9') result += c;
            }
            return result;
        }

        protected static int GetNumber(string str) => Convert.ToInt32(CutNonnumericSymbols(str));
    }
}
