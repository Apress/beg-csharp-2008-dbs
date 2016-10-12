using System;
using System.Data;
using System.Data.OleDb;

namespace Chapter09
{
    class OleDbProvider
    {
        static void Main(string[] args)
        {
            // Set up connection string
            string connString = @"
            provider = sqloledb;
            data source = .\sqlexpress;
            integrated security = sspi;
            initial catalog = northwind
         ";

            // Set up query string
            string sql = @"
            select
               *
            from
               employees
         ";

            // Declare connection and data reader variables
            OleDbConnection conn = null;
            OleDbDataReader reader = null;

            try
            {
                // Open connection
                conn = new OleDbConnection(connString);
                conn.Open();

                // Execute the query
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                reader = cmd.ExecuteReader();

                // Display output header
                Console.WriteLine(
                   "This program demonstrates the use of "
                 + "the OLE DB Data Provider."
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
