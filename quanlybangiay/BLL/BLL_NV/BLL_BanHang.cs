using quanlybangiay.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybangiay.BLL.BLL_NV
{
    class BLL_BanHang
    {
        DataPBL3 db = new DataPBL3();
        private static BLL_BanHang _Instance;
        public static BLL_BanHang Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_BanHang();
                }
                return _Instance;
            }
            private set { }
        }
        private BLL_BanHang()
        {

        }
        //public bool AddUpdate(String MaSP)
        //{
        //    bool Add = true;
        //    foreach (SP i in GetAllSP())
        //    {
        //        if (MaSP == i.MaSP)
        //        {
        //            Add = false;
        //        }
        //    }
        //    return Add;
        //}
        public List<String> GetCBBKhuyenmai(DateTime timeNow)
        {
            List<String> list = new List<String>();
            List<CTKM> ctkms = new List<CTKM>();
            ctkms = db.CTKMs.Where(p => p.NgayBatDau < timeNow && p.NgayKetThuc > timeNow)
                    .Select(p => p).ToList();
            
            foreach (CTKM i in ctkms)
            {
                list.Add(i.TenCT.ToString());
            }
            return list;
        }

        public double GetChietkhauByName(string Name)
        {
            double value = 1;
            foreach (CTKM i in db.CTKMs)
            {
                if (i.TenCT == Name)
                {
                    value = Convert.ToDouble(i.ChietKhau);
                }
            }
            return value;
        }

        public string GetID_KMByName(string name)
        {
            string ID = "";
            foreach (CTKM i in db.CTKMs)
            {
                if (i.TenCT == name)
                {
                    ID = i.ID_KhuyenMai.ToString();
                }
            }
            return ID;
        }

        public double GetGiaNhapByID(string ID)
        {
            Giay s = db.Giays.Find(ID);
            return (double)s.GiaNhap;
        }
        public Kho GetGiay_Kho(string ID)
        {
            return db.Khoes.Find(ID);
        }
        public void AddDL(string MaGiay, string Hang, string TenSP, int Size, double Gia, int SL, double ThanhTien)
        {
            DataSP.Instance.AddRow(MaGiay, Hang, TenSP, Size, Gia, SL, ThanhTien);
        }
        public void DelSP(string MaSP)
        {
            DataSP.Instance.DelRow(MaSP);
        }
        public void DelAllData()
        {
            DataSP.Instance.ResetData();
        }
        public double TongTien()
        {
            return DataSP.Instance.TongTienThanhToan();
        }
        public void AddHD(HoaDon s)
        {
            DataPBL3 db = new DataPBL3();
            HoaDon a = new HoaDon
            {
                ID_HoaDon = s.ID_HoaDon,
                SoDienThoai = s.SoDienThoai,
                Thanhvien = s.Thanhvien,
                NgayTao = s.NgayTao,
                TongTien = s.TongTien,
                ID_NhanVien = s.ID_NhanVien,
                ID_KhuyenMai = s.ID_KhuyenMai
            };
            db.HoaDons.Add(a);
            db.SaveChanges();
        }
        public void AddChiTietHD(ChiTietHoaDon s)
        {
            DataPBL3 db = new DataPBL3();
            ChiTietHoaDon a = new ChiTietHoaDon
            {
                ID_HoaDon = s.ID_HoaDon,
                ID_Giay = s.ID_Giay,
                SoLuong = s.SoLuong,
                GiaBan = s.GiaBan,
                GiaNhap = s.GiaNhap
            };
            db.ChiTietHoaDons.Add(a);
            db.SaveChanges();
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
        public string IDhoadon()
        {
            
            string so = "";
            string idhoadon = "0";
            List<string> list = new List<string>();
            foreach (HoaDon i in db.HoaDons)
            {


                list.Add(tachchuoi(i.ID_HoaDon));

            }
            foreach (string s in list)
            {
                if (Convert.ToInt32(s) > Convert.ToInt32(idhoadon))
                {
                    idhoadon = s;
                }
            }
            if(Convert.ToInt32(idhoadon) <=8)
            {
                return Convert.ToString("HD000" + Convert.ToString(Convert.ToInt32(idhoadon) + 1));
            }
            else if(Convert.ToInt32(idhoadon) >=9 && Convert.ToInt32(idhoadon) <=98)
            {
                return Convert.ToString("HD00" + Convert.ToString(Convert.ToInt32(idhoadon) + 1));
            }
            else if(Convert.ToInt32(idhoadon) >= 99 && Convert.ToInt32(idhoadon) <=998)
            {
                return Convert.ToString("HD0" + Convert.ToString(Convert.ToInt32(idhoadon) + 1));
            }
            else
            {
                return Convert.ToString("HD" + Convert.ToString(Convert.ToInt32(idhoadon) + 1));
            }
            
        }

       

        public bool checkSDT(string s)
        {
            int dem = 0;
            char[] a = s.ToArray();
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < 48 || a[i] > 57)
                {
                    dem++;
                }
            }
            if (dem > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
