using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlybangiay.DTO;
namespace quanlybangiay.BLL.BLL_AD
{
    class BLL_DoanhThu
    {
        private static BLL_DoanhThu _Instance;
        public static BLL_DoanhThu Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_DoanhThu();
                }
                return _Instance;
            }
            private set { }
        }
        private BLL_DoanhThu()
        {

        }

        private DateTime startDate;
        private DateTime endDate;
        private int numberDays;
        public int TongHoaDon { get; set; }
        public double TongDoanhThu { get; set; }
        public double TongLoiNhuan { get; set; }
        public int TongKhachHang { get; set; }
        public int TongGiayDaBan { get; set; }
        public int TongGiayTonKho { get; set; }

        public List<ChiTietHoaDon> GetChiTietHDByID(string ID)
        {
            DataPBL3 db = new DataPBL3();
            return db.ChiTietHoaDons.Where(p => p.ID_HoaDon == ID)
                                    .Select(p => p).ToList();
        }
        public int getSLcon()
        {
            DataPBL3 db = new DataPBL3();
            int max = 0;
            foreach (Kho i in db.Khoes)
            {
                max += Convert.ToInt32(i.SoLuongCon);
            }
            return max;
        }
        public void GetNumberItem()
        {
            DataPBL3 db = new DataPBL3();
            TongDoanhThu = 0;
            TongLoiNhuan = 0;
            TongGiayDaBan = 0;
            TongGiayTonKho = getSLcon();
            double gianhap;
            double Tonggianhap = 0;

            TongHoaDon = GetOrder().Count;
            List<String> ListSDTKH = new List<string>();
            foreach (HoaDon hd in GetOrder())
            {

                ListSDTKH.Add(hd.SoDienThoai);
                TongDoanhThu += Convert.ToDouble(hd.TongTien.Value.ToString());
                //int km =Convert.ToInt32(hd.Thanhvien) + Convert.ToInt32(BLL_HD.Instance.GetChietkhauByID(hd.ID_KhuyenMai));

                foreach (ChiTietHoaDon i in GetChiTietHDByID(hd.ID_HoaDon))
                {
                    gianhap = 0;
                   var a = BLL_KhoGiay.Instance.getListTimeNhapKhoByID(i.ID_Giay);
                    for (int k = a.Count -1 ; k >= 0; k--)
                    {
                        if(hd.NgayTao > a[k].NgayNhap)
                        {
                            gianhap = (double)a[k].GiaNhap;
                            break;
                        }
                    }
                    Tonggianhap += gianhap * Convert.ToInt32(i.SoLuong);
                        //TongLoiNhuan += ((Convert.ToDouble(i.GiaBan)*(100-km)/100 - gianhap) * Convert.ToInt32(i.SoLuong));
                    TongGiayDaBan += Convert.ToInt32(i.SoLuong);
                }
                TongLoiNhuan = TongDoanhThu - Tonggianhap;
            }
            TongKhachHang = ListSDTKH.Distinct().Count();
        }
        private List<HoaDon> GetOrder()
        {
            DataPBL3 db = new DataPBL3();
            var l1 = db.HoaDons.Where(p => (p.NgayTao.Value > startDate) && (p.NgayTao.Value < endDate)).Select(p => p).ToList();
            return l1;
        }

        public struct RevenueByDate
        {
            public string Date { get; set; }
            public double TotalAmount { get; set; }
        }
        public List<RevenueByDate> GrossRevenueList { get; private set; }

        private void GetOrderAnalisys()
        {
            DataPBL3 db = new DataPBL3();
            GrossRevenueList = new List<RevenueByDate>();

            var l2 = db.HoaDons.Where(p => (p.NgayTao.Value > startDate) && (p.NgayTao.Value < endDate))
                     .GroupBy(p => p.NgayTao)
                     .Select(p => new
                     {
                         date = p.Key,
                         Tong = p.Sum(w => w.TongTien)
                     }).ToList();

            var resultTable = new List<KeyValuePair<DateTime, double>>();
            foreach(var i in l2)
            {
                resultTable.Add(
                    new KeyValuePair<DateTime, double>((DateTime)i.date, (double)i.Tong)
                );
            }

            //Group by Hours
            if (numberDays <= 1)
            {
                GrossRevenueList = (from p in resultTable
                                    group p by p.Key.ToString("hh tt")
                                   into order
                                    select new RevenueByDate
                                    {
                                        Date = order.Key,
                                        TotalAmount = order.Sum(p => p.Value)
                                    }).ToList();


            }
            //Group by Days
            else if (numberDays <= 30)
            {
                GrossRevenueList = (from p in resultTable
                                    group p by p.Key.ToString("dd MMM")
                    into order
                                    select new RevenueByDate
                                    {
                                        Date = order.Key,
                                        TotalAmount = order.Sum(p => p.Value)
                                    }).ToList();
            }

            //Group by Weeks
            else if (numberDays <= 92)
            {
                GrossRevenueList = (from p in resultTable
                                    group p by CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                        p.Key, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                                   into order
                                    select new RevenueByDate
                                    {
                                        Date = "Week " + order.Key.ToString(),
                                        TotalAmount = order.Sum(p => p.Value)
                                    }).ToList();
            }

            //Group by Months
            else if (numberDays <= (365 * 2))
            {
                bool isYear = numberDays <= 365 ? true : false;
                GrossRevenueList = (from p in resultTable
                    group p by p.Key.ToString("MMM yyyy")
                    into order
                    select new RevenueByDate
                    {
                        Date = isYear ? order.Key.Substring(0, order.Key.IndexOf(" ")) : order.Key,
                        TotalAmount = order.Sum(p => p.Value)
                    }).ToList();
            }

             //Group by Years
             else
             {
                GrossRevenueList = (from p in resultTable
                    group p by p.Key.ToString("yyyy")
                    into order
                    select new RevenueByDate
                    {
                        Date = order.Key,
                        TotalAmount = order.Sum(p => p.Value)
                    }).ToList();
             }
            
        }

        public bool LoadData(DateTime startDate, DateTime endDate)
        {
            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day,
                endDate.Hour, endDate.Minute, 59);
            //if (startDate != this.startDate || endDate != this.endDate)
            //{
                this.startDate = startDate;
                this.endDate = endDate;
                this.numberDays = (endDate - startDate).Days;

                GetNumberItem();
                GetOrderAnalisys();
                Console.WriteLine("Refreshed data: {0} - {1}", startDate.ToString(), endDate.ToString());
                return true;
            //}
            //else
            //{
            //    Console.WriteLine("Data not refreshed, same query: {0} - {1}", startDate.ToString(), endDate.ToString());
            //    return false;
            //}
        }
    }
}
