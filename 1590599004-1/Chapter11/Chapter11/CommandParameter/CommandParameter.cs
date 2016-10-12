using System;
using System.Data;
using System.Data.SqlClient;

namespace Chapter11
{
    class CommandParameters
    {
        static void Main()
        {
            // set up rudimentary data
            string fname = "Zachariah";
            string lname = "Zinn";

            // create connection
            SqlConnection conn = new SqlConnection(@"
            server = .\sqlexpress;
            integrated security = true;
            database = northwind
         ");

            // define scalar query
            string sqlqry = @"
            select
               count(*)
            from
               employees
         ";

            // define insert statement
            string sqlins = @"
            insert into employees
            (
               firstname,
               lastname
            )
            values(@fname, @lname)
         ";

            // define delete statement
            string sqldel = @"
            delete from employees
            where
               firstname = @fname
               and
               lastname = @lname
         ";

            // create commands
            SqlCommand cmdqry = new SqlCommand(sqlqry, conn);
            SqlCommand cmdnon = new SqlCommand(sqlins, conn);
            cmdnon.Prepare();

            // add parameters to the command for statements
            cmdnon.Parameters.Add("@fname", SqlDbType.NVarChar, 10);
            cmdnon.Parameters.Add("@lname", SqlDbType.NVarChar, 20);
            
            try
            {
                // open connection
                conn.Open();

                // execute query to get number of employees
                Console.WriteLine(
                   "Before INSERT: Number of employees {0}\n"
                  , cmdqry.ExecuteScalar()
                );

                // execute nonquery to insert an employee
                cmdnon.Parameters["@fname"].Value = fname;
                cmdnon.Parameters["@lname"].Value = lname;
                Console.WriteLine(
                   "Executing statement {0}"
                 , cmdnon.CommandText
                );
                cmdnon.ExecuteNonQuery();
                Console.WriteLine(
                   "After INSERT: Number of employees {0}\n"
                  , cmdqry.ExecuteScalar()
                );

                // execute nonquery to delete an employee
                cmdnon.CommandText = sqldel;
                Console.WriteLine(
                   "Executing statement {0}"
                 , cmdnon.CommandText
                );
                cmdnon.ExecuteNonQuery();
                Console.WriteLine(
                   "After DELETE: Number of employees {0}\n"
                  , cmdqry.ExecuteScalar()
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

