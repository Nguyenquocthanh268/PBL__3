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
using quanlybangiay.BLL.BLL_NV;
using quanlybangiay.DTO;
namespace quanlybangiay
{
    public partial class Login : Form
    {
        DataPBL3 db = new DataPBL3();
    
        public Login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string pass = txtpw.Text;
            string user = txtuser.Text;

            if (pass != "" && user != "")
            {
                if (BLL_Login.Instance.Kt(pass, user))
                {
                    if (BLL_Login.Instance.GetTK(user).ChucVu == true)
                    {

                        
                        MainQL f = new MainQL(user);
                        this.Hide();
                        f.Show();
                       




                    }
                    else
                    {
                        
                        MainNV f = new MainNV(user, BLL_Login.Instance.GetTK(user).ID_NhanVien);
                        this.Hide();
                        f.Show();
                        BLL_BanHang.Instance.DelAllData();
                    }
                }
                else
                {
                    lb_Ms.Visible = true;

                }
            }
            else
            {
                if(user == "" && pass != "")
                {
                    lb_MessageTK.Visible = true;
                }
                else if (user != "" && pass == "")
                {
                    lb_MessageMK.Visible = true;
                }
                else
                {
                    lb_MessageTK.Visible = true;
                    lb_MessageMK.Visible = true;
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {
            lb_MessageMK.Visible = false;
            if (txtuser.Text == "")
                lb_MessageTK.Visible = true;
            else lb_MessageTK.Visible = false;
            lb_Ms.Visible = false;
        }

        private void txtpw_TextChanged(object sender, EventArgs e)
        {
            if (txtpw.Text == "")
                lb_MessageMK.Visible = true;
            else lb_MessageMK.Visible = false;
            lb_Ms.Visible = false;
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            lb_MessageTK.Visible = false;
        }

        private void txtpw_Leave(object sender, EventArgs e)
        {

            lb_MessageMK.Visible = false;
        }

        private void txtuser_Click(object sender, EventArgs e)
        {
            lb_Ms.Visible = false;
        }
    }

}
