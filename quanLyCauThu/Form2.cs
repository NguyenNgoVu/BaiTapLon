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
//using static System.Net.Mime.MediaTypeNames;

namespace quanLyCauThu {
  public partial class Form2 : Form {
    SqlConnection c = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\liemeid.mdf;Integrated Security=True;Connect Timeout=30");
    public Form2() {
      InitializeComponent();
    }

    private void Form2_Load(object sender, EventArgs e) {
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
      comboBox1.Items.Add("Già làng");
      comboBox1.Items.Add("Cò đất");
      comboBox1.Items.Add("Wibu");
      comboBox1.Items.Add("GENG con");
    }
    private void updateData() {
      SqlCommand cmd = new SqlCommand("SELECT * FROM congDan", c);
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataTable dt = new DataTable();
      adapter.Fill(dt);

      SqlCommand cmd2 = new SqlCommand("SELECT * FROM diemCong", c);
      SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
      DataTable dt2 = new DataTable();
      adapter2.Fill(dt2);

      SqlCommand cmd3 = new SqlCommand("SELECT * FROM diemTru", c);
      SqlDataAdapter adapter3 = new SqlDataAdapter(cmd3);
      DataTable dt3 = new DataTable();
      adapter3.Fill(dt3);


      foreach (DataRow row in dt.Rows) {
        int diemCongTotal = 0;
        foreach (DataRow diemCong in dt2.Select($"cccd = {row["cccd"]}")) {
          diemCongTotal += int.Parse(diemCong["diem"].ToString());
        }
        int diemTruTotal = 0;
        foreach (DataRow diemTru in dt3.Select($"cccd = {row["cccd"]}")) {
          diemTruTotal += int.Parse(diemTru["diem"].ToString());
        }

        row["diem"] = int.Parse(row["diem"].ToString()) + diemCongTotal - diemTruTotal;
      }
      dataGridView1.DataSource = dt;
    }


    private void hienB_Click(object sender, EventArgs e) {
      button5.Visible = true;
      button8.Visible = true;
    }

    private void button5_Click(object sender, EventArgs e) {
      totL.Visible = true;
      badL.Visible = false;
      SqlCommand cmd = new SqlCommand("SELECT TOP 3 * FROM congDan ORDER BY diem DESC", c);
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataTable dt = new DataTable();
      adapter.Fill(dt);
      dataGridView1.DataSource = dt;

    }

    private void button8_Click(object sender, EventArgs e) {
      badL.Visible = true;
      totL.Visible = false;
      SqlCommand cmd = new SqlCommand("SELECT TOP 3 * FROM congDan ORDER BY diem ASC", c);
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataTable dt = new DataTable();
      adapter.Fill(dt);
      dataGridView1.DataSource = dt;
    }

    private void button1_Click(object sender, EventArgs e) {
      string ngheNghiep = comboBox1.SelectedItem.ToString();
      int diemThayDoi = 0;


      if (ngheNghiep == "City boi")
        diemThayDoi = -200;
      else if (ngheNghiep == "Gamer")
        diemThayDoi = +100;
      else if (ngheNghiep == "Học vấn cao")
        diemThayDoi = +150;
      else if (ngheNghiep == "Đoàn viên")
        diemThayDoi = +175;
      else if (ngheNghiep == "Tattoo")
        diemThayDoi = 0;
      else if (ngheNghiep == "Gambler")
        diemThayDoi = -100;
      else if (ngheNghiep == "Hội phụ nữ")
        diemThayDoi = +50;
      else if (ngheNghiep == "Gymer")
        diemThayDoi = +50;
      else if (ngheNghiep == "Tiktoker")
        diemThayDoi = -150;
      else if (ngheNghiep == "Alan Walker")
        diemThayDoi = -50;
      else if (ngheNghiep == "Già làng")
        diemThayDoi = +200;
      else if (ngheNghiep == "Cò đất")
        diemThayDoi = -75;
      else if (ngheNghiep == "Wibu")
        diemThayDoi = +75;
      else if (ngheNghiep == "GENG con")
        diemThayDoi = -125;
      else diemThayDoi = 0;

      SqlCommand cmd = new SqlCommand("INSERT INTO congDan (cccd, hoTen, ngaySinh, diaChi, ngheNghiep,diem) VALUES (@cccd,@hoTen,@ngaySinh,@diaChi,@ngheNghiep,1000 + @diemThayDoi)", c);
      cmd.Parameters.AddWithValue("@cccd", textBox1.Text);
      cmd.Parameters.AddWithValue("@hoTen", textBox3.Text);
      cmd.Parameters.AddWithValue("@ngaySinh", dateTimePicker1.Value);
      cmd.Parameters.AddWithValue("@diaChi", textBox4.Text);
      cmd.Parameters.AddWithValue("@ngheNghiep", comboBox1.Text);
      cmd.Parameters.AddWithValue("@diemThayDoi", diemThayDoi);
      cmd.ExecuteNonQuery();

      updateData();
    }

    private void button2_Click(object sender, EventArgs e) {
      SqlCommand cmd = new SqlCommand("DELETE FROM congDan WHERE cccd=@cccd", c);
      cmd.Parameters.AddWithValue("@cccd", dataGridView1.CurrentRow.Cells["cccd"].Value);
      cmd.ExecuteNonQuery();
      updateData();
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
      textBox1.Text = dataGridView1.CurrentRow.Cells["cccd"].Value.ToString();
      textBox3.Text = dataGridView1.CurrentRow.Cells["hoTen"].Value.ToString();
      dateTimePicker1.Value = (DateTime) dataGridView1.CurrentRow.Cells["ngaySinh"].Value;
      textBox4.Text = dataGridView1.CurrentRow.Cells["diaChi"].Value.ToString();
      comboBox1.Text = dataGridView1.CurrentRow.Cells["ngheNghiep"].Value.ToString();
    }

    private void button3_Click(object sender, EventArgs e) {
      string ngheNghiep = comboBox1.SelectedItem.ToString();
      int diemThayDoi = 0;

      if (ngheNghiep == "City boi")
        diemThayDoi = -200;
      else if (ngheNghiep == "Gamer")
        diemThayDoi = +100;
      else if (ngheNghiep == "Học vấn cao")
        diemThayDoi = +150;
      else if (ngheNghiep == "Đoàn viên")
        diemThayDoi = +175;
      else if (ngheNghiep == "Tattoo")
        diemThayDoi = 0;
      else if (ngheNghiep == "Gambler")
        diemThayDoi = -100;
      else if (ngheNghiep == "Hội phụ nữ")
        diemThayDoi = +50;
      else if (ngheNghiep == "Gymer")
        diemThayDoi = +50;
      else if (ngheNghiep == "Tiktoker")
        diemThayDoi = -150;
      else if (ngheNghiep == "Alan Walker")
        diemThayDoi = -50;
      else if (ngheNghiep == "Già làng")
        diemThayDoi = +200;
      else if (ngheNghiep == "Cò đất")
        diemThayDoi = -75;
      else if (ngheNghiep == "Wibu")
        diemThayDoi = +75;
      else if (ngheNghiep == "GENG con")
        diemThayDoi = -125;
      else diemThayDoi = 0;

      SqlCommand cmd = new SqlCommand("UPDATE congDan SET cccd=@cccd,hoTen=@hoTen,ngaySinh=@ngaySinh,diaChi=@diaChi,ngheNghiep=@ngheNghiep, diem=1000+@diemThayDoi WHERE cccd=@cccd1", c);
      cmd.Parameters.AddWithValue("@cccd", textBox1.Text);
      cmd.Parameters.AddWithValue("@hoTen", textBox3.Text);
      cmd.Parameters.AddWithValue("@ngaySinh", dateTimePicker1.Value);
      cmd.Parameters.AddWithValue("@diaChi", textBox4.Text);
      cmd.Parameters.AddWithValue("@ngheNghiep", comboBox1.Text);
      cmd.Parameters.AddWithValue("@diemThayDoi", diemThayDoi);
      cmd.Parameters.AddWithValue("@cccd1", dataGridView1.CurrentRow.Cells["cccd"].Value);
      cmd.ExecuteNonQuery();

      updateData();
    }


    private void button4_Click(object sender, EventArgs e) {
      SqlCommand cmd = new SqlCommand("SELECT * FROM congDan ORDER BY diem DESC", c);
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataTable dt = new DataTable();
      adapter.Fill(dt);
      dataGridView1.DataSource = dt;
    }

  }
}
