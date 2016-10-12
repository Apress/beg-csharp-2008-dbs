using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Events : Form
    {
        public Events()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I have been Clicked");
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            label1.Text = "Mouse Enters into the TextBox";            
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            label1.Text = "Mouse Leaves the TextBox";            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt == true)
                label1.Text="The ALT has been pressed";
            else
                if (e.Control==true)
                    label1.Text="The Ctrl has been pressed";
                else
                    if (e.Shift==true)
                    label1.Text="The Shift has been pressed";                
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt == false || e.Control==false || e.Shift==false) 
                label1.Text = "The Key has been released";                    
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)==true)
                  label1.Text = "You have pressed a Numeric key";
               else
                  if(char.IsLetter(e.KeyChar)==true)
                  label1.Text = "You have pressed a Letter key";
            
               
        }                
    }
}


