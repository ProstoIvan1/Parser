using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleApp
{
    public static class DataBase
    {
        public static SqlConnection Connection { get; } = new SqlConnection(@"Server=DBSRV\ag2022; Database=KotovIN_007b1_ImportSk; Trusted_Connection=True;");

        public static DataTable GetFromDB(string selectCommand)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand, Connection);
            Connection.Open();
            try
            {
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }

            finally
            {
                Connection.Close();
            }
        }

        public static T GetValue<T>(string selectCommand)
        {
            SqlCommand command = new SqlCommand(selectCommand, Connection);
            Connection.Open();
            try
            {
                SqlDataReader reader = command.ExecuteReader();

                try
                {
                    if (reader.Read()) return reader.GetFieldValue<T>(0);
                    else throw new Exception("Value not found");
                }

                finally
                {
                    reader.Close();
                }
            }

            finally
            {
                Connection.Close();
            }
        }

        public static void ClearTable(string tableName)
        {
            SqlCommand sqlCommand = new SqlCommand("DELETE " + tableName, Connection);
            try
            {
                Connection.Open();
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                Connection.Close();
            }
        }

        public static void SetToDB(this DataTable dataTable, string tableName)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM " + tableName, Connection);
            new SqlCommandBuilder(adapter);
            adapter.Update(dataTable);
        }
    }
}
