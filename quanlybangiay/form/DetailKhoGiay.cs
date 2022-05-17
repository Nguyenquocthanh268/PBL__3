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
using quanlybangiay.DTO;
namespace quanlybangiay.form
{
    public partial class DetailKhoGiay : Form
    {
        //public delegate void Mydel
        public delegate void Mydel();
        public Mydel d { get; set; }

        public String IDGiay { get; set; }
        private int index;
        public DetailKhoGiay(String id, int i)
        {
            InitializeComponent();
            IDGiay = id;
            index = i;
            GUI(index);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            byte[] file = BLL_KhoGiay.Instance.ImagetoByte(pictureBox7.Image);

            
            BLL_KhoGiay.Instance.Excute(getGiay(), getKhoGiay());
            d();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void GUI(int index)
        {
            if (BLL_KhoGiay.Instance.check(IDGiay))
            {
                txtIDGiay.Enabled = false;
                if (index == 1)
                {
                    pictureBox7.Enabled = false;
                    txtName.Enabled = false;
                    txtHang.Enabled = false;
                    txtSize.Enabled = false;
                    txtGiaBan.Enabled = false;
                    btnOK.Enabled = false;
                }
                txtGiaNhap.Enabled = false;
                txtSLTon.Enabled = false;
                txtSLNhap.Enabled = false;
                txtSLDaBan.Enabled = false;
                txtIDGiay.Text = IDGiay;
                txtHang.Text = BLL_KhoGiay.Instance.GetGiayByID(IDGiay).HangGiay.ToString();
                txtName.Text = BLL_KhoGiay.Instance.GetGiayByID(IDGiay).TenGiay.ToString();
                txtSize.Text = BLL_KhoGiay.Instance.GetGiayByID(IDGiay).Size.ToString();
                txtGiaNhap.Text = BLL_KhoGiay.Instance.GetGiayByID(IDGiay).GiaNhap.ToString();
                txtGiaBan.Text = BLL_KhoGiay.Instance.GetGiayByID(IDGiay).GiaBan.ToString();
                txtSLNhap.Text = BLL_KhoGiay.Instance.GetkhoByID(IDGiay).TongSoLuongNhap.ToString();
                txtSLDaBan.Text = BLL_KhoGiay.Instance.GetkhoByID(IDGiay).SoLuongBan.ToString();
                txtSLTon.Text = BLL_KhoGiay.Instance.GetkhoByID(IDGiay).SoLuongCon.ToString();
                pictureBox7.Image = BLL_KhoGiay.Instance.BytetoPicter(BLL_KhoGiay.Instance.GetGiayByID(IDGiay).AnhSP);
            }

        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            PictureBox p = sender as PictureBox;
            if (p != null)
            {
                openFile.Filter = "(*.png) | *.png";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    p.Image = Image.FromFile(openFile.FileName);
                }
            }
        }
        private Giay getGiay()
        {
            try
                 
            {
                byte[] file = BLL_KhoGiay.Instance.ImagetoByte(pictureBox7.Image);
                Giay c = new Giay()
                {
                    ID_Giay = txtIDGiay.Text,
                    TenGiay = txtName.Text,
                    Size = Convert.ToInt32(txtSize.Text.ToString()),
                    HangGiay = txtHang.Text,
                    GiaNhap = Convert.ToDouble(txtGiaNhap.Text.ToString()),
                    GiaBan = Convert.ToDouble(txtGiaBan.Text.ToString()),
                    AnhSP = file
                };
                return c;
            }
            catch (Exception e)
            {
                MessageBox.Show("Nhập vào không hợp lệ");
                return null;
            }
        }
        private Kho getKhoGiay()
        {
            try
            {
                Kho c = new Kho()
                {
                    ID_Giay = txtIDGiay.Text,
                    TongSoLuongNhap = Convert.ToInt32(txtSLNhap.Text.ToString()),
                    SoLuongCon = Convert.ToInt32(txtSLNhap.Text.ToString()),
                    SoLuongBan = 0

                };
                return c;
            }
            catch (Exception e)
            {
                MessageBox.Show("Nhập vào không hợp lệ");
                return null;
            }
        }
      
    }
}
