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
    public partial class ParentForm : Form
    {
        public ParentForm()
        {
            InitializeComponent();
        }

        private void winAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WinApp wa = new WinApp();
            wa.MdiParent = this;
            wa.Show();
        }

        private void addNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNames an = new AddNames();
            an.MdiParent=this;
            an.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }      

        
    }
}
