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
    public partial class Khuyen_Mai : Form
    {
        public Khuyen_Mai()
        {
            InitializeComponent();
            cbItem.Items.AddRange((BLL_CTKM.Instance.CBB().ToArray()));
            cbb_sort.Items.AddRange((BLL_CTKM.Instance.CBB_sort().ToArray()));
            Khoa();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int index = cbItem.SelectedIndex;
            if (index >= 0)

            {
                Show(index, txt_search.Text);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Item");
            }

        }
        public void Show(int id, string txt)
        {
            dataGridView1.DataSource = BLL_CTKM.Instance.search(id, txt);
        }
        public void GUI(string ID)
        {
            txt_ID.Text = (BLL_CTKM.Instance.GetCTKM(ID)).ID_KhuyenMai.ToString();
            txt_tenchuongtrinh.Text = (BLL_CTKM.Instance.GetCTKM(ID)).TenCT.ToString();
            txt_chietkhau.Text = (BLL_CTKM.Instance.GetCTKM(ID)).ChietKhau.ToString();
            dt_ngaybatdau.Value = Convert.ToDateTime((BLL_CTKM.Instance.GetCTKM(ID)).NgayBatDau.ToString());
            dt_ngaykt.Value = Convert.ToDateTime((BLL_CTKM.Instance.GetCTKM(ID)).NgayKetThuc.ToString());
            richTextBox1.Text = (BLL_CTKM.Instance.GetCTKM(ID)).MoTa.ToString();


        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string ID = dataGridView1.SelectedRows[0].Cells["ID_KhuyenMai"].Value.ToString();
                txt_ID.Enabled = false;
                GUI(ID);
                MK();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần Edit");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                string ID = dataGridView1.SelectedRows[0].Cells["ID_KhuyenMai"].Value.ToString();
                GUI(ID);

                Khoa();
            }
        }
        private CTKM getCTKM()
        {
            try
            {
                CTKM c = new CTKM()
                {
                    ID_KhuyenMai = txt_ID.Text.ToString(),
                    TenCT = txt_tenchuongtrinh.Text.ToString(),
                    ChietKhau = Convert.ToInt32(txt_chietkhau.Text.ToString()),
                    NgayBatDau = dt_ngaybatdau.Value,
                    NgayKetThuc = dt_ngaykt.Value,
                    MoTa = richTextBox1.Text.ToString(),
                };
                return c;
            }
            catch (Exception e)
            {
                MessageBox.Show("Nhập vào không hợp lệ");
                return null;
            }
        }
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (txt_ID.Text != "" && txt_chietkhau.Text != "" && txt_tenchuongtrinh.Text != "" && richTextBox1.Text != "")
            {
                if (getCTKM() != null)
                {
                    BLL_CTKM.Instance.ExcuteDB(getCTKM());
                    Show(0, "");
                    Khoa();
                }

            }
            else
            {
                MessageBox.Show("Điền thông tin đầy đủ");
            }


        }
        public void Reset()
        {
            txt_ID.Text = "";
            txt_tenchuongtrinh.Text = "";
            txt_chietkhau.Text = "";
            dt_ngaybatdau.Value = DateTime.Now;
            dt_ngaykt.Value = DateTime.Now;
            richTextBox1.Text = "";
        }
        public void MK()
        {
            txt_tenchuongtrinh.Enabled = true;
            txt_chietkhau.Enabled = true;
            dt_ngaybatdau.Enabled = true;
            dt_ngaykt.Enabled = true;
            richTextBox1.Enabled = true;
            btn_ok.Enabled = true;
        }
        public void Khoa()
        {
            txt_ID.Enabled = false;
            txt_tenchuongtrinh.Enabled = false;
            txt_chietkhau.Enabled = false;
            dt_ngaybatdau.Enabled = false;
            dt_ngaykt.Enabled = false;
            richTextBox1.Enabled = false;
            btn_ok.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
            Khoa();
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            txt_ID.Enabled = false;
            Reset();
            if (txt_ID.Text == "")
            {
                txt_ID.Text = BLL_CTKM.Instance.IDKM();
            }

            btn_ok.Enabled = true;
            MK();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                List<string> list = new List<string>();
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    list.Add(i.Cells["ID_KhuyenMai"].Value.ToString());

                }
                foreach (string s in list)
                {
                    BLL_CTKM.Instance.Del(s);


                }
                Show(0, "");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa");
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            int index = cbb_sort.SelectedIndex;
            if (index >= 0)
            {
                dataGridView1.DataSource = BLL_CTKM.Instance.sort(index);
            }
            else
            {
                MessageBox.Show("Vui long chon Item");
            }

        }
    }
}
