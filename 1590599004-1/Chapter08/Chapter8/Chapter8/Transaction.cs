using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Transaction : Form
    {
        public Transaction()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"
            data source = .\sqlexpress;
            integrated security = true;
            database = Northwind
         ");

            // INSERT statement
            string sqlins = @"
            insert into customers(customerid,companyname)
            values(@newcustid, @newconame)
         ";

            // DELETE statement
            string sqldel = @"
            delete from customers
            where customerid = @oldcustid
         ";

            // Open connection
            conn.Open();

            // Begin transaction
            SqlTransaction sqltrans = conn.BeginTransaction();

            try
            {
                // create insert command
                SqlCommand cmdins = conn.CreateCommand();
                cmdins.CommandText = sqlins;
                cmdins.Transaction = sqltrans;
                cmdins.Parameters.Add("@newcustid", System.Data.SqlDbType.NVarChar, 5);
                cmdins.Parameters.Add("@newconame", System.Data.SqlDbType.NVarChar, 30);

                // create delete command
                SqlCommand cmddel = conn.CreateCommand();
                cmddel.CommandText = sqldel;
                cmddel.Transaction = sqltrans;
                cmddel.Parameters.Add("@oldcustid", System.Data.SqlDbType.NVarChar, 5);

                // add customer
                cmdins.Parameters["@newcustid"].Value = textBox1.Text;
                cmdins.Parameters["@newconame"].Value = textBox2.Text;
                cmdins.ExecuteNonQuery();

                // delete customer
                cmddel.Parameters["@oldcustid"].Value = textBox3.Text;
                cmddel.ExecuteNonQuery();

                //Commit transaction
                sqltrans.Commit();

                // No exception, transaction committed, give message
                MessageBox.Show("Transaction committed");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //Roll back transaction
                sqltrans.Rollback();

                MessageBox.Show(
                   "Transaction rolled back\n" + ex.Message,
                   "Rollback Transaction"
                );
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("System Error\n" + ex.Message, "Error");
            }
            finally
            {
                // Close connection
                conn.Close();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
