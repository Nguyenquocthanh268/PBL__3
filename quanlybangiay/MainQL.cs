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
    public partial class MainQL : Form
    {
        private Button currentButton;
        private Form dad_form;
        private Panel LeftBorderBtn;
       
        private string User { get; set; }
        public MainQL(string user)
        {
            InitializeComponent();
           User = user;
            LeftBorderBtn = new Panel();
            LeftBorderBtn.Size = new Size(7, 72);
            pn_menu.Controls.Add(LeftBorderBtn);
        }
        public struct Color_Icon
        {
            public static Color Blue = Color.FromArgb(66, 192, 251);
            public static Color Green = Color.FromArgb(166, 215, 133);
            public static Color Red = Color.FromArgb(219, 62, 6);
            public static Color Pink = Color.FromArgb(220, 32, 135);
            public static Color Yellow = Color.FromArgb(255, 165, 0);
        }


        private void setButton_UI(Button b, Color c, Image a, Panel p)
        {
            b.Image = a;
            b.BackColor = Color.FromArgb(42, 40, 86);
            b.ForeColor = c;
            p.BackColor = c;
        }
        private void bt_color(object sender)
        {
            if (sender != null)
            {
                if (currentButton != (Button)sender)
                {
                    //Button - UI
                    Disable();
                    currentButton = (Button)sender;

                    if (currentButton == button1)
                    {
                        setButton_UI(currentButton, Color_Icon.Red, global::quanlybangiay.Properties.Resources.warehouse_red, LeftBorderBtn);
                        lbImage.Image = quanlybangiay.Properties.Resources.warehouse_red;
                    }
                    if (currentButton == button2)
                    {
                        setButton_UI(currentButton, Color_Icon.Pink, global::quanlybangiay.Properties.Resources.bill_pink, LeftBorderBtn);
                        lbImage.Image = quanlybangiay.Properties.Resources.bill_pink;
                    }
                    if (currentButton == button3)
                    {
                        setButton_UI(currentButton, Color_Icon.Green, global::quanlybangiay.Properties.Resources.trending_green, LeftBorderBtn);
                        lbImage.Image = quanlybangiay.Properties.Resources.trending_green;
                    }
                    if (currentButton == button4)
                    {
                        setButton_UI(currentButton, Color_Icon.Blue, global::quanlybangiay.Properties.Resources.staff_blue, LeftBorderBtn);
                        lbImage.Image = quanlybangiay.Properties.Resources.staff_blue;
                    }
                    if (currentButton == button5)
                    {
                        setButton_UI(currentButton, Color_Icon.Green, global::quanlybangiay.Properties.Resources.customer_green, LeftBorderBtn);
                        lbImage.Image = quanlybangiay.Properties.Resources.customer_green;
                    }
                    if (currentButton == button6)
                    {
                        setButton_UI(currentButton, Color_Icon.Yellow, global::quanlybangiay.Properties.Resources.sale_yellow, LeftBorderBtn);
                        lbImage.Image = quanlybangiay.Properties.Resources.sale_yellow;
                    }
                    if (currentButton == button7)
                    {
                        setButton_UI(currentButton, Color_Icon.Red, global::quanlybangiay.Properties.Resources.profit_red, LeftBorderBtn);
                        lbImage.Image = quanlybangiay.Properties.Resources.profit_red;
                    }
                    if (currentButton == button8)
                    {
                        setButton_UI(currentButton, Color_Icon.Blue, global::quanlybangiay.Properties.Resources.account_blue, LeftBorderBtn);
                        lbImage.Image = quanlybangiay.Properties.Resources.account_blue;
                    }

                    currentButton.TextAlign = ContentAlignment.MiddleCenter;
                    currentButton.ImageAlign = ContentAlignment.MiddleRight;
                    currentButton.TextImageRelation = TextImageRelation.TextBeforeImage;

                    //LeftBorder
                    LeftBorderBtn.Location = new Point(0, currentButton.Location.Y);
                    LeftBorderBtn.Visible = true;
                    LeftBorderBtn.BringToFront();
                }

            }
        }
        private void Disable()
        {
            if (currentButton != null)
            {

                currentButton.BackColor = Color.FromArgb(31, 30, 65);
                currentButton.ForeColor = Color.Gainsboro;
                currentButton.TextAlign = ContentAlignment.MiddleLeft;
                currentButton.ImageAlign = ContentAlignment.MiddleLeft;
                currentButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                LeftBorderBtn.Visible = false;
                if (currentButton == button1) button1.Image = global::quanlybangiay.Properties.Resources.warehouse_white;
                if (currentButton == button2) button2.Image = global::quanlybangiay.Properties.Resources.bill_white;
                if (currentButton == button3) button3.Image = global::quanlybangiay.Properties.Resources.trending_white;
                if (currentButton == button4) button4.Image = global::quanlybangiay.Properties.Resources.staff_white;
                if (currentButton == button5) button5.Image = global::quanlybangiay.Properties.Resources.customer_white;
                if (currentButton == button6) button6.Image = global::quanlybangiay.Properties.Resources.sale_white;
                if (currentButton == button7) button7.Image = global::quanlybangiay.Properties.Resources.profit_white;
                if (currentButton == button8) button8.Image = global::quanlybangiay.Properties.Resources.account_white;

            }
        }
        private void openform(Form childform, object sender)
        {
            if (dad_form != null)
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
            //khogiay k = new khogiay():
            Kho_Giay k = new Kho_Giay();
            openform(k, sender);
            lb_ten.Text = "KHO GIÀY";
            lb_tenphu.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //hoadon f = new hoadon();
            Hoa_Don f = new Hoa_Don();
            openform(f, sender);
            lb_ten.Text = "HÓA ĐƠN";
            lb_tenphu.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            xuhuong x = new xuhuong();
            openform(x, sender);
            lb_ten.Text = "";
            lb_tenphu.Text = "XU HƯỚNG THỊ TRƯỜNG";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //nhanvien n = new nhanvien();
            Nhan_Vien n = new Nhan_Vien();
            openform(n, sender);
            lb_ten.Text = "NHÂN VIÊN";
            lb_tenphu.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //khachhang x = new khachhang();
            Khach_Hang x = new Khach_Hang();
            openform(x, sender);
            lb_ten.Text = "KHÁCH HÀNG";
            lb_tenphu.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //khuyenmai x = new khuyenmai();
            Khuyen_Mai x = new Khuyen_Mai();
            openform(x, sender);
            lb_ten.Text = "";
            lb_tenphu.Text = "CHƯƠNG TRÌNH KHUYẾN MÃI";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Doanh_Thu x = new Doanh_Thu();
            //doanhthu1 x = new doanhthu1();
            openform(x, sender);
            lb_ten.Text = "DOANH THU";
            lb_tenphu.Text = "";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            //taikhoan x = new taikhoan();

            Tai_Khoan x = new Tai_Khoan(User);
            x.d = new Tai_Khoan.MyDel(Dong);

            openform(x, sender);
            lb_ten.Text = "TÀI KHOẢN";
            lb_tenphu.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (dad_form != null)
                dad_form.Close();
            Disable();
            lbImage.Image = quanlybangiay.Properties.Resources.home_green;
            lb_ten.Text = "TRANG CHỦ";
            lb_tenphu.Text = "";

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Dong()
        {
            this.Hide();
        }


        private void MainQL_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login f = new Login();
            this.Hide();
            f.Show();
           
        }
    }
}