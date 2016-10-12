using System;
using System.Data;
using System.Data.SqlClient;

namespace Chapter13
{
    class WriteXML
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
               productname,
               unitprice
            from
               products
         ";

            // create connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand(qry, conn);

                // open connection
                conn.Open();

                // create and fill dataset
                DataSet ds = new DataSet();
                da.Fill(ds, "products");

                // extract dataset to XML file
                ds.WriteXml(
                   @"C:\Documents and Settings\Administrator\My Documents\Visual Studio Codename Orcas\Projects\Chapter13\productstable.xml"

                ); Console.WriteLine("The file is Created");
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

