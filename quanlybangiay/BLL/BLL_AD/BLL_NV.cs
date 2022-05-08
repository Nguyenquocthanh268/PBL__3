using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using quanlybangiay.DTO;


namespace quanlybangiay.BLL.BLL_AD
{
    public class BLL_NV
    {
        DataPBL3 db = new DataPBL3();
        private static BLL_NV _Instance;
        public static BLL_NV Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_NV();
                }
                return _Instance;
            }
            private set { }
        }

        private BLL_NV()
        {

        }
        public List<string> CBBSearch()
        {
            List<string> list = new List<string>();
            list.Add("ID Nhân viên");
            list.Add("Tên Nhân viên");
            return list;
        }
        public List<string> CBBSort()
        {
            List<string> list = new List<string>();
            list.Add("ID Nhân viên");
            list.Add("Tên nhân viên");
            return list;
        }


        public bool Check(string id)
        {
            foreach (NhanVien i in db.NhanViens)
            {
                if (id == i.ID_NhanVien)
                {
                    return true;
                }
            }
            return false;
        }

        public NhanVien GetNVByID(string ID)
        {
            return db.NhanViens.Find(ID);
        }

        public TaiKhoan GetTKByIDNV(string ID)
        {
            TaiKhoan s = new TaiKhoan();
            foreach (TaiKhoan i in db.TaiKhoans)
            {
                if (ID == i.ID_NhanVien)
                {
                    s = i;
                    break;
                }
            }
            return s;
        }

        public void Execute(NhanVien s, TaiKhoan t)
        {
            if (Check(s.ID_NhanVien))
            {
                NhanVien nv = db.NhanViens.Find(s.ID_NhanVien);
                nv.TenNhanVien = s.TenNhanVien;
                nv.NgaySinh = s.NgaySinh;
                nv.DiaChi = s.DiaChi;
                nv.GioiTinh = s.GioiTinh;
                nv.SoDienThoai = s.SoDienThoai;

                TaiKhoan tk = db.TaiKhoans.Find(t.Username);
                tk.Username = t.Username;
                tk.Pass = t.Pass;
                tk.ChucVu = false;
                tk.ID_NhanVien = nv.ID_NhanVien;
            }
            else
            {
                db.NhanViens.Add(s);
                db.TaiKhoans.Add(t);
            }
            db.SaveChanges();
        }

        public dynamic ShowAll()
        {
            return (db.NhanViens.Select(p => new { p.ID_NhanVien, p.TenNhanVien, p.SoDienThoai })).ToList();
        }

        public void Delete(string ID)
        {
            NhanVien nv = db.NhanViens.Find(ID);
            db.NhanViens.Remove(nv);
            db.SaveChanges();

        }
        public dynamic Sort(string txt)
        {
            return (db.NhanViens.Select(p => new { p.ID_NhanVien, p.TenNhanVien, p.SoDienThoai }).OrderBy(p => p.TenNhanVien)).ToList();
        }


        public dynamic Search(int index, string txt)
        {
            if (index == 0)
            {
                return db.NhanViens.Where(p => p.ID_NhanVien.Contains(txt)).Select(p => new { p.ID_NhanVien, p.TenNhanVien, p.SoDienThoai }).ToList();
            }
            else if (index == 1)
            {
                return db.NhanViens.Where(p => p.TenNhanVien.Contains(txt)).Select(p => new { p.ID_NhanVien, p.TenNhanVien, p.SoDienThoai }).ToList();
            }
            else
            {
                return (db.NhanViens.Select(p => new { p.ID_NhanVien, p.TenNhanVien, p.SoDienThoai })).ToList();
            }
        }

        public void ResetMK(string Username)
        {

                TaiKhoan s = db.TaiKhoans.Find(Username);
                s.Pass = "1";
                db.SaveChanges();
            
        }

    }
}
