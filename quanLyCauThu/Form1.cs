using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            textBox1.Text = "Nhập mã công dân";
            textBox2.Text = "Nhập họ và tên";
            textBox3.Text = "Nhập tuổi công dân";
            textBox4.Text = "Nhập điểm công dân";
            textBox1.ForeColor = Color.DarkGray;
            textBox2.ForeColor = Color.DarkGray;
            textBox3.ForeColor = Color.DarkGray;
            textBox4.ForeColor = Color.DarkGray;
            label1.Parent = pictureBox1;
            label1.ForeColor = Color.Black;
            button7.Visible = false;
            label2.Parent = pictureBox1;
            label2.ForeColor = Color.Black;
            label2.Visible = false;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Nhập mã công dân")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                textBox1.Text = "Nhập mã công dân";
                textBox1.ForeColor = Color.DarkGray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Nhập họ và tên")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Nhập họ và tên";
                textBox2.ForeColor = Color.DarkGray;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Nhập tuổi công dân";
                textBox3.ForeColor = Color.DarkGray;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Nhập tuổi công dân")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Nhập điểm công dân")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Nhập điểm công dân";
                textBox4.ForeColor = Color.DarkGray;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            button7.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
        }
    }
}
