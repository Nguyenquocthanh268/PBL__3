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
using quanlybangiay.BLL;
using quanlybangiay.DTO;
using quanlybangiay.BLL.BLL_NV;

namespace quanlybangiay
{
    public partial class MainNV : Form
    {  
        private string USer { get; set; }
        private string ID { get; set; }
        public int ChietKhau = 0;
        //private DataTable d1 { get; set; }
        public MainNV(string user ,string id)
        {
            ID = id;
            USer = user;
            InitializeComponent();
            ShowdtGV_Trangchu();
            LoadCBBKHO();
            CBBKhuyenMai();
        }
        private void ShowdtGV_Trangchu()
        {
            dtGV_Trangchu.DataSource = DataSP.Instance.d1;
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
            GUI_HD(USer);

        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Form Quan Ly Tai Khoan 
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
            lb_check.Text = "Nhập mật khẩu có tối thiểu 6 ký tự";
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Form Kiem Kho
        public void LoadCBBKHO()
        {
            foreach (string i in BLL_KiemkhoNV.Instance.size().Distinct())
            {
                cb_sizeKHO.Items.Add(i);
            }
            foreach (string i in BLL_KiemkhoNV.Instance.hang().Distinct())
            {
                cb_hangKHO.Items.Add(i);
            }
            foreach (string i in BLL_KiemkhoNV.Instance.ten().Distinct())
            {
                cb_tenKHO.Items.Add(i);
            }
        }
        private void btn_timkiemKHO_Click(object sender, EventArgs e)
        {
            int indexTen = cb_tenKHO.SelectedIndex;
            int indexHang =cb_hangKHO.SelectedIndex;
            int indexSize =cb_sizeKHO.SelectedIndex;
            string ID = txt_IDgiayKHO.Text;
            if (ID == "")
            {
                if(indexTen < 0)
                {
                    if (indexHang >= 0 && indexSize < 0 )
                    {
                        string hang = cb_hangKHO.SelectedItem.ToString();
                        dtGV_Kiemkho.DataSource= BLL_KiemkhoNV.Instance.search_Hang("", hang);
                    }
                    else if (indexHang < 0 && indexSize >= 0)
                    {
                        int size = Convert.ToInt32(cb_sizeKHO.SelectedItem.ToString());
                        dtGV_Kiemkho.DataSource = BLL_KiemkhoNV.Instance.searh_Size("", size);
                    }
                    
                    else if (indexHang < 0 && indexSize < 0 )
                    {
                        dtGV_Kiemkho.DataSource = BLL_KiemkhoNV.Instance.showAll();
                    }
                    else if (indexHang >= 0 && indexSize >= 0 )

                    {
                        int size = Convert.ToInt32(cb_sizeKHO.SelectedItem.ToString());
                        string hang = cb_hangKHO.SelectedItem.ToString();
                        dtGV_Kiemkho.DataSource = BLL_KiemkhoNV.Instance.search_Size_Hang("", hang, size);
                    }
                }
                else if(indexTen >= 0)
                {
                     if (indexHang >= 0 && indexSize >= 0)
                    {
                        string ten = cb_tenKHO.SelectedItem.ToString();
                        int size = Convert.ToInt32(cb_sizeKHO.SelectedItem.ToString());
                        string hang = cb_hangKHO.SelectedItem.ToString();
                        dtGV_Kiemkho.DataSource = BLL_KiemkhoNV.Instance.search_Size_Hang(ten, hang, size);
                    }
                    else if (indexHang < 0 && indexSize < 0 )
                    {
                        string ten = cb_tenKHO.SelectedItem.ToString();
                        dtGV_Kiemkho.DataSource = BLL_KiemkhoNV.Instance.search_Size_Hang(ten, "", 0);
                    }
                     else if(indexHang >= 0 && indexSize < 0)
                    {
                        string ten = cb_tenKHO.SelectedItem.ToString();
                        string hang = cb_hangKHO.SelectedItem.ToString();
                        dtGV_Kiemkho.DataSource = BLL_KiemkhoNV.Instance.search_Hang(ten, hang);
                    }
                     else if(indexHang < 0 && indexSize >= 0)
                    {
                        string ten = cb_tenKHO.SelectedItem.ToString();
                        int size = Convert.ToInt32(cb_sizeKHO.SelectedItem.ToString());
                        dtGV_Kiemkho.DataSource = BLL_KiemkhoNV.Instance.searh_Size(ten, size);
                    }
                    
                }
            }
            else 
            {
                dtGV_Kiemkho.DataSource = BLL_KiemkhoNV.Instance.search(ID, "", "", 0);
            }
        }

        private void dtGV_Kiemkho_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtGV_Kiemkho.SelectedRows.Count == 1)
            {
                string ID = dtGV_Kiemkho.SelectedRows[0].Cells["ID_Giay"].Value.ToString();
                GUIkho(ID);            
            }
        }
        public void GUIkho(string ID)
        {
            pic_kho.Image =BLL_KhoGiay.Instance.BytetoPicter(BLL_KhoGiay.Instance.GetGiayByID(ID).AnhSP);
            txt_giaKHO.Text = BLL_KhoGiay.Instance.GetGiayByID(ID).GiaBan.ToString();
            txt_sizeKHO.Text= BLL_KhoGiay.Instance.GetGiayByID(ID).Size.ToString();
            txt_SLkho.Text= BLL_KhoGiay.Instance.GetkhoByID(ID).SoLuongCon.ToString();
            tb_ten.Text=BLL_KhoGiay.Instance.GetGiayByID(ID).TenGiay.ToString();
            tb_ten.ForeColor = Color.Gold;
            tb_ten.Font= new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 2)
            {
                txt_IDgiayKHO.Text = "";
                cb_hangKHO.SelectedIndex = -1;
                cb_sizeKHO.SelectedIndex = -1;
                cb_tenKHO.SelectedIndex = -1;
                dtGV_Kiemkho.DataSource = null;
                pic_kho.Image = null;
                txt_sizeKHO.Text = "";
                txt_giaKHO.Text = "";
                txt_SLkho.Text = "";

            }
            if (tabControl1.SelectedIndex == 0)
            {
                ResetAllDataBanHang();
            }
        }


        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Form Chi tiet hoa don
        public void GUI_HD(string Username)
        {
            lbUsername.Text = Username.ToString();
            lbTen.Text = BLL_NV_HD.Instance.GetNVByUsername(Username).TenNhanVien.ToString();
            txtSohoadon.Text = dtGV_Chitiethd.Rows.Count.ToString();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            double sum = 0;
            string ID = BLL_NV_HD.Instance.GetNVByUsername(USer).ID_NhanVien.ToString();
            DateTime begin = dateBegin.Value;
            DateTime end = dateEnd.Value;
            dtGV_Chitiethd.DataSource = BLL_NV_HD.Instance.Search(ID, begin, end);
            txtSohoadon.Text = dtGV_Chitiethd.Rows.Count.ToString();
            foreach (DataGridViewRow dr in dtGV_Chitiethd.Rows)
            {
                sum += Convert.ToDouble(dr.Cells["TongTien"].Value);
            }
            txtTongtien.Text = sum.ToString() + " VND";
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Form Dang Ky Khach Hang

        private void butLuu_DangKyKhachHang_Click(object sender, EventArgs e)
        {
            //note: bổ sung sdt chỉ chứa kí tự số
            if(txtSdtKhachHang.Text.Length == 10)
            {
                if (BLL_QLKH.Instance.Check(txtSdtKhachHang.Text))
                {
                    lbCheckSdt.Text = "Số điện thoại đã tồn tại trong hệ thống ...";
                }
                else
                {
                    BLL_QLKH.Instance.AddKH(txtSdtKhachHang.Text, txtNameKhachHang.Text);
                    MessageBox.Show("Đăng Ký Thành Công !!!");
                    txtSdtKhachHang.Text = "";
                    txtNameKhachHang.Text = "";
                    lbCheckSdt.Text = "";
                }
            }
            else
            {
                lbCheckSdt.Text = "Số điện thoại phải đủ 10 kí tự, chỉ chứa kí tự số ";
            }

        }

        private void txtSdtKhachHang_MouseClick(object sender, MouseEventArgs e)
        {
            lbCheckSdt.Text = "Số điện thoại phải đủ 10 kí tự, chỉ chứa kí tự số ";
        }

        private void txtSdtKhachHang_TextChanged(object sender, EventArgs e)
        {
            lbCheckSdt.Text = "";
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Form Ban Hang

        //******************************************************************************************************
        //Thong tin khach hang
        private void but_CheckKH_Click(object sender, EventArgs e)
        {
            if (txtSdt_BanHang.Text.Length == 10)
            {
                if (BLL_QLKH.Instance.Check(txtSdt_BanHang.Text))
                {
                    KhachHang a = BLL_QLKH.Instance.Get1KH(txtSdt_BanHang.Text);
                    txtNameKH_BanHang.Text = a.TenKhachHang;
                    txtNgayDK_BanHang.Text =Convert.ToString(a.NgayDangKy);
                    txtDiemTL_BanHang.Text = Convert.ToString(a.DiemTichLuy);
                    txtSale_BanHang.Text = Convert.ToString(GiamGiaTheoDiemTichLuy((int)a.DiemTichLuy));
                    if (txtChietKhauCTKM_BanHang.Text != "")
                    {
                        ChietKhau = Convert.ToInt32(txtSale_BanHang.Text) + Convert.ToInt32(txtChietKhauCTKM_BanHang.Text);
                    }
                    else
                    {
                        ChietKhau = Convert.ToInt32(txtSale_BanHang.Text);
                    }
                    ResetData();
                }
                else
                {
                    lbKTthongTin_BanHang.Text = "Số điện thoại khách hàng không tồn tại...";
                }
            }
            else
            {
                lbKTthongTin_BanHang.Text = "Số điện thoại phải đủ 10 kí tự, chỉ chứa kí tự số ";
            }
        }
        //Xuli diem tich luy : 100.000d ~ 1d ; DTL < 100d : giam 2% ;100d <= DTL < 200d :giam 5%; 200d <= DTL < 500d : giam 10%; DTL >= 500 : giam 20%
        public int GiamGiaTheoDiemTichLuy(int DTL)
        {
            DataPBL3 db = new DataPBL3();
            if (DTL <= 0) return 0;
            else if (DTL < 100 && DTL > 0) return 2;
            else if (DTL >= 100 && DTL < 200) return 5;
            else if (DTL >= 200 && DTL < 500) return 10;
            else return 20;

        }
        private void txtSdt_TextChanged(object sender, EventArgs e)
        {
            lbKTthongTin_BanHang.Text = "";
        }
        //******************************************************************************************************


        //******************************************************************************************************
        //Thong tin CTKM
        //public void setCBBCTKM()
        //{
        //    cbbCTKM_BanHang.Items.AddRange(BLL_CTKM.Instance.GetListNameCTKM().ToArray());
        //}

        private void CBBKhuyenMai()
        {
            DateTime d = DateTime.Now;
            foreach (string i in BLL_BanHang.Instance.GetCBBKhuyenmai(d).Distinct())
            {
                cbbCTKM_BanHang.Items.Add(i);
            }
        }
        private void cbbCTKM_BanHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCTKM_BanHang.SelectedItem != null)
            {
                string name = cbbCTKM_BanHang.SelectedItem.ToString();
                txtChietKhauCTKM_BanHang.Text = BLL_BanHang.Instance.GetChietkhauByName(name).ToString();
                ResetData();
                if (txtSale_BanHang.Text != "")
                {
                    ChietKhau = Convert.ToInt32(txtSale_BanHang.Text) + Convert.ToInt32(txtChietKhauCTKM_BanHang.Text);
                }
                else
                {
                    ChietKhau = Convert.ToInt32(txtChietKhauCTKM_BanHang.Text);
                }
                ResetData();
            }
        }
        //******************************************************************************************************
        //Thong tin giay
        private void butCheckIDGiay_Click(object sender, EventArgs e)
        {
            ResetDataSP();
            if (BLL_KhoGiay.Instance.check(txtIDGiay_BanHang.Text))
            {
                int Soluong = Convert.ToInt32(BLL_BanHang.Instance.GetGiay_Kho(txtIDGiay_BanHang.Text).SoLuongCon);
                but_AddGiay.Enabled = true;
                Giay a = BLL_KhoGiay.Instance.GetGiayByID(txtIDGiay_BanHang.Text);
                txtNameSP_BanHang.Text = a.TenGiay;
                txtHang_BanHang.Text = a.HangGiay;
                txtSize_BanHang.Text = Convert.ToString(a.Size);
                txtSL_BanHang.Text = Soluong.ToString();
                if(Soluong > 0)
                {
                    rdConHang.Checked = true;
                    rdConHang.ForeColor = Color.Green;
                }
                else
                {
                    rdHetHang.Checked = true;
                    rdHetHang.ForeColor = Color.Red;
                }
            }
            else
            {
                lbKTthongTinID_BanHang.Text = "ID giày không tồn tại...";
            }
        }
        private void txtIDGiay_BanHang_TextChanged(object sender, EventArgs e)
        {
            lbKTthongTinID_BanHang.Text = "";
        }

        private void but_AddGiay_Click(object sender, EventArgs e)
        {
            int Soluong = Convert.ToInt32(BLL_BanHang.Instance.GetGiay_Kho(txtIDGiay_BanHang.Text).SoLuongCon);
            if (Soluong > 0)
            {
                BLL_BanHang.Instance.AddDL(txtIDGiay_BanHang.Text, txtHang_BanHang.Text, txtNameSP_BanHang.Text,Convert.ToInt32(txtSize_BanHang.Text), BLL_KhoGiay.Instance.GetGiaBanGiayByID(txtIDGiay_BanHang.Text), 1, BLL_KhoGiay.Instance.GetGiaBanGiayByID(txtIDGiay_BanHang.Text) * 1);
                ResetData();
                but_AddGiay.Enabled = false;
            }
            else
            {
                MessageBox.Show("Sản phẩm bạn cần tìm đã hết hàng, vui lòng kiểm tra lại...");
            }

            if(tb_Mahoadon.Text == "")
            {
                tb_Mahoadon.Text = BLL_BanHang.Instance.IDhoadon();
            }
        }
        public void ResetData()
        {
            txtIDGiay_BanHang.Text = "";
            ResetDataSP();
            tb_Tongcong.Text = BLL_BanHang.Instance.TongTien().ToString();
            //if (txtSale_BanHang.Text != "" )
            //{
                //if (txtChietKhauCTKM_BanHang.Text != "")
                //{
                //    tb_Phantramck.Text = (Convert.ToInt32(txtSale_BanHang.Text) + Convert.ToInt32(txtChietKhauCTKM_BanHang.Text)).ToString();
                //}
                //else
                //{
                //    tb_Phantramck.Text = (Convert.ToInt32(txtSale_BanHang.Text)).ToString();
                //}
                tb_Phantramck.Text = Convert.ToString(ChietKhau);
                tb_Chietkhau.Text = (Convert.ToInt32(tb_Phantramck.Text) * Convert.ToDouble(tb_Tongcong.Text) / 100).ToString();
                tb_Thanhtien.Text = (Convert.ToDouble(tb_Tongcong.Text) - Convert.ToDouble(tb_Chietkhau.Text)).ToString();
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng kiểm tra lại thông tin khách hàng...");
            //}
        }
        public void ResetDataSP()
        {
            
            txtNameSP_BanHang.Text = "";
            txtHang_BanHang.Text = "";
            txtSize_BanHang.Text = "";
            txtSL_BanHang.Text = "";
            rdConHang.Checked = false;
            rdHetHang.Checked = false;
        }
        //******************************************************************************************************

        //******************************************************************************************************
        //Danh sach SP

        private void butdel_Click(object sender, EventArgs e)
        {
            if (dtGV_Trangchu.SelectedRows.Count > 0)
            {
                String s = "Bạn có muốn xóa mặt hàng ??";
                String s1 = "Delete";
                MessageBoxButtons ok = MessageBoxButtons.OKCancel;
                DialogResult d = MessageBox.Show(s, s1, ok);
                if (d == DialogResult.OK)
                {
                    foreach (DataGridViewRow i in dtGV_Trangchu.SelectedRows)
                    {
                        String MaSP = i.Cells["Mã giày"].Value.ToString();
                        BLL_BanHang.Instance.DelSP(MaSP);
                    }
                    ShowdtGV_Trangchu();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa !!!");
            }
        }

        //******************************************************************************************************
        //Thanh toan 

        private void tb_Tienkhachdua_TextChanged(object sender, EventArgs e)
        {
            if(tb_Tienkhachdua.Text != "")
            {
                tb_Tientralai.Text = (Convert.ToDouble(tb_Tienkhachdua.Text) - Convert.ToDouble(tb_Thanhtien.Text)).ToString();
            }
        }
        //Xuli diem tich luy : 100.000d ~ 1d ; DTL < 100d : giam 2% ;100d <= DTL < 200d :giam 5%; 200d <= DTL < 500d : giam 10%; DTL >= 500 : giam 20%
        private void butSAVE_Click(object sender, EventArgs e)
        {
            if (tb_Tienkhachdua.Text != "")
            {

                if (Convert.ToDouble(tb_Tientralai.Text) > 0)
                {
                    String s = "Bạn có xác nhận lưu hóa đơn và in chưa ??";
                    String s1 = "Xác nhận hóa đơn";
                    MessageBoxButtons ok = MessageBoxButtons.OKCancel;
                    DialogResult d = MessageBox.Show(s, s1, ok);
                    if (d == DialogResult.OK)
                    {
                        //List<string> idsp = new List<string>();

                        string ID_HoaDon = BLL_BanHang.Instance.IDhoadon();
                        if (BLL_QLKH.Instance.Check(txtSdt_BanHang.Text))
                        {

                            KhachHang a = BLL_QLKH.Instance.Get1KH(txtSdt_BanHang.Text);
                            a.DiemTichLuy += Convert.ToInt32(tb_Thanhtien.Text) / 100000;
                            BLL_QLKH.Instance.UpdateKH(a);

                            {
                                HoaDon hoadon = new HoaDon();
                                hoadon.ID_HoaDon = ID_HoaDon;
                                hoadon.SoDienThoai = txtSdt_BanHang.Text;
                                hoadon.Thanhvien = Convert.ToInt32(txtSale_BanHang.Text);
                                hoadon.NgayTao = DateTime.Now;
                                hoadon.TongTien = Convert.ToDouble(tb_Thanhtien.Text);
                                hoadon.ID_NhanVien = ID;
                                if (cbbCTKM_BanHang.SelectedItem != null)
                                    hoadon.ID_KhuyenMai = BLL_BanHang.Instance.GetID_KMByName(cbbCTKM_BanHang.SelectedItem.ToString());
                                BLL_BanHang.Instance.AddHD(hoadon);
                            }

                            foreach (DataGridViewRow i in dtGV_Trangchu.Rows)
                            {

                                string IDGiay = i.Cells["Mã giày"].Value.ToString();
                                int Soluong = Convert.ToInt32(i.Cells["SL"].Value.ToString());
                                ChiTietHoaDon chitiet = new ChiTietHoaDon
                                {
                                    ID_HoaDon = ID_HoaDon,
                                    ID_Giay = IDGiay,
                                    SoLuong = Soluong,
                                    GiaBan = Convert.ToDouble(i.Cells["Giá(VNĐ)"].Value.ToString()),
                                    GiaNhap = BLL_BanHang.Instance.GetGiaNhapByID(i.Cells["Mã giày"].Value.ToString())
                                };
                                //idsp.Add(IDGiay);
                                BLL_BanHang.Instance.AddChiTietHD(chitiet);
                                BLL_BanHang.Instance.UpdateKho(IDGiay, Soluong);

                            }
                            MessageBox.Show("Đã lưu và xuất hoá đơn!!!");
                            ResetAllDataBanHang();
                            //foreach(string i in idsp.Distinct())
                            //{ 
                            //}
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Số tiền khách đưa không hợp lệ...");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số tiền khách đưa ...");
            }


        }

        public void ResetAllDataBanHang()
        {
            txtSdt_BanHang.Text = "";
            txtNameKH_BanHang.Text = "";
            txtNgayDK_BanHang.Text = "";
            txtDiemTL_BanHang.Text = "";
            txtSale_BanHang.Text = "";
            cbbCTKM_BanHang.SelectedItem = null;
            txtChietKhauCTKM_BanHang.Text = "";
            ResetDataSP();
            tb_Tongcong.Text = "";
            tb_Phantramck.Text = "";
            tb_Chietkhau.Text = "";
            tb_Thanhtien.Text = "";
            tb_Tienkhachdua.Text = "";
            tb_Tientralai.Text = "";
            tb_Mahoadon.Text = "";
            BLL_BanHang.Instance.DelAllData();
        }

    }
}
