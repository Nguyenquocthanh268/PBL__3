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
        public List<KhachHang> GetKH(int A, string txt = "")
        {
            DataPBL3 db = new DataPBL3();
            if(A == 0)
            {
                var l1 = db.KhachHangs.Where(p => p.SoDienThoai.Contains(txt)).Select(p => p);
                return l1.ToList();
            }
            else if(A == 1)
            {
                var l1 = db.KhachHangs.Where(p => p.TenKhachHang.Contains(txt)).Select(p => p);
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
            db.SaveChanges();
        }
        public void DelKH(string Sdt)
        {
            DataPBL3 db = new DataPBL3();
            KhachHang s = db.KhachHangs.Find(Sdt);
            db.KhachHangs.Remove(s);
            db.SaveChanges();
        }
        public List<KhachHang> sortKH(int indexcbbView, string txtSearch, int indexcbbSort)
        {
            if (indexcbbSort == 0)
            {
                var l1 = GetKH(indexcbbView, txtSearch).OrderBy(p => p.SoDienThoai);
                return l1.ToList();
            }
            else if (indexcbbSort == 1)
            {
                var l1 = GetKH(indexcbbView, txtSearch).OrderBy(p => p.TenKhachHang);
                return l1.ToList();
            }
            else if (indexcbbSort == 2)
            {
                var l1 = GetKH(indexcbbView, txtSearch).OrderBy(p => p.DiemTichLuy);
                return l1.ToList();
            }
            else
            {
                return null;
            }
        }
    }
}
