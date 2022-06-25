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
        public delegate void Mydel2();
        public Mydel2 d2 { get; set; }
        public String IDGiay { get; set; }
        private int index;
        public string size { get; set; }
        public DetailKhoGiay(String id, int i)
        {
            InitializeComponent();
            IDGiay = id;
            index = i;
            GUI(index);
            foreach (string k in BLL_KhoGiay.Instance.CBBhang().Distinct())
            {
                cb_hang.Items.Add(k);
            }
            if(index == 3)
            {
                size=txtSize.Text;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtSLNhap.Text == "")
            {
                txtSLNhap.Text = "0";
            }
            byte[] file = BLL_KhoGiay.Instance.ImagetoByte(pictureBox7.Image);

            if (txtIDGiay.Text != "" && txtName.Text != "" && txtSize.Text != ""  && cb_hang.Text !="")
            {

                if (getGiay() != null && getKhoGiay() != null && getNhapKHO_Giay() != null)
                {

                   
                        BLL_KhoGiay.Instance.Excute(getGiay(), getKhoGiay());
                        if (Convert.ToInt32(txtSLNhap.Text) > 0 && index == 2)
                        {
                            BLL_KhoGiay.Instance.ADD_nhapkho(getNhapKHO_Giay());
                        }
                        MessageBox.Show("Thực hiện thành công !");
                        d();

                        this.Close();
                        d2();
                 
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
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
                    btn_load.Visible= false;
                    label17.Visible=false;
                    //  txtHang.Enabled = false;
                    cb_hang.Enabled = false;
                    txtGiaBan.Enabled = false;
                    //btnOK.Enabled = false;
                    btnCancel.Location = new Point(398, 225);
                    btnOK.Visible = false;
                    txtName.Enabled = false;
                    txtSize.Enabled = false;
                    txtGiaNhap.Enabled = false;
                    txtSLTon.Enabled = false;
                    txtSLNhap.Enabled = false;
                    txtSLDaBan.Enabled = false;
                }
                if (index == 3)
                {
                    txtGiaBan.Enabled = true;
                    txtName.Enabled = true;
                    txtSize.Enabled = true;
                    //  txtHang.Enabled = true;
                    cb_hang.Enabled = false;
                    cb_hang.BackColor = Color.FromArgb(255, 255, 255);
                    txtGiaBan.BackColor = Color.FromArgb(255, 255, 255);
                    txtName.BackColor = Color.FromArgb(255, 255, 255);
                    txtSize.BackColor = Color.FromArgb(255, 255, 255);
                    // txtHang.BackColor = Color.FromArgb(255, 255, 255);

                    txtGiaNhap.Enabled = false;
                    txtSLTon.Enabled = false;
                    txtSLNhap.Enabled = false;
                    txtSLDaBan.Enabled = false;
                }
                txtIDGiay.Text = IDGiay;
                //   txtHang.Text = BLL_KhoGiay.Instance.GetGiayByID(IDGiay).HangGiay.ToString();
                cb_hang.Text = BLL_KhoGiay.Instance.GetGiayByID(IDGiay).HangGiay.ToString();
                txtName.Text = BLL_KhoGiay.Instance.GetGiayByID(IDGiay).TenGiay.ToString();
                txtSize.Text = BLL_KhoGiay.Instance.GetGiayByID(IDGiay).Size.ToString();
                txtGiaNhap.Text = BLL_KhoGiay.Instance.GetGiayByID(IDGiay).GiaNhap.ToString();
                txtGiaBan.Text = BLL_KhoGiay.Instance.GetGiayByID(IDGiay).GiaBan.ToString();
                txtSLNhap.Text = BLL_KhoGiay.Instance.GetkhoByID(IDGiay).TongSoLuongNhap.ToString();
                txtSLDaBan.Text = BLL_KhoGiay.Instance.GetkhoByID(IDGiay).SoLuongBan.ToString();
                txtSLTon.Text = BLL_KhoGiay.Instance.GetkhoByID(IDGiay).SoLuongCon.ToString();
                pictureBox7.Image = BLL_KhoGiay.Instance.BytetoPicter(BLL_KhoGiay.Instance.GetGiayByID(IDGiay).AnhSP);
            }
            else
            {
                txtName.BackColor = Color.FromArgb(255, 255, 255);
                txtSize.BackColor = Color.FromArgb(255, 255, 255);
                cb_hang.BackColor = Color.FromArgb(255, 255, 255);
                txtSLNhap.BackColor = Color.FromArgb(255, 255, 255);
            }

        }
     
        private Giay getGiay()
        {
            try

            {
                if (txtSLNhap.Text == "0")
                {
                    txtGiaNhap.Enabled = false;
                    txtGiaBan.Enabled = false;
                    txtGiaNhap.Text = "0";
                    txtGiaBan.Text = "0";

                }
                byte[] file = BLL_KhoGiay.Instance.ImagetoByte(pictureBox7.Image);
                Giay c = new Giay()
                {
                    ID_Giay = txtIDGiay.Text,
                    TenGiay = txtName.Text,
                    Size = Convert.ToInt32(txtSize.Text.ToString()),
                    //  HangGiay = txtHang.Text,
                    HangGiay = cb_hang.Text,
                    GiaNhap = Convert.ToDouble(txtGiaNhap.Text.ToString()),
                    GiaBan = Convert.ToDouble(txtGiaBan.Text.ToString()),
                    AnhSP = file
                };
                return c;
            }
            catch (Exception e)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return null;
            }
        }
        private NhapKho getNhapKHO_Giay()
        {
            try
            {
                NhapKho n = new NhapKho()
                {
                    Stt = BLL_KhoGiay.Instance.STTNhap(),
                    NgayNhap = DateTime.Now,
                    ID_Giay = txtIDGiay.Text,
                    SoLuongNhap = Convert.ToInt32(txtSLNhap.Text.ToString()),
                    GiaNhap = Convert.ToInt32(txtGiaNhap.Text.ToString()),
                };
                return n;
            }
            catch (Exception e)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return null;
            }
        }
        private Kho getKhoGiay()
        {
            try
            {
                if (txtSLNhap.Text == "")
                {
                    txtSLNhap.Text = "0";

                }
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
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return null;
            }
        }

      




        private void txtSLNhap_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSLNhap.Text == "" && index == 2)
                {
                    txtGiaBan.Enabled = false;
                    txtGiaNhap.Enabled = false;
                }
                else
                if (Convert.ToInt32(txtSLNhap.Text) == 0 && index == 2)
                {
                    txtGiaBan.Enabled = false;
                    txtGiaNhap.Enabled = false;
                }
                else
                if (Convert.ToInt32(txtSLNhap.Text) > 0 && index == 2)
                {
                    tb4.Text = "";
                    txtGiaBan.Enabled = true;
                    txtGiaNhap.Enabled = true;
                    txtGiaBan.BackColor = Color.FromArgb(255, 255, 255);
                    txtGiaNhap.BackColor = Color.FromArgb(255, 255, 255);
                }
            }
            catch (Exception ex)
            {
                tb4.Text = "Chỉ nhập kí tự 0-9";
                txtGiaBan.BackColor = Color.FromArgb(171, 171, 171);
                txtGiaNhap.BackColor = Color.FromArgb(171, 171, 171);
                txtSLNhap.Text = "";
                txtGiaBan.Text = "";
                txtGiaBan.Enabled = false;
                txtGiaNhap.Text = "";
                txtGiaNhap.Enabled = false;
            }
        }

        

        private void txtSize_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtSLNhap.Text == "")
            {
                txtSLNhap.Text = "0";
            }
  
        }

        private void txtSize_TextChanged(object sender, EventArgs e)
        {

            
             
           if(txtName.Text != "")
            {
                try
                {

                    if (txtSize.Text == "")
                    {

                    }
                    else
                    if (Convert.ToInt32(txtSize.Text) > 0)
                    {
                        tb_1.Text = "";

                    }

                }
                catch (Exception k)
                {
                    tb_1.Text = "Chỉ nhập kí tự 0-9";
                    txtSize.Text = "";

                }

            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên giày !");
            }

        }

        private void txtGiaNhap_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtGiaNhap.Text == "")
                {

                }
                else
                if (Convert.ToInt32(txtGiaNhap.Text) > 0 && index == 2)
                {
                    tb2.Text = "";
                }



            }
            catch (Exception k)
            {
                tb2.Text = "Chỉ nhập kí tự 0-9";
                txtGiaNhap.Text = "";
            }
        }

        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtGiaBan.Text == "")
                {

                }
                else
                if (Convert.ToInt32(txtGiaBan.Text) > 0)
                {
                    tb3.Text = "";
                }



            }
            catch (Exception k)
            {
                tb3.Text = "Chỉ nhập kí tự 0-9";
                txtGiaBan.Text = "";
            }
        }

       

        private void btn_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            PictureBox ptr = new PictureBox();
            string fileName = null;
            dlg.Filter = "Select files(*.jpg;*.png)|*.jpg;*png";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fileName = dlg.FileName;
                pictureBox7.Image = Image.FromFile(fileName.ToString());
                pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void cb_hang_Leave(object sender, EventArgs e)
        {
            txtIDGiay.Text = BLL_KhoGiay.Instance.RangeIDgiay(cb_hang.Text);
        }

        private void txtSize_Leave(object sender, EventArgs e)
        {
            if (index == 2)
            {
                if(txtSize.Text != "")
                {
                    if (BLL_KhoGiay.Instance.CheckSizeOFTen(txtName.Text, txtSize.Text))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Giày đã tồn tại size");
                        txtSize.Text = "";
                    }
                }
            }
            if(index == 3)
            {
                if(size != txtSize.Text)
                {
                    if (txtSize.Text != "")
                    {
                        if (BLL_KhoGiay.Instance.CheckSizeOFTen(txtName.Text, txtSize.Text))
                        {

                        }
                        else
                        {
                            MessageBox.Show("Giày đã tồn tại size");
                            txtSize.Text = "";
                        }
                    }
                }
            }
        }
    }
}
