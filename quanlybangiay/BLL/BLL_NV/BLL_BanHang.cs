using quanlybangiay.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybangiay.BLL.BLL_NV
{
    class BLL_BanHang
    {
        DataPBL3 db = new DataPBL3();
        private static BLL_BanHang _Instance;
        public static BLL_BanHang Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_BanHang();
                }
                return _Instance;
            }
            private set { }
        }
        private BLL_BanHang()
        {

        }
        //public bool AddUpdate(String MaSP)
        //{
        //    bool Add = true;
        //    foreach (SP i in GetAllSP())
        //    {
        //        if (MaSP == i.MaSP)
        //        {
        //            Add = false;
        //        }
        //    }
        //    return Add;
        //}
        public List<String> GetCBBKhuyenmai(DateTime timeNow, string Hang)
        {
            List<String> list = new List<String>();
            List<CTKM> ctkms = new List<CTKM>();
            var l = db.CTKMs.Where(p => p.NgayBatDau < timeNow && p.NgayKetThuc > timeNow && p.HangGiay == Hang)
                    .Select(p => p);
            ctkms = l.ToList();
            foreach (CTKM i in ctkms)
            {
                list.Add(i.TenCT.ToString());
            }
            return list;
        }

        public double GetChietkhauByName(string Name)
        {
            double value = 1;
            foreach (CTKM i in db.CTKMs)
            {
                if (i.TenCT == Name)
                {
                    value = Convert.ToDouble(i.ChietKhau);
                }
            }
            return value;
        }
        public void AddDL(string MaGiay, string Hang, string TenSP, int Size, double Gia, int SL, double ThanhTien)
        {
            DataSP.Instance.AddRow(MaGiay, Hang, TenSP, Size, Gia, SL, ThanhTien);
        }
        public void DelSP(string MaSP)
        {
            DataSP.Instance.DelRow(MaSP);
        }
        public double TongTien()
        {
            return DataSP.Instance.TongTienThanhToan();
        }
        public void AddHD(string idhoadon, string sodienthoai, DateTime ngaytao, double tongtien, string idnhanvien, string idkhuyenmai = "")
        {
            DataPBL3 db = new DataPBL3();
            HoaDon a = new HoaDon
            {
                ID_HoaDon = idhoadon,
                SoDienThoai = sodienthoai,
                NgayTao = ngaytao,
                TongTien = tongtien,
                ID_NhanVien = idnhanvien,
                ID_KhuyenMai = idkhuyenmai
            };
            db.HoaDons.Add(a);
            db.SaveChanges();
        }
        public void AddChiTietHD(string idhoadon, string idgiay, int soluong, double gia)
        {
            DataPBL3 db = new DataPBL3();
            ChiTietHoaDon a = new ChiTietHoaDon
            {
                ID_HoaDon = idhoadon,
                ID_Giay = idgiay,
                SoLuong = soluong,
                Gia = gia,
            };
            db.ChiTietHoaDons.Add(a);
            db.SaveChanges();
        }

    }
}
