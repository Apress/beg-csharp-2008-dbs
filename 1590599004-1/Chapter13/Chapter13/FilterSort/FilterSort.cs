using System;
using System.Data;
using System.Data.SqlClient;

namespace Chapter13
{
    class FilterSort
    {
        static void Main(string[] args)
        {
            // connection string
            string connString = @"
            server = .\sqlexpress;
            integrated security = true;
            database = northwind
         ";

            // query 1
            string sql1 = @"
            select
               *
            from
               customers
         ";

            // query 2
            string sql2 = @"
            select
               *
            from
               products
            where
               unitprice < 10
         ";

            // combine queries
            string sql = sql1 + sql2;

            // create connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(sql, conn);

                // create and fill data set
                DataSet ds = new DataSet();
                da.Fill(ds, "customers");

                // get the data tables collection
                DataTableCollection dtc = ds.Tables;

                // display data from first data table
                //
                // display output header
                Console.WriteLine("Results from Customers table:");
                Console.WriteLine(
                   "CompanyName".PadRight(20) +
                   "ContactName".PadLeft(23) + "\n");

                // set display filter
                string fl = "country = 'Germany'";

                // set sort
                string srt = "companyname asc";

                // display filtered and sorted data
                foreach (DataRow row in dtc["customers"].Select(fl, srt))
                {
                    Console.WriteLine(
                       "{0}\t{1}",
                       row["CompanyName"].ToString().PadRight(25),
                       row["ContactName"]);
                }

                // display data from second data table
                //
                // display output header
                Console.WriteLine("\n----------------------------");
                Console.WriteLine("Results from Products table:");
                Console.WriteLine(
                   "ProductName".PadRight(20) +
                   "UnitPrice".PadLeft(21) + "\n");

                // display data
                foreach (DataRow row in dtc[1].Rows)
                {
                    Console.WriteLine("{0}\t{1}",
                       row["productname"].ToString().PadRight(25),
                       row["unitprice"]);
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

