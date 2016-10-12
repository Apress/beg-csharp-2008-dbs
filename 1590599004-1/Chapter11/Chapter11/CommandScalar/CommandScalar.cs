using System;
using System.Data;
using System.Data.SqlClient;

namespace Chapter11
{
    class CommandScalar
    {
        static void Main()
        {
            // create connection
            SqlConnection conn = new SqlConnection(@"
            server = .\sqlexpress;
            integrated security = true;
            database = northwind
         ");

            // create command (with both text and connection)
            string sql = @"
            select
               count(*)
            from
               employees
         ";

            SqlCommand cmd = new SqlCommand(sql, conn);
            Console.WriteLine("Command created and connected.");

            try
            {
                // open connection
                conn.Open();

                // execute query
                Console.WriteLine(
                   "Number of Employees is {0}"
                 , cmd.ExecuteScalar()
                );
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
                Console.WriteLine("Connection Closed.");
            } 
        }
    }
}

