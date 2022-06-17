using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlybangiay.DTO;

namespace quanlybangiay.BLL.BLL_NV
{
    public class BLL_KiemkhoNV
    {
        DataPBL3 db = new DataPBL3();
        private static BLL_KiemkhoNV _Instance;
        public static BLL_KiemkhoNV Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_KiemkhoNV();
                }
                return _Instance;
            }
            private set { }
        }
        private BLL_KiemkhoNV()
        {

        }
        public List<string> hang()
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
            for (int i = 0; i < l.Count - 1; i++)
            {
                for (int j = i + 1; j < l.Count; j++)
                {
                    if (Convert.ToInt32(l[i]) > Convert.ToInt32(l[j]))
                    {
                        String temp = l[i];
                        l[i] = l[j];
                        l[j] = temp;
                    }
                }
            }
            s = l;
            return s;
        }
        public List<string> TenOfHang(string s)
        {
            List<string> data = new List<string>();
            foreach (Giay i in db.Giays)
            {
                if (i.HangGiay == s)
                {
                    data.Add(i.TenGiay);
                }
            }
            return data;
        }
        public List<string> SizeOfTen(string s)
        {
            List<string> data = new List<string>();
            foreach (Giay i in db.Giays)
            {
                if (i.TenGiay == s)
                {
                    data.Add(Convert.ToString((int)i.Size));
                }
            }
            return data;
        }
        public List<string> size()
        {
            List<string> l = new List<string>();
            foreach (Giay i in db.Giays)
            {
                l.Add(Convert.ToString((int)i.Size));
            }
            return l;
        }

        public List<string> ten()
        {
            List<string> k = new List<string>();
            foreach (Giay i in db.Giays)
            {
                k.Add(i.TenGiay);
            }
            return k;
        }

        public dynamic searh_Size(string ten, int size)
        {
            if (ten == "")
            {
                return (db.Giays.Where(p => p.Size == size).Select(p => new { p.ID_Giay, p.TenGiay, p.HangGiay, p.Size })).ToList();
            }
            else
            {
                return (db.Giays.Where(p => p.Size == size && p.TenGiay.Contains(ten)).Select(p => new { p.ID_Giay, p.TenGiay, p.HangGiay, p.Size })).ToList();
            }
        }
    
        public dynamic search_Hang(string ten, string hang)
        {
            if (ten == "")
            {
                return (db.Giays.Where(p => p.HangGiay.Contains(hang)).Select(p => new { p.ID_Giay, p.TenGiay, p.HangGiay, p.Size })).ToList();
            }
            else
            {
                return (db.Giays.Where(p => p.HangGiay.Contains(hang) && p.TenGiay.Contains(ten)).Select(p => new { p.ID_Giay, p.TenGiay, p.HangGiay, p.Size })).ToList();
            }

        }
        public dynamic search_Size_Hang(string ten, string hang, int size)
        {
            if (ten == "")
            {
                return (db.Giays.Where(p => p.HangGiay.Contains(hang) && p.Size == size).Select(p => new { p.ID_Giay, p.TenGiay, p.HangGiay, p.Size })).ToList();
            }
            else if (hang == "" && size == 0)
            {
                return (db.Giays.Where(p => p.TenGiay.Contains(ten)).Select(p => new { p.ID_Giay, p.TenGiay, p.HangGiay, p.Size })).ToList();
            }
            else
            {
                return (db.Giays.Where(p => p.Size == size && p.TenGiay.Contains(ten) && p.HangGiay.Contains(hang)).Select(p => new { p.ID_Giay, p.TenGiay, p.HangGiay, p.Size })).ToList();
            }
        }
        public dynamic search(string id, string ten, string hang, int size)
        {
            if (ten == "" && hang == "" && size == 0)
            {
                return (db.Giays.Where(p => p.ID_Giay.Contains(id)).Select(p => new { p.ID_Giay, p.TenGiay, p.HangGiay, p.Size })).ToList();
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
