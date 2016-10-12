﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace Chapter10
{
    class ConnectionDisplay
    {
        static void Main()
        {
            // Create connection
            SqlConnection conn = new SqlConnection(@"
            server = .\sqlexpress;
            user id=administrator;
            integrated security = true;
         ");

            try
            {
                // Open connection
                conn.Open();
                Console.WriteLine("Connection opened.");

                // Display connection properties
                Console.WriteLine("Connection Properties:");
                Console.WriteLine(
                   "\tConnection String: {0}",
                   conn.ConnectionString);
                Console.WriteLine(
                   "\tDatabase: {0}",
                   conn.Database);
                Console.WriteLine(
                   "\tDataSource: {0}",
                   conn.DataSource);
                Console.WriteLine(
                   "\tServerVersion: {0}",
                   conn.ServerVersion);
                Console.WriteLine(
                   "\tState: {0}",
                   conn.State);
                Console.WriteLine(
                   "\tWorkstationId: {0}",
                   conn.WorkstationId);
            }
            catch (SqlException e)
            {
                // Display error
                Console.WriteLine("Error: " + e);
            }
            finally
            {
                // Close connection
                conn.Close();
                Console.WriteLine("Connection closed.");
            }
        }
    }
}
 
