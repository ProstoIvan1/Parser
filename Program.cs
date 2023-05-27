using ConsoleApp;
using ConsoleApp.TableHandlers;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ServerImport
{
    class Program
    {

        static void Main(string[] args)
        {
            TextFileImporter.RowSpliter = '\n';
            TextFileImporter.ValueSpliter = ';';
            DataTable dt1 = TextFileImporter.ImportWithHeader(@"C:\temp\Parser\data\materials_s_import.csv");

            MaterialsHandler materialsHandler = new MaterialsHandler();
            DataTable dt2 = materialsHandler.GetNewTable(dt1);
            dt2.SetToDB("Material");
        }
    }
}
