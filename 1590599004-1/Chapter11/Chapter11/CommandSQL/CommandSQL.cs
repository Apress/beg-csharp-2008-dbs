using System;
using System.Data;
using System.Data.SqlClient;

namespace Chapter11
{
    class CommandSql
    {
        static void Main()
        {
            // create connection
            SqlConnection conn = new SqlConnection(@"
            server = .\sqlexpress;
            integrated security = true;
            database = northwind
         ");

            // create command
            SqlCommand cmd = new SqlCommand();
            Console.WriteLine("Command created.");

            try
            {
                // open connection
                conn.Open();           
                
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
