using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanLyCauThu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //label1.Parent = pictureBox1;
            //label1.ForeColor = Color.Black;
            //label2.Parent = pictureBox1;
            //label2.ForeColor = Color.Black;
            //label3.Parent = pictureBox1;
            //label3.ForeColor = Color.Black;
            //label4.Parent = pictureBox1;
            //label4.ForeColor = Color.Black;
            //label5.Parent = pictureBox1;
            //label5.ForeColor = Color.Black;
            //label6.Parent = pictureBox1;
            //label6.ForeColor = Color.Black;
            totL.Visible = false;
            badL.Visible = false;
        }

        private void hienB_Click(object sender, EventArgs e)
        {
            button5.Visible = true;
            button8.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            totL.Visible = true;
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            badL.Visible = true;
        }
    }
}
