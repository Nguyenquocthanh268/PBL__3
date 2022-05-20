using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlybangiay.DTO;

namespace quanlybangiay.BLL.BLL_NV
{
    public class BLL_NV_HD
    {
        DataPBL3 db = new DataPBL3();
        private static BLL_NV_HD _Instance;
        public static BLL_NV_HD Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_NV_HD();
                }
                return _Instance;
            }
            private set { }
        }

        private BLL_NV_HD()
        {

        }

        public dynamic Search(string ID, DateTime begin, DateTime end)
        {
            return db.HoaDons.Where(p => p.ID_NhanVien == ID && p.NgayTao >= begin && p.NgayTao <= end).Select(p => new { p.ID_HoaDon, p.KhachHang.TenKhachHang, p.SoDienThoai, p.NgayTao, p.TongTien }).ToList(); ;
        }

        public NhanVien GetNVByUsername(string Username)
        {
            NhanVien nv = new NhanVien();
            TaiKhoan tk = db.TaiKhoans.Find(Username);
            nv = db.NhanViens.Find(tk.ID_NhanVien);
            return nv;
        }


    }
}
