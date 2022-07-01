using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using quanlybangiay.DTO;

namespace quanlybangiay.BLL.BLL_AD
{
    public class BLL_CTKM
    {
        private static BLL_CTKM _Instance;
        public static BLL_CTKM Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_CTKM();
                }
                return _Instance;
            }
            private set { }
        }
        private BLL_CTKM()
        {

        }
        public List<string> CBB()
        {
            List<string> list = new List<string>();
            list.Add("Tất cả");
            list.Add("ID CTKM");
            list.Add("Tên CTKM");
            return list;
        }
        public List<string> CBB_sort()
        {
            List<string> list = new List<string>();
            list.Add("Chiết khấu");
            list.Add("Ngày bắt đầu");
            list.Add("Ngày kết thúc");
            return list;
        }
        public List<CTKM_view> search(int index,string s)
        {
            DataPBL3 db = new DataPBL3();
            
          if(index ==1)
            {

                return (db.CTKMs.Where(p => p.ID_KhuyenMai.Contains(s)).Select(p => new CTKM_view{ID= p.ID_KhuyenMai,Ten= p.TenCT,chietkhau=(int) p.ChietKhau })).ToList();
            }
            else if(index ==2)
            {

                return (db.CTKMs.Where(p => p.TenCT.Contains(s)).Select(p => new CTKM_view { ID = p.ID_KhuyenMai, Ten = p.TenCT, chietkhau = (int)p.ChietKhau })).ToList();
            }
            else
            {
                return (db.CTKMs.Select(p => new CTKM_view { ID = p.ID_KhuyenMai, Ten = p.TenCT, chietkhau = (int)p.ChietKhau })).ToList();
            }
         
        }
        public CTKM GetCTKM(string a)
        {
            DataPBL3 db = new DataPBL3();
            return db.CTKMs.Find(a);
        }
        public bool KT (string s)
        {
            DataPBL3 db = new DataPBL3();
            foreach (CTKM i in db.CTKMs)
            {
                if(i.ID_KhuyenMai == s)
                {
                    return false;
                }
            }
            return true;
        }
        public void Add(CTKM s)
        {
            if (KT(s.ID_KhuyenMai))
            {
                DataPBL3 db = new DataPBL3();

                db.CTKMs.Add(s);
                db.SaveChanges();

            }
            

        }
        
        public void Update(CTKM s)
        {
            DataPBL3 db = new DataPBL3();
            CTKM c = db.CTKMs.Find(s.ID_KhuyenMai);
            c.TenCT = s.TenCT;
            c.ChietKhau = s.ChietKhau;
            c.NgayBatDau = s.NgayBatDau;
            c.NgayKetThuc = s.NgayKetThuc;
            c.MoTa = s.MoTa;
            db.SaveChanges();
        }
        public void ExcuteDB(CTKM s)
        {
            if (KT(s.ID_KhuyenMai))
            {
                Add(s);
            }
            else
            {
                Update(s);
            }
        }
        public void Del(string ID)
        {
            DataPBL3 db = new DataPBL3();
            CTKM c = db.CTKMs.Find(ID);
            db.CTKMs.Remove(c);
            db.SaveChanges();

        }
        public List<CTKM_view> sort(int index)
        {
            DataPBL3 db = new DataPBL3();
           if(index == 0)
            {
                return (
               from p in db.CTKMs
               orderby p.ChietKhau
               select new CTKM_view{ ID = p.ID_KhuyenMai,Ten = p.TenCT,chietkhau = (int)p.ChietKhau }).ToList();
            }
            else if(index == 1)
            {
                return (
                              from p in db.CTKMs
                              orderby p.NgayBatDau
                              select new CTKM_view { ID = p.ID_KhuyenMai, Ten = p.TenCT, chietkhau = (int)p.ChietKhau }
                              ).ToList();
            }
            else
            {
                return (
                              from p in db.CTKMs
                              orderby p.NgayKetThuc
                              select new CTKM_view { ID = p.ID_KhuyenMai, Ten = p.TenCT, chietkhau = (int)p.ChietKhau }
                              ).ToList();
            }
        }
        public List<string> GetListNameCTKM()
        {
            DataPBL3 db = new DataPBL3();
            List<string> data = new List<string>();
            foreach (CTKM i in db.CTKMs)
            {
                data.Add(i.TenCT);
            }
            return data;
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
        public string IDKM()
        {
            DataPBL3 db = new DataPBL3();
            string so = "";
            string id = "0";
            List<string> list = new List<string>();
            foreach (CTKM i in db.CTKMs)
            {


                list.Add(tachchuoi(i.ID_KhuyenMai));

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
                return Convert.ToString("KM000" + Convert.ToString(Convert.ToInt32(id) + 1));
            }
            else if (Convert.ToInt32(id) >= 9 && Convert.ToInt32(id) <= 98)
            {
                return Convert.ToString("KM00" + Convert.ToString(Convert.ToInt32(id) + 1));
            }
            else if (Convert.ToInt32(id) >= 99 && Convert.ToInt32(id) <= 998)
            {
                return Convert.ToString("KM0" + Convert.ToString(Convert.ToInt32(id) + 1));
            }
            else
            {
                return Convert.ToString("KM" + Convert.ToString(Convert.ToInt32(id) + 1));
            }

        }
    }
}
