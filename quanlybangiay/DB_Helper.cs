using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybangiay
{
    class DB_Helper
    {
        private string cnnstring;
        private static DB_Helper _Instance;
        public static DB_Helper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DB_Helper();
                }
                return _Instance;
            }
            private set { }
        }
        private DB_Helper()
        {
            //cnnstring = @"Data Source=DESKTOP-9S9FSI0\SQLEXPRESS;Initial Catalog=ADMIN;Integrated Security=True";
            //  cnnstring = @"Data Source=DESKTOP-9S9FSI0\SQLEXPRESS;Initial Catalog=TaiKhoan;Integrated Security=True";
            cnnstring = @"Data Source = MSI\SQLEXPRESS; Initial Catalog = DATAPBL; Integrated Security = True";
        }
        public bool ExecuteDB(string query)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(cnnstring))
                {
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DataTable GetRecord(string query)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(cnnstring))
                {
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    cnn.Open();
                    da.Fill(dt);
                    cnn.Close();
                    return dt;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
