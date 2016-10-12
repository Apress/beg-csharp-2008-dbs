﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace Chapter12
{
    class TypedAccessors
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
               unitprice,
               unitsinstock,
               discontinued
            from
               products
         ";

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

                // fetch data
                while (rdr.Read())
                {
                    Console.WriteLine(
                       "{0}\t {1}\t\t {2}\t {3}",
                        // nvarchar
                       rdr.GetString(0).PadRight(30),
                        // money
                       rdr.GetDecimal(1),
                        // smallint
                       rdr.GetInt16(2),
                        // bit
                       rdr.GetBoolean(3));
                }

                // close data reader
                rdr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occurred: " + e);
            }
            finally
            {
                // close connection
                conn.Close();
            } 
        }
    }
}




