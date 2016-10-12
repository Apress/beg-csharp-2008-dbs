using System;
using System.Data;
using System.Data.SqlClient;

namespace Chapter13
{
    class PersistAddsBuilder
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
            string qry = @"
            select
               *
            from
               employees
            where
               country = 'UK'
         ";

            // create connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(qry, conn);

                // create command builder
                SqlCommandBuilder cb = new SqlCommandBuilder(da);

                // create and fill dataset
                DataSet ds = new DataSet();
                da.Fill(ds, "employees");

                // get data table reference
                DataTable dt = ds.Tables["employees"];

                // add a row
                DataRow newRow = dt.NewRow();
                newRow["firstname"] = "Roy";
                newRow["lastname"] = "Beatty";
                newRow["titleofcourtesy"] = "Sir";
                newRow["city"] = "Birmingham";
                newRow["country"] = "UK";
                dt.Rows.Add(newRow);

                // display rows
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(
                       "{0} {1} {2}",
                       row["firstname"].ToString().PadRight(15),
                       row["lastname"].ToString().PadLeft(25),
                       row["city"]);
                }

                // insert employees
                da.Update(ds, "employees");
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

