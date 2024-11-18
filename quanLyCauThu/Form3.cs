using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanLyCauThu
{
    public partial class Form3 : Form
    {
        SqlConnection c = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\luv\BaiTapLon\quanLyCauThu\liemeid.mdf;Integrated Security=True;Connect Timeout=30");

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            c.Open();
            comboBox1.Items.Add("Tham gia đội dân quân tự vệ(+300)");
            comboBox1.Items.Add("Tham gia phòng chống dịch bệnh, ảnh hưởng của thiên tai(+300)");
            comboBox1.Items.Add("Tuân thủ pháp luật(+200)");
            comboBox1.Items.Add("Tham gia hiến máu(+200)");
            comboBox1.Items.Add("Quyên góp đồng bào khó khăn(+150)");
            comboBox1.Items.Add("Tham gia chiến dịch bảo vệ môi trường(+150)");
            comboBox1.Items.Add("Khác(+50)");

            comboBox2.Items.Add("Tàng trữ, sử dụng chất cấm(-300)");
            comboBox2.Items.Add("Dính líu đến hoạt động rửa tiền bất hợp pháp(-300)");
            comboBox2.Items.Add("Lừa đảo chiếm đoạt tài sản(-250)");
            comboBox2.Items.Add("Trộm cắp(-200)");
            comboBox2.Items.Add("Tham gia giao thông khi sử dụng rượu bia(-200)");
            comboBox2.Items.Add("Gây rối trật tự công cộng(-150)");
            comboBox2.Items.Add("Phóng nhanh vượt ẩu(-150)");
            comboBox2.Items.Add("Không đội mũ bảo hiểm khi sử dụng xe gắn máy(-100)");
            comboBox2.Items.Add("Vượt đèn đỏ(-100)");
            comboBox2.Items.Add("Xả rác bừa bãi(-50)");
            comboBox2.Items.Add("Hút pod(-50)");
            comboBox2.Items.Add("Khác(-50)");

        }


        private void button1_Click(object sender, EventArgs e)
        {
            int cccd = int.Parse(textBox1.Text);
            int diemCong = 0;
            int diemTru = 0;
            if (comboBox1.SelectedItem != null)
            {
                switch (comboBox1.SelectedItem)
                {
                    case "Tham gia đội dân quân tự vệ(+300)":
                        diemCong = +300;
                        break;
                    case "Tham gia phòng chống dịch bệnh, ảnh hưởng của thiên tai(+300)":
                        diemCong = +300;
                        break;
                    case "Tuân thủ pháp luật(+200)":
                        diemCong = +200;
                        break;
                    case "Tham gia hiến máu(+200)":
                        diemCong = +200;
                        break;
                    case "Quyên góp đồng bào khó khăn(+150)":
                        diemCong = +150;
                        break;
                    case "Tham gia chiến dịch bảo vệ môi trường(+150)":
                        diemCong = +150;
                        break;
                    case "Khác(+50)":
                        diemCong = +50;
                        break;
                }
            }
            if (comboBox2.SelectedItem != null)
            {
                switch (comboBox2.SelectedItem.ToString())
                {
                    case "Tàng trữ, sử dụng chất cấm(-300)":
                        diemTru = -300;
                        break;
                    case "Dính líu đến hoạt động rửa tiền bất hợp pháp(-300)":
                        diemTru = -300;
                        break;
                    case "Lừa đảo chiếm đoạt tài sản(-250)":
                        diemTru = -250;
                        break;
                    case "Trộm cắp(-200)":
                        diemTru = -200;
                        break;
                    case "Tham gia giao thông khi sử dụng rượu bia(-200)":
                        diemTru = -200;
                        break;
                    case "Gây rối trật tự công cộng(-150)":
                        diemTru = -150;
                        break;
                    case "Phóng nhanh vượt ẩu(-150)":
                        diemTru = -150;
                        break;
                    case "Không đội mũ bảo hiểm khi sử dụng xe gắn máy(-100)":
                        diemTru = -100;
                        break;
                    case "Vượt đèn đỏ(-100)":
                        diemTru = -100;
                        break;
                    case "Xả rác bừa bãi(-50)":
                        diemTru = -50;
                        break;
                    case "Hút pod(-50)":
                        diemTru = -50;
                        break;
                    case "Khác(-50)":
                        diemTru = -50;
                        break;
                }
            }

            String SQL = "UPDATE congDan SET diem = diem +@diemCong ";
            if (diemTru < 0) SQL += "+@diemTru ";
            SQL += "WHERE cccd=@cccd";
            SqlCommand cmd = new SqlCommand(SQL, c);
            cmd.Parameters.AddWithValue("@diemCong", diemCong);
            if (diemTru < 0) cmd.Parameters.AddWithValue("@diemTru", diemTru);
            cmd.Parameters.AddWithValue("@cccd", cccd);
            cmd.ExecuteNonQuery();

        }
    }
}
