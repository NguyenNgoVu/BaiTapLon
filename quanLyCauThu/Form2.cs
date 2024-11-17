using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace quanLyCauThu
{
    public partial class Form2 : Form
    {
        SqlConnection c = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\luv\BaiTapLon\quanLyCauThu\liemeid.mdf;Integrated Security=True;Connect Timeout=30");
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           c.Open();
            updateData();
            totL.Visible = false;
            badL.Visible = false;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy";
            dataGridView1.Columns["ngaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns["hoTen"].Width = 200;
            dataGridView1.Columns["hoTen"].Resizable = DataGridViewTriState.True;
            dataGridView1.Columns["ngheNghiep"].Width = 130;
            dataGridView1.Columns["ngheNghiep"].Resizable = DataGridViewTriState.True;
            comboBox1.Items.Add("City boi");
            comboBox1.Items.Add("Gamer");
            comboBox1.Items.Add("Học vấn cao");
            comboBox1.Items.Add("Đoàn viên");
            comboBox1.Items.Add("Gambler");
            comboBox1.Items.Add("Tattoo");
            comboBox1.Items.Add("Gymer");
            comboBox1.Items.Add("Hội phụ nữ");
            comboBox1.Items.Add("Tiktoker");
            comboBox1.Items.Add("Alan Walker");
     
        }
        private void updateData()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM congDan", c);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
     

        private void hienB_Click(object sender, EventArgs e)
        {
            button5.Visible = true;
            button8.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            totL.Visible = true;
            badL.Visible = false;
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            badL.Visible = true;
            totL.Visible = false;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            string ngheNghiep = comboBox1.SelectedItem.ToString();
            int diemThayDoi = 0;

            
            if (ngheNghiep == "City boi")
                diemThayDoi = -200;
            else if (ngheNghiep == "Gamer")
                diemThayDoi = +100;
            else if (ngheNghiep == "Học vấn cao")
                diemThayDoi = +100;
            else if (ngheNghiep == "Đoàn viên")
                diemThayDoi = +150;
            else if (ngheNghiep == "Tattoo")
                diemThayDoi = 0;
            else if (ngheNghiep == "Gambler")
                diemThayDoi = -100;
            else if (ngheNghiep == "Hội phụ nữ")
                diemThayDoi = +50;
            else if (ngheNghiep == "Gymer")
                diemThayDoi = +50;
            else if (ngheNghiep == "Tiktoker")
                diemThayDoi = 0;
            else if (ngheNghiep == "Alan Walker")
                diemThayDoi = +50;
            else diemThayDoi = 0;

            SqlCommand cmd = new SqlCommand("INSERT INTO congDan VALUES (@cccd,@hoTen,@ngaySinh,@diaChi,@ngheNghiep,@diem + diemThayDoi)", c);
            cmd.Parameters.AddWithValue("@cccd", textBox1.Text);
            cmd.Parameters.AddWithValue("@hoTen", textBox3.Text);
            cmd.Parameters.AddWithValue("@ngaySinh", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@diaChi", textBox4.Text);
            cmd.Parameters.AddWithValue("@ngheNghiep", comboBox1.Text);
            cmd.ExecuteNonQuery();

            updateData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM congDan WHERE cccd=@cccd", c);
            cmd.Parameters.AddWithValue("@cccd", dataGridView1.CurrentRow.Cells["cccd"].Value);
            cmd.ExecuteNonQuery();
            updateData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["cccd"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["hoTen"].Value.ToString();
            dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells["ngaySinh"].Value;
            textBox4.Text = dataGridView1.CurrentRow.Cells["diaChi"].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells["ngheNghiep"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE congDan SET cccd=@cccd,hoTen=@hoTen,ngaySinh=@ngaySinh,diaChi=@diaChi,ngheNghiep=@ngheNghiep WHERE cccd=@cccd1", c);
            cmd.Parameters.AddWithValue("@cccd", textBox1.Text);
            cmd.Parameters.AddWithValue("@hoTen", textBox3.Text);
            cmd.Parameters.AddWithValue("@ngaySinh", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@diaChi", textBox4.Text);
            cmd.Parameters.AddWithValue("@ngheNghiep", comboBox1.Text);
            cmd.Parameters.AddWithValue("@cccd1", dataGridView1.CurrentRow.Cells["cccd"].Value);
            cmd.ExecuteNonQuery();

            updateData();
        }

      

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
