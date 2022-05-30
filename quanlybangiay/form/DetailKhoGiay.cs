﻿using System;
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
    public partial class DetailKhoGiay : Form
    {
        //public delegate void Mydel
        public delegate void Mydel();
        public Mydel d { get; set; }

        public String IDGiay { get; set; }
        private int index;
        public DetailKhoGiay(String id, int i)
        {
            InitializeComponent();
            IDGiay = id;
            index = i;
            GUI(index);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtSLNhap.Text == "")
            {
                txtSLNhap.Text = "0";
            }
            byte[] file = BLL_KhoGiay.Instance.ImagetoByte(pictureBox7.Image);

            
            if(getGiay() != null && getKhoGiay() != null  && getNhapKHO_Giay() !=null)
            {
                
                BLL_KhoGiay.Instance.Excute(getGiay(), getKhoGiay());
                if (Convert.ToInt32(txtSLNhap.Text) > 0 && index == 2)
                {
                    BLL_KhoGiay.Instance.ADD_nhapkho(getNhapKHO_Giay());
                }
                MessageBox.Show("Đã cập nhật !!!");
                d();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void GUI(int index)
        {
            if (BLL_KhoGiay.Instance.check(IDGiay))
            {
                txtIDGiay.Enabled = false;
                if (index == 1)
                {
                    pictureBox7.Enabled = false;
                
                    txtHang.Enabled = false;
                   
                    txtGiaBan.Enabled = false;
                    btnOK.Enabled = false;
                    txtName.Enabled = false;
                    txtSize.Enabled = false;
                    txtGiaNhap.Enabled = false;
                    txtSLTon.Enabled = false;
                    txtSLNhap.Enabled = false;
                    txtSLDaBan.Enabled = false;
                }
                if(index == 3)
                {
                    txtGiaBan.Enabled = true;
                    txtName.Enabled = true;
                    txtSize.Enabled = true;
                    txtHang.Enabled = true;
                    txtGiaBan.BackColor = Color.FromArgb(255, 255, 255);
                    txtName.BackColor = Color.FromArgb(255, 255, 255);
                    txtSize.BackColor = Color.FromArgb(255, 255, 255);
                    txtHang.BackColor = Color.FromArgb(255, 255, 255);

                    txtGiaNhap.Enabled = false;
                    txtSLTon.Enabled = false;
                    txtSLNhap.Enabled = false;
                    txtSLDaBan.Enabled = false;
                }
                txtIDGiay.Text = IDGiay;
                txtHang.Text = BLL_KhoGiay.Instance.GetGiayByID(IDGiay).HangGiay.ToString();
                txtName.Text = BLL_KhoGiay.Instance.GetGiayByID(IDGiay).TenGiay.ToString();
                txtSize.Text = BLL_KhoGiay.Instance.GetGiayByID(IDGiay).Size.ToString();
                txtGiaNhap.Text = BLL_KhoGiay.Instance.GetGiayByID(IDGiay).GiaNhap.ToString();
                txtGiaBan.Text = BLL_KhoGiay.Instance.GetGiayByID(IDGiay).GiaBan.ToString();
                txtSLNhap.Text = BLL_KhoGiay.Instance.GetkhoByID(IDGiay).TongSoLuongNhap.ToString();
                txtSLDaBan.Text = BLL_KhoGiay.Instance.GetkhoByID(IDGiay).SoLuongBan.ToString();
                txtSLTon.Text = BLL_KhoGiay.Instance.GetkhoByID(IDGiay).SoLuongCon.ToString();
                pictureBox7.Image = BLL_KhoGiay.Instance.BytetoPicter(BLL_KhoGiay.Instance.GetGiayByID(IDGiay).AnhSP);
            }
            else
            {
                txtName.BackColor= Color.FromArgb(255,255,255);
                txtSize.BackColor = Color.FromArgb(255, 255, 255);
                txtHang.BackColor = Color.FromArgb(255, 255, 255);
                txtSLNhap.BackColor = Color.FromArgb(255, 255, 255);
            }

        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            PictureBox p = sender as PictureBox;
            if (p != null)
            {
                openFile.Filter = "(*.png) | *.png";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    p.Image = Image.FromFile(openFile.FileName);
                }
            }
        }
        private Giay getGiay()
        {
            try
                 
            {
                if (txtSLNhap.Text == "0")
                {
                    txtGiaNhap.Enabled = false;
                    txtGiaBan.Enabled = false;
                    txtGiaNhap.Text = "0";
                    txtGiaBan.Text = "0";
                    
                }
                byte[] file = BLL_KhoGiay.Instance.ImagetoByte(pictureBox7.Image);
                Giay c = new Giay()
                {
                    ID_Giay = txtIDGiay.Text,
                    TenGiay = txtName.Text,
                    Size = Convert.ToInt32(txtSize.Text.ToString()),
                    HangGiay = txtHang.Text,
                    GiaNhap = Convert.ToDouble(txtGiaNhap.Text.ToString()),
                    GiaBan = Convert.ToDouble(txtGiaBan.Text.ToString()),
                    AnhSP = file
                };
                return c;
            }
            catch (Exception e)
            {
                MessageBox.Show("Nhập vào không hợp lệ");
                return null;
            }
        }
        private NhapKho getNhapKHO_Giay()
        {
            try
            {
                NhapKho n = new NhapKho()
                {
                    Stt = BLL_KhoGiay.Instance.STTNhap(),
                    NgayNhap = DateTime.Now,
                    ID_Giay = txtIDGiay.Text,
                    SoLuongNhap = Convert.ToInt32(txtSLNhap.Text.ToString()),
                    GiaNhap = Convert.ToInt32(txtGiaNhap.Text.ToString()),
                };
                return n;
            }
            catch(Exception e)
            {
                MessageBox.Show("Nhập vào không hợp lệ");
                return null;
            }
        }
        private Kho getKhoGiay()
        {
            try
            {
                if(txtSLNhap.Text == "")
                {
                    txtSLNhap.Text = "0";

                }
                Kho c = new Kho()
                {
                    ID_Giay = txtIDGiay.Text,
                    TongSoLuongNhap = Convert.ToInt32(txtSLNhap.Text.ToString()),
                    SoLuongCon = Convert.ToInt32(txtSLNhap.Text.ToString()),
                    SoLuongBan = 0

                };
                return c;
            }
            catch (Exception e)
            {
                MessageBox.Show("Nhập vào không hợp lệ");
                return null;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if(txtSize.Text != "" && index ==2)
            {
                txtSize.Enabled = true;
                txtName.Enabled = true;
                txtIDGiay.Text=BLL_KhoGiay.Instance.ID_giay(txtName.Text,txtSize.Text);
            }
        }

        private void txtSize_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text != "" && index == 2)
            {
                txtSize.Enabled = true;
                txtName.Enabled = true;
                txtIDGiay.Text = BLL_KhoGiay.Instance.ID_giay(txtName.Text, txtSize.Text);
            }
        }

      

        private void txtSLNhap_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSLNhap.Text == ""&& index == 2)
                {
                    txtGiaBan.Enabled = false;
                    txtGiaNhap.Enabled = false;
                }
                else
                if (Convert.ToInt32(txtSLNhap.Text) == 0 && index == 2)
                {
                    txtGiaBan.Enabled = false;
                    txtGiaNhap.Enabled = false;
                }
                else 
                if (Convert.ToInt32(txtSLNhap.Text) > 0 && index == 2)
                {
                    txtGiaBan.Enabled = true;
                    txtGiaNhap.Enabled = true;
                    txtGiaBan.BackColor = Color.FromArgb(255, 255, 255);
                    txtGiaNhap.BackColor = Color.FromArgb(255, 255, 255);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chỉ nhập kí tự 0-9 ...");
                txtGiaBan.BackColor = Color.FromArgb(171, 171, 171);
                txtGiaNhap.BackColor = Color.FromArgb(171, 171, 171);
                txtSLNhap.Text = "";
                txtGiaBan.Text = "";
                txtGiaBan.Enabled = false;
                txtGiaNhap.Text = "";
                txtGiaNhap.Enabled = false;
            }



        }

        private void txtHang_TextChanged(object sender, EventArgs e)
        {
           if(index == 2)
            {
                if (txtName.Text != "" && txtSize.Text != "" )
                {
                    if (index == 2)
                    {
                        if (BLL_KhoGiay.Instance.check(txtIDGiay.Text))
                        {
                            MessageBox.Show("ID đã tồn tại ....");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng điền ID và size đầu tiên");

                }
            }
        }

        private void txtSize_MouseClick(object sender, MouseEventArgs e)
        {
            if(txtSLNhap.Text == "")
            {
                txtSLNhap.Text = "0";
            }
        }
    }
}
