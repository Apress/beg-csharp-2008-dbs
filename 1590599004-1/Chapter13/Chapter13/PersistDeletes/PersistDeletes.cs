using System;
using System.Data;
using System.Data.SqlClient;

namespace Chapter13
{
    class PersistDeletes
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

            // SQL to delete employees
            string del = @"
            delete from employees
            where
               employeeid = @employeeid
         ";

            // create connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(qry, conn);

                // create and fill dataset
                DataSet ds = new DataSet();
                da.Fill(ds, "employees");

                // get data table reference
                DataTable dt = ds.Tables["employees"];

                // delete employees
                //
                // create command
                SqlCommand cmd = new SqlCommand(del, conn);
                //
                // map parameters
                cmd.Parameters.Add(
                   "@employeeid",
                   SqlDbType.Int,
                   4,
                   "employeeid");
                //
                // select employees
                string filt = @"
                  firstname = 'Roy'
                  and
                  lastname = 'Beatty'
            ";
                //
                // delete employees
                foreach (DataRow row in dt.Select(filt))
                {
                    row.Delete();
                }
                da.DeleteCommand = cmd;
                da.Update(ds, "employees");

                // display rows
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(
                       "{0} {1} {2}",
                       row["firstname"].ToString().PadRight(15),
                       row["lastname"].ToString().PadLeft(25),
                       row["city"]);
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
