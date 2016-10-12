using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class WinApp : Form
    {
        public WinApp()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello" + ' ' + txtFname.Text + ' ' 
            + txtLname.Text + ' ' + "Welcome to the Windows Application","Welcome");

        } 

             
               
    }
}
