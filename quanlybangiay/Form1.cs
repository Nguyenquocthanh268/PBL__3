using quanlybangiay.form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace quanlybangiay
{
    public partial class Form1 : Form
    {
        private Button currentButton;
        private Form dad_form;
        public Form1()
        {
            InitializeComponent();
        
        }

        
        private void bt_color(object sender)
        {
            if(sender != null)
            {
                if(currentButton !=(Button)sender)
                {
                    Disable();
                    Color clor = Color.Red;
                    currentButton = (Button)sender;
                    currentButton.BackColor = clor;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font= new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                }
            }
        }
        private void Disable()
        {
            foreach(Control k in pn_menu.Controls)
            {
                if (k.GetType() == typeof(Button))
                {
                    k.BackColor = Color.FromArgb(0, 135, 137);
                    k.ForeColor = Color.Gainsboro;
                    k.Font=new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void openform(Form childform,object sender)
        {
            if(dad_form != null)
            {
                dad_form.Close();
            }
            bt_color(sender);
            dad_form = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            this.pn_desktop.Controls.Add(childform);
            this.pn_desktop.Tag = childform;
            childform.BringToFront();
            childform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            khogiay k = new khogiay();
            openform(k, sender);
            lb_ten.Text = "QUẢN LÝ KHO GIÀY";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            hoadon f = new hoadon();
            openform(f, sender);
            lb_ten.Text = "QUẢN LÝ HÓA ĐƠN";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            xuhuong x = new xuhuong();
            openform(x, sender);
            lb_ten.Text = "XU HƯỚNG THỊ TRƯỜNG";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            nhanvien n = new nhanvien();
            openform(n, sender);
            lb_ten.Text = "QUẢN LÝ NHÂN VIÊN";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            khachhang x = new khachhang();
            openform(x, sender);
            lb_ten.Text = "QUẢN LÝ KHÁCH HÀNG";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            khuyenmai x = new khuyenmai();
            openform(x, sender);
            lb_ten.Text = "QUẢN LÝ CHƯƠNG TRÌNH KHUYẾN MÃI";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            doanhthu1 x = new doanhthu1();
            openform(x, sender);
            lb_ten.Text = "QUẢN LÝ DOANG THU";

        }
        private void button8_Click(object sender, EventArgs e)
        {
           taikhoan x = new taikhoan();
            openform(x, sender);
            lb_ten.Text = "QUẢN LÝ TÀI KHOẢN";
        }
    }
}
