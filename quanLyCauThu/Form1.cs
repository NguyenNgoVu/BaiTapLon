using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace quanLyCauThu
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
            label1.Parent = pictureBox1;
            label1.ForeColor = Color.Black;
            label2.Parent = pictureBox1;
            label2.ForeColor = Color.Black;
            label3.Parent = pictureBox1;
            label3.ForeColor = Color.Black;
            label4.Parent = pictureBox1;
            label4.ForeColor = Color.Black;
            label5.Parent = pictureBox1;
            label5.ForeColor = Color.Black;
            label6.Parent = pictureBox1;
            label6.ForeColor = Color.Black;
            label7.Parent = pictureBox1;
            label7.ForeColor = Color.Black;

        }

 
        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.Show();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            label2.Visible = true;
            label3.Visible = true;
            label7.Visible = true;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            label7.Visible = false;
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
        }
    }
}
