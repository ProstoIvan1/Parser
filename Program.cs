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
            TextFileImporter.RowSpliter = '\r';
            TextFileImporter.ValueSpliter = ',';
            TextFileImporter.SkipingSymbols.Add('\n');
            DataTable dt1 = TextFileImporter.ImportWithHeader(@"G:\Пробный ДЭ\18363\Сессия 1\service_b_import.txt");

            TextFileImporter.RowSpliter = '\n';
            TextFileImporter.ValueSpliter = ';';
            DataTable dt2 = TextFileImporter.ImportWithHeader(@"U:\Максимович ИА\ДЕМО-ЭКЗАМЕН\КОД 1.5._ВАРИАНТ_4\Сессия 1\materials_s_import.csv");
        }
    }
}
