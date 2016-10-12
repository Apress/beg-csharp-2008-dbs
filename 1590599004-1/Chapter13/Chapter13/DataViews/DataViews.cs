using System;
using System.Data;
using System.Data.SqlClient;

namespace Chapter13
{
    class DataViews
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
               contactname,
               country
            from
               customers
         ";

            // create connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                // Create data adapter
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sql, conn);

                // create and fill dataset
                DataSet ds = new DataSet();
                da.Fill(ds, "customers");

                // get data table reference
                DataTable dt = ds.Tables["customers"];

                // create data view
                DataView dv = new DataView(
                   dt,
                   "country = 'Germany'",
                   "country",
                   DataViewRowState.CurrentRows
                );

                // display data from data view
                foreach (DataRowView drv in dv)
                {
                    for (int i = 0; i < dv.Table.Columns.Count; i++)
                        Console.Write(drv[i] + "\t");
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
            finally
            {
                // close connection
                conn.Close();
            } Console.ReadLine();
        }
    }
}

