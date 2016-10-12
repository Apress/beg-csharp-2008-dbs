﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace Chapter12
{
    class MultipleResults
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
               companyname,
               contactname
            from
               customers
            where
               companyname like 'A%'
         ";

            // query 2
            string sql2 = @"
            select
               firstname,
               lastname
            from
               employees
         ";

            // combine queries
            string sql = sql1 + sql2;

            // create connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                // open connection
                conn.Open();

                // create command
                SqlCommand cmd = new SqlCommand(sql, conn);

                // create data reader
                SqlDataReader rdr = cmd.ExecuteReader();

                // loop through result sets
                do
                {
                    while (rdr.Read())
                    {
                        // Print one row at a time
                        Console.WriteLine("{0} : {1}", rdr[0], rdr[1]);
                    }
                    Console.WriteLine("".PadLeft(60, '='));
                }
                while (rdr.NextResult());

                // close data reader
                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occurred: " + e);
            }
            finally
            {
                // Close connection
                conn.Close();
            } 
        }
    }
}

