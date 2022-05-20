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

        public void AddDL(string MaGiay, string Hang, string TenSP, int Size, double Gia, int SL, double ThanhTien)
        {
            DataSP.Instance.AddRow(MaGiay, Hang, TenSP, Size, Gia, SL, ThanhTien);
        }
        public void DelSP(string MaSP)
        {
            DataSP.Instance.DelRow(MaSP);
        }
    }
}
