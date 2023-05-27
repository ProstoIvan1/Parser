using System.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.TableHandlers
{
    internal class MaterialsHandler : CarrentDataTableHandler
    {
        private static string GetNullable(string sourseStr)
        {
            switch(sourseStr)
            {
                case "не указано":
                    return null;
                case "нет":
                    return null;
                case "отсутствует":
                    return null;
            }
            return sourseStr;
        }
        protected override DataRow GetNewRow(DataTable sourseTable, int id)
        {
            DataRow newRow = TableTemplate.NewRow();

            newRow.ItemArray = new object[]
            {
                    id + 1,                                                              //ID
                    sourseTable.Rows[id][0],                                             //Name
                    DataBase.GetValue<int>($"SELECT ID FROM MaterialType WHERE Name = '{sourseTable.Rows[id][1]}'"),     //Type
                    GetNullable((string) sourseTable.Rows[id][2]),                                             //ImagePath
                    GetNumber((string) sourseTable.Rows[id][3]),                         //Prize
                    GetNumber((string) sourseTable.Rows[id][4]),                         //Quantity
                    GetNumber((string) sourseTable.Rows[id][5]),                         //MinimumQuantity
                    GetNumber((string) sourseTable.Rows[id][6]),                         //QuantityPerPackage
                    DataBase.GetValue<int>($"SELECT ID FROM UnitOfMeasure WHERE Name = '{sourseTable.Rows[id][7]}'"),    //UnitOfMeasure
            };
            return newRow;
        }

        protected override DataTable TableTemplate { get; } = DataBase.GetFromDB("SELECT * FROM Material");
    }
}
