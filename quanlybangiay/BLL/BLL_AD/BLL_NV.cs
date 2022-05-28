using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using quanlybangiay.DTO;
using System.IO;
using System.Drawing;

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
            list.Add("Tất cả");
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
            NhanVien k= db.NhanViens.Find(ID);
            if (k != null)
            {
                return k;
            }
            else
            {
                return null;
            }
        }

        public dynamic GetUsername(string ID)
        {
            return db.TaiKhoans.Where(p => p.ID_NhanVien == ID)
                                    .Select(p => p.Username).ToList();
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
                nv.AnhNV = s.AnhNV;
                nv.SoDienThoai = s.SoDienThoai;


                BLL_Login.Instance.UpdateTK(t);
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
            foreach (string i in GetUsername(ID))
            {
                TaiKhoan tk = db.TaiKhoans.Find(i); ;
                db.TaiKhoans.Remove(tk);
            }
            db.SaveChanges();

        }
        public dynamic Sort(string txt, int index)
        {
            if(index == 0)
            {
                return (db.NhanViens.Select(p => new { p.ID_NhanVien, p.TenNhanVien, p.SoDienThoai }).OrderBy(p => p.ID_NhanVien)).ToList();
            }
            else
            {
                return (db.NhanViens.Select(p => new { p.ID_NhanVien, p.TenNhanVien, p.SoDienThoai }).OrderBy(p => p.TenNhanVien)).ToList();
            }
            
        }


        public dynamic Search(int index, string txt)
        {
            if (index == 0)
            {
                return (db.NhanViens.Select(p => new { p.ID_NhanVien, p.TenNhanVien, p.SoDienThoai })).ToList();
            }
            else if (index == 1)
            {
                return db.NhanViens.Where(p => p.ID_NhanVien.Contains(txt)).Select(p => new { p.ID_NhanVien, p.TenNhanVien, p.SoDienThoai }).ToList();
            }
            else if (index == 2)
            {
                return db.NhanViens.Where(p => p.TenNhanVien.Contains(txt)).Select(p => new { p.ID_NhanVien, p.TenNhanVien, p.SoDienThoai }).ToList();
            }
            else
            {
                return (db.NhanViens.Select(p => new { p.ID_NhanVien, p.TenNhanVien, p.SoDienThoai })).ToList();
            }
        }

        public byte[] ImagetoByte(Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        public Image BytetoPicter(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
        public string tachchuoi(string s)
        {
            string h = "";
            char[] a = s.ToArray();
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] >= 48 && a[i] <= 57)
                {
                    h += a[i];
                }
            }
            return h;
        }
        public string IDNV()
        {
            
            string so = "";
            string id = "0";
            List<string> list = new List<string>();
            foreach (TaiKhoan i in db.TaiKhoans)
            {


                list.Add(tachchuoi(i.Username));

            }
            foreach (string s in list)
            {
                if (Convert.ToInt32(s) > Convert.ToInt32(id))
                {
                    id = s;
                }
            }
            if (Convert.ToInt32(id) <= 8)
            {
                return Convert.ToString("NV00" + Convert.ToString(Convert.ToInt32(id) + 1));
            }
            else if (Convert.ToInt32(id) >= 9 && Convert.ToInt32(id) <= 98)
            {
                return Convert.ToString("NV0" + Convert.ToString(Convert.ToInt32(id) + 1));
            }
            
            else
            {
                return Convert.ToString("NV" + Convert.ToString(Convert.ToInt32(id) + 1));
            }

        }
        public bool CheckUsername(string username)
        {
            bool check = false;
            if (db.TaiKhoans.Find(username) == null)
            {
                check = true;
            }
            return check;
        }
    }
        
}

