using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DisplayImages
{
    public partial class DisplayImages : Form
    {
        public DisplayImages()
        {
            InitializeComponent();

            images = new Images();

            if (images.GetRow())
            {
                this.textBox1.Text = images.GetFilename();
                this.pictureBox1.Image = (Image)images.GetImage();
            }
            else
            {
                this.textBox1.Text = "DONE";
                this.pictureBox1.Image = null;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (images.GetRow())
            {
                this.textBox1.Text = images.GetFilename();
                this.pictureBox1.Image = (Image)images.GetImage();
            }
            else
            {
                this.textBox1.Text = "DONE";
                this.pictureBox1.Image = null;
            }

        }
    }
}
