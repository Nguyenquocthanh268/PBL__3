using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlybangiay.DTO;
namespace quanlybangiay.BLL.BLL_AD
{
    class BLL_QLKH
    {
        private static BLL_QLKH _Instance;
        public static BLL_QLKH Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_QLKH();
                }
                return _Instance;
            }
            private set { }
        }
        private BLL_QLKH()
        {

        }
        public dynamic GetKH(int A, string txt = "")
        {
            DataPBL3 db = new DataPBL3();
            if(A == 0)
            {
                var l1 = db.KhachHangs.Select(p =>new {p.TenKhachHang,p.SoDienThoai,p.NgayDangKy,p.DiemTichLuy} );
                return l1.ToList();
            }
            else if(A == 1)
            {
                var l1 = db.KhachHangs.Where(p => p.SoDienThoai.Contains(txt)).Select(p => new { p.TenKhachHang, p.SoDienThoai, p.NgayDangKy, p.DiemTichLuy });
                return l1.ToList();
            }
            else if (A == 2)
            {
                var l1 = db.KhachHangs.Where(p => p.TenKhachHang.Contains(txt)).Select(p => new { p.TenKhachHang, p.SoDienThoai, p.NgayDangKy, p.DiemTichLuy });
                return l1.ToList();
            }
            else
            {
                return null;
            }
        }
        public KhachHang Get1KH(string SDT)
        {
            DataPBL3 db = new DataPBL3();
            KhachHang a = db.KhachHangs.Find(SDT);
            return a;
        }
        public void UpdateKH(KhachHang a)
        {
            DataPBL3 db = new DataPBL3();
            KhachHang kh = db.KhachHangs.Find(a.SoDienThoai);
            kh.TenKhachHang = a.TenKhachHang;
            kh.DiemTichLuy = a.DiemTichLuy;
            db.SaveChanges();
        }
        public void DelKH(string Sdt)
        {
            DataPBL3 db = new DataPBL3();
            KhachHang s = db.KhachHangs.Find(Sdt);
            db.KhachHangs.Remove(s);
            db.SaveChanges();
        }
        public dynamic sortKH(int indexcbbView, string txtSearch, int indexcbbSort)
        {
            DataPBL3 db = new DataPBL3();
            if (indexcbbSort == 0)
            {
                var l1 = db.KhachHangs.Select(p => new { p.TenKhachHang, p.SoDienThoai, p.NgayDangKy, p.DiemTichLuy }).OrderBy(p => p.SoDienThoai);
                return l1.ToList();
            }
            else if (indexcbbSort == 1)
            {
                var l1 = db.KhachHangs.Select(p => new { p.TenKhachHang, p.SoDienThoai, p.NgayDangKy, p.DiemTichLuy }).OrderBy(p => p.TenKhachHang);
                return l1.ToList();
            }
            else if (indexcbbSort == 2)
            {
                var l1 = db.KhachHangs.Select(p => new { p.TenKhachHang, p.SoDienThoai, p.NgayDangKy, p.DiemTichLuy }).OrderBy(p => p.DiemTichLuy);
                return l1.ToList();
            }
            else
            {
                return null;
            }
        }
        public bool Check(string Sdt)
        {
            DataPBL3 db = new DataPBL3();
            bool check = false;
            foreach (KhachHang i in db.KhachHangs)
            {
                if (i.SoDienThoai == Sdt)
                {
                    check = true;
                }
            }
            return check;
        }
        public void AddKH(string Sdt,string name)
        {
            DataPBL3 db = new DataPBL3();
            KhachHang a = new KhachHang
            {
                SoDienThoai = Sdt,
                TenKhachHang = name,
                DiemTichLuy = 0,
                NgayDangKy = DateTime.Now
            };
            db.KhachHangs.Add(a);
            db.SaveChanges();
        }
        public List<string> CBBView()
        {
            List<string> list = new List<string>();
            list.Add("Tất cả");
            list.Add("Số ĐT");
            list.Add("Tên");
            return list;
        }
        public List<string> CBBSort()
        {
            List<string> list = new List<string>();
            list.Add("Số ĐT");
            list.Add("Tên");
            list.Add("Điểm tích lũy");
            return list;
        }
    }
}
