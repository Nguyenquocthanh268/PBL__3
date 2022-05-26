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
    public partial class Nhap_kho : Form
    {

        public String IDGiay { get; set; }
        public Nhap_kho(string ID)
        {
            IDGiay = ID;
            InitializeComponent();
            GUI();
            show();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (txt_gia.Text == "" && txt_sln.Text == "")
            {

                MessageBox.Show("Vui long dien day du !!!");
            }
            else
            {
                try
                {
                    NhapKho n = new NhapKho()
                    {
                        Stt = BLL_KhoGiay.Instance.STTNhap(),
                        NgayNhap = DateTime.Now,
                        ID_Giay = IDGiay,
                        SoLuongNhap = Convert.ToInt32(txt_sln.Text.ToString()),
                        GiaNhap = Convert.ToInt32(txt_gia.Text.ToString()),
                    };
                    Giay g = new Giay()
                    {
                        ID_Giay = IDGiay,
                        GiaNhap = Convert.ToInt32(txt_gia.Text.ToString())
                    };
                    Kho k = new Kho()
                    {
                        ID_Giay = IDGiay,
                        TongSoLuongNhap = Convert.ToInt32(txt_sln.Text.ToString()),
                        SoLuongCon = Convert.ToInt32(txt_sln.Text.ToString()),
                    };
                    BLL_KhoGiay.Instance.NhapKho(g, k, n);
                    show();
                    MessageBox.Show("Da nhap thanh cong !!!");
                }catch (Exception ex)
                {
                    MessageBox.Show("Nhập vào không hợp lệ");
                }
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            DateTime start = Convert.ToDateTime(dt_st.Value.ToString());
            DateTime end = Convert.ToDateTime(dt_end.Value.ToString()); ;
            dataGridView1.DataSource = BLL_KhoGiay.Instance.SearchNhapKho(start, end);
        }
        public void show()
        {
            dataGridView1.DataSource = BLL_KhoGiay.Instance.showNhap();
        }
        public void GUI()
        {
            txtIDGiay.Text = IDGiay;
            txtHang.Text = BLL_KhoGiay.Instance.GetGiayByID(IDGiay).HangGiay.ToString();
            txtName.Text = BLL_KhoGiay.Instance.GetGiayByID(IDGiay).TenGiay.ToString();
            txtSize.Text = BLL_KhoGiay.Instance.GetGiayByID(IDGiay).Size.ToString();
            pictureBox7.Image = BLL_KhoGiay.Instance.BytetoPicter(BLL_KhoGiay.Instance.GetGiayByID(IDGiay).AnhSP);
            txtIDGiay.Enabled = false;
            txtHang.Enabled = false;
            txtName.Enabled = false;
            txtSize.Enabled = false;
            pictureBox7.Enabled = false;
        }
    }
}
