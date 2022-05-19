using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using quanlybangiay.BLL.BLL_AD;
using quanlybangiay.BLL;

namespace quanlybangiay
{
    public partial class MainNV : Form
    {
        private string USer { get; set; }
        private string ID { get; set; }
        public MainNV(string user ,string id)
        {
            ID = id;
            USer = user;
            InitializeComponent();
            ShowdtGV_Trangchu();
        }
        private void ShowdtGV_Trangchu()
        {
            DataTable d1 = new DataTable();
            d1.Columns.AddRange(new DataColumn[]
            {
                new DataColumn{ColumnName = "Mã giày",DataType =typeof(string)},
                new DataColumn{ColumnName = "Hãng",DataType =typeof(string)},
                new DataColumn{ColumnName = "Tên SP",DataType =typeof(string)},
                new DataColumn{ColumnName = "Size",DataType =typeof(int)},
                new DataColumn{ColumnName = "Giá(VNĐ)",DataType =typeof(int)},
                new DataColumn{ColumnName = "SL",DataType =typeof(int)},
                new DataColumn{ColumnName = "Thành tiền(VNĐ)",DataType =typeof(int)}
            });
            dtGV_Trangchu.DataSource = d1;
        }

        private void MainNV_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login f = new Login();
            this.Hide();
            f.Show();
            this.Activate();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            GUI();
        }
        public void GUI()
        {
            txt_id.Text =BLL_NV.Instance.GetNVByID(ID).ID_NhanVien.ToString();
            txt_ten.Text = BLL_NV.Instance.GetNVByID(ID).TenNhanVien.ToString();
            txt_sdt.Text = BLL_NV.Instance.GetNVByID(ID).SoDienThoai.ToString();
            bool gender = Convert.ToBoolean(BLL_NV.Instance.GetNVByID(ID).GioiTinh.ToString());
            if (gender)
            {
                Nam.Checked = true;
            }
            else
            {
                nu.Checked = true;
            }
            txt_daichi.Text = BLL_NV.Instance.GetNVByID(ID).DiaChi.ToString();
            ngaysinh.Value = Convert.ToDateTime(BLL_NV.Instance.GetNVByID(ID).NgaySinh.ToString());
        }

       

        private void btn_luu_Click(object sender, EventArgs e)
        {
            string mkc = txt_mkc.Text;
            string mkm = txt_mkm.Text;
            string nlmk = txt_xacnhan.Text;
            if (BLL_Login.Instance.checkMK(mkm))
            {
                if (BLL_Login.Instance.Update(USer, mkc, mkm, nlmk))
                {
                    MessageBox.Show("Đổi thành công");
                }
                else
                {
                    MessageBox.Show("Kiểm tra lại MK");
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu của bạn ít hơn 6 ký tự vui lòng kiểm tra lại !");
            }
        }

        private void btn_out_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login a = new Login();
       
            a.Show();
        }

        private void txt_mkm_MouseClick(object sender, MouseEventArgs e)
        {
            lb_check.Enabled = false;
            lb_check.Text = "Nhập mật khẩu có tối thiểu 6 ký tự";
        }
    }
}
