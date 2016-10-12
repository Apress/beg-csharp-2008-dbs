using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Chapter16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create connection
            SqlConnection conn = new SqlConnection(@"
            data source = .\sqlexpress;
            integrated security = true;
            database = northwind
         ");

            // Create command
            SqlCommand cmd = conn.CreateCommand();

            // Specify that a stored procedure is to be executed
            cmd.CommandType = CommandType.StoredProcedure;

            // Deliberately fail to specify the procedure
            // cmd.CommandText = "sp_Select_All_Employees";

            try
            {
                // Open connection
                conn.Open();
                // Create data reader
                SqlDataReader dr = cmd.ExecuteReader();
                // Close reader
                dr.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string str;
                str = "Source: " + ex.Source;
                str += "\n" + "Exception Message: " + ex.Message;
                MessageBox.Show(str, "Database Exception");
            }
            catch (System.Exception ex)
            {
                string str;
                str = "Source: " + ex.Source;
                str += "\n" + "Exception Message: " + ex.Message;
                MessageBox.Show(str, "Non-Database Exception");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    MessageBox.Show("Finally block closing the connection", "Finally");
                    conn.Close();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create connection
            SqlConnection conn = new SqlConnection(@"
            data source = .\sqlexpress;
            integrated security = true;
            database = northwind
         ");

            // Create command
            SqlCommand cmd = conn.CreateCommand();

            // Specify that a stored procedure is to be executed
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_Select_No_Employees";

            try
            {
                // Open connection
                conn.Open();

                // Create data reader
                SqlDataReader dr = cmd.ExecuteReader();

                // Access nonexistent column
                string str = dr.GetValue(20).ToString();

                // Close reader
                dr.Close();
            }
            catch (System.InvalidOperationException ex)
            {
                string str;
                str = "Source: " + ex.Source;
                str += "\n" + "Message: " + ex.Message;
                str += "\n" + "\n";
                str += "\n" + "Stack Trace: " + ex.StackTrace;
                MessageBox.Show(str, "Specific Exception");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string str;
                str = "Source: " + ex.Source;
                str += "\n" + "Exception Message: " + ex.Message;
                MessageBox.Show(str, "Database Exception");
            }
            catch (System.Exception ex)
            {
                string str;
                str = "Source: " + ex.Source;
                str += "\n" + "Exception Message: " + ex.Message;
                MessageBox.Show(str, "Non-Database Exception");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    MessageBox.Show("Finally block closing the connection", "Finally");
                    conn.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Create connection
            SqlConnection conn = new SqlConnection(@"
            data source = .\sqlexpress;
            integrated security = true;
            database = northwind
         ");

            // Create command
            SqlCommand cmd = conn.CreateCommand();

            // Specify that a stored procedure to be executed
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_DbException_1";

            try
            {
                // Open connection
                conn.Open();

                // Execute stored procedure
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string str;
                str = "Source: " + ex.Source;
                str += "\n" + "Number: " + ex.Number.ToString();
                str += "\n" + "Message: " + ex.Message;
                str += "\n" + "Class: " + ex.Class.ToString();
                str += "\n" + "Procedure: " + ex.Procedure.ToString();
                str += "\n" + "Line Number: " + ex.LineNumber.ToString();
                str += "\n" + "Server: " + ex.Server.ToString();

                MessageBox.Show(str, "Database Exception");
            }
            catch (System.Exception ex)
            {
                string str;
                str = "Source: " + ex.Source;
                str += "\n" + "Exception Message: " + ex.Message;
                MessageBox.Show(str, "General Exception");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    MessageBox.Show(
                        "Finally block closing the connection",
                       "Finally"
                    );
                    conn.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Create connection
            SqlConnection conn = new SqlConnection(@"
            data source = .\sqlexpress;
            integrated security = true;
            database = northwind
         ");

            // Create command
            SqlCommand cmd = conn.CreateCommand();

            // Specify stored procedure to be executed
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_DbException_2";

            try
            {
                // Open connection
                conn.Open();

                // Execute stored procedure
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string str;
                str = "Source: " + ex.Source;
                str += "\n" + "Number: " + ex.Number.ToString();
                str += "\n" + "Message: " + ex.Message;
                str += "\n" + "Class: " + ex.Class.ToString();
                str += "\n" + "Procedure: " + ex.Procedure.ToString();
                str += "\n" + "Line Number: " + ex.LineNumber.ToString();
                str += "\n" + "Server: " + ex.Server.ToString();

                MessageBox.Show(str, "Database Exception");
            }
            catch (System.Exception ex)
            {
                string str;
                str = "Source: " + ex.Source;
                str += "\n" + "Exception Message: " + ex.Message;
                MessageBox.Show(str, "ADO.NET Exception");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    MessageBox.Show(
                        "Finally block closing the connection",
                       "Finally"
                    );
                    conn.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Create connection
            SqlConnection conn = new SqlConnection(@"
            data source = .\sqlexpress;
            integrated security = true;
            database = northwnd
         ");

            // Create command
            SqlCommand cmd = conn.CreateCommand();

            // Specify stored procedure to be executed
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_DbException_2";

            try
            {
                // Open connection
                conn.Open();

                // Execute stored procedure
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string str = "";
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    str +=
                        "\n" + "Index #" + i + "\n"
                      + "Exception: " + ex.Errors[i].ToString() + "\n"
                      + "Number: " + ex.Errors[i].Number.ToString() + "\n"
                    ;
                }
                MessageBox.Show(str, "Database Exception");
            }
            catch (System.Exception ex)
            {
                string str;
                str = "Source: " + ex.Source;
                str += "\n" + "Exception Message: " + ex.Message;
                MessageBox.Show(str, "ADO.NET Exception");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    MessageBox.Show(
                        "Finally block closing the connection",
                       "Finally"
                    );
                    conn.Close();
                }
            }
        }

        
    }
}
