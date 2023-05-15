﻿using ConsoleApp;
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
            DataTable dt = CSVImporter.ImportWithHeader(@"U:\Максимович ИА\ДЕМО-ЭКЗАМЕН\КОД 1.5._ВАРИАНТ_4\Сессия 1\materials_s_import.csv");
            MaterialsHandler.MaterialTypeTable = DataBase.GetFromDB("SELECT * FROM MaterialType");
            MaterialsHandler.UnitOfMeasureTable = DataBase.GetFromDB("SELECT * FROM UnitOfMeasure");
            MaterialsHandler handler = new MaterialsHandler();
            DataTable newDt = handler.GetNewTable(dt);
        }
    }
}
