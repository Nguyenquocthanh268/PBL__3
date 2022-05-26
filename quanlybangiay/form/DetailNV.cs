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
using quanlybangiay.DTO;

namespace quanlybangiay.form
{
    public partial class DetailNV : Form
    {
        public delegate void Mydel();
        public Mydel d { get; set; }
        public string ID { get; set; }
        public int index;
        public DetailNV(string id, int i)
        {
            InitializeComponent();
            ID = id;
            index = i;
            GUI(index);
        }

        public void GUI(int index)
        {
            if (BLL_NV.Instance.Check(ID))
            {
                txtID.Enabled = false;
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
                    btnCancel.Enabled = false;
                    btnReset.Enabled = false;
                    lb_notify.Enabled = false;
                }
                if(index == 3)
                { 
                    txtMK.Enabled = false;
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
                txtTK.Text = BLL_NV.Instance.GetTKByIDNV(ID).Username.ToString();
                txtMK.Text = BLL_NV.Instance.GetTKByIDNV(ID).Pass.ToString();

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
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
               if(txtID.Text == "" || txtSDT.Text == "" || txtTen.Text == "" || txtDiaChi.Text == ""
                  || txtMK.Text == "" || txtTK.Text == "" || lb_notify.Visible == true )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            } else
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
                    this.Close();
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
                BLL_NV.Instance.ResetMK(Username);
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
                MessageBox.Show("ID nhân viên đã tồn tại ...");
            }
        }

        private void txtMK_Click(object sender, EventArgs e)
        {
            if (BLL_NV.Instance.CheckUsername(txtTK.Text) == false)
            {
                lb_notify.Visible = true;
            } else
            {
                lb_notify.Visible = false;
            }
        }

    }
}
