using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.EntityClient;


namespace EntityDataModel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {        

             EntityConnection connection = new EntityConnection("name=NorthwindEntitiesConnectionString");
             connection.Open();
             EntityCommand command = connection.CreateCommand();
             command.CommandText = "select E.FirstName,E.LastName from NorthwindEntitiesConnectionString.Employees as E";
             EntityDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess);
                lstEmployees.Items.Clear();
                while (reader.Read())
                {
                    lstEmployees.Items.Add(reader["FirstName"] + " " + reader["LastName"]);
                }

            
        }
    }
}