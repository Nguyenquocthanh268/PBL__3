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
            list.Add("All");
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
        public dynamic search(int index,string s)
        {
            DataPBL3 db = new DataPBL3();
            
          if(index ==1)
            {

                return (db.CTKMs.Where(p => p.ID_KhuyenMai.Contains(s)).Select(p => new { p.ID_KhuyenMai, p.TenCT, p.ChietKhau })).ToList();
            }
            else if(index ==2)
            {

                return (db.CTKMs.Where(p => p.TenCT.Contains(s)).Select(p => new { p.ID_KhuyenMai, p.TenCT, p.ChietKhau })).ToList();
            }
            else
            {
                return (db.CTKMs.Select(p => new { p.ID_KhuyenMai, p.TenCT, p.ChietKhau })).ToList();
            }
         
        }
        public CTKM GetCTKM(string MSSV)
        {
            DataPBL3 db = new DataPBL3();
            return db.CTKMs.Find(MSSV);
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
        public dynamic sort(int index)
        {
            DataPBL3 db = new DataPBL3();
           if(index == 0)
            {
                return (
               from p in db.CTKMs
               orderby p.ChietKhau
               select new { p.ID_KhuyenMai, p.TenCT, p.ChietKhau }
               ).ToList();
            }
            else if(index == 1)
            {
                return (
                              from p in db.CTKMs
                              orderby p.NgayBatDau
                              select new { p.ID_KhuyenMai, p.TenCT, p.ChietKhau }
                              ).ToList();
            }
            else
            {
                return (
                              from p in db.CTKMs
                              orderby p.NgayKetThuc
                              select new { p.ID_KhuyenMai, p.TenCT, p.ChietKhau }
                              ).ToList();
            }
        }
        
    }
}
