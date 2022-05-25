using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlybangiay.DTO;

namespace quanlybangiay.BLL.BLL_AD
{
    public class BLL_HD
    {
        DataPBL3 db = new DataPBL3();
        private static BLL_HD _Instance;
        public static BLL_HD Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_HD();
                }
                return _Instance;
            }
            private set { }
        }

        private BLL_HD()
        {

        }

        public List<string> CBBSearch()
        {
            List<string> list = new List<string>();
            list.Add("Tất cả");
            list.Add("Tên khách hàng");
            list.Add("Số điện thoại");
            return list;
        }
        public List<string> CBBSort()
        {
            List<string> list = new List<string>();
            list.Add("Tên khách hàng");
            list.Add("Ngày tạo");
            list.Add("Tổng tiền");
            return list;
        }

        public HoaDon GetHDByID(string ID)
        {
            return db.HoaDons.Find(ID);
        }

        public dynamic GetChiTietHDByID(string ID)
        {
            return db.ChiTietHoaDons.Where(p => p.ID_HoaDon == ID)
                                    .Select(p => new { p.Giay.TenGiay, p.Giay.HangGiay, p.Giay.Size, p.SoLuong,p.GiaNhap, p.Giay.GiaBan }).ToList();
        }

        public dynamic GetID_Giay(string ID)
        {
            return db.ChiTietHoaDons.Where(p => p.ID_HoaDon == ID)
                                    .Select(p => p.ID_Giay).ToList();
        }

        public KhachHang GetKHBySDT(string SDT)
        {
            return db.KhachHangs.Find(SDT);
        }


        public dynamic ShowAll()
        {
            return db.HoaDons.Select(p => new { p.ID_HoaDon, p.KhachHang.TenKhachHang, p.SoDienThoai, p.NgayTao, p.TongTien }).ToList();
        }

        public dynamic Search(int index, string txt, DateTime begin, DateTime end)
        {
            if (index == 0)
            {
                return db.HoaDons.Select(p => new { p.ID_HoaDon, p.KhachHang.TenKhachHang, p.SoDienThoai, p.NgayTao, p.TongTien }).ToList(); ;
            }
            else if (index == 1)
            {
                return db.HoaDons.Where(p => p.KhachHang.TenKhachHang.Contains(txt) && p.NgayTao >= begin && p.NgayTao <= end).Select(p => new { p.ID_HoaDon, p.KhachHang.TenKhachHang, p.SoDienThoai, p.NgayTao, p.TongTien }).ToList(); ;
            }
            else if (index == 2)
            {
                return db.HoaDons.Where(p => p.SoDienThoai.Contains(txt) && p.NgayTao >= begin && p.NgayTao <= end).Select(p => new { p.ID_HoaDon, p.KhachHang.TenKhachHang, p.SoDienThoai, p.NgayTao, p.TongTien }).ToList();
            }
            else return db.HoaDons.Where(p => p.NgayTao >= begin && p.NgayTao <= end).Select(p => new { p.ID_HoaDon, p.KhachHang.TenKhachHang, p.SoDienThoai, p.NgayTao, p.TongTien }).ToList();
        }

        public void Delete(string ID)
        {
            HoaDon s = db.HoaDons.Find(ID);
            db.HoaDons.Remove(s);
            foreach (string i in GetID_Giay(ID))
            {
                ChiTietHoaDon c = db.ChiTietHoaDons.Find(ID, i);
                db.ChiTietHoaDons.Remove(c);
            }
            db.SaveChanges();
        }

        public dynamic Sort(int index)
        {
            if (index == 0)
            {
                return (db.HoaDons.Select(p => new { p.ID_HoaDon, p.KhachHang.TenKhachHang, p.SoDienThoai, p.NgayTao, p.TongTien }).OrderBy(p => p.TenKhachHang)).ToList();
            }
            else if (index == 1)
            {
                return (db.HoaDons.Select(p => new { p.ID_HoaDon, p.KhachHang.TenKhachHang, p.SoDienThoai, p.NgayTao, p.TongTien }).OrderBy(p => p.NgayTao)).ToList();
            }
            else
            {
                return (db.HoaDons.Select(p => new { p.ID_HoaDon, p.KhachHang.TenKhachHang, p.SoDienThoai, p.NgayTao, p.TongTien }).OrderBy(p => p.TongTien)).ToList();
            }

        }
    }
}
