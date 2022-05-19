using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using quanlybangiay.BLL;
namespace quanlybangiay.form
{
    public partial class Tai_Khoan : Form
    {
        public delegate void MyDel();
        public MyDel d { get; set; }
        private string ID;
        public Tai_Khoan(string id)
        {
            ID = id;
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string mkc = txt_mkc.Text;
            string mkm = txt_mkm.Text;
            string nlmk = txt_nlmk.Text;
            if (BLL_Login.Instance.checkMK(mkm))
            {
                if (BLL_Login.Instance.Update(ID, mkc, mkm, nlmk))
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

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login a = new Login();
            d();
            a.Show();
            
        }



        private void txt_mkm_MouseClick(object sender, MouseEventArgs e)
        {
            lb_check.Enabled = false;
            lb_check.Text = "Nhập mật khẩu có tối thiểu 6 ký tự";
            lb_check.ForeColor =Color.Red;
        }

    
    }
}
