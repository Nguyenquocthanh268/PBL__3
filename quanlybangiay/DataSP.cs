using quanlybangiay.BLL.BLL_AD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybangiay
{
    class DataSP
    {
        private static DataSP _Instance;
        public static DataSP Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DataSP();
                }
                return _Instance;
            }
            private set { }
        }
        public DataTable d1 { get; set; }
        private DataSP()
        {
            d1 = new DataTable();
            d1.Columns.AddRange(new DataColumn[]
            {
                new DataColumn{ColumnName = "Mã giày",DataType =typeof(string)},
                new DataColumn{ColumnName = "Hãng",DataType =typeof(string)},
                new DataColumn{ColumnName = "Tên SP",DataType =typeof(string)},
                new DataColumn{ColumnName = "Size",DataType =typeof(int)},
                new DataColumn{ColumnName = "Giá(VNĐ)",DataType =typeof(double)},
                new DataColumn{ColumnName = "SL",DataType =typeof(int)},
                new DataColumn{ColumnName = "Thành tiền(VNĐ)",DataType =typeof(double)}
            });
        }
        public void AddRow(string MaGiay, string Hang, string TenSP, int Size, double Gia,int SL, double ThanhTien)
        {
            int i;
            //d1.Rows.Add(MaGiay, Hang, TenSP, Size, Gia, SL, ThanhTien);
            if (d1.Rows.Count == 0)
            {
                d1.Rows.Add(MaGiay, Hang, TenSP, Size, Gia, SL, ThanhTien);
            }
            else
            {
                for (i = 0; i < d1.Rows.Count; i++)
                {
                    if (d1.Rows[i]["Mã giày"].ToString() == MaGiay)
                    {
                        d1.Rows[i]["SL"] = Convert.ToInt32(d1.Rows[i]["SL"]) + 1;
                        d1.Rows[i]["Thành tiền(VNĐ)"] = BLL_KhoGiay.Instance.GetGiaBanGiayByID(MaGiay) * Convert.ToInt32(d1.Rows[i]["SL"]);
                        break;
                    }
                }
                if (i == d1.Rows.Count)
                {
                    d1.Rows.Add(MaGiay, Hang, TenSP, Size, Gia, SL, ThanhTien);
                }
            }
        }
        public void DelRow(String MaSP)
        {
            foreach (DataRow i in d1.Rows)
            {
                if (i["Mã giày"].ToString() == MaSP)
                {
                    i.Delete();
                    break;
                }
            }
        }
        public double TongTienThanhToan()
        {
            double sum = 0;
            for (int i = 0;i < d1.Rows.Count; i++)
            {
                sum += Convert.ToDouble(d1.Rows[i]["Thành tiền(VNĐ)"]);

            }
            return sum;
        }
        public void ResetData()
        {
            d1.Clear();
        }
    }
}
