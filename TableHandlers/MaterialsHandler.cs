using System.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.TableHandlers
{
    internal class MaterialsHandler : CarrentDataTableHandler
    {
        public static DataTable MaterialTypeTable { get; set; }
        public static DataTable UnitOfMeasureTable { get; set; }

        protected override DataRow GetNewRow(DataTable sourseTable, int id)
        {
            DataRow newRow = TableTemplate.NewRow();

            newRow.ItemArray = new object[]
            {
                    id + 1,                                                              //ID
                    sourseTable.Rows[id][0],                                             //Name
                    MaterialTypeTable.Select($"Name = '{sourseTable.Rows[id][1]}'"),     //Type
                    sourseTable.Rows[id][2],                                             //ImagePath
                    GetNumber((string) sourseTable.Rows[id][3]),                         //Prize
                    GetNumber((string) sourseTable.Rows[id][4]),                         //Quantity
                    GetNumber((string) sourseTable.Rows[id][5]),                         //MinimumQuantity
                    GetNumber((string) sourseTable.Rows[id][6]),                         //QuantityPerPackage
                    UnitOfMeasureTable.Select($"Name = '{sourseTable.Rows[id][7]}'"),    //UnitOfMeasure
            };
            return newRow;
        }

        protected override DataTable TableTemplate { get; } = DataBase.GetFromDB("SELECT * FROM Material");
    }
}
