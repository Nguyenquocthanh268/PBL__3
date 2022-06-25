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
        //public NhapKho GetNhapkho(string ID)
        //{
        //    return (NhapKho)db.NhapKhoes.Where(p => p.ID_Giay == ID);
        //}
 
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
            string s = "",c="";
            int dem = 0;
            char[] a = ten.ToCharArray();
          

            for(int i = 0; i < a.Length; i++)
            {
                if(a[i] != 32)
                {
                    c+=a[i];
                }
                
              
            }
            char[] b =c.ToCharArray();
            for (int i=0;i < 4; i++)
            {
                s += c[i];
            }
            return s.ToUpper()+size;
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
        public void ADD_nhapkho(NhapKho n)
        {
            db.NhapKhoes.Add(n);

            db.SaveChanges();
        }
        public void Delete(string ID)
        {
            Giay g = db.Giays.Find(ID);
            Kho k = db.Khoes.Find(ID);
            foreach(NhapKho i in db.NhapKhoes)
            {
                if (i.ID_Giay == ID)
                {
                  db.NhapKhoes.Remove(i);
                }
            }
            db.Giays.Remove(g);
            db.Khoes.Remove(k);
            db.SaveChanges();
        }
        public dynamic getListTimeNhapKhoByID(string id)
        {
            return db.NhapKhoes.Where(p => p.ID_Giay == id).Select(p =>new { p.Stt, p.ID_Giay, p.Kho.Giay.TenGiay, p.SoLuongNhap, p.NgayNhap, p.GiaNhap }).ToList();
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
        public List<GiayView> sort(int index)
        {
            if (index == 0)
            {
                return (db.Giays.Select(p => new  GiayView {ID= p.ID_Giay,Name= p.TenGiay,Hang= p.HangGiay,size=(int) p.Size }).OrderBy(p => p.Name)).ToList();
            }
            else
            {
                return (db.Giays.Select(p => new GiayView { ID = p.ID_Giay, Name = p.TenGiay, Hang = p.HangGiay, size = (int)p.Size }).OrderBy(p => p.size)).ToList();
            }
        }
        public List<string> CBBsort()
        {
            List<string> list = new List<string>();
            list.Add("Tên Giày");
            list.Add("Size");
            return list;
        }
        public dynamic SearchNhapKho(DateTime st, DateTime end,string ID)
        {
            return db.NhapKhoes.Where(p => p.NgayNhap >= st && p.NgayNhap <= end && p.ID_Giay==ID).Select(p => new { p.Stt, p.ID_Giay, p.Kho.Giay.TenGiay, p.SoLuongNhap, p.NgayNhap, p.GiaNhap }).ToList();
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

        public List<string> SapxepSize(List<string> l)
        {
            List<string> s = new List<string>();
            for(int i = 0; i < l.Count-1; i++)
            {
                for(int j = i + 1; j < l.Count; j++)
                {
                    if (Convert.ToInt32(l[i]) > Convert.ToInt32(l[j]))
                    {
                        String temp =l[i];
                        l[i] = l[j];
                        l[j] = temp;
                    }
                }
            }
            s = l;
            return s;
        }
      
        public Boolean CheckSizeOFTen(String ten,String size)
        {
            int dem = 0;
           List<Giay> l = new List<Giay>();
           foreach(Giay i in db.Giays)
            {
                if(i.TenGiay == ten)
                {
                    l.Add(i);
                }
            }
           foreach(Giay i in l)
            {
                if(i.Size == Convert.ToInt32(size))
                {
                    dem++;
                }
            }
           if(dem == 0)
            {
                return true;
            }
            else
            {
                return false;
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
        public string Laychuoi(string s)
        {
            string h = "";
            char[] a = s.ToArray();
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] >= 65 && a[i] <= 90)
                {
                    h += a[i];
                }
            }
            return h;
        }
        public string  RangeIDgiay(string Hang)
        {
            string id = "0";
            List<Giay> l = new List<Giay>();
            List<string> data = new List<string>();
            foreach (Giay i in db.Giays)
            {
                if (Laychuoi(i.ID_Giay).ToLower() == Hang.ToLower())
                {
                     l.Add(i);
                 
                }
            }

            foreach (Giay i in l)
            {
                data.Add(tachchuoi(i.ID_Giay));
            }
            foreach (string s in data)
            {
                if (Convert.ToInt32(s) > Convert.ToInt32(id))
                {
                    id = s;
                }
            }
            if (Convert.ToInt32(id) <= 8)
            {
                return Convert.ToString(Hang.ToUpper() + "00" + Convert.ToString(Convert.ToInt32(id) + 1));
            }
            else if (Convert.ToInt32(id) >= 9 && Convert.ToInt32(id) <= 98)
            {
                return Convert.ToString(Hang.ToUpper() + "0" + Convert.ToString(Convert.ToInt32(id) + 1));
            }
            else
            {
                return Convert.ToString(Hang.ToUpper() + Convert.ToString(Convert.ToInt32(id) + 1));
            }
        }
        public List<GiayView> searh_Size(string ten, int size)
        {
            if(ten == "")
            {
                return (db.Giays.Where(p => p.Size == size).Select(p => new GiayView { ID = p.ID_Giay, Name = p.TenGiay, Hang = p.HangGiay, size = (int)p.Size })).ToList();
            }
            else
            {
                return (db.Giays.Where(p => p.Size==size && p.TenGiay.Contains(ten)).Select(p => new GiayView { ID = p.ID_Giay, Name = p.TenGiay, Hang = p.HangGiay, size = (int)p.Size })).ToList();
            }
        }
        public List<GiayView> search_Hang(string ten ,string hang)
        {  
            if(ten== "")
            {
                return (db.Giays.Where(p => p.HangGiay == hang ).Select(p => new GiayView { ID = p.ID_Giay, Name = p.TenGiay, Hang = p.HangGiay, size = (int)p.Size })).ToList();
            }
            else
            {
                return (db.Giays.Where(p => p.HangGiay == hang && p.TenGiay.Contains(ten)).Select(p => new GiayView { ID = p.ID_Giay, Name = p.TenGiay, Hang = p.HangGiay, size = (int)p.Size })).ToList();
            }

        }
        public List<GiayView> search_Size_Hang(string ten , string hang ,int size)
        {
            if(ten == "")
            {
                return (db.Giays.Where(p => p.HangGiay == hang && p.Size ==size).Select(p => new GiayView { ID = p.ID_Giay, Name = p.TenGiay, Hang = p.HangGiay, size = (int)p.Size })).ToList();
            }
            else if(hang =="" && size == 0)
            {
                return (db.Giays.Where(p =>  p.TenGiay.Contains(ten) ).Select(p => new GiayView { ID = p.ID_Giay, Name = p.TenGiay, Hang = p.HangGiay, size = (int)p.Size })).ToList();
            }    
            else
            {
                return (db.Giays.Where(p => p.Size == size && p.TenGiay.Contains(ten) && p.HangGiay == hang).Select(p => new GiayView { ID = p.ID_Giay, Name = p.TenGiay, Hang = p.HangGiay, size = (int)p.Size })).ToList();
            }
        }
        public List<GiayView> search(string id ,string ten ,string hang ,int size)
        {
          if(ten ==""  && hang =="" && size == 0)
            {
                return (db.Giays.Where(p => p.ID_Giay.Contains(id)).Select(p => new GiayView { ID = p.ID_Giay, Name = p.TenGiay, Hang = p.HangGiay, size = (int)p.Size })).ToList();
            }
         
            else
            {
                return (db.Giays.Select(p => new GiayView { ID = p.ID_Giay, Name = p.TenGiay, Hang = p.HangGiay, size = (int)p.Size })).ToList();
            }
        }
        public List<GiayView> getAllGiay()
        {
            return (db.Giays.Select(p => new GiayView { ID = p.ID_Giay, Name = p.TenGiay, Hang = p.HangGiay, size = (int)p.Size })).ToList();
        }
        public Kho GetGiay_INKho(string ID)
        {
            return db.Khoes.Find(ID);
        }

    }
}

