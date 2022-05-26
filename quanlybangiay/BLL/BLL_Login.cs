using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlybangiay.DTO;
namespace quanlybangiay.BLL
{
    public class BLL_Login
    {
        DataPBL3 db = new DataPBL3();
        private static BLL_Login _Instance;
        public static BLL_Login Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_Login();
                }
                return _Instance;
            }
            private set { }
        }

        private BLL_Login()
        {
          
        }
        public TaiKhoan GetTK(string user)
        {
            
                TaiKhoan k = db.TaiKhoans.Find(user);
                if (k != null)
                {
                    return k;
                }
                else
                {
                    return null;
                }
           
        }
        public Boolean Kt(string pass, string user)
        {
            if (GetTK(user) == null)
            {
                return false;
            }
            else
            {
                if (GetTK(user).Pass == pass)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool Update(string user, string mkc, string mkm, string nlmk)
        {
            
                TaiKhoan t = db.TaiKhoans.Find(user); ;
                if (t.Pass != mkc)
                {
                    return false;
                }
                else
                {
                    if (mkm == nlmk)
                    {
                        t.Pass = nlmk;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            
        }
        public bool checkMK(string MK)
        {
            if(MK.Length < 6)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void UpdateTK(TaiKhoan s)
        {
            TaiKhoan t = db.TaiKhoans.Find(s.Username);
            t.Pass = s.Pass;
        }
        public TaiKhoan GetTKByID(string ID)
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
        public void ResetMK(string Username)
        {

            TaiKhoan s = db.TaiKhoans.Find(Username);
            s.Pass = "1";
            db.SaveChanges();

        }
    }
}
