using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using quanlybangiay.DTO;
using System.IO;

namespace quanlybangiay.BLL.BLL_AD
{
    public class BLL_KhoGiay
    {

        DataPBL3 db = new DataPBL3();
        private static BLL_KhoGiay _Instance;
        public static BLL_KhoGiay Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_KhoGiay();
                }
                return _Instance;
            }
            private set { }
        }

        private BLL_KhoGiay()
        {

        }
       
        public Giay GetGiayByID(string ID)
        {
            return db.Giays.Find(ID);
        }
        public double GetGiaBanGiayByID(string ID)
        {
            return (double)db.Giays.Find(ID).GiaBan;
        }
        public Kho GetkhoByID(string ID)
        {
            return db.Khoes.Find(ID);
        }
        public NhapKho GetNhapkho(string ID)
        {
            return (NhapKho)db.NhapKhoes.Where(p => p.ID_Giay == ID);
        }
 
        public bool check(string ID)
        {

            foreach (Giay i in db.Giays)
            {
                if (i.ID_Giay == ID)
                {
                    return true;
                }
            }
            return false;
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
      
        public void Excute(Giay s, Kho kh)
        {
            if (check(s.ID_Giay))
            {
                Giay giay = db.Giays.Find(s.ID_Giay);
                giay.TenGiay = s.TenGiay;
                giay.Size = s.Size;
                giay.HangGiay = s.HangGiay;
                giay.GiaBan = s.GiaBan;
                giay.AnhSP= s.AnhSP;
            }
            else
            {
            
                db.Giays.Add(s);
                db.Khoes.Add(kh);
            }
            db.SaveChanges();
        }
        public void UpdateKho(string ID, int sl)
        {
            Kho kho = db.Khoes.Find(ID);
            kho.SoLuongBan += sl;
            kho.SoLuongCon -= sl;
            db.SaveChanges();
        }
        public string ID_giay(string ten , string size)
        {
            return ten + size;
        }
        public void NhapKho(Giay g, Kho k, NhapKho n)
        {

            Giay giay = db.Giays.Find(g.ID_Giay);
            giay.GiaNhap = g.GiaNhap;
            Kho kho = db.Khoes.Find(k.ID_Giay);
            kho.TongSoLuongNhap = kho.TongSoLuongNhap + k.TongSoLuongNhap;
            kho.SoLuongCon = kho.SoLuongCon + k.SoLuongCon;
            db.NhapKhoes.Add(n);




            db.SaveChanges();
        }
        public void Delete(string ID)
        {
            Giay g = db.Giays.Find(ID);
            Kho k = db.Khoes.Find(ID);
            db.Giays.Remove(g);
            db.Khoes.Remove(k);
            db.SaveChanges();
        }
        public dynamic showNhap()
        {
            return (db.NhapKhoes.Select(p => new { p.Stt, p.ID_Giay, p.Kho.Giay.TenGiay, p.SoLuongNhap, p.NgayNhap, p.GiaNhap })).ToList();
        }
        public int STTNhap()
        {
            int max = 0;
            foreach (NhapKho i in db.NhapKhoes)
            {
                if (i.Stt > max)
                {
                    max = i.Stt;
                }
            }
            return max + 1;
        }
        public dynamic sort(int index)
        {
            if (index == 0)
            {
                return (db.Giays.Select(p => new { p.ID_Giay, p.TenGiay, p.HangGiay, p.Size }).OrderBy(p => p.TenGiay)).ToList();
            }
            else
            {
                return (db.Giays.Select(p => new { p.ID_Giay, p.TenGiay, p.HangGiay, p.Size }).OrderBy(p => p.Size)).ToList();
            }
        }
        public List<string> CBBsort()
        {
            List<string> list = new List<string>();
            list.Add("Tên Giày");
            list.Add("Size");
            return list;
        }
        public dynamic SearchNhapKho(DateTime st, DateTime end)
        {
            return db.NhapKhoes.Where(p => p.NgayNhap >= st && p.NgayNhap <= end).Select(p => new { p.Stt, p.ID_Giay, p.Kho.Giay.TenGiay, p.SoLuongNhap, p.NgayNhap, p.GiaNhap }).ToList();
        }
        public List<string> CBBsize()
        {
            List<string> l = new List<string>();
            foreach (Giay i in db.Giays)
            {
                l.Add(Convert.ToString((int)i.Size));
            }
            return l;
        }
        public List<string> CBBhang()
        {
            List<string> k = new List<string>();
            foreach (Giay i in db.Giays)
            {
                k.Add(i.HangGiay);
            }
            return k;
        }
     
        public dynamic searh_Size(string ten, int size)
        {
            if(ten == "")
            {
                return (db.Giays.Where(p => p.Size == size).Select(p => new { p.ID_Giay, p.TenGiay, p.HangGiay, p.Size })).ToList();
            }
            else
            {
                return (db.Giays.Where(p => p.Size==size && p.TenGiay.Contains(ten)).Select(p => new { p.ID_Giay, p.TenGiay, p.HangGiay, p.Size })).ToList();
            }
        }
        public dynamic search_Hang(string ten ,string hang)
        {  
            if(ten== "")
            {
                return (db.Giays.Where(p => p.HangGiay == hang ).Select(p => new { p.ID_Giay, p.TenGiay, p.HangGiay, p.Size })).ToList();
            }
            else
            {
                return (db.Giays.Where(p => p.HangGiay == hang && p.TenGiay.Contains(ten)).Select(p => new { p.ID_Giay, p.TenGiay, p.HangGiay, p.Size })).ToList();
            }

        }
        public dynamic search_Size_Hang(string ten , string hang ,int size)
        {
            if(ten == "")
            {
                return (db.Giays.Where(p => p.HangGiay == hang && p.Size ==size).Select(p => new { p.ID_Giay, p.TenGiay, p.HangGiay, p.Size })).ToList();
            }
            else if(hang =="" && size == 0)
            {
                return (db.Giays.Where(p =>  p.TenGiay.Contains(ten) ).Select(p => new { p.ID_Giay, p.TenGiay, p.HangGiay, p.Size })).ToList();
            }    
            else
            {
                return (db.Giays.Where(p => p.Size == size && p.TenGiay.Contains(ten) && p.HangGiay == hang).Select(p => new { p.ID_Giay, p.TenGiay, p.HangGiay, p.Size })).ToList();
            }
        }
        public dynamic search(string id ,string ten ,string hang ,int size)
        {
          if(ten ==""  && hang =="" && size == 0)
            {
                return (db.Giays.Where(p => p.ID_Giay==id).Select(p => new { p.ID_Giay, p.TenGiay, p.HangGiay, p.Size })).ToList();
            }
         
            else
            {
                return (db.Giays.Select(p => new { p.ID_Giay, p.TenGiay, p.HangGiay, p.Size })).ToList();
            }
        }
        public dynamic showAll()
        {
            return (db.Giays.Select(p => new { p.ID_Giay, p.TenGiay, p.HangGiay, p.Size })).ToList();
        }

    }
}

