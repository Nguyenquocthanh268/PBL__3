using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using quanlybangiay.BLL.BLL_AD;
using quanlybangiay.BLL;
using quanlybangiay.BLL.BLL_NV;

namespace quanlybangiay
{
    public partial class MainNV : Form
    {  
        private string USer { get; set; }
        private string ID { get; set; }
        public MainNV(string user ,string id)
        {
            ID = id;
            USer = user;
            InitializeComponent();
            ShowdtGV_Trangchu();
            LoadCBBKHO();
           
        }
        private void ShowdtGV_Trangchu()
        {
            DataTable d1 = new DataTable();
            d1.Columns.AddRange(new DataColumn[]
            {
                new DataColumn{ColumnName = "Mã giày",DataType =typeof(string)},
                new DataColumn{ColumnName = "Hãng",DataType =typeof(string)},
                new DataColumn{ColumnName = "Tên SP",DataType =typeof(string)},
                new DataColumn{ColumnName = "Size",DataType =typeof(int)},
                new DataColumn{ColumnName = "Giá(VNĐ)",DataType =typeof(int)},
                new DataColumn{ColumnName = "SL",DataType =typeof(int)},
                new DataColumn{ColumnName = "Thành tiền(VNĐ)",DataType =typeof(int)}
            });
            dtGV_Trangchu.DataSource = d1;
        }

        private void MainNV_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login f = new Login();
            this.Hide();
            f.Show();
            this.Activate();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            GUI();
         
        }
        public void GUI()
        {
            txt_id.Text =BLL_NV.Instance.GetNVByID(ID).ID_NhanVien.ToString();
            txt_ten.Text = BLL_NV.Instance.GetNVByID(ID).TenNhanVien.ToString();
            txt_sdt.Text = BLL_NV.Instance.GetNVByID(ID).SoDienThoai.ToString();
            bool gender = Convert.ToBoolean(BLL_NV.Instance.GetNVByID(ID).GioiTinh.ToString());
            if (gender)
            {
                Nam.Checked = true;
            }
            else
            {
                nu.Checked = true;
            }
            txt_daichi.Text = BLL_NV.Instance.GetNVByID(ID).DiaChi.ToString();
            ngaysinh.Value = Convert.ToDateTime(BLL_NV.Instance.GetNVByID(ID).NgaySinh.ToString());
        }
        public void LoadCBBKHO()
        {
            foreach (string i in BLL_KiemkhoNV.Instance.size().Distinct())
            {
                cb_sizeKHO.Items.Add(i);
            }
            foreach (string i in BLL_KiemkhoNV.Instance.hang().Distinct())
            {
                cb_hangKHO.Items.Add(i);
            }
            foreach (string i in BLL_KiemkhoNV.Instance.ten().Distinct())
            {
                cb_tenKHO.Items.Add(i);
            }
        }
       

        private void btn_luu_Click(object sender, EventArgs e)
        {
            string mkc = txt_mkc.Text;
            string mkm = txt_mkm.Text;
            string nlmk = txt_xacnhan.Text;
            if (BLL_Login.Instance.checkMK(mkm))
            {
                if (BLL_Login.Instance.Update(USer, mkc, mkm, nlmk))
                {
                    MessageBox.Show("Đổi thành công");
                }
                else
                {
                    MessageBox.Show("Kiểm tra lại MK");
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu của bạn ít hơn 6 ký tự vui lòng kiểm tra lại !");
            }
        }

        private void btn_out_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login a = new Login();
       
            a.Show();
        }

        private void txt_mkm_MouseClick(object sender, MouseEventArgs e)
        {
            lb_check.Enabled = false;
            lb_check.Text = "Nhập mật khẩu có tối thiểu 6 ký tự";
        }

        private void btn_timkiemKHO_Click(object sender, EventArgs e)
        {
            int indexTen = cb_tenKHO.SelectedIndex;
            int indexHang =cb_hangKHO.SelectedIndex;
            int indexSize =cb_sizeKHO.SelectedIndex;
            string ID = txt_IDgiayKHO.Text;
            if (ID == "")
            {
                if(indexTen < 0)
                {
                    if (indexHang >= 0 && indexSize < 0 )
                    {
                        string hang = cb_hangKHO.SelectedItem.ToString();
                        dtGV_Kiemkho.DataSource= BLL_KiemkhoNV.Instance.search_Hang("", hang);
                    }
                    else if (indexHang < 0 && indexSize >= 0)
                    {
                        int size = Convert.ToInt32(cb_sizeKHO.SelectedItem.ToString());
                        dtGV_Kiemkho.DataSource = BLL_KiemkhoNV.Instance.searh_Size("", size);
                    }
                    
                    else if (indexHang < 0 && indexSize < 0 )
                    {
                        dtGV_Kiemkho.DataSource = BLL_KiemkhoNV.Instance.showAll();
                    }
                    else if (indexHang >= 0 && indexSize >= 0 )

                    {
                        int size = Convert.ToInt32(cb_sizeKHO.SelectedItem.ToString());
                        string hang = cb_hangKHO.SelectedItem.ToString();
                        dtGV_Kiemkho.DataSource = BLL_KiemkhoNV.Instance.search_Size_Hang("", hang, size);
                    }
                }
                else if(indexTen >= 0)
                {
                     if (indexHang >= 0 && indexSize >= 0)
                    {
                        string ten = cb_tenKHO.SelectedItem.ToString();
                        int size = Convert.ToInt32(cb_sizeKHO.SelectedItem.ToString());
                        string hang = cb_hangKHO.SelectedItem.ToString();
                        dtGV_Kiemkho.DataSource = BLL_KiemkhoNV.Instance.search_Size_Hang(ten, hang, size);
                    }
                    else if (indexHang < 0 && indexSize < 0 )
                    {
                        string ten = cb_tenKHO.SelectedItem.ToString();
                        dtGV_Kiemkho.DataSource = BLL_KiemkhoNV.Instance.search_Size_Hang(ten, "", 0);
                    }
                     else if(indexHang >= 0 && indexSize < 0)
                    {
                        string ten = cb_tenKHO.SelectedItem.ToString();
                        string hang = cb_hangKHO.SelectedItem.ToString();
                        dtGV_Kiemkho.DataSource = BLL_KiemkhoNV.Instance.search_Hang(ten, hang);
                    }
                     else if(indexHang < 0 && indexSize >= 0)
                    {
                        string ten = cb_tenKHO.SelectedItem.ToString();
                        int size = Convert.ToInt32(cb_sizeKHO.SelectedItem.ToString());
                        dtGV_Kiemkho.DataSource = BLL_KiemkhoNV.Instance.searh_Size(ten, size);
                    }
                    
                }
            }
            else 
            {
                dtGV_Kiemkho.DataSource = BLL_KiemkhoNV.Instance.search(ID, "", "", 0);
            }
        }

        private void dtGV_Kiemkho_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtGV_Kiemkho.SelectedRows.Count == 1)
            {
                string ID = dtGV_Kiemkho.SelectedRows[0].Cells["ID_Giay"].Value.ToString();
                GUIkho(ID);
                
            }
        }
        public void GUIkho(string ID)
        {
            pic_kho.Image =BLL_KhoGiay.Instance.BytetoPicter(BLL_KhoGiay.Instance.GetGiayByID(ID).AnhSP);
            txt_giaKHO.Text = BLL_KhoGiay.Instance.GetGiayByID(ID).GiaBan.ToString();
            txt_sizeKHO.Text= BLL_KhoGiay.Instance.GetGiayByID(ID).Size.ToString();
            txt_SLkho.Text= BLL_KhoGiay.Instance.GetkhoByID(ID).SoLuongCon.ToString();
            tb_ten.Text=BLL_KhoGiay.Instance.GetGiayByID(ID).TenGiay.ToString();
            tb_ten.ForeColor = Color.Gold;
            tb_ten.Font= new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 2)
            {
                txt_IDgiayKHO.Text = "";
                cb_hangKHO.SelectedIndex = -1;
                cb_sizeKHO.SelectedIndex = -1;
                cb_tenKHO.SelectedIndex = -1;
                dtGV_Kiemkho.DataSource = null;
                pic_kho.Image = null;
                txt_sizeKHO.Text = "";
                txt_giaKHO.Text = "";
                txt_SLkho.Text = "";

            }
        }
    }
}
