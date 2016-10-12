﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace RetrieveText
{
    public class RetrieveText
    {
        string textFile = null;
        char[] textChars = null;
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;

        public RetrieveText()
        {
            // Create connection
            conn = new SqlConnection(@"
            data source = .\sqlexpress;
            integrated security = true;
            initial catalog = tempdb;
         ");

            // Create command
            cmd = new SqlCommand(
                 @"
              select
                 textfile,
                 textdata
              from
                 texttable
              "
               , conn
            );

            // Open connection
            conn.Open();

            // Create data reader
            dr = cmd.ExecuteReader();
        }

        public bool GetRow()
        {
            long textSize;
            int bufferSize = 100;
            long charsRead;
            textChars = new Char[bufferSize];

            if (dr.Read())
            {
                // Get file name
                textFile = dr.GetString(0);
                Console.WriteLine("------ start of file:");
                Console.WriteLine(textFile);
                textSize = dr.GetChars(1, 0, null, 0, 0);
                Console.WriteLine("--- size of text: {0} characters -----",
                   textSize);
                Console.WriteLine("--- first 100 characters in text -----");
                charsRead = dr.GetChars(1, 0, textChars, 0, 100);
                Console.WriteLine(new String(textChars));
                Console.WriteLine("--- last 100 characters in text -----");
                charsRead = dr.GetChars(1, textSize - 100, textChars, 0, 100);
                Console.WriteLine(new String(textChars));

                return true;
            }
            else
            {
                return false;
            }
        }

        public void endRetrieval()
        {
            // Close the reader and the connection. 
            dr.Close();
            conn.Close();
        }

        static void Main()
        {
            RetrieveText rt = null;
            try
            {
                rt = new RetrieveText();

                while (rt.GetRow() == true)
                {
                    Console.WriteLine("----- end of file:");
                    Console.WriteLine(rt.textFile);
                    Console.WriteLine("======================================");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                rt.endRetrieval();
            }
        }
    }
}

