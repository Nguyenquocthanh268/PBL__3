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
                    }
                }
                else
                {
                    MessageBox.Show("Vui long kiem tra tai khoan hoac mat khau !");

                }
            }
            else
            {
                MessageBox.Show("Vui long dien day du !");
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
    }
}
