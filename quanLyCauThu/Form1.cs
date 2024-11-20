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


namespace quanLyCauThu {
  public partial class Form1 : Form {

    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e) {

      label1.Parent = pictureBox1;
      label1.ForeColor = Color.Black;

      pictureBox1.Controls.Add(pictureBox2);
      pictureBox2.BackColor = Color.Transparent;

      pictureBox1.Controls.Add(pictureBox3);
      pictureBox3.BackColor = Color.Transparent;
      pictureBox3.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);

      textBox1.BackColor = Color.White;
      textBox2.BackColor = Color.White;
    }


    private void button5_Click(object sender, EventArgs e) {
      Form2 form = new Form2();
      form.Show();
    }

    private void button9_Click(object sender, EventArgs e) {
      Form3 form = new Form3();
      form.Show();
    }

    private void button1_MouseEnter(object sender, EventArgs e) {
      textBox1.Visible = true;
      pictureBox2.Visible = true;
    }

    private void button1_MouseLeave(object sender, EventArgs e) {
      textBox1.Visible = false;
      pictureBox2.Visible = false;
    }

    private void button9_MouseEnter(object sender, EventArgs e) {
      textBox2.Visible = true;
      pictureBox3.Visible = true;
    }

    private void button9_MouseLeave(object sender, EventArgs e) {
      textBox2.Visible = false;
      pictureBox3.Visible = false;
    }
  }
}
