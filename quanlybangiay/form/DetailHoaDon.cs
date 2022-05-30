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
    public partial class DetailHoaDon : Form
    {
        public delegate void Mydel();
        public Mydel d { get; set; }
        public string ID { get; set; }
        public int index;
        public DetailHoaDon(string m)
        {
            InitializeComponent();
            ID = m;
            GUI();
        }

        public void GUI()
        {
            HoaDon s = BLL_HD.Instance.GetHDByID(ID);
            txtID_HD.Text = s.ID_HoaDon;
            txtNgaytao.Text = s.NgayTao.ToString();
            if (BLL_HD.Instance.GetKHBySDT(s.SoDienThoai) != null)
            {
                txtTen_KH.Text = BLL_HD.Instance.GetKHBySDT(s.SoDienThoai).TenKhachHang;
            }
            else
            {
                txtTen_KH.Text = "KHACH HANG BI XOA";
            }
            if (BLL_NV.Instance.GetNVByID(s.ID_NhanVien) != null)
            {
                txtTen_NV.Text = BLL_NV.Instance.GetNVByID(s.ID_NhanVien).TenNhanVien;
            }
            else
            {
                txtTen_NV.Text= "NHAN VIEN BI XOA";
            }
            if(s.ID_KhuyenMai != null)
            {
                txt_IDKM.Text = s.ID_KhuyenMai.ToString();
                txt_KM.Text = s.chietKhauKM.ToString() + "%";
            }
            else
            {

                txt_IDKM.Text = "KHONG CO CTKM";
                txt_KM.Text = 0 + "%";
            }
           
            txt_TV.Text = s.Thanhvien.ToString() + "%";
            txt_tongck.Text= Convert.ToInt32(Convert.ToInt32(s.Thanhvien)+Convert.ToInt32(s.chietKhauKM)).ToString() +"%";
            txtTong.Text = s.TongTien.ToString() + " VND";
            dtgDetailHD.DataSource = BLL_HD.Instance.GetChiTietHDByID(ID);
        }
    }
}
