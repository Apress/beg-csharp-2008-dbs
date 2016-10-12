using System;
using System.Data;
using System.Data.SqlClient;

namespace Chapter12
{
    class SchemaTable
    {
        static void Main(string[] args)
        {
            // connection string
            string connString = @"
            server = .\sqlexpress;
            integrated security = true;
            database = northwind
         ";

            // query 
            string sql = @"
            select
               *
            from
               employees
         ";

            // create connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                // store Employees schema in a data table
                DataTable schema = rdr.GetSchemaTable();

                // display info from each row in the data table.
                // each row describes a column in the database table.
                foreach (DataRow row in schema.Rows)
                {
                    foreach (DataColumn col in schema.Columns)
                        Console.WriteLine(col.ColumnName + " = " + row[col]);
                    Console.WriteLine("----------------");
                }

                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occurred: " + e);
            }
            finally
            {
                conn.Close();
            } 
        }
    }
}
