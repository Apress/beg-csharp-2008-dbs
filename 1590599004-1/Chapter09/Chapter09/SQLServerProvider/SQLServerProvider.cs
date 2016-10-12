using System;
//using System.Data;
using System.Data.SqlClient;

namespace Chapter09
{
    class SqlServerProvider
    {
        static void Main(string[] args)
        {
            // Set up connection string
            string connString = @"
            server = .\sqlexpress;
            integrated security = true;
            database = northwind
         ";

            // Set up query string
            string sql = @"
            select
               *
            from
               employees
         ";

            // Declare connection and data reader variables
            SqlConnection conn = null;
            SqlDataReader reader = null;

            try
            {
            // Open connection
            conn = new SqlConnection(connString);
            conn.Open();

            // Execute the query
            SqlCommand cmd = new SqlCommand(sql, conn);
            reader = cmd.ExecuteReader();

            // Display output header
            Console.WriteLine(
               "This program demonstrates the use of "
             + "the SQL Server Data Provider."
            );
            Console.WriteLine(
               "Querying database {0} with query {1}\n"
             , conn.Database
             , cmd.CommandText
            );
            Console.WriteLine("First Name\tLast Name\n");

            // Process the result set
            while (reader.Read())
            {
                Console.WriteLine(
                   "{0} | {1}"
                 , reader["FirstName"].ToString().PadLeft(10)
                 , reader[1].ToString().PadLeft(10)
                );
            }
            }
            catch (Exception e)
            {
               Console.WriteLine("Error: " + e);
            }
             finally
            {
            // Close connection
            reader.Close();
            conn.Close();
            }
        }
    }
}