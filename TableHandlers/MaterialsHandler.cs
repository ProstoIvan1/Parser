using System.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.TableHandlers
{
    internal class MaterialsHandler : CarrentDataTableHandler
    {
        public DataTable MaterialTypeTable { get; set; }
        public DataTable UnitOfMeasureTable { get; set; }
        public override DataTable GetNewTable(DataTable sourseTable)
        {
            DataTable resultTable = DataBase.GetFromDB("SELECT * FROM Material");
            if (resultTable.Rows.Count > 0 ) 
            {
                throw new Exception("Table is already fill");
            }

            for (int i = 0; i < sourseTable.Rows.Count; i++)
            {
                DataRow newRow = resultTable.NewRow();
                newRow.ItemArray = new object[]
                {
                    i + 1,                                                              //ID
                    sourseTable.Rows[i][0],                                             //Name
                    MaterialTypeTable.Select("Name = " + sourseTable.Rows[i][1]),       //Type
                    sourseTable.Rows[i][2],                                             //ImagePath
                    GetNumber((string) sourseTable.Rows[i][3]),                         //Prize
                    GetNumber((string) sourseTable.Rows[i][4]),                         //Quantity
                    GetNumber((string) sourseTable.Rows[i][5]),                         //MinimumQuantity
                    GetNumber((string) sourseTable.Rows[i][6]),                         //QuantityPerPackage
                    UnitOfMeasureTable.Select("Name = " + sourseTable.Rows[i][7]),      //UnitOfMeasure
                };

                resultTable.Rows.Add(newRow);
            }
            

            return resultTable;
        }

        protected override DataRow GetNewRow(DataTable sourseTable, DataTable resultTable, int id)
        {
            DataRow newRow = resultTable.NewRow();
            newRow.ItemArray = new object[]
            {
                    i + 1,                                                              //ID
                    sourseTable.Rows[id][0],                                             //Name
                    MaterialTypeTable.Select("Name = " + sourseTable.Rows[id][1]),       //Type
                    sourseTable.Rows[id][2],                                             //ImagePath
                    GetNumber((string) sourseTable.Rows[id][3]),                         //Prize
                    GetNumber((string) sourseTable.Rows[id][4]),                         //Quantity
                    GetNumber((string) sourseTable.Rows[id][5]),                         //MinimumQuantity
                    GetNumber((string) sourseTable.Rows[id][6]),                         //QuantityPerPackage
                    UnitOfMeasureTable.Select("Name = " + sourseTable.Rows[id][7]),      //UnitOfMeasure
            };
        }
    }
}
