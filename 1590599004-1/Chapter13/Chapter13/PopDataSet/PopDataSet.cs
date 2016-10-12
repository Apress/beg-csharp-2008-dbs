using System;
using System.Data;
using System.Data.SqlClient;

namespace Chapter13
{
    class PopDataSet
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
               productname,
               unitprice
            from
               products
            where
               unitprice < 20
         ";

            // create connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                // open connection
                conn.Open();

                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                // create dataset
                DataSet ds = new DataSet();

                // fill dataset
                da.Fill(ds, "products");

                // get data table
                DataTable dt = ds.Tables["products"];

                // display data
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                        Console.WriteLine(row[col]);
                    Console.WriteLine("".PadLeft(20, '='));
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
