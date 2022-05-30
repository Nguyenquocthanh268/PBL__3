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
    public partial class Khach_Hang : Form
    {
        public Khach_Hang()
        {
            InitializeComponent();
            SetCBB();
            
        }
        public void GUI(string sdt)
        {

            KhachHang a = BLL_QLKH.Instance.Get1KH(sdt);
            tbSdt.Text = a.SoDienThoai;
            tbName.Text= a.TenKhachHang;
            tbDiemTL.Text = a.DiemTichLuy.ToString();
            datetimeNgayDK.Value = a.NgayDangKy.Value;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                GUI(dataGridView1.SelectedRows[0].Cells["SoDienThoai"].Value.ToString());
            }
        }
        public void SetCBB()
        {
            cbView.Items.Add("Chọn tất cả");
            cbView.Items.Add("Số ĐT");
            cbView.Items.Add("Tên");
            cbSort.Items.Add("Số ĐT");
            cbSort.Items.Add("Tên");
            cbSort.Items.Add("Điểm tích lũy");
        }
        private void Show()
        {
            dataGridView1.DataSource = BLL.BLL_AD.BLL_QLKH.Instance.GetKH(cbView.SelectedIndex, tbSearch.Text);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                KhachHang s = new KhachHang
                {
                    SoDienThoai = tbSdt.Text.ToString(),
                    TenKhachHang = tbName.Text.ToString(),
                    DiemTichLuy =Convert.ToInt32(tbDiemTL.Text.ToString()),
                };
                BLL_QLKH.Instance.UpdateKH(s);
                Show();
            }
            else
            {
                MessageBox.Show("*Vui long chon 1 khach hang de cap nhat thong tin.");
            }
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                String s = "Bạn có muốn xóa Khách Hàng ??";
                String s1 = "Delete";
                MessageBoxButtons ok = MessageBoxButtons.OKCancel;
                DialogResult d = MessageBox.Show(s, s1, ok);
                if (d == DialogResult.OK)
                {
                    foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                    {
                        String Sdt = i.Cells["SoDienThoai"].Value.ToString();
                        BLL_QLKH.Instance.DelKH(Sdt);
                    }
                }
                Show();
            }
            else
            {
                MessageBox.Show("Vui long chon dong can Xoa !!!");
            }
        }

        private void butSort_Click(object sender, EventArgs e)
        {
            if(cbSort.SelectedIndex >= 0)
            {
                dataGridView1.DataSource = BLL_QLKH.Instance.sortKH(cbView.SelectedIndex, tbSearch.Text, cbSort.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Item ...");
            }
        }
    }
}
