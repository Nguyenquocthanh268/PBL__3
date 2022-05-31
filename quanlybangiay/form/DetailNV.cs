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
using quanlybangiay.DTO;

namespace quanlybangiay.form
{
    public partial class DetailNV : Form
    {
        public delegate void Mydel();
        public Mydel d { get; set; }
        public string ID { get; set; }
        public int index;
        public bool checkAddNV;
        public bool checkTK;
        public DetailNV(string id, int i)
        {
            InitializeComponent();
            checkAddNV = false;
            ID = id;
            index = i;
            GUI(index);
        }

        public void GUI(int index)
        {
            btnReset.Enabled = false;
            if (BLL_NV.Instance.Check(ID))
            {
                txtID.Enabled = false;
                txtID.BackColor = Color.FromArgb(171, 171, 171);
                if (index == 1)
                {
                    txtTen.Enabled = false;
                    txtDiaChi.Enabled = false;
                    txtMK.Enabled = false;
                    txtSDT.Enabled = false;
                    txtTK.Enabled = false;
                    dateTimePicker1.Enabled = false;
                    btnUpload.Enabled = false;
                    btnOK.Enabled = false;
                    radNam.Enabled = false;
                    radNu.Enabled = false;
                    txtTen.BackColor = Color.FromArgb(171, 171, 171);
                    txtDiaChi.BackColor = Color.FromArgb(171, 171, 171);
                    txtMK.BackColor = Color.FromArgb(171, 171, 171);
                    txtSDT.BackColor = Color.FromArgb(171, 171, 171);
                    txtTK.BackColor = Color.FromArgb(171, 171, 171);
                    dateTimePicker1.BackColor = Color.FromArgb(171, 171, 171); 
                  
                }
                if (index == 3)
                {
                    txtTK.Enabled = false;
                    txtMK.Enabled = false;
                    btnReset.Enabled = true;
                    txtTK.BackColor = Color.FromArgb(171, 171, 171);
                    txtMK.BackColor = Color.FromArgb(171, 171, 171);
                }
                txtID.Text = BLL_NV.Instance.GetNVByID(ID).ID_NhanVien.ToString();
                txtTen.Text = BLL_NV.Instance.GetNVByID(ID).TenNhanVien.ToString();
                txtSDT.Text = BLL_NV.Instance.GetNVByID(ID).SoDienThoai.ToString();
                txtDiaChi.Text = BLL_NV.Instance.GetNVByID(ID).DiaChi.ToString();
                if (Convert.ToBoolean(BLL_NV.Instance.GetNVByID(ID).GioiTinh.ToString()))
                {
                    radNam.Checked = true;
                }
                else radNu.Checked = true;
                pictureBox1.Image = BLL_NV.Instance.BytetoPicter(BLL_NV.Instance.GetNVByID(ID).AnhNV);
                dateTimePicker1.Value = Convert.ToDateTime(BLL_NV.Instance.GetNVByID(ID).NgaySinh.ToString());
                txtTK.Text = BLL_Login.Instance.GetTKByID(ID).Username.ToString();
                txtMK.Text = BLL_Login.Instance.GetTKByID(ID).Pass.ToString();

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtSDT.Text == "" || txtTen.Text == "" || txtDiaChi.Text == ""
            || txtMK.Text == "" || txtTK.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {
                if (checkAddNV == false)
                {
                    if (checkTK == false)
                    {
                        byte[] file = BLL_NV.Instance.ImagetoByte(pictureBox1.Image);
                        NhanVien nv = new NhanVien()
                        {
                            ID_NhanVien = txtID.Text,
                            TenNhanVien = txtTen.Text,
                            DiaChi = txtDiaChi.Text,
                            SoDienThoai = txtSDT.Text,
                            NgaySinh = dateTimePicker1.Value,
                            AnhNV = file,
                            GioiTinh = Convert.ToBoolean(radNam.Checked),
                        };

                        TaiKhoan tk = new TaiKhoan()
                        {
                            Username = txtTK.Text,
                            Pass = txtMK.Text,
                            ChucVu = false,
                            ID_NhanVien = txtID.Text
                        };
                        try
                        {
                            BLL_NV.Instance.Execute(nv, tk);
                            d();
                            if (txtID.Enabled == false)
                            {
                                GUI(index);
                                MessageBox.Show("Thay đổi thành công!");
                            }
                            else
                            {
                                MessageBox.Show("Đã thêm thông tin nhân viên mới !!!");
                                checkAddNV = false;
                                checkTK = false;
                                this.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Vui long kiem tra du lieu");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng kiểm tra lại thông tin Tài khoản ...");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng kiểm tra lại thông tin ID nhân viên ...");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (txtID.Enabled)
            {
                MessageBox.Show("Không thể reset mật khẩu!");
            }
            else
            {
                string Username = txtTK.Text;
               BLL_Login.Instance.ResetMK(Username);
                MessageBox.Show("Đã reset mật khẩu thành công !");
                GUI(index);
            }

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            PictureBox ptr = new PictureBox();
            string fileName = null;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fileName = dlg.FileName;
                pictureBox1.Image = Image.FromFile(fileName.ToString());
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            

        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            if (BLL_NV.Instance.Check(txtID.Text))
            {
                tb_2.Text = "*ID nhân viên đã tồn tại";
                checkAddNV = true;
            }
            else
            {
                checkAddNV = false;
            }
    }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            tb_2.Text = "";
        }

        private void txtTK_Leave(object sender, EventArgs e)
        {
            if (BLL_NV.Instance.CheckUsername(txtTK.Text) == false)
            {
                lb_notify.Text = "*Tên tài khoản đã tồn tại";
                checkTK = true;
            }
            else
            {
                lb_notify.Text = "";
                checkTK = false;
            }
        }

        private void txtTK_TextChanged(object sender, EventArgs e)
        {
            lb_notify.Text = "";
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            tb_2.Text = "";
            try
            {
                if (txtSDT.Text == "")
                {
                    tb_2.Text = "";

                }
                else
                if(Convert.ToInt32(txtSDT.Text) > 0)
                {
                    tb_2.Text = "";
                }
                else
                if (txtSDT.Text.Length > 10)
                {
                    tb_2.Text = "";
                }
            }catch (Exception ex)
            {
                tb_2.Text = "Vui Lòng Kiểm tra lại SĐT";
            }
        }
    }
}
