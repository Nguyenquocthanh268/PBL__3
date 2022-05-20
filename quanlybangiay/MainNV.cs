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
using quanlybangiay.BLL.BLL_NV;

namespace quanlybangiay
{
    public partial class MainNV : Form
    {  
        private string USer { get; set; }
        private string ID { get; set; }
        //private DataTable d1 { get; set; }
        public MainNV(string user ,string id)
        {
            ID = id;
            USer = user;
            InitializeComponent();
            ShowdtGV_Trangchu();
            LoadCBBKHO();
           
        }
        private void ShowdtGV_Trangchu()
        {
            
            //d1 = new DataTable();
            //d1.Columns.AddRange(new DataColumn[]
            //{
            //    new DataColumn{ColumnName = "Mã giày",DataType =typeof(string)},
            //    new DataColumn{ColumnName = "Hãng",DataType =typeof(string)},
            //    new DataColumn{ColumnName = "Tên SP",DataType =typeof(string)},
            //    new DataColumn{ColumnName = "Size",DataType =typeof(int)},
            //    new DataColumn{ColumnName = "Giá(VNĐ)",DataType =typeof(double)},
            //    new DataColumn{ColumnName = "SL",DataType =typeof(int)},
            //    new DataColumn{ColumnName = "Thành tiền(VNĐ)",DataType =typeof(double)}
            //});
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
         
        }
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
                setCBBCTKM();
            }
        }
        //------------------------------------------------------------------------------------------------------------------------
        //Form Dang Ky Khach Hang

        private void butLuu_DangKyKhachHang_Click(object sender, EventArgs e)
        {
            //note: bổ sung sdt chỉ chứa kí tự số
            if(txtSdtKhachHang.Text.Length == 10)
            {
                if (BLL_QLKH.Instance.Check(txtSdtKhachHang.Text))
                {
                    lbCheckSdt.Text = "So dien thoai da ton tai trong he thong...";
                }
                else
                {
                    BLL_QLKH.Instance.AddKH(txtSdtKhachHang.Text, txtNameKhachHang.Text);
                    MessageBox.Show("Dang Ky Thanh Cong !!!");
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

        //------------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------------------
        //Form Ban Hang
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
            if (DTL < 100) return 2;
            else if (DTL >= 100 && DTL < 200) return 5;
            else if (DTL >= 200 && DTL < 500) return 10;
            else return 20;

        }

        private void txtSdt_TextChanged(object sender, EventArgs e)
        {
            lbKTthongTin_BanHang.Text = "";
        }

        //Thong tin CTKM
        public void setCBBCTKM()
        {
            cbbCTKM_BanHang.Items.AddRange(BLL_CTKM.Instance.GetListNameCTKM().ToArray());
        }

        private void cbbCTKM_BanHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void butCheckIDGiay_Click(object sender, EventArgs e)
        {
            
            if (BLL_KhoGiay.Instance.check(txtIDGiay_BanHang.Text))
            {
                but_AddGiay.Enabled = true;
                Giay a = BLL_KhoGiay.Instance.GetGiayByID(txtIDGiay_BanHang.Text);
                txtNameSP_BanHang.Text = a.TenGiay;
                txtHang_BanHang.Text = a.HangGiay;
                txtSize_BanHang.Text = Convert.ToString(a.Size);
                txtSL_BanHang.Text = "4";
                if(Convert.ToInt32(txtSL_BanHang.Text) > 0)
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

        private void but_AddGiay_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(txtSL_BanHang.Text) > 0)
            {
                BLL_BanHang.Instance.AddDL(txtIDGiay_BanHang.Text, txtHang_BanHang.Text, txtNameSP_BanHang.Text, Convert.ToInt32(txtSize_BanHang.Text), BLL_KhoGiay.Instance.GetGiaBanGiayByID(txtIDGiay_BanHang.Text), 1, BLL_KhoGiay.Instance.GetGiaBanGiayByID(txtIDGiay_BanHang.Text) * 1);
                ResetDataSP();
                but_AddGiay.Enabled = false;
            }
            else
            {
                MessageBox.Show("Sản phẩm bạn cần tìm đã hết hàng, vui lòng kiểm tra lại...");
            }
        }
        public void ResetDataSP()
        {
            txtIDGiay_BanHang.Text = "";
            txtNameSP_BanHang.Text = "";
            txtHang_BanHang.Text = "";
            txtSize_BanHang.Text = "";
            txtSL_BanHang.Text = "";
            rdConHang.Checked = false;
            rdHetHang.Checked = false;
        }

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

        private void txtIDGiay_BanHang_TextChanged(object sender, EventArgs e)
        {
            lbKTthongTinID_BanHang.Text = "";
        }
    }
}
