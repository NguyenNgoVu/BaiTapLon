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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace quanLyCauThu
{
    public partial class Form1 : Form
    {
        SqlConnection c = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\QLcongDan.mdf"";Integrated Security=True;Connect Timeout=30;Encrypt=True");
        DataTable dt = new DataTable();
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
            c.Open();
            updateData();
        }
        private void updateData()
        {
            dt.Clear();
            SqlCommand cmd = new SqlCommand("SELECT * FROM congDan", c);
            SqlDataAdapter a = new SqlDataAdapter(cmd);
            a.Fill(dt);
            dataGridView1.DataSource = dt;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["ma"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["hoTen"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["tuoi"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["diemCongDan"].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            updateData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO congDan VALUES (@ma,@hoTen,@tuoi,@diemCongDan)", c);
            cmd.Parameters.AddWithValue("@ma", textBox1.Text);
            cmd.Parameters.AddWithValue("@ten", textBox2.Text);
            cmd.Parameters.AddWithValue("@ban", textBox3.Text);
            cmd.Parameters.AddWithValue("@que", textBox4.Text);
            cmd.ExecuteNonQuery();
            updateData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM congDan WHERE ma=@ma", c);
            cmd.Parameters.AddWithValue("@ma", dataGridView1.CurrentRow.Cells["ma"].Value);
            cmd.ExecuteNonQuery();
            updateData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE congDan SET ma=@ma,hoTen=@hoTen,tuoi=@tuoi,diemCongDan=@diemCongDan WHERE ma=@ma2", c);
            cmd.Parameters.AddWithValue("@ma", textBox1.Text);
            cmd.Parameters.AddWithValue("@ten", textBox2.Text);
            cmd.Parameters.AddWithValue("@ban", textBox3.Text);
            cmd.Parameters.AddWithValue("@que", textBox4.Text);
            cmd.Parameters.AddWithValue("@ma2", dataGridView1.CurrentRow.Cells["ma"].Value);
            cmd.ExecuteNonQuery();
            updateData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dt.Clear();
            SqlCommand cmd = new SqlCommand("SELECT * FROM congDan WHERE ma=@ma", c);
            cmd.Parameters.AddWithValue("@ma", textBox1.Text);
            SqlDataAdapter a = new SqlDataAdapter(cmd);
            a.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
